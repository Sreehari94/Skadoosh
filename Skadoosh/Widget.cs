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
    public partial class Widget : Form
    {
        public Widget()
        {
            InitializeComponent();
        }
        bool read;

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;


        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void Form3_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Closing Application");
            this.Close();
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void Widget_Load(object sender, EventArgs e)
        {
            this.Left = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Right - this.Width;
            this.Top = 0;
            read = Form1.state;
        }
   

        private void pictureBox3_Click(object sender, EventArgs e)
        {
          
            if (read == true)
            {
                pictureBox3.BackgroundImage = Skadoosh.Properties.Resources.play;
                Form1.control = true;
                read = false;
            }
            else
            {
                pictureBox3.BackgroundImage = Skadoosh.Properties.Resources.pause;
                Form1.control = false;
                read = true;
            }

        }


    }
}
