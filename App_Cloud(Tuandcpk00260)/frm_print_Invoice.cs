using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;




namespace App_Cloud_Tuandcpk00260_
{
    public partial class frm_print_Invoice : Form
    {
        public frm_print_Invoice()
        {
            InitializeComponent();
        }

        DataTable dt = frm_main.das;
        int total;
        private void frm_print_Invoice_Load(object sender, EventArgs e)
        {
            int i = 0;
            int tonggia;
            lsvcthd.Items.Clear();
            foreach (DataRow row in dt.Rows)
            {
                int stt = i + 1;
                lsvcthd.Items.Add(stt.ToString());
                lsvcthd.Items[i].SubItems.Add(row["TENSANPHAM"].ToString());
                lsvcthd.Items[i].SubItems.Add(row["DONGIAs"].ToString());
                lsvcthd.Items[i].SubItems.Add(row["SOLUONG"].ToString());
                tonggia = Convert.ToInt32(row["SOLUONG"]) * Convert.ToInt32(row["DONGIAs"]);
                total = total + tonggia;
                lsvcthd.Items[i].SubItems.Add(tonggia.ToString());
                i++;
            }

            label6.Text = frm_main.ngaylap;
            label7.Text = frm_main.tenkh;
            label8.Text = Convert.ToString(i);
            label9.Text = Convert.ToString(total);
            }
        private void button1_Click(object sender, EventArgs e)
        {


        }

    }
}
