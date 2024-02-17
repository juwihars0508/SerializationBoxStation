using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using PhaprosSerializationBoxStation.Includes;

namespace PhaprosSerializationBoxStation
{
    public partial class reprint : Form
    {
        public reprint()
        {
            InitializeComponent();
        }

        SQLConfig config = new SQLConfig();

        public string vDataSerial;
        public string vData1;
        public string vData2;
        public string vData3;
        public string vData4;
        public string VIP_printer;
        public string VPORT_Printer;
        public string vDataBatch;
        public string vDataWO;
        public string vDataProductName;
        public string vDataGTINDecs;
        public string vDataGTINFull;


        public string ChrSTX = System.Char.ConvertFromUtf32(02);
        public string ChrETX = System.Char.ConvertFromUtf32(03);

        public void Read_IP_String()
        {
            StreamReader file = new StreamReader(varUtility.fileIpAddress);
            string line = file.ReadLine();

            VIP_printer = line;
            file.Close();
        }

        //Read data Port Printer
        public void Read_Port_String()
        {
            StreamReader file = new StreamReader(varUtility.filePort);
            string line = file.ReadLine();

            VPORT_Printer = line;
            file.Close();
        }

       

        public void LoadIP()
        {
            Read_IP_String();
            Read_Port_String();
        }
        private void reprint_Load(object sender, EventArgs e)
        {
            CB_User.Items.Clear();

            //init Data
            List<varDataState> list = new List<varDataState>();
            list.Add(new varDataState() { ID = "01", Name = "Administrator" });
            list.Add(new varDataState() { ID = "02", Name = "Supervisor" });
            //list.Add(new varDataState() { ID = "03", Name = "Operator 1" });
            //list.Add(new varDataState() { ID = "04", Name = "Operator 2" });

            //set display member and value member for combobox
            CB_User.DataSource = list;
            CB_User.ValueMember = "ID";
            CB_User.DisplayMember = "Name";
        }
        
        private void load_CB()
        {
            config.Init_Con();
            config.con.Open();
            string sql = "select wo_no from tblhistory_print where status=1 group by wo_no desc ";
            MySqlCommand cmd = new MySqlCommand(sql, config.con);
            MySqlDataReader dr;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                CbNo_WO.Items.Add(dr[0].ToString());


            }

            dr.Close();
            config.con.Close();
            CbNo_WO.SelectedIndex = 0;
            config.con.Close();
        }

        private void loadShift()
        {
            config.Init_Con();
            config.con.Open();
            string sql = "select noBatch from tblhistory_print where wo_no='" + CbNo_WO.Text + "' and status=1";
            MySqlCommand cmd = new MySqlCommand(sql, config.con);
            MySqlDataReader dr;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                tbNo_Batch.Text = dr[0].ToString();


            }
            dr.Close();
            config.con.Close();
        }

        private void btnIN_Click(object sender, EventArgs e)
        {
            if (CB_User.Text == "Administrator" && tbPass.Text == "admin123")
            {
                varGlobal.Username = CB_User.Text;
                panel1.Visible = true;
                load_CB();

            }
            else if (CB_User.Text == "Supervisor" && tbPass.Text == "spv123")
            {
                varGlobal.Username = CB_User.Text;
                panel1.Visible = true;
                load_CB();
            }
            else
            {
                MessageBox.Show("Username or Password NotFound", "Perhatian..", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormMain formMain = new FormMain();
            formMain.Show();
            this.Hide();
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            config.Init_Con();
            string sql = "select wo_no as 'WO NO', product  as 'Product Name', noBatch as 'NO Batch', data_print as 'Data Serial' from tblhistory_print where wo_no='"+ CbNo_WO.Text +"' and noBatch='"+ tbNo_Batch.Text + "' and data_print='" + tbNo_SN.Text + "'";
            config.Load_DTG(sql, dgvReprint);
        }

        private void CbNo_WO_SelectedValueChanged(object sender, EventArgs e)
        {
            loadShift();
        }

        private void btn_Print_Click(object sender, EventArgs e)
        {
            KirimkePrinterTIJ();
        }

        private void getDataGTINdesc()
        {
            config.Init_Con();
            config.con.Open();
            string sql = "select GTIN_Desc from tblworkorder where wo_no='" + vDataWO + "' and noBatch='" + vDataBatch + "'";
            MySqlCommand cmd = new MySqlCommand(sql, config.con);
            MySqlDataReader dr;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                vDataGTINDecs = dr[0].ToString();


            }
            dr.Close();
            config.con.Close();
        }

        private void split_Data_Serial()
        {
            string authors = vDataGTINFull;
            string[] authorsList = authors.Split(new char[] { ';' });
            lb_data1.Text = authorsList[0];
            lb_data2.Text = authorsList[1];
            lb_data3.Text = authorsList[2];
            lb_data4.Text = authorsList[3];

        }

        private void dgvReprint_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            vDataWO = dgvReprint.SelectedRows[0].Cells[0].Value.ToString();
            vDataProductName = dgvReprint.SelectedRows[0].Cells[1].Value.ToString();
            vDataBatch = dgvReprint.SelectedRows[0].Cells[2].Value.ToString();
            vDataSerial = dgvReprint.SelectedRows[0].Cells[3].Value.ToString();
            string vDataSerial_temp = dgvReprint.SelectedRows[0].Cells[3].Value.ToString();
            int length = 13;
            int startingIndex = vDataSerial_temp.Length - length;
            getDataGTINdesc();
            string vDataSerialPartial = vDataSerial_temp.Substring(startingIndex);

            vDataGTINFull = vDataGTINDecs + vDataSerialPartial;

            split_Data_Serial();
        }

        public void SaveHistory_Reprint()
        {
            
            config.Init_Con();

            config.con.Open();

            string sql = "INSERT INTO  `tblhistory_reprint` (`woNo`, `productName`, `noBatch`, `dataSerial`,`create_Date`) values('" + vDataWO + "','" + vDataProductName + "','" + vDataBatch + "','" + vDataSerial + "','" + DateTime.Now + "') ";
            //config.Execute_CUD(sql, "Unable to saved", "Data has been saved in the database.");
            MySqlCommand cmd = new MySqlCommand(sql, config.con);
            cmd.ExecuteNonQuery();

            //MessageBox.Show("Save ");
            config.con.Close();
            //LoadDGV();
        }



        public void KirimkePrinterTIJ()
        {
            //lb_data4.Text = "(21)";
            //generate_Code();

            //vData_tempUnicode = "(21)" + Vdata_unicode;



            string dataUnicode;
            string dataResult;


            //dataUnicode = lb_data4.Text + randomPassword;

            dataResult = ChrSTX + "DATA;" + lb_data1.Text + ";" + lb_data2.Text + ";" + lb_data3.Text + ";" + lb_data4.Text + ";" + vDataSerial + ChrETX;
            //dataResult = "";
            //VdataPrint = vData_GTINCodeMatrixFull;




            LoadIP();

            IPAddress ip = IPAddress.Parse(VIP_printer);
            IPEndPoint remoteEP = new IPEndPoint(ip, Convert.ToInt32(VPORT_Printer));

            Socket clientPrinter = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            clientPrinter.Connect(remoteEP);



            byte[] byteData = System.Text.Encoding.ASCII.GetBytes(dataResult);
            clientPrinter.Send(byteData);


            //byte[] inStream = new byte[4096];
            //int bytesRead = clientPrinter.Receive(inStream);



            clientPrinter.Shutdown(SocketShutdown.Both);
            clientPrinter.Close();
            SaveHistory_Reprint();
            

        }
    }
}
