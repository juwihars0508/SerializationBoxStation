using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using PhaprosSerializationBoxStation.Includes;

namespace PhaprosSerializationBoxStation
{
    public partial class FormGenerateUnicode : Form
    {
        private Size formOriginalSize;
        private Rectangle recBut1;
        private Rectangle recBut2;
        private Rectangle recBut3;
        private Rectangle recCBbox1;
        private Rectangle recCBbox2;
        private Rectangle recTxt1;
        private Rectangle recTxt2;
        private Rectangle recPicBox1;
        private Rectangle recDgv1;
        private Rectangle recPrgBar1;
        private Rectangle recPnl1;
        private Rectangle recPnl2;
        private Rectangle recPnl3;
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



        public FormGenerateUnicode()
        {
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            this.Resize += Form4_Resize;
            formOriginalSize = this.Size;
            recBut1 = new Rectangle(btnGenerate.Location, btnGenerate.Size);
            recBut2 = new Rectangle(btn_MainMenu.Location, btn_MainMenu.Size);
            recBut3 = new Rectangle(btnMin.Location, btnMin.Size);
            recCBbox1 = new Rectangle(cbProductName.Location, cbProductName.Size);
            recCBbox2 = new Rectangle(cbBatch.Location, cbBatch.Size);
            recTxt1 = new Rectangle(tbProductCode.Location, tbProductCode.Size);
            recTxt2 = new Rectangle(tbQty.Location, tbQty.Size);
            recPicBox1 = new Rectangle(pictureBox1.Location, pictureBox1.Size);
            recDgv1 = new Rectangle(dgvGenCode.Location, dgvGenCode.Size);
            recPrgBar1 = new Rectangle(progressBar1.Location, progressBar1.Size);
            recPnl1 = new Rectangle(panel1.Location, panel1.Size);
            recPnl2 = new Rectangle(panel2.Location, panel2.Size);
            recPnl3 = new Rectangle(panel3.Location, panel3.Size);
            recLblH1 = new Rectangle(label7.Location, label7.Size);
            recLblH2 = new Rectangle(lblUser.Location, lblUser.Size);
            recLblH3 = new Rectangle(lblTime.Location, lblTime.Size);
            recLblPrgBr1 = new Rectangle(label14.Location, label14.Size);
            recLblPrgBr2 = new Rectangle(lb_ActualQty.Location, lb_ActualQty.Size);
            recLblPrgBr3 = new Rectangle(lblPersen.Location, lblPersen.Size);
            recLblPrgBr4 = new Rectangle(label15.Location, label15.Size);
            recLblPrgBr5 = new Rectangle(lb_targetQty.Location, lb_targetQty.Size);
            recLbl1 = new Rectangle(label3.Location, label3.Size);
            recLbl2 = new Rectangle(label8.Location, label8.Size);
            recLbl3 = new Rectangle(label1.Location, label1.Size);
            recLbl4 = new Rectangle(label4.Location, label4.Size);
            recLbl5 = new Rectangle(label5.Location, label5.Size);
            recLbl6 = new Rectangle(label9.Location, label9.Size);
            recLbl7 = new Rectangle(label2.Location, label2.Size);
            recLbl8 = new Rectangle(label6.Location, label6.Size);
            recLbl9 = new Rectangle(label26.Location, label26.Size);
            recLbl10 = new Rectangle(lbGTINCodeDesc.Location, lbGTINCodeDesc.Size);
            recLbl11 = new Rectangle(lbGTINCodeMatrix.Location, lbGTINCodeMatrix.Size);
            
        }

        SQLConfig config = new SQLConfig();
        usableFunction usable = new usableFunction();

        public string Vdata_ProductCode;
        public string Vdata_ProductName;
        public string Vdata_Batch;
        public string Vdata_ExpDate;
        public string Vdata_GTINCodeMatrix;
        public string Vdata_GTINCodeDesc;
        public int Vdata_TargetData;
        public int Vtotal_Count;
        public string Vdata_unicode;


