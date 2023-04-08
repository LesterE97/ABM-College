using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace customerdata
{
    public partial class Form1 : Form
    {
        private const string ConnectionString = "Data Source=TITE\\TITE;Initial Catalog=customerdb;Integrated Security=True;Pooling=False";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=TITE\\TITE;Initial Catalog=customerdb;Integrated Security=True;Pooling=False");
                {
                    con.Open();
                    using (var cmd = new SqlCommand("INSERT INTO dbo.UserTab (Name, Address, Phone, Email) VALUES (@Name, @Address, @Phone, @Email)", con))
                    {
                        cmd.Parameters.AddWithValue("@Name", textBox1.Text);
                        cmd.Parameters.AddWithValue("@Address", textBox2.Text);
                        cmd.Parameters.AddWithValue("@Phone", textBox3.Text);
                        cmd.Parameters.AddWithValue("@Email", textBox4.Text);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Successfully saved.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while saving the data: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=TITE\\TITE;Initial Catalog=customerdb;Integrated Security=True;Pooling=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("Delete where Name=@Name", con);
            cmd.Parameters.AddWithValue("@Name", textBox1.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Deleted");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=TITE\\TITE;Initial Catalog=customerdb;Integrated Security=True;Pooling=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("Search * from UserTab", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
