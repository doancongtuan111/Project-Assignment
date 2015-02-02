using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;


namespace App_Cloud_Tuandcpk00260_
{
    public partial class frm_config : Form
    {
        public frm_config()
        {
            InitializeComponent();

        }


        private void frm_config_Load(object sender, EventArgs e)
        {
            XmlDocument MyDoc = new XmlDocument();
            MyDoc.Load("config.xml");
            XmlNodeList dataNode = MyDoc.SelectNodes("config");
            foreach (XmlNode node in dataNode)
            {
                XmlNode address = node.SelectSingleNode("address");
                XmlNode dataname = node.SelectSingleNode("dataname");
                XmlNode username = node.SelectSingleNode("username");
                XmlNode password = node.SelectSingleNode("password");
                lblIP.Text = address.InnerText;
                lblname.Text = dataname.InnerText;
                lbluser.Text = username.InnerText;
                lblpass.Text = password.InnerText;
            }

        }

            private void button1_Click(object sender, EventArgs e)
            {

            }

            private void button2_Click(object sender, EventArgs e)
            {
                this.Close();
            }



    }

}
