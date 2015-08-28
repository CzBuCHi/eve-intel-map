using System;
using System.Drawing;
using System.Windows.Forms;

namespace eve_intel_map.controls
{
    public partial class ColorConfig : UserControl
    {
        public ColorConfig() {
            InitializeComponent();
        }

        public string Caption {
            get { return label.Text; }
            set { label.Text = value; }
        }

        public Color Color {
            get { return pictureBox.BackColor; }
            set { pictureBox.BackColor = value; }
        }

        public int CaptionWidth {
            get { return label.Width; }
            set { label.Width = value;  }
        }

        private void pictureBox_Click(object sender, EventArgs e) {
            colorDialog.Color = pictureBox.BackColor;
            if (colorDialog.ShowDialog() == DialogResult.OK) {
                pictureBox.BackColor = colorDialog.Color;
            }
        }
    }
}
