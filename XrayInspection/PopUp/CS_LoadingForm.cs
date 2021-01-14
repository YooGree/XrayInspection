using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XrayInspection.PopUp
{
    public partial class CS_LoadingForm : Form
    {
        public Timer _timer = new Timer();

        public CS_LoadingForm()
        {
            InitializeComponent();
            InitializeEvent();
            InitializeSetting();
        }

        private void InitializeEvent()
        {
            this.FormClosing += CS_LoadingForm_FormClosing;
        }

        private void CS_LoadingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            loadingbar.Value = loadingbar.Maximum;
            _timer.Stop();
        }

        private void InitializeSetting()
        {
            // Progress Bar 세팅
            loadingbar.Minimum = 0;
            loadingbar.Maximum = 200;
            loadingbar.Step = 10;
            loadingbar.Value = 0;

            // Timer 세팅
            _timer.Interval = 100;
            _timer.Tick += _timer_Tick;
            _timer.Start();
        }

        private void _timer_Tick(object sender, EventArgs e)
        {
            if (loadingbar.Value < loadingbar.Maximum)
            {
                loadingbar.Value++;
            }
            else
            {
                loadingbar.Value = loadingbar.Maximum;
                _timer.Stop();
            }
        }
    }
}
