using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Net;


namespace IsThisWebsiteOnline
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ipaddress = textBox1.Text;

            IPAddress[] addresslist = Dns.GetHostAddresses(ipaddress);

            foreach (IPAddress theaddress in addresslist)
            {

                string lel = theaddress.ToString();

                Ping pingSender = new Ping();
                IPAddress address = IPAddress.Parse(lel);
                PingReply reply = pingSender.Send(address);

                if (reply.Status == IPStatus.Success)
                {
                    label1.Text = "WebAddress: " + ipaddress;
                    label2.Text = "Address: " + reply.Address.ToString();
                    label3.Text = "Status: " + reply.Status.ToString();
                }
                else
                {
                    MessageBox.Show("No connection");
                }
            }
        }

    }
}
