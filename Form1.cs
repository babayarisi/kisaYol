using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kisaYol
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
            this.ShowIcon = false;
            Boolean kopyala = Form1.RegisterHotKey(this.Handle, 0, 0x0001, 0x43);
            Boolean goster = Form1.RegisterHotKey(this.Handle, 1, 0x0001, 0x41);
            string imzaici = System.IO.File.ReadAllText("imza.txt");
            txtimza.Text = imzaici;
        }
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);
        //[DllImport("user32.dll")]
        //public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0312)
            {
                if (m.WParam.ToInt32() == 0) 
                {
                    Clipboard.SetText(txtimza.Text);
                }
                if (m.WParam.ToInt32() == 1)
                {
                    if (this.WindowState == FormWindowState.Minimized)
                    {
                        this.WindowState = FormWindowState.Normal;
                    }
                    else
                    {
                        this.WindowState = FormWindowState.Minimized;
                    }
                    
                }
                

                 
            }
            base.WndProc(ref m);
           
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            trackBar1.Maximum = 100;
            trackBar1.Minimum = 5;
            trackBar1.Value = 70;
        }


        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter("imza.txt");
            file.WriteLine(txtimza.Text);
            MessageBox.Show("Güncellendi");
            file.Close();
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            string imzaici = System.IO.File.ReadAllText("imza.txt");
            txtimza.Text = imzaici;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            this.Opacity = (double)trackBar1.Value / 100;
        }
    }
}
