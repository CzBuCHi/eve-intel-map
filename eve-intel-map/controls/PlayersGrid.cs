using System.Windows.Forms;

namespace eve_intel_map.controls
{
    public partial class PlayersGrid : UserControl
    {
        public delegate void ShipUpdateDelegate(long characterId, long shipId);

        public PlayersGrid() {
            InitializeComponent();
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex == -1) {
                return;
            }

            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            DataGridViewCell id = row.Cells["Id"];
            DataGridViewCell ship = row.Cells["Ship"];
            OnShipUpdate((long) id.Value, (long) ship.Value);
        }

        public event ShipUpdateDelegate ShipUpdate;

        protected virtual void OnShipUpdate(long characterId, long shipId) {
            ShipUpdate?.Invoke(characterId, shipId);
        }
    }
}
