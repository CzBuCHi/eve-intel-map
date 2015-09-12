using eve_intel_server.CvaKos;
using eve_intel_server.Data;
using eve_intel_server.Service;
using JetBrains.Annotations;

namespace eve_intel_server
{
    public static class DataHelper
    {
        public static void FillintelDataRow([NotNull] IntelData.IntelDataRow intelDataRow, [NotNull] CvaCharacterInfo cvaCharacterInfo) {
            intelDataRow.CharacterID = cvaCharacterInfo.EveId;
            intelDataRow.CharacterName = cvaCharacterInfo.Label;
            intelDataRow.CharacterKos = cvaCharacterInfo.Kos;
            intelDataRow.CorporationName = cvaCharacterInfo.Corp.Label;
            intelDataRow.CorporationKos = cvaCharacterInfo.Corp.Kos;
            intelDataRow.AllianceName = cvaCharacterInfo.Corp.Alliance?.Label;
            intelDataRow.AllianceKos = cvaCharacterInfo.Corp.Alliance?.Kos ?? false;
        }

        [NotNull]
        public static EveIntelCharacterInfo GetEveIntelCharacterInfo([NotNull] IntelData.IntelDataRow intelDataRow) {
            return new EveIntelCharacterInfo {
                CharacterID = intelDataRow.CharacterID,
                CharacterName = intelDataRow.CharacterName,
                CharacterKos = intelDataRow.CharacterKos,
                CorporationName = intelDataRow.CorporationName,
                CorporationKos = intelDataRow.CorporationKos,
                AllianceName = intelDataRow.AllianceName,
                AllianceKos = intelDataRow.AllianceKos,
                SolarsystemID = intelDataRow.SolarsystemID,
                SolarsystemTime = intelDataRow.SolarsystemTime,
                ShipTypeID = intelDataRow.ShipTypeID,
                ShipTypeTime = intelDataRow.ShipTypeTime,
                Notes = intelDataRow.Notes
            };
        }
    }
}
