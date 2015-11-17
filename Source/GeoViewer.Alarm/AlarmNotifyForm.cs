using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Resources;
using System.Text;
using System.Windows.Forms;
using GeoViewer.Alarm.Properties;

namespace GeoViewer.Alarm
{
    public partial class AlarmNotifyForm : Form
    {
        public static bool EnableAudio = true;
        public static bool DisableToUntilAlarm = false;
        public static bool IsNotifying = false;
        public static int NumberOfSensor = 0;

        private SoundPlayer player;

        public AlarmNotifyForm()
        {
            InitializeComponent();
            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Size.Width - this.Width, Screen.PrimaryScreen.WorkingArea.Size.Height - this.Height);
            this.TopMost = true;
            AlarmNotifyForm.DisableToUntilAlarm = false;
            AlarmNotifyForm.IsNotifying = true;
            this.Text = string.Format(Resources.AlarmNotifyForm_Title, NumberOfSensor);
            ckEnableSound.Checked = AlarmNotifyForm.EnableAudio;
            // play sound
            if (AlarmNotifyForm.EnableAudio)
            {
                player = new SoundPlayer(Resources.ALARM);
                player.PlayLooping();
            }
        }

        private void AlarmNotifyForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            AlarmNotifyForm.IsNotifying = false;
            if (player != null)
            {
                player.Stop();
                player.Dispose();
                player = null;
            }
        }

        private void btnTurnOff_Click(object sender, EventArgs e)
        {
            AlarmNotifyForm.DisableToUntilAlarm = true;
            this.Close();
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            new AlarmManagerForm(isEnded: false).Show();
            this.Close();
        }

        private void ckEnableSound_CheckedChanged(object sender, EventArgs e)
        {
            if (ckEnableSound.Checked)
            {
                //MessageBox.Show("Enable Sound");
                AlarmNotifyForm.EnableAudio = true;
                if (player == null)
                {
                    player = new SoundPlayer(Resources.ALARM);
                    player.PlayLooping();
                }
            }
            else
            {
                //MessageBox.Show("Disable Sound");
                AlarmNotifyForm.EnableAudio = false;
                if (player != null)
                {
                    player.Stop();
                    player.Dispose();
                    player = null;
                }
            }
        }
    }
}