        private void time_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void loadDataSKU()
        {
            config.Init_Con();
            config.con.Open();
            string query = "SELECT DISTINCT  product_name FROM  tbldatasku order by product_name ASC";
            MySqlCommand cmd = new MySqlCommand(query, config.con);
            MySqlDataReader dr;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cbProductName.Items.Add(dr[0].ToString());
            }
            dr.Close();
            config.con.Close(); 
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            panel1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel1.Width, panel1.Height, 20, 20));
            panel2.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel2.Width, panel2.Height, 20, 20));
            panel3.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel3.Width, panel3.Height, 20, 20));
            btnGenerate.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnGenerate.Width, btnGenerate.Height, 20, 20));
            btn_MainMenu.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn_MainMenu.Width, btn_MainMenu.Height, 20, 20));
            dgvGenCode.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, dgvGenCode.Width, dgvGenCode.Height, 20, 20));

            loadDataSKU();
            cbProductName.SelectedIndex = 0;
            cbBatch.SelectedIndex = 0;
            lblUser.Text = varGlobal.Username;
        }

        private void cbProductName_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbBatch.Items.Clear();
            config.Init_Con();
            config.con.Open();
            string query = "select * from tbldatasku where product_name='" + cbProductName.Text + "'";
           
            MySqlDataAdapter da = new MySqlDataAdapter(query, config.con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if(dt.Rows.Count == 1)
            {
                foreach(DataRow dr in dt.Rows)
                {
                    //Vdata_ProductCode = dr[1].ToString();
                    //tbProductCode.Text = dr[1].ToString();
                    //Vdata_ProductName = dr[2].ToString();
                    //Vdata_Batch = dr[3].ToString();
                    //Vdata_ExpDate = dr[4].ToString();
                    cbBatch.Items.Add(dr[3].ToString());
                }
                cbBatch.SelectedIndex = 0;
                //Vdata_GTINCodeMatrix = "90" + Vdata_ProductCode + "10" + Vdata_Batch + "17" + Vdata_ExpDate;
                //Vdata_GTINCodeDesc = "(90)" + Vdata_ProductCode + "(10)" + Vdata_Batch + "(17)" + Vdata_ExpDate;

                //lbGTINCodeDesc.Text = Vdata_GTINCodeDesc;
                //lbGTINCodeMatrix.Text = Vdata_GTINCodeMatrix;
            }
            else
            {
                foreach (DataRow dr in dt.Rows)
                {
                    //Vdata_ProductCode = dr[1].ToString();
                    //tbProductCode.Text = dr[1].ToString();
                    //Vdata_ProductName = dr[2].ToString();
                    //Vdata_Batch = dr[3].ToString();
                    //Vdata_ExpDate = dr[4].ToString();
                    cbBatch.Items.Add(dr[3].ToString());
                }
                cbBatch.SelectedIndex = 0;
                //Vdata_GTINCodeMatrix = "90" + Vdata_ProductCode + "10" + Vdata_Batch + "17" + Vdata_ExpDate;
                //Vdata_GTINCodeDesc = "(90)" + Vdata_ProductCode + "(10)" + Vdata_Batch + "(17)" + Vdata_ExpDate;

                //lbGTINCodeDesc.Text = Vdata_GTINCodeDesc;
                //lbGTINCodeMatrix.Text = Vdata_GTINCodeMatrix;
            }
            
            config.con.Close();

            
        }

        private void tampil_data()
        {
            
            dgvGenCode.ColumnCount = 4;
            dgvGenCode.Columns[0].Name = "Product Code";
            dgvGenCode.Columns[0].Width = 100;
            dgvGenCode.Columns[1].Name = "Batch";
            dgvGenCode.Columns[1].Width = 100;
            dgvGenCode.Columns[2].Name = "Code Desc";
            dgvGenCode.Columns[2].Width = 350;
            dgvGenCode.Columns[3].Name = "Waktu";
            dgvGenCode.Columns[3].Width = 120;

            string[] row = new string[] { Vdata_ProductCode, Vdata_Batch ,Vdata_GTINCodeDesc, DateTime.Now.ToString()};
            dgvGenCode.Rows.Add(row);
            //dgvGenCode.Rows[Vtotal_Count].Selected = true;

            //int nRowIndex = dgvGenCode.Rows.Count - 1;
            //int nColumnIndex = 3;

            //dgvGenCode.Rows[nRowIndex].Selected = true;
            //dgvGenCode.Rows[nRowIndex].Cells[nColumnIndex].Selected = true;

            highlightrow1(dgvGenCode);
        }

        protected void highlightrow1(DataGridView gridviewRows)
        {
            gridviewRows.ClearSelection();

            foreach (DataGridViewRow row in gridviewRows.Rows)
            {
                string colCode = row.Cells[0].Value.ToString();
                string colSerial = row.Cells[1].Value.ToString();
                
                if (colCode == Vdata_ProductCode && colSerial == Vdata_GTINCodeDesc)
                {
                    
                    gridviewRows.FirstDisplayedScrollingRowIndex = row.Index;
                    


                    break;
                }

                
            }

            gridviewRows.Rows[gridviewRows.Rows.Count - 1].Selected = true;
        }

        private void generate_Code()
        {
            Vdata_TargetData = Convert.ToInt32(tbQty.Text);
            progressBar1.Minimum = 0;
            progressBar1.Maximum = Vdata_TargetData;

            Vtotal_Count++;

            progressBar1.Value = Vtotal_Count;

            //Double percentage = (100 / Vdata_TargetData) * Vtotal_Count;

            Decimal percentage = ((Vtotal_Count / Vdata_TargetData) * 100);

            lblPersen.Text = percentage.ToString() + " %";

            lb_ActualQty.Text = Vtotal_Count.ToString();
            lb_targetQty.Text = tbQty.Text;

            Task<string> Result = GeneratePatientNumberAsync();
            Vdata_unicode = Result.Result;

            Vdata_GTINCodeMatrix = "90" + Vdata_ProductCode + ";" + "10" + Vdata_Batch + ";" + "17" + Vdata_ExpDate + ";" + "21" + Vdata_unicode;
            Vdata_GTINCodeDesc = "(90)" + Vdata_ProductCode + ";" + "(10)" + Vdata_Batch + ";" + "(17)" + Vdata_ExpDate + ";" + "(21)" + Vdata_unicode;

            lbGTINCodeDesc.Text = Vdata_GTINCodeDesc;
            lbGTINCodeMatrix.Text = Vdata_GTINCodeMatrix;

            tampil_data();
            simpan_Unicode();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            generate_Code();
            if (lb_ActualQty.Text == lb_targetQty.Text)
            {
                timer1.Stop();
                btnGenerate.Enabled = true;
                cbProductName.Enabled = true;
                cbBatch.Enabled = true;
                tbQty.Enabled = true;
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            //Vdata_TargetData = Convert.ToInt32(tbQty.Text);
            Vtotal_Count = 0;
            //Decimal percentage = ((100 / Vdata_TargetData) * Vtotal_Count);
            //lblPersen.Text = percentage.ToString(); ;

            //lbGTINCodeDesc.Text = Result.Result;
            //string Result = await GeneratePatientNumberAsync();
            btnGenerate.Enabled = false;
            cbProductName.Enabled = false;
            cbBatch.Enabled = false;
            tbQty.Enabled = false;
            timer1.Start();
        }

        public async Task<string> GeneratePatientNumberAsync()
        {
            var random = new Random();
            var chars = DateTime.Now.Ticks + "123456789ABCD" + DateTime.Now.Ticks;
            return new string(Enumerable.Repeat(chars, 13)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public void simpan_Unicode()
        {
            config.Init_Con();
            config.con.Open();
            string query = "insert into tblgeneratecode(product_code, batch, code_matrix, code_desc, waktu, user, status)values('"+ tbProductCode.Text + "','" + Vdata_Batch + "' ,'" + Vdata_GTINCodeMatrix + "', '" + Vdata_GTINCodeDesc + "', '" + DateTime.Now + "', '" + lblUser.Text + "', '" + 0 + "')";
            MySqlCommand cmd = new MySqlCommand(query, config.con);
            cmd.ExecuteNonQuery();
            config.con.Close();
        }

        private void cbBatch_SelectedIndexChanged(object sender, EventArgs e)
        {
            config.Init_Con();
            config.con.Open();
            string query = "select * from tbldatasku where product_name='" + cbProductName.Text + "' and batch='" + cbBatch.Text + "'";

            MySqlDataAdapter da = new MySqlDataAdapter(query, config.con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Vdata_ProductCode = dr[1].ToString();
                    tbProductCode.Text = dr[1].ToString();
                    Vdata_ProductName = dr[2].ToString();
                    Vdata_Batch = dr[3].ToString();
                    Vdata_ExpDate = dr[4].ToString();
                    //cbBatch.Items.Add(dr[3].ToString());
                }

                Vdata_GTINCodeMatrix = "90" + Vdata_ProductCode + "10" + Vdata_Batch + "17" + Vdata_ExpDate;
                Vdata_GTINCodeDesc = "(90)" + Vdata_ProductCode + "(10)" + Vdata_Batch + "(17)" + Vdata_ExpDate;

                lbGTINCodeDesc.Text = Vdata_GTINCodeDesc;
                lbGTINCodeMatrix.Text = Vdata_GTINCodeMatrix;
            }

            config.con.Close();
        }

        private void btn_MainMenu_Click(object sender, EventArgs e)
        {
            FormMain MainMenu = new FormMain();
            MainMenu.Show();
            this.Hide();
        }

        private void Form4_Resize(object sender, EventArgs e)
        {
            resize_Control(btnGenerate, recBut1);
            resize_Control(btn_MainMenu, recBut2);
            resize_Control(btnMin, recBut3);
            resize_Control(cbProductName, recCBbox1);
            resize_Control(cbBatch, recCBbox2);
            resize_Control(tbProductCode, recTxt1);
            resize_Control(tbQty, recTxt2);
            resize_Control(pictureBox1, recPicBox1);
            resize_Control(dgvGenCode, recDgv1);
            resize_Control(progressBar1, recPrgBar1);
            resize_Control(panel1, recPnl1);
            resize_Control(panel2, recPnl2);
            resize_Control(panel3, recPnl3);
            resize_Control(label7, recLblH1);
            resize_Control(lblUser, recLblH2);
            resize_Control(lblTime, recLblH3);
            resize_Control(label14, recLblPrgBr1);
            resize_Control(lb_ActualQty, recLblPrgBr2);
            resize_Control(lblPersen, recLblPrgBr3);
            resize_Control(label15, recLblPrgBr4);
            resize_Control(lb_targetQty, recLblPrgBr5);
            resize_Control(label3, recLbl1);
            resize_Control(label8, recLbl2);
            resize_Control(label1, recLbl3);
            resize_Control(label4, recLbl4);
            resize_Control(label5, recLbl5);
            resize_Control(label9, recLbl6);
            resize_Control(label2, recLbl7);
            resize_Control(label6, recLbl8);
            resize_Control(label26, recLbl9);
            resize_Control(lbGTINCodeDesc, recLbl10);
            resize_Control(lbGTINCodeMatrix, recLbl11);

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

        private void btnMin_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}
