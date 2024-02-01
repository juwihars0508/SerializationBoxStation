using System;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
//using Org.BouncyCastle.Utilities;
using PhaprosSerializationBoxStation.Includes;
using System.Runtime.InteropServices;

namespace PhaprosSerializationBoxStation
{
    public partial class FormDataPrint : Form
    {
        System.Net.Sockets.TcpClient clientSocket = new System.Net.Sockets.TcpClient();
        Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );

        private Size formOriginalSize;
        private Rectangle recBut1;
        private Rectangle recBut2;
        private Rectangle recBut3;
        private Rectangle recBut4;
        private Rectangle recCBbox1;
        private Rectangle recCBbox2;
        private Rectangle recCBbox3;
        private Rectangle recPicBox1;
        private Rectangle recPicBox2;
        private Rectangle recPicBox3;
        private Rectangle recPicBox4;
        private Rectangle recPrgBar1;
        private Rectangle recPrgBar2;
        private Rectangle recPnl1;
        private Rectangle recPnl2;
        private Rectangle recPnl3;
        private Rectangle recPnl4;
        private Rectangle recPnl5;
        private Rectangle recPnl6;
        private Rectangle recPnl7;
        private Rectangle recPnl8;
        private Rectangle recPnl9;
        private Rectangle recLblH1;
        private Rectangle recLblH2;
        private Rectangle recLblH3;
        private Rectangle recLblPrgBr1;
        private Rectangle recLblPrgBr2;
        private Rectangle recLblPrgBr3;
        private Rectangle recLblPrgBr4;
        private Rectangle recLblPrgBr5;
        private Rectangle recLbl1;
        private Rectangle recLbl2;
        private Rectangle recLbl3;
        private Rectangle recLbl4;
        private Rectangle recLbl5;
        private Rectangle recLbl6;
        private Rectangle recLbl7;
        private Rectangle recLbl8;
        private Rectangle recLbl9;
        private Rectangle recLbl10;
        private Rectangle recLbl11;
        private Rectangle recLbl12;
        private Rectangle recLbl13;
        private Rectangle recLbl14;
        private Rectangle recLbl15;
        private Rectangle recLbl16;
        private Rectangle recLbl17;
        private Rectangle recLbl18;
        private Rectangle recLbl19;
        private Rectangle recLbl20;
        private Rectangle recLbl21;


        public FormDataPrint()
        {
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            //this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            this.Resize += Form3_Resize;
            formOriginalSize = this.Size;
            recBut1 = new Rectangle(btnStart.Location, btnStart.Size);
            recBut2 = new Rectangle(btnStop.Location, btnStop.Size);
            recBut3 = new Rectangle(btnExit.Location, btnExit.Size);
            recBut4 = new Rectangle(btnMin.Location, btnMin.Size);
            recCBbox1 = new Rectangle(cb_wo.Location, cb_wo.Size);
            recCBbox2 = new Rectangle(cbRecipe.Location, cbRecipe.Size);
            recCBbox3 = new Rectangle(cb_Batch.Location, cb_Batch.Size);
            recPicBox1 = new Rectangle(pictureBox1.Location, pictureBox1.Size);
            recPicBox2 = new Rectangle(PB_Load.Location, PB_Load.Size);
            recPicBox3 = new Rectangle(PB_NG.Location, PB_NG.Size);
            recPicBox4 = new Rectangle(PB_OK.Location, PB_OK.Size);
            recPrgBar1 = new Rectangle(progressBar1.Location, progressBar1.Size);
            recPrgBar2 = new Rectangle(progressBar2.Location, progressBar2.Size);
            recPnl1 = new Rectangle(panel1.Location, panel1.Size);
            recPnl2 = new Rectangle(panel2.Location, panel2.Size);
            recPnl3 = new Rectangle(panel3.Location, panel3.Size);
            recPnl4 = new Rectangle(panel4.Location, panel4.Size);
            recPnl5 = new Rectangle(panel5.Location, panel5.Size);
            recPnl6 = new Rectangle(panel6.Location, panel6.Size);
            recPnl7 = new Rectangle(panel7.Location, panel7.Size);
            recPnl8 = new Rectangle(panel8.Location, panel8.Size);
            recPnl9 = new Rectangle(panel9.Location, panel9.Size);
            recLblH1 = new Rectangle(label1.Location, label1.Size);
            recLblH2 = new Rectangle(lblUser.Location, lblUser.Size);
            recLblH3 = new Rectangle(lblTime.Location, lblTime.Size);
            recLblPrgBr1 = new Rectangle(label14.Location, label14.Size);
            recLblPrgBr2 = new Rectangle(lb_actualLotSize.Location, lb_actualLotSize.Size);
            recLblPrgBr3 = new Rectangle(lblPersen.Location, lblPersen.Size);
            recLblPrgBr4 = new Rectangle(label15.Location, label15.Size);
            recLblPrgBr5 = new Rectangle(lb_targetLotsize.Location, lb_targetLotsize.Size);
            recLbl1 = new Rectangle(label3.Location, label3.Size);
            recLbl2 = new Rectangle(label8.Location, label8.Size);
            recLbl3 = new Rectangle(lb_woNo.Location, lb_woNo.Size);
            recLbl4 = new Rectangle(label11.Location, label11.Size);
            recLbl5 = new Rectangle(lb_lotNo.Location, lb_lotNo.Size);
            recLbl6 = new Rectangle(label12.Location, label12.Size);
            recLbl7 = new Rectangle(lb_productName.Location, lb_productName.Size);
            recLbl8 = new Rectangle(label2.Location, label2.Size);
            recLbl9 = new Rectangle(lb_WO_Progress.Location, lb_WO_Progress.Size);
            recLbl10 = new Rectangle(lb_WOP_Status.Location, lb_WOP_Status.Size);
            recLbl11 = new Rectangle(label19.Location, label19.Size);
            recLbl12 = new Rectangle(lb_actualReadCode.Location, lb_actualReadCode.Size);
            recLbl13 = new Rectangle(lbWaiting.Location, lbWaiting.Size);
            recLbl14 = new Rectangle(label16.Location, label16.Size);
            recLbl15 = new Rectangle(lb_Scanned.Location, lb_Scanned.Size);
            recLbl16 = new Rectangle(label17.Location, label17.Size);
            recLbl17 = new Rectangle(lb_fail.Location, lb_fail.Size);
            recLbl18 = new Rectangle(lb_data1.Location, lb_data1.Size);
            recLbl19 = new Rectangle(lb_data2.Location, lb_data2.Size);
            recLbl20 = new Rectangle(lb_data3.Location, lb_data3.Size);
            recLbl21 = new Rectangle(lb_data4.Location, lb_data4.Size);





        }

