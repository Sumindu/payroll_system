using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace payroll_system
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-5713COU\SQLEXPRESS;Initial Catalog=payroll;Integrated Security=True");

        string ShowPswdBtnSts = "hide", memlogin;

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            if (ShowPswdBtnSts == "show")
            {
                guna2CircleButton1.Image = Properties.Resources.hide;
                ShowPswdBtnSts = "hide";
                guna2TextBox2.PasswordChar = '●';
                guna2TextBox2.UseSystemPasswordChar = true;

            }
            else if(ShowPswdBtnSts=="hide")
            {
                guna2CircleButton1.Image = Properties.Resources.show;
                ShowPswdBtnSts = "show";
                guna2TextBox2.PasswordChar = '\0';
                guna2TextBox2.UseSystemPasswordChar = false;
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            guna2TextBox1.Clear();
            guna2TextBox2.Clear();
            guna2TextBox1.Focus();

            memlogin = "f";
            this.Hide();
            home f = new home(memlogin);
            f.ShowDialog();
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //this.ActiveControl = guna2TextBox1;
        }

        private void guna2TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.ActiveControl = guna2TextBox2;
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            guna2Panel2.Show();
            guna2Panel1.Hide();
            guna2HtmlLabel4.Text = "Welcome!!";
            guna2HtmlLabel3.Text = "You can create and sign in to access<br>with your account";
            guna2TextBox4.Focus();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            guna2Panel1.Show();
            guna2Panel2.Hide();
            guna2HtmlLabel4.Text = "Welcome Back!";
            guna2HtmlLabel3.Text = "You can sign in to access with your<br>existing account";
            guna2TextBox1.Focus();
        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {
            guna2Panel1.Hide();
            guna2Panel2.Show();
        }

        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            DialogResult v1 = MessageBox.Show("Are you sure??","Exit",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (v1 == DialogResult.Yes)
            {
                this.Close();
            }
            else if (v1 == DialogResult.No)
            {
                this.Show();
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            

            try
            {
                string username = guna2TextBox1.Text;
                String q = "SELECT * FROM tb1 WHERE usernm = '" + guna2TextBox1.Text + "'AND pswd = '" + guna2TextBox2.Text + "'";
                SqlDataAdapter sda = new SqlDataAdapter(q, con);

                DataTable dtable = new DataTable();
                sda.Fill(dtable);
                if (dtable.Rows.Count > 0)
                {
                    memlogin = username;
                    this.Hide();
                    home f = new home(memlogin);
                    f.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid login credentials,please check Username and Password and try again.", "Invalid Login Details.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    guna2TextBox1.Clear();
                    guna2TextBox2.Clear();
                    guna2TextBox1.Focus();
                }
            }
            catch(Exception r)
            {
                MessageBox.Show("Sql Connection Error"+r, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
