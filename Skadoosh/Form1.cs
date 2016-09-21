using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Media;
using System.IO;

namespace Skadoosh
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

        }
        public static Boolean state;
        private void Form1_Load(object sender, EventArgs e)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(0, 0, this.Width, this.Height);
            Region region = new Region(path);
            this.Region = region;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        string[] files, path;
        private void button3_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                files = openFileDialog1.SafeFileNames;
                path = openFileDialog1.FileNames;
            }
                for(int i = 0; i < files.Length; i++)
                {
                    listBox1.Items.Add(files[i]);
                }
                int count = listBox1.Items.Count - 1;
                listBox1.SelectedItem = listBox1.Items[count];
        }
       

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

            WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();
            /*     int count = listBox1.Items.Count - 1;
                 listBox1.SelectedItem = listBox1.Items[count];*/
            //axWindowsMediaPlayer1.URL = textBox1.Text;
          
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();

        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

       
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void Form1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

       private void axWindowsMediaPlayer1_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsMediaEnded)
            {
                timer1.Interval = 100;
                timer1.Enabled = true;
            }
        }
       public static bool control=true;
        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
       {
           if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsMediaEnded)

               listBox1.SelectedIndex = listBox1.SelectedIndex + 1;

           axWindowsMediaPlayer1.URL = path[listBox1.SelectedIndex];
          if(control==true)
           {
               axWindowsMediaPlayer1.Ctlcontrols.play();
               state = true;
           }
          else
           {
               axWindowsMediaPlayer1.Ctlcontrols.pause();
               state = false;
           }

       }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < files.Length - 1)
            {
                listBox1.SelectedIndex++;
                timer1.Enabled = false;
            }
            else
            {
                listBox1.SelectedIndex = 0;
                timer1.Enabled = false;
            }        
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            Widget pg = new Widget();
            control = false;
            this.Hide(); 
            pg.ShowDialog();
            this.Show();
          
        }
    }
}
