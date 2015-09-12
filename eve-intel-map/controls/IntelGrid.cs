using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace eve_intel_map.controls
{
    public partial class IntelGrid : UserControl
    {
        public IntelGrid() {
            InitializeComponent();
            string[] columns = Properties.Settings.Default.intel_grid_columns.Split(',');
            foreach (DataGridViewColumn column in dataGridView.Columns) {
                column.Visible = false;
            }
            for (int i = 0; i < columns.Length; i++) {
                DataGridViewColumn column = dataGridView.Columns[columns[i]];
                if (column != null) {
                    column.DisplayIndex = i;
                    column.Visible = true;
                }
            }
        }

        private void dataGridView_ColumnDisplayIndexChanged(object sender, DataGridViewColumnEventArgs e) {
            IEnumerable<string> q = from DataGridViewColumn column in dataGridView.Columns
                                    where column.Visible
                                    select column.Name;

            Properties.Settings.Default.intel_grid_columns = string.Join(",", q);
        }
    }
}
