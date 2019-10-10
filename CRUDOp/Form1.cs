using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace CRUDOp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label2.ForeColor = Color.Black;
        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            label2.ForeColor = Color.Gray;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignUp ob = new SignUp();
            ob.ShowDialog();
            this.txtuser.Text = ob.getUsername();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtuser.Text == "" || txtpwd.Text=="")
            {
                MessageBox.Show("Please enter username and password !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtuser.Focus();
                return;
            }
            OleDbConnection cn = new OleDbConnection();
            cn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\WIN10\Documents\studentD.accdb";
            cn.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Login Where Username='"+txtuser.Text+"' and Password='"+txtpwd.Text+"'";
            OleDbDataReader dr;
            dr = cmd.ExecuteReader();
            if(!dr.HasRows)
            {
                MessageBox.Show("Login Failed !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtpwd.Clear();
                txtuser.Clear();
                txtuser.Focus();
            }
            else
            {
                //MessageBox.Show("Login Successfull !!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                StudentRecord ob = new StudentRecord();
                this.Hide();
                ob.Show();
            }
            cn.Close();
        }
    }
}
