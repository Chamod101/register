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
    public partial class register_form : MetroFramework.Forms.MetroForm
    {
        public register_form()
        {
            InitializeComponent();
        }

        SqlConnection con;
        SqlCommand cmd;
        private void register_form_Load(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection("Data Source=DESKTOP-INVLEDJ;Initial Catalog=school10;Integrated Security=True");
            }
            catch(Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message);
            }
            
        }

        private void picker_dob_ValueChanged(object sender, EventArgs e)
        {
            txt_age.Text = (DateTime.Now.Year - picker_dob.Value.Year).ToString();
        }

        private void btn_save_Click(object sender, EventArgs e)     
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("Insert into register values('" + txt_id.Text + "','" + txt_name.Text + "','" + txt_address.Text + "','" + picker_dob.Value + "','" + txt_age.Text + "','" + txt_tp.Text + "')", con);
                int i = cmd.ExecuteNonQuery();
                if (i == 1)
                    MetroFramework.MetroMessageBox.Show(this, "Data save Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MetroFramework.MetroMessageBox.Show(this, "Data Cannot Save", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
                cmd.Dispose();
            }
            catch(SqlException)
            {

            }
            
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            this.Hide();
            Update obj = new Update();
            obj.Show();
        }
    }
}
