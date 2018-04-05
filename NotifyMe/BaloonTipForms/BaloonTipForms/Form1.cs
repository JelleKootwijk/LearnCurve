using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
<<<<<<< Updated upstream
using System.Drawing.Text;  
=======
using System.Drawing.Text;
using Microsoft.Win32;
using System.IO;
>>>>>>> Stashed changes

namespace BaloonTipForms
{
    public partial class Form1 : Form
    {
<<<<<<< Updated upstream
=======
        RegistryKey reg = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

>>>>>>> Stashed changes
        static NotifyIcon _NotifyIcon1 = new NotifyIcon();

        public Point mouseLocation;

        public Form1()
        {
            reg.SetValue("Notify me!", Application.ExecutablePath.ToString());
            InitializeComponent();
        }

        // make timer
        private System.Threading.Timer timer;
        // setup timer
        private void SetUpTimer(TimeSpan alertTime)
        {
            // get current time
            DateTime current = DateTime.Now;

            TimeSpan timeToGo = alertTime - current.TimeOfDay;
            if (timeToGo < TimeSpan.Zero)
            {
                return;
            }
            this.timer = new System.Threading.Timer(x =>
            {
                this.SomeMethodRunsAtTime();
            }, null, timeToGo, Timeout.InfiniteTimeSpan);
        }

        private void SomeMethodRunsAtTime()
        {
            _NotifyIcon1.Icon = BaloonTipForms.Properties.Resources.photo;
            _NotifyIcon1.BalloonTipTitle = "Notification!";
            _NotifyIcon1.BalloonTipText = txtNotification.Text;
            _NotifyIcon1.BalloonTipIcon = ToolTipIcon.None;

            _NotifyIcon1.Visible = true;
            _NotifyIcon1.ShowBalloonTip(500);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Int32.TryParse(txtHours.Text, out int hoursParsed);
            Int32.TryParse(txtMinutes.Text, out int minutesParsed);
            Int32.TryParse(txtSeconds.Text, out int secondsParsed);

            SetUpTimer(new TimeSpan(hoursParsed, minutesParsed, secondsParsed));
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePose = Control.MousePosition;
                mousePose.Offset(mouseLocation.X, mouseLocation.Y);
                Location = mousePose;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(56)))), ((int)(((byte)(52)))));
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(56)))), ((int)(((byte)(52)))));
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
        }
    }
}
