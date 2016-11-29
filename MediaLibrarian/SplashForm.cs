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
        Timer _timer;
        int _span = 0;
        private void SplashForm_Load(object sender, EventArgs e)
        {
            _timer = new Timer() { Interval = 300 };
            _timer.Tick += new EventHandler(timer_tick);
            _timer.Start();

        }
        void timer_tick(object sender, EventArgs e)
        {
            if (_span % 3 == 0) { progressLabel.Text = "Загрузка."; }
            if (_span % 3 == 1) { progressLabel.Text = "Загрузка.."; }
            if (_span % 3 == 2) { progressLabel.Text = "Загрузка..."; }
            if (_span >= 15) { _timer.Stop(); Close(); }
            _span++;
        }

        private void SplashForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
