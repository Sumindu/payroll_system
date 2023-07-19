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
    public partial class home : Form
    {
        public string userid,f_nm,l_nm;

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-5713COU\SQLEXPRESS;Initial Catalog=payroll;Integrated Security=True");

        public home(string memlogin)
        {
            userid = memlogin;
            InitializeComponent();

            DataTable dt = new DataTable();

            con.Open();
            SqlCommand cmd = new SqlCommand("Select * From St_reg where regnum=@regnum", con);
            cmd.Parameters.AddWithValue("@regnum", userid);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            con.Close();

            f_nm = dt.Rows[0]["f_nm"].ToString();
            l_nm = dt.Rows[0]["l_nm"].ToString();
            //guna2CirclePictureBox1.Image = (Image)dt.Rows[0]["img"];
            guna2HtmlLabel1.Text = "Hi " + f_nm;
        }

        private void home_Load(object sender, EventArgs e)
        {
            //guna2HtmlLabel1.Text = f_nm + " " + l_nm;
        }
    }
}
