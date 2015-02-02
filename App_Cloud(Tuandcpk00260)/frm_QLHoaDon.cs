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
    public partial class frm_QLHoaDon : Form
    {
        public frm_QLHoaDon()
        {
            InitializeComponent();
        }

        localhost.bus_data sevice_data = new localhost.bus_data();

        private void frm_QLHoaDon_Load(object sender, EventArgs e)
        {
            cbxNam.Text = DateTime.Now.Year.ToString();
            getData_HD();
            getData_CTHD();
        }

        private void getData_HD()
        {
            DataSet ds = new DataSet();
            ds = sevice_data.getdata("select MAHD,TENKH,TENNV,NGAYLAP,MOTA,HideHD from tbl_HoaDon left join tbl_NhanVien on tbl_HoaDon.MANV = tbl_NhanVien.MANV left join tbl_KhachHang on tbl_KhachHang.MAKH = tbl_HoaDon.MAKH");
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            int i =0;
            lsvHD.Items.Clear();
            foreach (DataRow rows in dt.Rows)
            {
                lsvHD.Items.Add(rows["MAHD"].ToString());
                lsvHD.Items[i].SubItems.Add(rows["TENKH"].ToString());
                lsvHD.Items[i].SubItems.Add(rows["TENNV"].ToString());
                lsvHD.Items[i].SubItems.Add(rows["NGAYLAP"].ToString());
                lsvHD.Items[i].SubItems.Add(rows["MOTA"].ToString());
                lsvHD.Items[i].SubItems.Add(rows["HideHD"].ToString());
                i++;
            }
            lblTongHD.Text = i.ToString();
        }

        int tong = 0;
        DataTable dtCTHD = new DataTable();

        private void getData_CTHD()
        {            
            DataSet ds = new DataSet();
            ds = sevice_data.getdata("select * from tbl_CTHD");
            dtCTHD = ds.Tables[0];            
        } 

        private void CTHD(string cmd)
        { 
        int i = 0;
            tong = 0;

            foreach (DataRow rows in dtCTHD.Rows)
            {
                if (rows["MAHDONs"].ToString() == cmd)
                {
                    lsvCTHD.Items.Add(rows["MACTHD"].ToString());
                    lsvCTHD.Items[i].SubItems.Add(rows["MAHDONs"].ToString());
                    lsvCTHD.Items[i].SubItems.Add(rows["MASANPHAMM"].ToString());
                    lsvCTHD.Items[i].SubItems.Add(rows["SOLUONG"].ToString());
                    lsvCTHD.Items[i].SubItems.Add(rows["DONGIAs"].ToString());
                    tong += int.Parse(rows["SOLUONG"].ToString()) * int.Parse(rows["DONGIAs"].ToString());
                    lsvCTHD.Items[i].SubItems.Add(rows["HideCTHD"].ToString());
                    i++;
                }
            }
            lblSoLuong.Text = i.ToString();
            lblTongTien.Text = tong.ToString() + " VNĐ";
        }
        

        private void lsvHD_SelectedIndexChanged(object sender, EventArgs e)
        {
            lsvCTHD.Items.Clear();
            string cmd = "";
            foreach (ListViewItem item in lsvHD.SelectedItems)
            {
                lblMaHD.Text = item.SubItems[0].Text;
                lblKH.Text = item.SubItems[1].Text;
                lblNV.Text = item.SubItems[2].Text;
                lblNgayLap.Text = item.SubItems[3].Text;
                lblMoTa.Text = item.SubItems[4].Text;
            }         
            cmd = lblMaHD.Text;
            CTHD(cmd);
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string tinhtrang = "";
            string tinhtrang2 = "";
            string mahd = lblMaHD.Text;
            tinhtrang = sevice_data.excutedata("update tbl_HoaDon set HideHD = 'true' where MAHD ='"+mahd+"'");
            tinhtrang2 = sevice_data.excutedata("update tbl_CTHD set HideCTHD = 'true' where MAHDONs ='" + mahd + "'");
            if (tinhtrang == "OK" && tinhtrang2 == "OK")
            {
                MessageBox.Show("Đã xóa hóa đơn thành công", "xóa thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                getData_HD();
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra !", "xóa lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }


    }

}
