using System;
using System.Windows.Forms;

namespace MediaLibrarian_
{
    public partial class PictureViewer : Form
    {
        public PictureViewer()
        {
            InitializeComponent();
        }

        private void PictureViewer_Deactivate(object sender, EventArgs e)
        {
            Close();
        }

        private void PictureViewer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Close();
        }
    }
}
