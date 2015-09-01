using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
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

            eveMapSolarsystemsTableAdapter.Fill(dataSet.EveMapSolarsystems);
            eveMapRegionsTableAdapter.Fill(dataSet.EveMapRegions);

            mapControl1.CurrentSystem = Settings.Default.currentSystemId;
            comboBox2.SelectedValue = Settings.Default.currentSystemId;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
            mapControl1.RegionId = (long?)comboBox1.SelectedValue;
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
            Guid? id = _EveIntel.Connect(4637402, "H9TKjC7jatai0Ms97LL9zChRTFhdfdNr67IF5VcFbMG6T6Yr4oXkFWJPn0h4UOfp");
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

        public void SecondConnection() {
            MessageBox.Show(@"Second connection to server detected! Disconnection both.");
            _ClientId = Guid.Empty;
            button2.Enabled = true;
            button3.Enabled = false;
            label1.Text = @"clients: disconnected";
        }

        public void ClientLocalUpdate(long solarsystemId, List<EveIntelCharacterInfo> characters) {
            foreach (var character in characters) {
                DataSet.PlayerInfoRow row = dataSet.PlayerInfo.NewPlayerInfoRow();
                row.Id = character.EveId;
                row.Name = character.Label;
                row.Solarsystem = solarsystemId;
                row.SolarsystemTime = DateTime.Now;
                dataSet.PlayerInfo.AddPlayerInfoRow(row);
            }
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e) {
            comboBox1.Enabled = checkBox1.Checked;
            if (!checkBox1.Checked) {
                comboBox1.SelectedIndex = -1;
            }
        }
    }
}
