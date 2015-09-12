using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Windows.Forms;
using eve_intel_map.Data;
using eve_intel_map.EveIntel;
using eve_intel_map.Properties;

namespace eve_intel_map
{
    public partial class FormMain : Form, IEveIntelCallback
    {
        private readonly EveIntelClient _EveIntel;
        private Guid _ClientId;

        public FormMain() {
            InitializeComponent();
            _EveIntel = new EveIntelClient(new InstanceContext(this));

            
            mapControl1.CurrentSystem = Settings.Default.currentSystemId;
            comboBox2.SelectedValue = Settings.Default.currentSystemId;
            
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) {
            long? solarsystemId = (long?)comboBox2.SelectedValue;

            if (solarsystemId != null) {
                mapControl1.CurrentSystem = (long) solarsystemId;
                Settings.Default.currentSystemId = (long) solarsystemId;
                Settings.Default.Save();
            }            
        }


        private async void btnConnect_Click(object sender, EventArgs e) {
            Guid? id = _EveIntel.Connect(4637402, "H9TKjC7jatai0Ms97LL9zChRTFhdfdNr67IF5VcFbMG6T6Yr4oXkFWJPn0h4UOfp", Settings.Default.currentSystemId);
            if (id != null) {
                _ClientId = id.Value;
                btnConnect.Enabled = false;
                btnDisconnect.Enabled = true;
                ClientIntelUpdate(await _EveIntel.ClientGlobalUpdateAsync(_ClientId));
            } else {
                _ClientId = Guid.Empty;
                btnConnect.Enabled = true;
                btnDisconnect.Enabled = false;
                label1.Text = @"clients: disconnected";
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e) {
            _EveIntel.Disconnect(_ClientId);
            _ClientId = Guid.Empty;
            btnConnect.Enabled = true;
            btnDisconnect.Enabled = false;
            label1.Text = @"clients: disconnected";
        }

        #region Implementation of IEveIntelCallback

        public void ClientCountUpdate(int clientCount) {
            label1.Text = @"clients: " + clientCount;
        }

        public void SecondConnection(long solarsystemID) {            
            IQueryable<string> q = from o in staticData.MapSolarSystemTable
                                   join c in staticData.MapConstellationTable on o.ConstellationID equals c.ConstellationID
                                   join r in staticData.MapRegionTable on o.RegionID equals r.RegionID
                                   where o.SolarSystemID == solarsystemID
                                   select $"{o.SolarSystemName} {c.ConstellationName} {r.RegionName}";

            MessageBox.Show($@"Second connection to server detected! Originated from: {q.FirstOrDefault()}. Disconnection both.");
            _ClientId = Guid.Empty;
            btnConnect.Enabled = true;
            btnDisconnect.Enabled = false;
            label1.Text = @"clients: disconnected";
        }

        public void ClientIntelUpdate(List<EveIntelCharacterInfo> characters) {
            IntelData intelData = new IntelData();;            
            foreach (EveIntelCharacterInfo character in characters) {
                var stored = intelData.IntelDataTable.FirstOrDefault(o => o.CharacterID == character.CharacterID);
                if (stored != null) {
                    stored.SolarsystemID = character.SolarsystemID;
                    stored.SolarsystemTime = character.SolarsystemTime;
                    stored.ShipTypeID = character.ShipTypeID;
                    stored.ShipTypeTime = character.ShipTypeTime;
                    stored.Notes = character.Notes;
                } else {
                    var row = new IntelData.IntelDataRow();
                    row.CharacterID = character.CharacterID;
                    row.CharacterName = character.CharacterName;
                    row.CharacterKos = character.CharacterKos;
                    row.CorporationName = character.CorporationName;
                    row.CorporationKos = character.CorporationKos;
                    row.AllianceName = character.AllianceName;
                    row.AllianceKos = character.AllianceKos;
                    row.SolarsystemID = character.SolarsystemID;
                    row.SolarsystemTime = character.SolarsystemTime;
                    row.ShipTypeID = character.ShipTypeID;
                    row.ShipTypeTime = character.ShipTypeTime;
                    row.Notes = character.Notes;
                    intelData.IntelDataTable.Add(row);
                }
            }
            //mapControl1.UpdateData();
            intelGrid1.UpdateData();
        }

        #endregion

      
        private void btnCheck_Click(object sender, EventArgs e) {
            //string text = Clipboard.GetText();
            //if (string.IsNullOrEmpty(text)) {
            //    return;
            //}
            //List<string> names = text.Split(new[] {'\r', '\n'}, StringSplitOptions.RemoveEmptyEntries).ToList();

            // dummy data
            List<string> names = new List<string> { "kazzard20", "naderah", "Commander John Snow"};
            if (names.Count > 0) {
                _EveIntel.UpdateLocal(_ClientId, Settings.Default.currentSystemId, names);
            }
        }
    }
}
