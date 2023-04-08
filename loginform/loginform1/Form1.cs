using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;

namespace loginform1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="")
            {
                MessageBox.Show("Enter the Username");
            }
            else if(textBox2.Text=="")
            {
                MessageBox.Show("Enter the password");
            }
            else
            {
                try
                {
                    SqlConnection con = new SqlConnection("Data Source=TITE\\TITE;Initial Catalog=loginform;Integrated Security=True");
                    SqlCommand cmd = new SqlCommand("select * from tbl_login where username = @username and password = @password", con);
                    cmd.Parameters.AddWithValue("@username", textBox1.Text);
                    cmd.Parameters.AddWithValue("@password", textBox2.Text);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    if(dt.Rows.Count > 0)
                    {
                        MessageBox.Show("login successfull");
                    }
                    else
                    {
                        MessageBox.Show("username or password is invalid");
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(("" + ex);
                }
            }
        }
    }
}
