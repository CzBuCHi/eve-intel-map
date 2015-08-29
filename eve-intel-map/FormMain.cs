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

        #endregion

        private void button2_Click(object sender, EventArgs e) {
            Guid? id = _EveIntel.Connect(42, "");
            if (id != null) {
                _ClientId = id.Value;
            }
            button2.Enabled = false;
            button3.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e) {
            _EveIntel.Disconnect(_ClientId);
            button2.Enabled = true;
            button3.Enabled = false;
            label1.Text = @"clients: disconnected";
        }
    }
}
