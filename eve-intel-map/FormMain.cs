using System;
using System.ServiceModel;
using System.Windows.Forms;
using eve_intel_map.EveIntel;

namespace eve_intel_map
{
    public partial class FormMain : Form, IEveIntelCallback
    {
        private readonly EveIntelClient _EveIntel;
        private Guid _ClientId;

        public FormMain() {
            InitializeComponent();
            _EveIntel = new EveIntelClient(new InstanceContext(this));
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
    }
}
