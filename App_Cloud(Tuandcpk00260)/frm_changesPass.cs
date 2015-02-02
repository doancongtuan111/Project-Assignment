using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_Cloud_Tuandcpk00260_
{
    public partial class frm_changesPass : Form
    {
        public frm_changesPass()
        {
            InitializeComponent();
        }

        string manv = frm_login.manv;
        private void frm_changesPass_Load(object sender, EventArgs e)
        {

        }

        localhost.bus_data webservices = new localhost.bus_data();
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtpass1.Text == txtpass2.Text)
            {
                if (txtpass1.Text.Length >= 6)
                {
                    string trangthai = "";
                    trangthai = webservices.excutedata("update tbl_NhanVien set PASSWORDS = '" + txtpass2.Text + "', CHANGPAS = 'False' where MANV = '" + manv + "'");
                    if (trangthai == "OK")
                    {
                        MessageBox.Show("OK");
                        frm_login frm = new frm_login();
                        frm.Activate();
                        frm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Lỗi");
                    }
                }
                else
                {
                    MessageBox.Show("lớn hơn 6 ký tự");
                }
            }
            else
            {
                MessageBox.Show("Hai mật khẩu không khớp.");
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