        SQLConfig config = new SQLConfig();
        usableFunction funct = new usableFunction();

        string readData = null;

        public string ChrSTX = System.Char.ConvertFromUtf32(02);
        public string ChrETX = System.Char.ConvertFromUtf32(03);

        public int VPORTTIJ;
        public string VIPTIJ1;

        //Variable IP and Port Printer
        public string VIP_printer;
        public string VPORT_Printer;

        //Variable IP and Port Camera
        public string VIP_camera;
        public string VPORT_camera;
        public string VDataGtin;
        public string Vstatus;
        public int count;
        public int countNG;
        public int TotalCount;
        public int TotalCountPrint;
        public string VDataTarget;
        public string VdataPrint;
        public int targetData;
        public string Vdata_ProductCode;
        public string Vdata_Batch;
        public string Vdata_GTINCodeMatrix;
        public string Vdata_GTINCodeDesc;
        public int Vdata_qtybatch;
        public string Vdata_Check;
        public string Vcamera_data1;
        public string Vcamera_data2;
        public string Vcamera_data3;
        public string Vcamera_data4;
        public string Vcamera_data5;
        public string Vcamera_data6;
        public string Vcamera_data7;
        public string Vcamera_data8;
        public string Vdata_Camera;

        public string vData_GTINCodeMatrixFull;
        public string vData_GTINCodeDescFull;
        public string Vdata_unicode;
        public string vData_tempUnicode;
        public string Vdata_Merged;

        //public string dataResult;


        //variable COM Port Setting
        public string VCOMPort;
        public string VBaudrate;
        public string VDataBits;
        public string VStopBits;
        public string VParity;

        //variable Data PLC
        public string TX;
        public string FCS;
        public string RXD;

        public string txt_kirim;
        public string Txt_terima;



        public void Read_IPCamera_String()
        {
            StreamReader file = new StreamReader(varUtility.fileIpAddressCamera);
            string line = file.ReadLine();

            VIP_camera = line;
            file.Close();
        }

        //Read data Port Camera
        public void Read_PortCamera_String()
        {
            StreamReader file = new StreamReader(varUtility.filePortCamera);
            string line = file.ReadLine();

            VPORT_camera = line;
            file.Close();
        }

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

        public void LoadIP_Camera()
        {
            Read_IPCamera_String();
            Read_PortCamera_String();
        }

        public void LoadIP()
        {
            Read_IP_String();
            Read_Port_String();
        }

        private void connect()
        {
            try
            {
                //msg1("Client Started");
                //Read_IP_String();
                //Read_Port_String();
                //clientSocket.Connect(VIPAddress_Camera, Convert.ToInt32(VPort_Camera));
                //printerSocket.Connect(tbIPDomino.Text,Convert.ToInt32(tbPortDomino.Text));  
                //lblSTATUS.Text = "Server Connected ...";

                Read_IPCamera_String();
                Read_PortCamera_String();
                IPAddress ip = IPAddress.Parse(VIP_camera);
                IPEndPoint remoteEP = new IPEndPoint(ip, Convert.ToInt32(VPORT_camera));



                client.Connect(remoteEP);

                Tcplisten();
                //msg1("Received");
            }
            catch (SocketException e)
            {
                MessageBox.Show("SocketException: {0}" + e);
            }

        }

        private void Tcplisten()
        {
            try
            {
                //msg1("Waiting for Data Received... ");
                Thread ctThread = new Thread(getMessage);
                ctThread.Start();

                //tbTimbang.Text = tbFixData.Text;
            }
            catch (SocketException e)
            {
                MessageBox.Show("SocketException: {0}" + e);
            }
        }

