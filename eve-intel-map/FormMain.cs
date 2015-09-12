using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Windows.Forms;
using eve_intel_map.Data;
using eve_intel_map.Data.IntelDataTableAdapters;
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


        private void button2_Click(object sender, EventArgs e) {
            Guid? id = _EveIntel.Connect(4637402, "H9TKjC7jatai0Ms97LL9zChRTFhdfdNr67IF5VcFbMG6T6Yr4oXkFWJPn0h4UOfp", Settings.Default.currentSystemId);
            if (id != null) {
                _ClientId = id.Value;
                button2.Enabled = false;
                button3.Enabled = true;
            } else {
                _ClientId = Guid.Empty;
                button2.Enabled = true;
                button3.Enabled = false;
                label1.Text = @"clients: disconnected";
            }
        }

        private void button3_Click(object sender, EventArgs e) {
            _EveIntel.Disconnect(_ClientId);
            _ClientId = Guid.Empty;
            button2.Enabled = true;
            button3.Enabled = false;
            label1.Text = @"clients: disconnected";
        }

        #region Implementation of IEveIntelCallback

        public void ClientCountUpdate(int clientCount) {
            label1.Text = @"clients: " + clientCount;
        }

        public void SecondConnection(long solarsystemID) {            
            MessageBox.Show($@"Second connection to server detected! Originated from: {staticData.GetSolarSystemInfo(solarsystemID)}. Disconnection both.");
            _ClientId = Guid.Empty;
            button2.Enabled = true;
            button3.Enabled = false;
            label1.Text = @"clients: disconnected";
        }

        public void ClientLocalUpdate(long solarsystemId, List<EveIntelCharacterInfo> characters) {
            IntelData.intelDataDataTable intelData = new IntelData.intelDataDataTable();
            intelDataTableAdapter adapter = new intelDataTableAdapter();
            adapter.Fill(intelData);
            
            foreach (EveIntelCharacterInfo character in characters) {
                var stored = intelData.AsQueryable().FirstOrDefault(o => o.characterID == character.CharacterID);
                if (stored != null) {
                    stored.solarsystemID = character.SolarsystemID;
                    stored.solarsystemTime = character.SolarsystemTime;
                    stored.shipTypeID = character.ShipTypeID;
                    stored.shipTypeTime = character.ShipTypeTime;
                    stored.notes = character.Notes;
                } else {
                    IntelData.intelDataRow row = intelData.NewintelDataRow();
                    row.characterID = character.CharacterID;
                    row.characterName = character.CharacterName;
                    row.characterKos = character.CharacterKos;
                    row.corporationName = character.CorporationName;
                    row.corporationKos = character.CorporationKos;
                    row.allianceName = character.AllianceName;
                    row.allianceKos = character.AllianceKos;
                    row.solarsystemID = character.SolarsystemID;
                    row.solarsystemTime = character.SolarsystemTime;
                    row.shipTypeID = character.ShipTypeID;
                    row.shipTypeTime = character.ShipTypeTime;
                    row.notes = character.Notes;
                    intelData.AddintelDataRow(row);
                }
            }
            intelData.AcceptChanges();
            adapter.Update(intelData);
        }

        #endregion

      
        private void button1_Click(object sender, EventArgs e) {
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

        private void FormMain_Load(object sender, EventArgs e) {
            // TODO: This line of code loads data into the 'staticData.mapSolarSystem' table. You can move, or remove it, as needed.
            this.mapSolarSystemsTableAdapter.Fill(this.staticData.mapSolarSystems);

        }
    }
}
