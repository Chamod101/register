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

namespace register2
{
    public partial class Update : MetroFramework.Forms.MetroForm
    {
        public Update()
        {
            InitializeComponent();
        }

        SqlConnection con;
        SqlCommand cmd;

        private void Update_Load(object sender, EventArgs e)
        {
            con = new SqlConnection("Data Source=DESKTOP-INVLEDJ;Initial Catalog=school10;Integrated Security=True");
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("Update register set student_name= '"+txt_name.Text+ "',S_address= '"+txt_address.Text+ "',dob= '"+picker_dob.Value+ "',age= '"+txt_age.Text+ "',tp='"+txt_tp.Text+ "' where studentid= '" + txt_id.Text + "' ",con);
            int i = cmd.ExecuteNonQuery();
            if(i == 1)
                MetroFramework.MetroMessageBox.Show(this, "Data Update Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MetroFramework.MetroMessageBox.Show(this, "Data Cannot Update", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            con.Close();
            cmd.Dispose();
        }

        private void txt_delete_Click(object sender, EventArgs e)
        {
            this.Hide();
            Delete obj = new Delete();
            obj.Show();
        }
    }
}
