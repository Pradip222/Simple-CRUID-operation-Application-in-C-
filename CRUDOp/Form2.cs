using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDOp
{
    public partial class frmProfilePic : Form
    {
        public frmProfilePic()
        {
            InitializeComponent();
        }
        String photopath = "",staus="",profileimage="";
        private void Btnbrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.Title = "Open Image";
            String target = "C:\\pradip23\\";
            if (!System.IO.Directory.Exists(target))
                System.IO.Directory.CreateDirectory(target);


            if (dlg.ShowDialog() == DialogResult.OK)
            {
                PictureBox PictureBox1 = new PictureBox();
                string get = dlg.SafeFileName;
                target += get;
                System.IO.File.Copy(dlg.FileName, target, true);

                
            }
            pictureBox1.ImageLocation = target;
            photopath = target;
            this.Hide();

            dlg.Dispose();
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }
        public string getPictureRecord
        {
            get
            {
                return photopath;
            }
        }
    }
}
