using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace employeeData
{
    public partial class Form1 : Form
    {
        TestEntities test;
        private object txtName;

        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel.Enabled = false;
            employeeBindingSource.ResetBindings(false);
            foreach (DbEntityEntry entry in test.Changetracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Modified:
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Deleted:
                        entry.Reload();
                        break;
                }
            }
            private void button3_Click(object sender, EventArgs e)
        {
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                panel.Enabled = true;
                txtName.Focus();
                employee e = new employee();
                test.employees.Add(e);
                employeeBindingSource.Add(e);
                employeeBindingSource.MoveLast();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (string.IsNullOrEmpty(textBox5.Text))
                {
                    dataGridView1.DataSource = employeeBindingSource;
                }
                else
                {
                    var query = from o in employeeBindingSource.DataSource as List<employee>
                                where o.Name == textBox5.Text || o.Position.Contains(textBox5.Text) || o.Salary.Contains(textBox5.Text) || o.Email.Contains(textBox5.Text)
                                select o;
                    dataGridView1.DataSource = query.ToList();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                employeeBindingSource.EndEdit();
                test.SaveChanges.Async();
                panel.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                employeeBindingSource.ResetBindings(false);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel.Enabled = false;
            test = new TestEntities();
            employeeBindingSource.DataSource = test.Employees.ToList();
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete) 
            {
               if(MessageBox.Show("Are you sure you want to delete this record?", "Message" , MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
                {
                    test.employees.Remove(employeeBindingSource.Current as employee);
                    employeeBindingSource.RemoveCurrent();
                }
            }
        }
    }
}
