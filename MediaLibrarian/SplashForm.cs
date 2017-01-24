using System;
using System.Windows.Forms;

namespace MediaLibrarian
{
    public partial class SplashForm : Form
    {
        public SplashForm()
        {
            InitializeComponent();
        }

        private Timer _timer;
        private int _span;

        public static void ShowForm()
        {
            var splash = new SplashForm();
            splash.ShowDialog();
        }

        private void SplashForm_Load(object sender, EventArgs e)
        {
            _timer = new Timer { Interval = 300 };
            _timer.Tick += timer_tick;
            _timer.Start();
        }

        private void timer_tick(object sender, EventArgs e)
        {
            if (_span % 3 == 0) { progressLabel.Text = "Загрузка."; }
            if (_span % 3 == 1) { progressLabel.Text = "Загрузка.."; }
            if (_span % 3 == 2) { progressLabel.Text = "Загрузка..."; }
            if (_span >= 6) { _timer.Stop(); Close(); }
            _span++;
        }

        private void SplashForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
