using System.Windows.Forms;
using eve_intel_map.Properties;

namespace eve_intel_map.controls
{
    public partial class ColorsConfig : UserControl
    {
        public ColorsConfig() {
            InitializeComponent();
            colorKos0.Color = Settings.Default.colorKos0;
            colorKos1.Color = Settings.Default.colorKos1;
            colorKos3.Color = Settings.Default.colorKos3;
            colorKos5.Color = Settings.Default.colorKos5;
            colorKos10.Color = Settings.Default.colorKos10;
            colorKos20.Color = Settings.Default.colorKos20;
            colorKos20plus.Color = Settings.Default.colorKos20plus;
        }

        public void Save() {
            Settings.Default.colorKos0 = colorKos0.Color;
            Settings.Default.colorKos1 = colorKos1.Color;
            Settings.Default.colorKos3 = colorKos3.Color;
            Settings.Default.colorKos5 = colorKos5.Color;
            Settings.Default.colorKos10 = colorKos10.Color;
            Settings.Default.colorKos20 = colorKos20.Color;
            Settings.Default.colorKos20plus = colorKos20plus.Color;
        }
    }
}
