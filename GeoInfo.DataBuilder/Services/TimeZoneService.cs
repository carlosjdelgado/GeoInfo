using NodaTime.TimeZones;
using System.Collections.Generic;
using System.Linq;

namespace GeoInfo.DataBuilder.Services
{
    public class TimeZoneService
    {
        private readonly TzdbDateTimeZoneSource _tzdbSource;
        private readonly string[] utcZones = new[] { "Etc/UTC", "Etc/UCT", "Etc/GMT" };

        public TimeZoneService()
        {
            _tzdbSource = TzdbDateTimeZoneSource.Default;
        }

        public Dictionary<string, string> GetWindowsTimeZoneMapping()
        {
            var windowsTimeZoneMapping = new Dictionary<string, string>();

            var ianaTimeZones = _tzdbSource.ZoneLocations.Select(z => z.ZoneId).ToList();
            ianaTimeZones.ForEach(i => windowsTimeZoneMapping.Add(i, MapWindowsTimeZone(i)));
            return windowsTimeZoneMapping;
        }

        private string MapWindowsTimeZone(string ianaTimeZone)
        {
            if (utcZones.Contains(ianaTimeZone)) return "UTC";

            var links = _tzdbSource.CanonicalIdMap.Where(x => x.Value.Equals(ianaTimeZone)).Select(x => x.Key);
            var possibleZones = _tzdbSource.CanonicalIdMap.ContainsKey(ianaTimeZone) ? links.Concat(new[] { _tzdbSource.CanonicalIdMap[ianaTimeZone], ianaTimeZone }) : links;

            var mappings = _tzdbSource.WindowsMapping.MapZones;
            var item = mappings.FirstOrDefault(x => x.TzdbIds.Any(possibleZones.Contains));
            if (item == null) return null;
            return item.WindowsId;           
        }
    }    
}
