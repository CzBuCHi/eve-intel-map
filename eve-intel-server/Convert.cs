using eve_intel_server.CvaKos;
using eve_intel_server.Service;
using JetBrains.Annotations;

namespace eve_intel_server
{
    public static class Convert
    {
        [NotNull]
        public static EveIntelCharacterInfo GetEveIntelCharacterInfo([NotNull] CvaCharacterInfo info) {
            return new EveIntelCharacterInfo {
                EveId = info.EveId,
                Corp = GetEveIntelCorporationInfo(info.Corp),
                Label = info.Label,
                Kos = info.Kos
            };
        }

        [NotNull]
        public static EveIntelCorporationInfo GetEveIntelCorporationInfo([NotNull] CvaCorporationInfo info) {
            return new EveIntelCorporationInfo {
                EveId = info.EveId,
                Label = info.Label,
                Kos = info.Kos,
                Alliance = info.Alliance != null ? GetEveIntelAllianceInfo(info.Alliance) : null,
                Npc = info.Npc
            };
        }

        [NotNull]
        public static EveIntelAllianceInfo GetEveIntelAllianceInfo([NotNull] CvaAllianceInfo info) {
            return new EveIntelAllianceInfo {
                EveId = info.EveId,
                Label = info.Label,
                Kos = info.Kos
            };
        }

        [NotNull]
        public static CvaCharacterInfo GetCvaCharacterInfo([NotNull] EveIntelCharacterInfo info) {
            return new CvaCharacterInfo {
                EveId = info.EveId,
                Corp = GetCvaCorporationInfo(info.Corp),
                Label = info.Label,
                Kos = info.Kos
            };
        }

        [NotNull]
        public static CvaCorporationInfo GetCvaCorporationInfo([NotNull] EveIntelCorporationInfo info) {
            return new CvaCorporationInfo {
                EveId = info.EveId,
                Label = info.Label,
                Kos = info.Kos,
                Alliance = info.Alliance != null ? GetCvaAllianceInfo(info.Alliance) : null,
                Npc = info.Npc
            };
        }

        [NotNull]
        public static CvaAllianceInfo GetCvaAllianceInfo([NotNull] EveIntelAllianceInfo info) {
            return new CvaAllianceInfo {
                EveId = info.EveId,
                Label = info.Label,
                Kos = info.Kos
            };
        }
    }
}