        private void getMessage()
        {
            try
            {
                while (true)
                {

                    //NetworkStream stream = clientSocket.GetStream();

                    //byte[] inStream = new byte[4096];
                    //int bytesRead = stream.Read(inStream, 0, inStream.Length);


                    //string returndata = Encoding.ASCII.GetString(inStream, 0, bytesRead);
                    //readData = "" + returndata;
                    //msg();

                    //LoadIP();




                    byte[] inStream = new byte[4096];
                    int bytesRead = client.Receive(inStream);

                    //string returndata = BitConverter.ToString(inStream, 0, bytesRead).Replace("-", "") ?? "";
                    string returndata = Encoding.ASCII.GetString(inStream, 0, bytesRead);
                    readData = "" + returndata;
                    msg2();
                    //msg();
                    //load_kode_model();





                }
            }
            catch (SocketException)
            {
                //MessageBox.Show("SocketException: {0}" + e);
            }


        }

        private void msg2()
        {
            if (this.InvokeRequired)
                this.Invoke(new MethodInvoker(msg2));
            else
                //textBox1.Text = textBox2.Text + Environment.NewLine + " >> " + readData;

                //tbHASIL.Text = tbHASIL.Text + Environment.NewLine + " >> " + readData;
                lb_dataReceived.Text = readData;
        }
        public async Task<string> GeneratePatientNumberAsync()
        {
            var random = new Random();
            var chars = DateTime.Now.Ticks + "123456789ABCD" + DateTime.Now.Ticks;
            return new string(Enumerable.Repeat(chars, 13)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void generate_Code()
        {
            
            Task<string> Result = GeneratePatientNumberAsync();
            Vdata_unicode = Result.Result;

            vData_GTINCodeMatrixFull= Vdata_GTINCodeMatrix + Vdata_unicode;
            vData_GTINCodeDescFull = Vdata_GTINCodeDesc + Vdata_unicode;

 
        }

        private void merged_Data()
        {
            Vdata_Merged = lb_data1.Text + ";" + lb_data2.Text + ";" + lb_data3.Text + ";" + vData_tempUnicode;
            //lb_actualReadCode.Text = lb_data1.Text + lb_data2.Text + lb_data3.Text + lb_data4.Text;
        }

        private void split_Data_display()
        {
            string authors = Vdata_Merged;
            string[] authorsList = authors.Split(new char[] { ';' });
            lb_data1.Text = authorsList[0];
            lb_data2.Text = authorsList[1];
            lb_data3.Text = authorsList[2];
            lb_data4.Text = authorsList[3];

        }
        public void KirimkePrinterTIJ()
        {
            //lb_data4.Text = "(21)";
            generate_Code();
            
            vData_tempUnicode = "(21)"+ Vdata_unicode;
            

            
            string dataUnicode;
            string dataResult;

            
            //dataUnicode = lb_data4.Text + randomPassword;

            dataResult = ChrSTX + "DATA;" + lb_data1.Text + ";" + lb_data2.Text + ";" + lb_data3.Text + ";" + vData_tempUnicode + ";" + vData_GTINCodeMatrixFull + ChrETX;

            VdataPrint = vData_GTINCodeMatrixFull;

            

            
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

            merged_Data();
            split_Data_display();
            SaveHistory_print();
            GetDataCamera();

        }

        public void GetStatusACKMarkem()
        {
            LoadIP_Camera();
            IPAddress ip = IPAddress.Parse(VIP_camera);
            IPEndPoint remoteEP = new IPEndPoint(ip, Convert.ToInt32(VPORT_camera));

            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            client.Connect(remoteEP);


            //byte[] cccc = HexStringToByteArray("4100010141");
            //byte[] outStream = (cccc);
            //byte[] byteData = System.Text.Encoding.ASCII.GetBytes(data);
            //client.Send(cccc);
            //readData = "";
            //string returndata = "";

            byte[] inStream = new byte[4096];
            int bytesRead = client.Receive(inStream);


            //string returndata = BitConverter.ToString(inStream, 0, bytesRead).Replace("-", "") ?? "";
            string returndata = Encoding.ASCII.GetString(inStream, 0, bytesRead);
            readData = "" + returndata;
            msgMarkem();
            client.Shutdown(SocketShutdown.Both);
            client.Close();
        }

        private void msgMarkem()
        {
            
            if (this.InvokeRequired)
                this.Invoke(new MethodInvoker(msgMarkem));
            else
                //textBox3.Text = Environment.NewLine + " >> " + readData;
            lb_dataReceived.Text = readData;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = targetData;

            TotalCount++;

            int percentage = (100 / targetData) * TotalCount;

            lblPersen.Text = percentage.ToString() + " %";
            progressBar1.Value = TotalCount;
            lb_Scanned.Text = TotalCount.ToString();
            lb_actualLotSize.Text = TotalCount.ToString();
            if (lb_dataReceived.Text == "NG")
            {
                Vstatus = "NG";

                countNG++;
                lb_fail.Text = countNG.ToString();
                lb_actualReadCode.Text = "NG";

                //lb_Scanned.Text = count.ToString();
                //Thread.Sleep(500);
                //await Task.Delay(100);

            }
            else
            {
                Vstatus = "OK";
                count++;
                label4.Text = count.ToString();
                lb_actualReadCode.Text = readData;
                Vdata_Camera = readData;
                lb_data4.Text = vData_tempUnicode;
                //split_data_camera();
                
                //merged_Data();
                //split_Data_display();
            }

            //split_Data_display();
            SaveHistory_camera();
            Update_data_status();
            //timer2.Stop();
            //timer3.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void GetDataCamera()
        {
            GetStatusACKMarkem();
            //KirimkePrinterTIJ1();
            if (VDataTarget == lb_actualLotSize.Text)
            {
                //timer2.Stop();
                //timer3.Stop();
                //lb_WOP_Status.Text = "DONE";
                PB_OK.Visible = true;
                PB_Load.Visible = false;
                //Completed_Lamp();
                //btnStart.Enabled = true;
                btnStart.BackColor = Color.Gray;
                //btnStop.Enabled = false;
                btnStop.BackColor = Color.Red;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            //this.progressBar1.Increment(1);
            
            GetStatusACKMarkem();
            //KirimkePrinterTIJ1();
            if (VDataTarget == lb_actualLotSize.Text)
            {
                timer2.Stop();
                //timer3.Stop();
                //lb_WOP_Status.Text = "DONE";
                PB_OK.Visible = true;
                PB_Load.Visible = false;
                Completed_Lamp();
                //btnStart.Enabled = true;
                btnStart.BackColor = Color.Gray;
                //btnStop.Enabled = false;
                btnStop.BackColor = Color.Red;
            }

        }

        public void KirimkePrinterTIJ1()
        {
            string dataResult;

            var generator = new RandomGenerator();

            LoadIP();

            varGlobal.alamatIPServer = VIP_printer;
            varGlobal.port = Int16.Parse(Convert.ToString(VPORT_Printer));

            

            dataResult = "";

            var randomPassword = generator.RandomPassword();


            dataResult = ChrSTX + "DATA;" + lb_data1.Text + ";" + lb_data2.Text + ";" + lb_data3.Text + ";" + lb_data4.Text + randomPassword  + ChrETX;
            SocketTCP.StartClientTIJ(dataResult);
            //GetStatusACKMarkem();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Load_Lot_size();
            //connect();
            lbWaiting.Text = "Waiting...";
            count = 0;
            countNG = 0;
            TotalCount = Convert.ToInt32(lb_actualLotSize.Text);
            TotalCountPrint = Convert.ToInt32(lb_actualLotSize.Text);
            cb_wo.Enabled = false;
            cb_Batch.Enabled = false;
            cbRecipe.Enabled = false;
            btnStart.BackColor = Color.Green;
            btnStop.BackColor = Color.Gray;
            PB_NG.Visible = false;
            PB_OK.Visible = false;
            PB_Load.Visible = true;
            //btnStop.Enabled = true;
            targetData = 0;
            //timer2.Start();
            timer3.Start();
            targetData = Convert.ToInt32(lb_targetLotsize.Text);
            lb_WO_Progress.Text = cb_wo.Text;
            lbWO_Status.Text = "";
            //progressBar1.Minimum = 0;
            //progressBar1.Maximum = targetData;

            //int percent = (int)(((double)(progressBar1.Value - progressBar1.Minimum) / (double)(progressBar1.Maximum - progressBar1.Minimum)) * 100);
            //using (Graphics gr = progressBar1.CreateGraphics())
            //{
            //    gr.DrawString(percent.ToString() + "%",
            //        SystemFonts.DefaultFont,
            //        Brushes.Black,
            //        new PointF(progressBar1.Width / 2 - (gr.MeasureString(percent.ToString() + "%",
            //            SystemFonts.DefaultFont).Width / 2.0F),
            //        progressBar1.Height / 2 - (gr.MeasureString(percent.ToString() + "%",
            //            SystemFonts.DefaultFont).Height / 2.0F)));
            //}


            //for (int i = 0; i <= targetData; i++)
            //{
                //progressBar1.Increment(1);
                //KirimkePrinterTIJ1();
                //GetStatusACKMarkem();
                //Thread.Sleep(200);
                //lb_actualLotSize.Text = count.ToString();
                //lblPersen.Text = "Loading..." + i.ToString() + "%";

            //}
        }

        private void tampilDataCombo()
        {
            config.Init_Con();
            config.con.Open();
            string sql = "select DISTINCT wo_no from tblworkorder order by id ASC";
            MySqlCommand cmd = new MySqlCommand(sql, config.con);
            MySqlDataReader dr;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                
                cb_wo.Items.Add(dr[0].ToString());
                
                
            }

            dr.Close();
            config.con.Close();
            

            //cb_wo.SelectedItem = dr[1].ToString();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            panel1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel1.Width, panel1.Height, 20, 20));
            panel2.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel2.Width, panel2.Height, 20, 20));
            panel3.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel3.Width, panel3.Height, 20, 20));
            panel4.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel4.Width, panel4.Height, 20, 20));
            panel5.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel5.Width, panel5.Height, 20, 20));
            panel6.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel6.Width, panel6.Height, 20, 20));
            panel7.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel7.Width, panel7.Height, 20, 20));
            panel8.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel8.Width, panel8.Height, 20, 20));
            panel9.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel9.Width, panel9.Height, 20, 20));
            panel10.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel10.Width, panel10.Height, 20, 20));
            btnStart.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnStart.Width, btnStart.Height, 20, 20));
            btnStop.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnStop.Width, btnStop.Height, 20, 20));
            btnExit.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnExit.Width, btnExit.Height, 20, 20));
            tampilDataCombo();

            //cb_wo.SelectedIndex = 0;
            //cb_Batch.SelectedIndex = 0;
            //cbProduct.SelectedIndex = 0;

            lblUser.Text = varGlobal.Username;
            //btnStop.Enabled = false;
            //connect();
        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void cb_wo_SelectedValueChanged(object sender, EventArgs e)
        {
            cbRecipe.Items.Clear();
            config.Init_Con();
            config.con.Open();
            string sql = "select DISTINCT kodeRecipe from tblworkorder where wo_no='" + cb_wo.Text + "'";
            MySqlCommand cmd = new MySqlCommand(sql, config.con);
            MySqlDataReader dr;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                cbRecipe.Items.Add(dr[0].ToString());


            }

            dr.Close();
            config.con.Close();
            cbRecipe.SelectedIndex = 0;
            lb_WO_Progress.Text =  cb_wo.Text;

        }
        private void split_data_camera()
        {
            //string autors = lb_actualReadCode.Text;
            //string[] authorsList = autors.Split(new char[] { '(', ')',';' });
            //Vcamera_data1 = authorsList[1];
            //Vcamera_data2 = authorsList[2];
            //Vcamera_data3 = authorsList[3];
            //Vcamera_data4 = authorsList[4];
            //Vcamera_data5 = authorsList[5];
            //Vcamera_data6 = authorsList[6];
            //Vcamera_data7 = authorsList[7];
            //Vcamera_data8 = authorsList[8];
            
        }
        private void split_Data()
        {
            string authors = Vdata_GTINCodeDesc;
            string[] authorsList = authors.Split(new char[] { ';' });
            lb_data1.Text = authorsList[0];
            lb_data2.Text = authorsList[1];
            lb_data3.Text = authorsList[2];
            lb_data4.Text = authorsList[3];

        }

        
        private void btnStop_Click(object sender, EventArgs e)
        {
            TotalCountPrint = 0;
            cb_wo.Enabled = true;
            timer2.Stop();
            timer3.Stop();
            //btnStart.Enabled = true;
            //btnStop.Enabled = false;
            

            if (lb_actualLotSize.Text != lb_targetLotsize.Text)
            {
                btnStart.BackColor = Color.Gray;
                btnStop.BackColor = Color.Red;
                PB_NG.Visible = true;
                PB_OK.Visible = false;
                PB_Load.Visible = false;
            }

            //client.Shutdown(SocketShutdown.Both);
            //client.Close();
        }

        public class RandomGenerator
        {
            // Instantiate random number generator.  
            // It is better to keep a single Random instance 
            // and keep using Next on the same instance.  
            private readonly Random _random = new Random();

            // Generates a random number within a range.      
            public int RandomNumber(int min, int max)
            {
                return _random.Next(min, max);
            }

            // Generates a random string with a given size.    
            public string RandomString(int size, bool lowerCase = false)
            {
                var builder = new StringBuilder(size);

                // Unicode/ASCII Letters are divided into two blocks
                // (Letters 65–90 / 97–122):   
                // The first group containing the uppercase letters and
                // the second group containing the lowercase.  

                // char is a single Unicode character  
                char offset = lowerCase ? 'a' : 'A';
                const int lettersOffset = 26; // A...Z or a..z: length = 26  

                for (var i = 0; i < size; i++)
                {
                    var @char = (char)_random.Next(offset, offset + lettersOffset);
                    builder.Append(@char);
                }

                return lowerCase ? builder.ToString().ToLower() : builder.ToString();
            }

            // Generates a random password.  
            // 4-LowerCase + 4-Digits + 2-UpperCase  
            public string RandomPassword()
            {
                var passwordBuilder = new StringBuilder();

                // 4-Letters lower case   
                passwordBuilder.Append(RandomString(4, true));

                // 4-Digits between 1000 and 9999  
                passwordBuilder.Append(RandomNumber(1000, 9999));

                // 2-Letters upper case  
                passwordBuilder.Append(RandomString(2));
                return passwordBuilder.ToString();
            }
        }
        //int z;

        private void Completed_Lamp()
        {
            txt_kirim = "00SC02";
            WritePLC();
            txt_kirim = "00WD" + "0100" + "0001";
            WritePLC();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            txt_kirim = "00SC02";
            WritePLC();
            txt_kirim = "00WD" + "0100" + "0001";
            WritePLC();



            //for (int i = 0; i <= 100; i++)
            //{
            //    //label4.Text = (i).ToString();
            //    z = z + 1;
            //    label4.Text = z.ToString();
            //    //progressBar1.Value = i;
            //    //KirimkePrinterTIJ1();
            //    //GetStatusACKMarkem();
            //    //Thread.Sleep(200);
            //    //lb_actualLotSize.Text = count.ToString();
            //    //lblPersen.Text = "Loading..." + i.ToString() + "%";

            //}
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            //KirimkePrinterTIJ1();
            //KirimkePrinterTIJ();
            //Load_dataUnicode();
            
            if (VDataTarget == lb_actualLotSize.Text)
            {
                timer3.Stop();
            }
            else
            {
                //Load_dataUnicode_perRow();
                KirimkePrinterTIJ();
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //KirimkePrinterTIJ();
            

            txt_kirim = "00RD" + "0100" + "0001";
            ReadPLC();
            lbDM0100.Text = Txt_terima;
        }

        public void SaveHistory_camera()
        {
            config.Init_Con();

            config.con.Open();

            string sql = "INSERT INTO  `tblhistory_camera` (`wo_no`, `kodeRecipe`, `noBatch`, `product`, `status_read`,`actual_code`, `waktu`) values('" + lb_woNo.Text + "','" + cbRecipe.Text + "','" + lb_lotNo.Text + "','" + lb_productName.Text + "','" + Vstatus + "','" + lb_dataReceived.Text + "','" + DateTime.Now + "') ";
            //config.Execute_CUD(sql, "Unable to saved", "Data has been saved in the database.");
            MySqlCommand cmd = new MySqlCommand(sql, config.con);
            cmd.ExecuteNonQuery();

            //MessageBox.Show("Save ");
            config.con.Close();
            //LoadDGV();
        }

        public void SaveHistory_print()
        {
            config.Init_Con();

            config.con.Open();

            string sql = "INSERT INTO  `tblhistory_print` (`wo_no`, `kodeRecipe`, `noBatch`, `product`, `data_print`, `waktu`) values('" + lb_woNo.Text + "','" + cbRecipe.Text + "','" + lb_lotNo.Text + "','" + lb_productName.Text + "','" + VdataPrint + "','" + DateTime.Now + "') ";
            //config.Execute_CUD(sql, "Unable to saved", "Data has been saved in the database.");
            MySqlCommand cmd = new MySqlCommand(sql, config.con);
            cmd.ExecuteNonQuery();

            //MessageBox.Show("Save ");
            config.con.Close();
            //LoadDGV();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            timer2.Stop();
            timer3.Stop();
            FormLogin frmExit = new FormLogin();
            frmExit.Show();
            this.Hide();
        }
        public void Load_dataUnicode_perRow()
        {
            config.Init_Con();
            config.con.Open();
            string query = "SELECT MIN(id), product_code, batch, code_matrix, code_desc FROM tblgeneratecode WHERE product_code='" + cbRecipe.Text + "' and batch='" + cb_Batch.Text + "' and status=0";
            MySqlDataAdapter da = new MySqlDataAdapter(query, config.con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Vdata_ProductCode = dr[1].ToString();
                    //tbProductCode.Text = dr[1].ToString();
                    //Vdata_ProductName = dr[2].ToString();
                    Vdata_Batch = dr[2].ToString();
                    lb_lotNo.Text = Vdata_Batch;
                    Vdata_GTINCodeMatrix = dr[3].ToString();
                    Vdata_GTINCodeDesc = dr[4].ToString();

                    split_Data();

                    

                }
            }

            config.con.Close();
        }

        private void Load_dataUnicode()
        {
            lbWaiting.Text = "Waiting..";
            config.Init_Con();
            config.con.Open();
            string query = "select * from tblgeneratecode where product_code='" + cbRecipe.Text + "' and batch='" + cb_Batch.Text + "' and status=0 ";
            //string query = "SELECT max(`id`), product_code, batch, code_matrix, code_desc FROM tblgeneratecode where product_code='" + cbProduct.Text + "' and batch='" + cb_Batch.Text + "' and status=0 ";

            MySqlDataAdapter da = new MySqlDataAdapter(query, config.con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            //TotalCountPrint = dt.Rows.Count;

            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Vdata_ProductCode = dr[1].ToString();
                    //tbProductCode.Text = dr[1].ToString();
                    //Vdata_ProductName = dr[2].ToString();
                    Vdata_Batch = dr[2].ToString();
                    lb_lotNo.Text = Vdata_Batch; 
                    Vdata_GTINCodeMatrix = dr[3].ToString();
                    Vdata_GTINCodeDesc = dr[4].ToString();
                    //Vdata_ExpDate = dr[4].ToString();
                    //cbBatch.Items.Add(dr[3].ToString());

                    split_Data();
                    //merged_Data();
                    
                    progressBar2.Minimum = 0;
                    progressBar2.Maximum = targetData;

                    KirimkePrinterTIJ();

                    TotalCountPrint++;
                    progressBar2.Value = TotalCountPrint;
                    
                    if (TotalCountPrint == targetData)
                    {
                        lbWaiting.Text = "Finish Send";
                        timer3.Stop();
                    }
                    //timer2.Start();
                    //timer3.Stop();
                    //GetStatusACKMarkem();
                    

                    //progressBar1.Minimum = 0;
                    //progressBar1.Maximum = targetData;

                    //TotalCount++;

                    //int percentage = (100 / targetData) * TotalCount;

                    //lblPersen.Text = percentage.ToString() + " %";
                    //progressBar1.Value = TotalCount;
                    //lb_Scanned.Text = TotalCount.ToString();
                    //lb_actualLotSize.Text = TotalCount.ToString();
                }

                timer3.Stop();
                //timer2.Start();
            }

            config.con.Close();
        }

        private void Update_data_status()
        {
            if(Vdata_Camera == vData_GTINCodeMatrixFull)
            {
                config.Init_Con();
                config.con.Open();
                string sql = "update tblhistory_print set status=1 where kodeRecipe='" + cbRecipe.Text + "' and noBatch='" + cb_Batch.Text + "' and data_print='" + Vdata_Camera + "'";
                MySqlCommand cmd = new MySqlCommand(sql, config.con);
                int v = cmd.ExecuteNonQuery();

                config.con.Close();
            }
            else
            {
                lbWaiting.Text = "Data Not Match";
            }
        }

        private void Load_Lot_size()
        {
            config.Init_Con();
            config.con.Open();
            string sql = "SELECT COUNT(ID) FROM tblhistory_print WHERE kodeRecipe='" + cbRecipe.Text + "'  AND noBatch='" + cb_Batch.Text + "' AND STATUS=1";
            MySqlCommand cmd = new MySqlCommand(sql, config.con);
            MySqlDataReader dr;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lb_actualLotSize.Text = dr[0].ToString();
            }
            dr.Close();
            config.con.Close();
        }

        private void Load_Datawo()
        {
            config.Init_Con();
            config.con.Open();
            string sql = "select * from tblworkorder where kodeRecipe='" + cbRecipe.Text + "' and noBatch='" + cb_Batch.Text + "'";
            MySqlCommand cmd = new MySqlCommand(sql, config.con);
            MySqlDataReader dr;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lb_woNo.Text = dr[1].ToString();
                //lb_WO_Progress.Text = dr[1].ToString();
                lb_lotNo.Text = dr[5].ToString();
                lb_productName.Text = dr[4].ToString();
                lb_targetLotsize.Text = dr[8].ToString();
                VDataTarget = dr[8].ToString();
                Vdata_GTINCodeMatrix = dr[9].ToString();
                Vdata_GTINCodeDesc = dr[10].ToString();

                split_Data();
            }
            dr.Close();
            config.con.Close();

            
            
        }

        private void Load_dataSKU()
        {
            config.Init_Con();
            config.con.Open();
            string sql = "select * from tblworkorder where product_code='" + cbRecipe.Text + "' and batch='" + cb_Batch.Text + "'";
            MySqlCommand cmd = new MySqlCommand(sql, config.con);
            MySqlDataReader dr;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                //lb_woNo.Text = dr[1].ToString();
                //lb_WO_Progress.Text = dr[1].ToString();
                //lb_lotNo.Text = dr[3].ToString();
                lb_productName.Text = dr[2].ToString();
                //lb_targetLotsize.Text = dr[4].ToString();
                //VDataTarget = dr[4].ToString();
                //VDataGtin = dr[5].ToString();
            }
            dr.Close();
            config.con.Close();
        } 

        private void cb_Batch_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Load_dataUnicode();
            //Load_dataSKU();
            Load_Datawo();
        }

        private void GetCOMSetting()
        {
            varGlobal.GetValues(varUtility.fileComSetting);
            VCOMPort = Values.StringCOM;
            VBaudrate = Values.IntBaudRate;
            VDataBits = Values.IntDataBits;
            VStopBits = Values.IntStopBits;
            VParity = Values.IntParity;

        }

        private void Connect_COM()
        {
            try
            {
                GetCOMSetting();
                serialPort1.PortName = VCOMPort;
                serialPort1.BaudRate = Convert.ToInt32(VBaudrate);
                serialPort1.DataBits = Convert.ToInt32(VDataBits);
                serialPort1.StopBits = (StopBits)Enum.Parse(typeof(StopBits), VStopBits);
                serialPort1.Parity = (Parity)Enum.Parse(typeof(Parity), VParity);

                serialPort1.Open();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GetFCS()
        {
            //This will calculate the FCS value for the communications
            int L = 0;
            string A = null;
            string TJ = null;
            L = TX.Length;
            A = "0";
            for (var J = 1; J <= L; J++)
            {
                TJ = TX.Substring(J - 1, 1);
                A = (Strings.Asc(TJ) ^ Convert.ToInt32(A)).ToString();

            }
            FCS = Convert.ToString(Convert.ToInt64(A), 16).ToUpper();
            if (FCS.Length == 1)
            {
                FCS = "0" + FCS;
            }
        }

        private void communicate()
        {
            //This will communicate to the Omron PLC
            string BufferTX = null;
            string fcs_rxd = null;
            try
            {
                RXD = "";
                BufferTX = TX + FCS + "*" + "\r";
                //Send the information out the serial port
                serialPort1.Write(BufferTX);
                //Sleep for 50 msec so the information can be sent on the port
                System.Threading.Thread.Sleep(50);
                //Set the timeout for the serial port at 100 msec
                serialPort1.ReadTimeout = 100;
                //Read up to the carriage return
                RXD = (serialPort1.ReadTo("\r"));
            }
            catch (Exception)
            {
                //If an error occurs then indicate communication error
                RXD = "Communication Error";
            }
            //Get the FCS of the returned information
            fcs_rxd = RXD.Substring(RXD.Length - 3, 2);
            if (RXD.Substring(0, 1) == "@")
            {
                TX = RXD.Substring(0, RXD.Length - 3);
            }
            else if (RXD.Substring(2, 1) == "@")
            {
                TX = RXD.Substring(2, RXD.Length - 5);
                RXD = RXD.Substring(2, RXD.Length - 1);
            }
            //Check the FCS of the return information. If they are not the same then an error has occurred.
            GetFCS();
            if (FCS != fcs_rxd)
            {
                RXD = "Communication Error";
            }

        }

        private void ReadPLC()
        {
            //string bufferRXD = null;
            //string buffer_TX = null;
            Connect_COM();
            //@00RD00100001"
            TX = "@" + txt_kirim;
            GetFCS();
            lbTX.Text = TX + FCS + "*";
            communicate();

            serialPort1.Close();
            lbRXD.Text = RXD;
            Txt_terima = RXD.Substring(7, 4);

        }

        private void WritePLC()
        {
            //string bufferRXD = null;
            //string buffer_TX = null;
            Connect_COM();
            //"00WD" + "1010" + "000A"
            TX = "@" + txt_kirim;
            GetFCS();
            lbTX.Text = TX + FCS + "*";
            communicate();

            serialPort1.Close();
            lbRXD.Text = RXD;
        }

        private void GetDataPLC()
        {
            txt_kirim = "00RD" + "0110" + "0001";
            ReadPLC();
            lbDM0110.Text = Txt_terima;
            txt_kirim = "00RD" + "0100" + "0001";
            ReadPLC();
            lbDM0100.Text = Txt_terima;
            txt_kirim = "00RD" + "0010" + "0001";
            ReadPLC();
            lbDM0010.Text = Txt_terima;
        }

        private void cbProduct_SelectedValueChanged(object sender, EventArgs e)
        {
            cb_Batch.Items.Clear();
            config.Init_Con();
            config.con.Open();
            string sql = "select DISTINCT noBatch from tblworkorder where kodeRecipe='" + cbRecipe.Text + "'";
            MySqlCommand cmd = new MySqlCommand(sql, config.con);
            MySqlDataReader dr;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                cb_Batch.Items.Add(dr[0].ToString());


            }

            dr.Close();
            config.con.Close();
            cb_Batch.SelectedIndex = 0;
        }

        private void cb_Batch_SelectedValueChanged(object sender, EventArgs e)
        {
            //Load_dataSKU();
            Load_Datawo();
            Load_Lot_size();
            if (lb_actualLotSize.Text == lb_targetLotsize.Text)
            {
                lbWO_Status.Text = "WO Completed";
                lbWO_Status.BackColor = Color.Green;
                btnStart.Enabled = false;
            }
            else
            {
                lbWO_Status.Text = "WO Un-Completed";
                lbWO_Status.BackColor = Color.Red;
                btnStart.Enabled = true;
            }
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void Form3_Resize(object sender, EventArgs e)
        {
            resize_Control(btnStart, recBut1);
            resize_Control(btnStop, recBut2);
            resize_Control(btnExit, recBut3);
            resize_Control(btnMin, recBut4);
            resize_Control(cb_wo, recCBbox1);
            resize_Control(cbRecipe, recCBbox2);
            resize_Control(cb_Batch, recCBbox3);
            resize_Control(pictureBox1, recPicBox1);
            resize_Control(PB_Load, recPicBox2);
            resize_Control(PB_NG, recPicBox3);
            resize_Control(PB_OK, recPicBox4);
            resize_Control(progressBar1, recPrgBar1);
            resize_Control(progressBar2, recPrgBar2);
            resize_Control(panel1, recPnl1);
            resize_Control(panel2, recPnl2);
            resize_Control(panel3, recPnl3);
            resize_Control(panel4, recPnl4);
            resize_Control(panel5, recPnl5);
            resize_Control(panel6, recPnl6);
            resize_Control(panel7, recPnl7);
            resize_Control(panel8, recPnl8);
            resize_Control(panel9, recPnl9);
            resize_Control(label1, recLblH1);
            resize_Control(lblUser ,recLblH2);
            resize_Control(lblTime, recLblH3);
            resize_Control(label14, recLblPrgBr1);
            resize_Control(lb_actualLotSize, recLblPrgBr2);
            resize_Control(lblPersen, recLblPrgBr3);
            resize_Control(label15, recLblPrgBr4);
            resize_Control(lb_targetLotsize, recLblPrgBr5);
            resize_Control(label3, recLbl1);
            resize_Control(label8, recLbl2);
            resize_Control(lb_woNo, recLbl3);
            resize_Control(label11, recLbl4);
            resize_Control(lb_lotNo, recLbl5);
            resize_Control(label12, recLbl6);
            resize_Control(lb_productName, recLbl7);
            resize_Control(label2, recLbl8);
            resize_Control(lb_WO_Progress, recLbl9);
            resize_Control(lb_WOP_Status, recLbl10);
            resize_Control(label19, recLbl11);
            resize_Control(lb_actualReadCode, recLbl12);
            resize_Control(lbWaiting, recLbl13);
            resize_Control(label16, recLbl14);
            resize_Control(lb_Scanned, recLbl15);
            resize_Control(label17, recLbl16);
            resize_Control(lb_fail, recLbl17);
            resize_Control(lb_data1, recLbl18);
            resize_Control(lb_data2, recLbl19);
            resize_Control(lb_data3, recLbl20);
            resize_Control(lb_data4, recLbl21);

                

        }

        private void resize_Control(Control c, Rectangle r)
        {
            float xRatio = (float)(this.Width) / (float)(formOriginalSize.Width);
            float yRatio = (float)(this.Height) / (float)(formOriginalSize.Height);
            int newX = (int)(r.X * xRatio);
            int newY = (int)(r.Y * yRatio);

            int newWidth = (int)(r.Width * xRatio);
            int newHeight = (int)(r.Height * yRatio);

            c.Location = new Point(newX, newY);
            c.Size = new Size(newWidth, newHeight);

        }

        private void lb_targetLotsize_Click(object sender, EventArgs e)
        {

        }
    }
}
