using GeoInfo.DataBuilder.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.ComponentModel;
using System.Threading;
using System.IO.Compression;
using System.IO;
using GeoInfo.Application.Services;

namespace GeoInfo.DataBuilder
{
    class Program
    {
        private static readonly GeoNamesService GeoNamesService = new GeoNamesService();
        private static readonly TimeZoneService TimeZoneService = new TimeZoneService();
        private static readonly FileSystemService FileSystemService = new FileSystemService();
        
        private static readonly SemaphoreSlim Semaphore = new SemaphoreSlim(0);

        private const string OriginDataFolder = @".\Data";

        static void Main(string[] args)
        {
            var dataBuilderService = new DataBuilderService(Path.Combine(OriginDataFolder, "GeoInfo.db"));

            FileSystemService.CreateFolderIfNotExist(OriginDataFolder);
            FileSystemService.RemoveFiles(OriginDataFolder, "*.*");

            var filesToDownload = BuildFilesToDownloadDictionary();
            foreach (var fileToDownload in filesToDownload)
            {
                DownloadFile(fileToDownload.Key, fileToDownload.Value);
                if (fileToDownload.Value.IndexOf(".zip") > 0) ExtractFile(fileToDownload.Value, OriginDataFolder);
            }

            Console.Write("Extracting data from files... ");
            var geoNames = GeoNamesService.GetGeoNames();
            var geoCountries = GeoNamesService.GetGeoCountries();
            var geoAlternateNames = GeoNamesService.GetGeoAlternateNames();
            var geoLanguages = GeoNamesService.GetGeoLanguages();
            Console.Write("Done\n");

            Console.Write("Creating Timezones mapping... ");
            var timeZonesMapping = TimeZoneService.GetWindowsTimeZoneMapping();
            Console.Write("Done\n");

            Console.Write("Creating database... ");
            dataBuilderService.BuildData(geoNames, geoCountries, geoAlternateNames, geoLanguages, timeZonesMapping);
            Console.Write("Done\n");           
        }

        private static void ExtractFile(string filePath, string destinationPath)
        {
            Console.Write("Extracting file {0}... ", filePath);
            ZipFile.ExtractToDirectory(filePath, destinationPath);
            Console.WriteLine("Done");
        }

        private static Dictionary<string, string> BuildFilesToDownloadDictionary()
        {
            var filesToDownload = new Dictionary<string, string>
            {
                {
                    "http://download.geonames.org/export/dump/countryInfo.txt",
                    Path.Combine(OriginDataFolder, "countryInfo.txt")
                },
                {
                    "http://download.geonames.org/export/dump/cities1000.zip",
                    Path.Combine(OriginDataFolder, "cities1000.zip")
                },
                {
                    "http://download.geonames.org/export/dump/alternateNames.zip",
                    Path.Combine(OriginDataFolder, "alternateNames.zip")
                }
            };

            return filesToDownload;
        }

        private static void DownloadFile(string fileUrl, string destinationPath)
        {
            try
            {
                var fileUri = new Uri(fileUrl);

                using (var webClient = new WebClient())
                {
                    webClient.DownloadProgressChanged += DownloadProgressChanged;
                    webClient.DownloadFileCompleted += DownloadCompleted;
                    Console.WriteLine(@"Downloading file {0}", fileUri.AbsoluteUri);
                    webClient.DownloadFileAsync(fileUri, destinationPath);
                    Semaphore.Wait();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Was not able to download file!");
                Console.Write(ex);
            }
        }

        private static void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            Console.Write("\rFile Sucesfully downloaded.\n");
            Semaphore.Release();
        }

        private static void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            Console.Write("\rProgress... {0}%         ", e.ProgressPercentage);
        }
    }
}
