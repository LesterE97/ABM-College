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
namespace splash
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            Thread t= new Thread(new ThreadStart(SplashStart));
            t.Start();
            Thread.Sleep(5000);

            InitializeComponent();

            t.Abort();
        }

        public void SplashStart()

        {
            Application.Run(new Form2());
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
