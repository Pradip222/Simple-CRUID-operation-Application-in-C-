using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;// Step 1

namespace CRUDOp
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }
        public string getUsername()
        {
            return txtuser.Text;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void txtemail_TextChanged(object sender, EventArgs e)
        {
            txtuser.Text = txtemail.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(txtname.Text=="" || txtemail.Text=="" || 
                txtmobile.Text=="" || txtdob.Text==DateTime.Now.
                ToShortDateString() || txtpwd.Text== "" || 
                txtpwdRe.Text=="")
            {
                MessageBox.Show("Please enter all Fields !!!", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string password, reEnter;
            password = txtpwd.Text;
            reEnter = txtpwdRe.Text;
            if(!password.Equals(reEnter))
            {
                MessageBox.Show("Please Enter Password Correctly !!!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtpwdRe.Clear();
                txtpwd.Clear();
                txtpwd.Focus();
                return;
            }
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\WIN10\Documents\studentD.accdb";
            con.Open();//step 1 completed
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO Signup(FullName,Email,DOB,"+ "MobileNo) VALUES ('"+txtname.Text+"','"+txtemail.Text+ "','"+txtdob.Text+"','"+txtmobile.Text+"')";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "INSERT INTO Login VALUES" + " ('" + txtuser.Text + "','" + txtpwd.Text + "')";
            MessageBox.Show(cmd.CommandText);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Signup Successfully !!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            con.Close();

            this.Hide();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //step 2
            OleDbConnection cn = new OleDbConnection();
            cn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\WIN10\Documents\studentD.accdb";
            cn.Open();
            lbdbStatus.Text = "Connected !!!";
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
