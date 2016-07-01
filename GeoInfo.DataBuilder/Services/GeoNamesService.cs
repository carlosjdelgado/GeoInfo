using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeoInfo.Application.Models.DataBuilder;

namespace GeoInfo.DataBuilder.Services
{
    public class GeoNamesService
    {
        private const string GeoNamesDataFilePath = @".\Data\cities1000.txt";
        private const string GeoAlternateNamesDataFilePath = @".\Data\alternateNames.txt";
        private const string GeoCountriesDataFilePath = @".\Data\countryInfo.txt";
        private const string GeoLanguagesDataFilePath = @".\Data\iso-languagecodes.txt";

        public GeoNamesService()
        {
        }

        public List<GeoNameModel> GetGeoNames()
        {
            var geoNames = new List<GeoNameModel>();

            using (var dataFile = new StreamReader(GeoNamesDataFilePath))
            {
                var line = string.Empty;
                while((line = dataFile.ReadLine()) != null)
                {
                    var geoName = BuildGeoName(line);
                    if (geoName != null) geoNames.Add(geoName);
                }
            }
            return geoNames;
        }

        public List<GeoLanguageModel> GetGeoLanguages()
        {
            var geoLanguages = new List<GeoLanguageModel>();

            using (var dataFile = new StreamReader(GeoLanguagesDataFilePath))
            {
                var line = string.Empty;
                while ((line = dataFile.ReadLine()) != null)
                {
                    if (!line.StartsWith("ISO 639-3")) geoLanguages.Add(BuildGeoLanguage(line));
                }
            }

            return geoLanguages;
        }

        public List<GeoAlternateNameModel> GetGeoAlternateNames()
        {
            var geoAlternateNames = new List<GeoAlternateNameModel>();

            using (var dataFile = new StreamReader(GeoAlternateNamesDataFilePath))
            {
                var line = string.Empty;
                while ((line = dataFile.ReadLine()) != null)
                {
                    geoAlternateNames.Add(BuildGeoAlternateName(line));
                }
            }
            
            return geoAlternateNames;
        }

        public List<GeoCountryModel> GetGeoCountries()
        {
            var geoCountries = new List<GeoCountryModel>();

            using (var dataFile = new StreamReader(GeoCountriesDataFilePath))
            {
                var line = string.Empty;
                while ((line = dataFile.ReadLine()) != null)
                {
                    if(line[0] != '#') geoCountries.Add(BuildGeoCountry(line));
                }
            }

            return geoCountries;
        }

        private GeoCountryModel BuildGeoCountry(string line)
        {
            var lineArray = line.Split('\t');
            return new GeoCountryModel
            {
                IsoCode = lineArray[0],
                Iso3Code = lineArray[1],
                IsoNumericCode = lineArray[2],
                FipsCode = lineArray[3],
                Name = lineArray[4],
                Capital = lineArray[5],
                Area = double.Parse(lineArray[6]),
                Population = long.Parse(lineArray[7]),
                ContinentCode = lineArray[8],
                TopLevelDomain = lineArray[9],
                CurrencyCode = lineArray[10],
                CurrencyName = lineArray[11],
                PhonePrefix = lineArray[12],
                PostalCodeFormat = lineArray[13],
                PostalCodeRegex = lineArray[14],
                Languages = lineArray[15].Split(',').ToList(),
                GeoNameId = int.Parse(lineArray[16]),
                NeighbourCountryCodes = lineArray[17].Split(',').ToList(),
                EquivalentFipsCode = lineArray[18]
            };
        }

        private GeoAlternateNameModel BuildGeoAlternateName(string line)
        {
            var lineArray = line.Split('\t');
            return new GeoAlternateNameModel
            {
                AlternateNameId = int.Parse(lineArray[0]),
                GeoNameId = int.Parse(lineArray[1]),
                IsoLanguage = lineArray[2],
                AlternateName = lineArray[3],
                IsPreferredName = (lineArray[4] == "1"),
                IsShortName = (lineArray[5] == "1"),
                IsColloquial = (lineArray[6] == "1"),
                IsHistoric = (lineArray[7] == "1")
            };
        }

