using System.Windows.Forms;

namespace eve_intel_map.controls
{
    public partial class IntelGrid : UserControl
    {
        public IntelGrid() {
            InitializeComponent();
        }

        public void UpdateData() {
            intelGridRowBindingSource.ResetBindings(true);
        }
    }
}
