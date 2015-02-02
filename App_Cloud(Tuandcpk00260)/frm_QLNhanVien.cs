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
    public partial class frm_QLNhanVien : Form
    {
        public frm_QLNhanVien()
        {
            InitializeComponent();
        }

        //Khởi tạo webservices  ############################################################
        localhost.bus_data webservices = new localhost.bus_data();

        //Form load   ############################################################
        private void frm_QLNhanVien_Load(object sender, EventArgs e)
        {
            laydulieu();
            loaddata();

        }

        //Lấy dữ liệu từ services   ############################################################
        DataSet ds = new DataSet();
        private void laydulieu()
        {
            ds = webservices.getdata("Select * from tbl_NhanVien");
        }

        //Đổ dữ liệu lên listview   ############################################################
        private void loaddata()
        {
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            int i =0;
            foreach (DataRow rows in dt.Rows)
            {
                lsvNV.Items.Add(rows["MANV"].ToString());
                lsvNV.Items[i].SubItems.Add(rows["TENNV"].ToString());
                if (rows["GIOITINH"].ToString() == "True")
                {
                    lsvNV.Items[i].SubItems.Add("Nam");
                }
                else if (rows["GIOITINH"].ToString() == "False")
                {
                    lsvNV.Items[i].SubItems.Add("Nữ");
                }
                lsvNV.Items[i].SubItems.Add(rows["NAMSINH"].ToString());
                lsvNV.Items[i].SubItems.Add(rows["EMAIL"].ToString());
                lsvNV.Items[i].SubItems.Add(rows["PASSWORDS"].ToString());
                if (rows["QH"].ToString() == "BH")
                {
                    lsvNV.Items[i].SubItems.Add("Bán hàng");
                }
                else if (rows["QH"].ToString() == "HD")
                {
                    lsvNV.Items[i].SubItems.Add("Hóa đơn");
                }
                else if (rows["QH"].ToString() == "HH")
                {
                    lsvNV.Items[i].SubItems.Add("Hàng hóa");
                }
                else if (rows["QH"].ToString() == "KH")
                {
                    lsvNV.Items[i].SubItems.Add("Khách hàng");
                }
                else if (rows["QH"].ToString() == "NV")
                {
                    lsvNV.Items[i].SubItems.Add("Nhân viên");
                }
                else if (rows["QH"].ToString() == "admin")
                {
                    lsvNV.Items[i].SubItems.Add("Admin");
                }
                if (rows["HideNV"].ToString() == "True")
                {
                    lsvNV.Items[i].SubItems.Add("Đã xóa");
                }
                else if (rows["HideNV"].ToString() == "False")
                {
                    lsvNV.Items[i].SubItems.Add("Kích hoạt");
                }
                i++;
            }
        }
            string gt = "";
            string quyenhan = "";
            string changepass = "";
            private void bochuyendoi()
            {
                //Chuyển đổi giới tính
                if (cbxGT.Text == "Nam")
                {
                    gt = "True";
                }
                else if (cbxGT.Text == "Nữ")
                {
                    gt = "False";
                }
                //chuyển đổi quyền hạn
                if (cbxQuyenHan.Text == "Bán hàng")
                {
                    quyenhan = "BH";
                }
                else if (cbxQuyenHan.Text == "Hóa đơn")
                {
                    quyenhan = "HD";
                }
                else if (cbxQuyenHan.Text == "Hàng hóa")
                {
                    quyenhan = "HH";
                }
                else if (cbxQuyenHan.Text == "Khách hàng")
                {
                    quyenhan = "KH";
                }
                else if (cbxQuyenHan.Text == "Nhân viên")
                {
                    quyenhan = "NV";
                }
                else if (cbxQuyenHan.Text == "Admin")
                {
                    quyenhan = "admin";
                }
                //Chuyển đổi bộ thay đổi password.

                if (ckbDoiMK.Checked == true)
                {
                    changepass = "True";
                }
                else
                {
                    changepass = "False";
                }
            }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string tennv= txtTenNV.Text;
            string namsinh = datetime.Text;
            string email = txtEmail.Text;
            string matkhau = txtMatKhau.Text;
            bochuyendoi();
            
            string cmd = "insert into tbl_NhanVien (TENNV,GIOITINH,NAMSINH,EMAIL,PASSWORDS,QH,CHANGPAS) values (N'" + tennv + "','" + gt + "','" + namsinh + "','" + email + "','" + matkhau + "','" + quyenhan + "','" + changepass + "')";
            string trangthai = "";

            trangthai =webservices.excutedata(cmd);
            if (trangthai == "OK")
            {
                MessageBox.Show("Đã thêm nhân viên tên " + tennv + "", "Thêm thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                laydulieu();
                loaddata();
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm nhân viên " + tennv + "", "Thêm lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);            
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            string trangthai = "";
            string manv = txtMaNV.Text;
            trangthai = webservices.excutedata("update tbl_NhanVien set HideNV = 'True' where MANV = '"+manv+"'");
            if (trangthai == "OK")
            {
                MessageBox.Show("Đã xóa nhân viên thành công!", "xóa thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Có lỗi khi xóa nhân viên mã " + manv + "", "Xóa lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);                            
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string tennv = txtTenNV.Text;
            string namsinh = datetime.Text;
            string email = txtEmail.Text;
            string matkhau = txtMatKhau.Text;
            bochuyendoi();
            string trangthai = "";
            string manv = txtMaNV.Text;
            trangthai = webservices.excutedata("update tbl_NhanVien set TENNV= N'"+tennv+"',GIOITINH= '"+gt+"',NAMSINH= '"+namsinh+"',EMAIL= '"+email+"',PASSWORDS= '"+matkhau+"',QH= '"+quyenhan+"',CHANGPAS= '"+changepass+"' where MANV = '" + manv + "'");
            if (trangthai == "OK")
            {
                MessageBox.Show("Đã sửa nhân viên thành công!", "sửa thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa nhân viên mã " + manv + "", "Sửa bị lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lsvNV_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (ListViewItem item in lsvNV.SelectedItems)
            {
                txtMaNV.Text = item.SubItems[0].Text;
                txtTenNV.Text = item.SubItems[1].Text;
                cbxGT.Text = item.SubItems[2].Text;
                datetime.Text = item.SubItems[3].Text;
                txtEmail.Text = item.SubItems[4].Text;
                txtMatKhau.Text = item.SubItems[5].Text;
                cbxQuyenHan.Text =  item.SubItems[6].Text;
            }
        }
    }
}