        private GeoLanguageModel BuildGeoLanguage(string line)
        {
            var lineArray = line.Split('\t');

            return new GeoLanguageModel
            {
                Iso6393 = lineArray[0],
                Iso6392 = lineArray[1],
                Iso6391 = lineArray[2],
                LanguageName = lineArray[3]
            };
        }

        private GeoNameModel BuildGeoName(string line)
        {
            var lineArray = line.Split('\t');

            return new GeoNameModel
            {
                GeoNameId = BuildGeoNameId(lineArray[0]),
                Name = lineArray[1],
                AsciiName = lineArray[2],
                AlternateNames = BuildAlternateNames(lineArray[3]),
                Latitude = BuildLatitude(lineArray[4]),
                Longitude = BuildLongitude(lineArray[5]),
                FeatureClass = BuildFeatureClass(lineArray[6]),
                FeatureCode = lineArray[7],
                CountryCode = lineArray[8],
                AlternateCountryCodes = BuildAlternateCountryCodes(lineArray[9]),
                Admin1Code = lineArray[10],
                Admin2Code = lineArray[11],
                Admin3Code = lineArray[12],
                Admin4Code = lineArray[13],
                Population = BuildPopulation(lineArray[14]),
                Elevation = BuildElevation(lineArray[15]),
                DigitalElevationModel = BuildDigitalElevationModel(lineArray[16]),
                TimeZone = lineArray[17],
                LastModification = BuildLastModification(lineArray[18])
            };       
        }

        private int? BuildDigitalElevationModel(string digitalElevationModelString)
        {
            if (string.IsNullOrEmpty(digitalElevationModelString))
            {
                return null;
            }

            return int.Parse(digitalElevationModelString);
        }

        private int? BuildElevation(string elevationString)
        {
            if (string.IsNullOrEmpty(elevationString))
            {
                return null;
            }

            return int.Parse(elevationString);
        }

        private long? BuildPopulation(string populationString)
        {
            if (string.IsNullOrEmpty(populationString))
            {
                return null;
            }

            return long.Parse(populationString);
        }

        private char? BuildFeatureClass(string featureClassString)
        {
            if (string.IsNullOrEmpty(featureClassString))
            {
                return null;
            }

            return char.Parse(featureClassString);
        }

        private float? BuildLongitude(string longitudeString)
        {
            if (string.IsNullOrEmpty(longitudeString))
            {
                return null;
            }

            return float.Parse(longitudeString, CultureInfo.InvariantCulture.NumberFormat);
        }

        private float? BuildLatitude(string latitudeString)
        {
            if (string.IsNullOrEmpty(latitudeString))
            {
                return null;
            }

            return float.Parse(latitudeString, CultureInfo.InvariantCulture.NumberFormat);            
        }

        private int BuildGeoNameId(string geoNameIdString)
        {
            return int.Parse(geoNameIdString);
        }

        private DateTime? BuildLastModification(string lastModificationString)
        {
            if(string.IsNullOrEmpty(lastModificationString))
            {
                return null;
            }

            return DateTime.ParseExact(lastModificationString, "yyyy-MM-dd", CultureInfo.InvariantCulture);
        }

        private List<string> BuildAlternateCountryCodes(string alternateCountryCodesString)
        {
            if (string.IsNullOrEmpty(alternateCountryCodesString))
            {
                return new List<string>();
            }

            return alternateCountryCodesString.Split(',').ToList();
        }

        private List<string> BuildAlternateNames(string alternateNamesString)
        {
            if (string.IsNullOrEmpty(alternateNamesString))
            {
                return new List<string>();
            }

            return alternateNamesString.Split(',').ToList();
        }
    }
}
