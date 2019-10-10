using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDOp
{
    public partial class StudentRecord : Form
    {
        private frmProfilePic frmProfilePic;
        string profileimage = "", status = "";
        public StudentRecord()
        {
            InitializeComponent();
        }
        private void allClear()
        {
            txtname.Clear();
            txtmobile.Clear();
            txtrn.Clear();
            txtage.Clear();
            txtadd.Clear();
            cmbBranch.SelectedIndex = 0;
            cmbClass.SelectedIndex = 0;
        }
        private void fillgrid()
        {
            OleDbConnection cn = new OleDbConnection();
            cn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Backup\Documents\studentD.accdb";
            cn.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from student order by ID";
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds,"sm");
            gridStudent.DataSource = ds.Tables["sm"];
            gridStudent.ClearSelection();
            cn.Close();

        }
        private void  unlockAll(bool b)
        {
            txtadd.Enabled = b;
            txtage.Enabled = b;
            txtmobile.Enabled = b;
            txtname.Enabled = b;
            txtrn.Enabled = b;
            cmbBranch.Enabled = b;
            cmbClass.Enabled = b;
        }
        private void actionButtonNormalStage()
        {
            btnAddNew.Enabled = true;
            btnCan.Enabled = false;
            btnDel.Enabled = false;
            btnSave.Enabled = false;
            btnUp.Enabled = false;
        }
        private void actionButtonEditStage()
        {
            btnSave.Enabled = true;
            btnCan.Enabled = true;
            btnAddNew.Enabled = false;
            btnUp.Enabled = false;
            btnDel.Enabled = false;
        }
        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void StudentRecord_Load(object sender, EventArgs e)
        {
            unlockAll(false);
            actionButtonNormalStage();
            fillgrid();
            allClear();
        }
       
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            unlockAll(true);
            actionButtonEditStage();
            txtname.Focus();
        }

        private void btnCan_Click(object sender, EventArgs e)
        {
            unlockAll(false);
            actionButtonNormalStage();
            allClear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            OleDbConnection cn = new OleDbConnection();
            cn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Backup\Documents\studentD.accdb";
            cn.Open();
            DialogResult drs = MessageBox.Show("Are you sure, Do you wants to add this record..?", "Question",MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (drs == DialogResult.No)
                return;
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Insert into Student(FullName, Age, Address, MobileNo, RollNo,Class, Branch) values('"+txtname.Text+"','"+txtage.Text+"', '"+txtadd.Text+"','"+txtmobile.Text+"','"+txtrn.Text+"','"+cmbClass.Text+ "','" + cmbBranch.Text + "')";
            cmd.ExecuteNonQuery();
            MessageBox.Show("Student added Successfully","Information", MessageBoxButtons.OK,MessageBoxIcon.Information);
            cn.Close();
            allClear();
            unlockAll(false);
            actionButtonNormalStage();
            fillgrid();
        }

        private void GridStudent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtname.Text = gridStudent.CurrentRow.Cells["FullName"].Value.ToString();
            txtadd.Text = gridStudent.CurrentRow.Cells["Address"].Value.ToString();
            txtmobile.Text = gridStudent.CurrentRow.Cells["MobileNo"].Value.ToString();
            txtage.Text = gridStudent.CurrentRow.Cells["Age"].Value.ToString();
            txtrn.Text = gridStudent.CurrentRow.Cells["RollNo"].Value.ToString();
            cmbClass.Text = gridStudent.CurrentRow.Cells["Class"].Value.ToString();
            cmbBranch.Text = gridStudent.CurrentRow.Cells["Branch"].Value.ToString();
            btnDel.Enabled = true;
            btnAddNew.Enabled = false;
            btnUp.Enabled = true;
            txtrn.Enabled = true;
            txtname.Enabled = true;
            txtmobile.Enabled = true;
            cmbBranch.Enabled = true;
            cmbClass.Enabled = true;
            txtadd.Enabled = true;
            txtage.Enabled = true;

        }

        private void BtnUp_Click(object sender, EventArgs e)
        {
            OleDbConnection cn = new OleDbConnection();
            cn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Backup\Documents\studentD.accdb";
            cn.Open();
            DialogResult drs = MessageBox.Show("Are you sure, Do you wants to add this record..?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (drs == DialogResult.No)
                return;
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "DELETE FROM Student WHERE FullName ='" + txtname.Text+"';";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Insert into Student(FullName, Age, Address, MobileNo, RollNo,Class, Branch) values('" + txtname.Text + "','" + txtage.Text + "', '" + txtadd.Text + "','" + txtmobile.Text + "','" + txtrn.Text + "','" + cmbClass.Text + "','" + cmbBranch.Text + "')";
            cmd.ExecuteNonQuery();
            
            MessageBox.Show("Student Updated Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            cn.Close();
            allClear();
            unlockAll(false);
            actionButtonNormalStage();
            fillgrid();
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Lnkbrowse_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmProfilePic = new frmProfilePic();
            frmProfilePic.Show();
            profileimage = frmProfilePic.getPictureRecord;
        }
    }
}
