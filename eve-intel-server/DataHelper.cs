using eve_intel_server.CvaKos;
using eve_intel_server.Data;
using eve_intel_server.Data.IntelDataTableAdapters;
using eve_intel_server.Service;
using JetBrains.Annotations;

namespace eve_intel_server
{
    public static class DataHelper
    {
        public static IntelData.intelDataDataTable IntelData { get; }

        static DataHelper() {
            IntelData = new IntelData.intelDataDataTable();
            intelDataTableAdapter intelAdapter = new intelDataTableAdapter();
            intelAdapter.Fill(IntelData);
        }

        public static void FillintelDataRow([NotNull] IntelData.intelDataRow intelDataRow, [NotNull] CvaCharacterInfo cvaCharacterInfo) {
            intelDataRow.characterID = cvaCharacterInfo.EveId;
            intelDataRow.characterName = cvaCharacterInfo.Label;
            intelDataRow.characterKos = cvaCharacterInfo.Kos;
            intelDataRow.corporationName = cvaCharacterInfo.Corp.Label;
            intelDataRow.corporationKos = cvaCharacterInfo.Corp.Kos;
            intelDataRow.allianceName = cvaCharacterInfo.Corp.Alliance?.Label;
            intelDataRow.allianceKos = cvaCharacterInfo.Corp.Alliance?.Kos ?? false;
        }

        [NotNull]
        public static EveIntelCharacterInfo GetEveIntelCharacterInfo([NotNull] IntelData.intelDataRow intelDataRow) {
            return new EveIntelCharacterInfo {
                CharacterID = intelDataRow.characterID,
                CharacterName = intelDataRow.characterName,
                CharacterKos = intelDataRow.characterKos,
                CorporationName = intelDataRow.corporationName,
                CorporationKos = intelDataRow.corporationKos,
                AllianceName = intelDataRow.allianceName,
                AllianceKos = intelDataRow.allianceKos,
                SolarsystemID = intelDataRow.solarsystemID,
                SolarsystemTime = intelDataRow.solarsystemTime,
                ShipTypeID = intelDataRow.shipTypeID,
                ShipTypeTime = intelDataRow.shipTypeTime,
                Notes = intelDataRow.notes
            };
        }
    }
}
