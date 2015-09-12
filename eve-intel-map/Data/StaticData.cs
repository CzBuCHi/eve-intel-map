using System.Linq;
using JetBrains.Annotations;

namespace eve_intel_map.Data
{
    partial class StaticData
    {
        [CanBeNull]
        public string GetSolarSystemInfo(long solarsystemID) {
            var q = from s in mapSolarSystems.AsQueryable()
                    join c in mapConstellations.AsQueryable() on s.constellationID equals c.constellationID
                    join r in mapRegions.AsQueryable() on s.regionID equals r.regionID
                    where s.solarSystemID == solarsystemID
                    select new { s.solarSystemName, c.constellationName, r.regionName };

            var info = q.FirstOrDefault();
            return info == null ? null : $"{info.solarSystemName} - {info.constellationName} - {info.regionName}";
        }
    }
}
