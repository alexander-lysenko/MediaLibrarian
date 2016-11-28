using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MediaLibrarian
{
    public partial class SplashForm : Form
    {
        public SplashForm()
        {
            InitializeComponent();
        }
        Timer timer;
        int span = 0;
        private void SplashForm_Load(object sender, EventArgs e)
        {
            timer = new Timer() { Interval = 300 };
            timer.Tick += new EventHandler(timer_tick);
            timer.Start();
        }
        void timer_tick(object sender, EventArgs e)
        {
            if (span % 3 == 0) { progressLabel.Text = "Загрузка."; }
            if (span % 3 == 1) { progressLabel.Text = "Загрузка.."; }
            if (span % 3 == 2) { progressLabel.Text = "Загрузка..."; }
            if (span >= 15) { timer.Stop(); Close(); }
            span++;
        }
    }
}
