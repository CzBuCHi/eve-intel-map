using System.Windows.Forms;

namespace eve_intel_map
{
    public partial class FormConfig : Form
    {
        public FormConfig() {
            InitializeComponent();
        }

        public void Save() {
            colorsConfig.Save();
        }
    }
}
