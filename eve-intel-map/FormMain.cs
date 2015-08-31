using System;
using System.Linq;
using System.ServiceModel;
using System.Windows.Forms;
using eve_intel_map.EveIntel;
using eve_intel_map.Model;
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

            EveMapSolarsystem[] eveMapSolarsystems = DbHelper.DataContext.SolarSystems.ToArray();
            comboBox1.DataSource = eveMapSolarsystems;
            if (Settings.Default.currentSystemId != 0) {
                comboBox1.SelectedIndex = Array.FindIndex(eveMapSolarsystems, system => system.Id == Settings.Default.currentSystemId);                                
            } else {
                comboBox1.SelectedIndex = 0;
            }
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;

            comboBox2.DataSource = DbHelper.DataContext.Regions.ToArray();
            comboBox2.SelectedIndex = -1;
            comboBox2.SelectedIndexChanged += this.comboBox2_SelectedIndexChanged;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
            EveMapSolarsystem solarsystem = (EveMapSolarsystem) comboBox1.SelectedItem;            
            mapControl1.CurrentSystem = solarsystem.Id;

            Settings.Default.currentSystemId = solarsystem.Id;
            Settings.Default.Save();
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

        #endregion

        private void FormMain_Load(object sender, EventArgs e) {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) {
            EveMapRegion region = (EveMapRegion)comboBox2.SelectedItem;
            mapControl1.RegionId = region.Id;
        }
    }
}
