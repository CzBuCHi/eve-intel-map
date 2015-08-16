using System;
using System.ServiceModel;
using System.Windows.Forms;
using eve_intel_map.IntelService;

namespace eve_intel_map
{
    public partial class Form1 : Form, IIntelServiceCallback
    {
        private IntelServiceClient _Client;
        private Guid _ClientId;

        public Form1() {
            InitializeComponent();
        }

        public void LocalKosInfo(LocalKosInfo kosInfo) {
            listBox1.Items.Insert(0, "system: " + kosInfo.SystemId + ", pilots: " + string.Join(", ", kosInfo.PilotNames));
        }

        public void OnlineClientsUpdate(long onlineClients) {
            label1.Text = @"clients: " + onlineClients;
        }

        private void button1_Click(object sender, EventArgs e) {
            LocalKosInfo info = new LocalKosInfo {
                SenderId = _ClientId,
                SystemId = 42,
                PilotNames = textBox1.Lines
            };
            _Client.BroadcastLocalKos(info);
        }

        private void button2_Click(object sender, EventArgs e) {

            _Client = new IntelServiceClient(new InstanceContext(this));

            ConnectionInfo info = _Client.Connect();
            if (info == null) {
                MessageBox.Show(@"cannot connect to server...");
                return;
            }
            _ClientId = info.ClientId;
            OnlineClientsUpdate(info.OnlineClients);
        }

        private void button3_Click(object sender, EventArgs e) {
            _Client.Close();
        }
    }
}
