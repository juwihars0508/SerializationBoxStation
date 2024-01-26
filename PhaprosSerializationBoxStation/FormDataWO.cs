using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PhaprosSerializationBoxStation.Includes;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Runtime.InteropServices;

namespace PhaprosSerializationBoxStation
{
    public partial class FormDataWO : Form
    {
        private Size formOriginalSize;
        private Rectangle recBut1;
        private Rectangle recBut2;
        private Rectangle recBut3;
        private Rectangle recBut4;
        private Rectangle recText1;
        private Rectangle recPicBox1;
        private Rectangle recDgv1;
        private Rectangle recDgv2;
        private Rectangle recPnl1;
        private Rectangle recPnl2;
        private Rectangle recLblH1;
        private Rectangle recLblH2;
        private Rectangle recLblH3;
        private Rectangle recLbl1;
        private Rectangle recLbl2;
        private Rectangle recLbl3;
        private Rectangle recLbl4;
        private Rectangle recLbl5;

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

        public FormDataWO()
        {
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            this.Resize += Form5_Resize;
            formOriginalSize = this.Size;
            recBut1 = new Rectangle(btnAddWo.Location, btnAddWo.Size);
            recBut2 = new Rectangle(btnSaveWo.Location, btnSaveWo.Size);
            recBut3 = new Rectangle(btn_MainMenu.Location, btn_MainMenu.Size);
            recBut4 = new Rectangle(btnMin.Location, btnMin.Size);
            recText1 = new Rectangle(tbwoNo.Location, tbwoNo.Size);
            recPicBox1 = new Rectangle(pictureBox1.Location, pictureBox1.Size);
            recDgv1 = new Rectangle(dgvProduct.Location, dgvProduct.Size);
            recDgv2 = new Rectangle(dgvWorkOrder.Location, dgvWorkOrder.Size);
            recPnl1 = new Rectangle(panel1.Location, panel1.Size);
            recPnl2 = new Rectangle(panel2.Location, panel2.Size);
            recLblH1 = new Rectangle(label7.Location, label7.Size);
            recLblH2 = new Rectangle(lblUser.Location, lblUser.Size);
            recLblH3 = new Rectangle(lblTime.Location, lblTime.Size);
            recLbl1 = new Rectangle(label3.Location, label5.Size);
            recLbl2 = new Rectangle(label5.Location, label5.Size);
            recLbl3 = new Rectangle(label26.Location, label26.Size);
            recLbl4 = new Rectangle(label10.Location, label10.Size);
            recLbl5 = new Rectangle(label11.Location, label11.Size);
        }

        SQLConfig config = new SQLConfig();
        usableFunction funct = new usableFunction();

        public string vData_woNo;
        public string vData_idRecipe;
        public string vData_kodeRecipe;
        public string vData_productName;
        public string vData_noBatch;
        public string vData_expDate;
        public string vData_kodeNIE;
        public string vData_qtyTarget;
        public string vDataCodeGtin;
        public string vDataDescGtin;

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void btnAddWo_Click(object sender, EventArgs e)
        {
            dgvProduct.Enabled = true;
            kode_autoGenerate();
            tampilDataSKU();
            vData_woNo = tbwoNo.Text;
            btnAddWo.Enabled = false;
            btnSaveWo.Enabled = true;
        }

        private void tampilDataSKU()
        {
            config.Init_Con();
            config.con.Open();
            string query = "SELECT * FROM viewdatawo ";
            MySqlDataAdapter sda = new MySqlDataAdapter(query, config.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dgvProduct.DataSource = dt;
            if(dt.Rows.Count != 0)
            {
                for (int i = dt.Rows.Count - 1; i >= 0; i--)
                {
                    dgvProduct.Rows[i].Cells[0].Value = false;
                }

            }

            config.con.Close();

            //dgvProduct.Rows.Add();
            


        }

        private void kode_autoGenerate()
        {
            config.Init_Con();
            config.con.Open();
            string query = "select count(wo_no) from tblworkorder";
            MySqlDataAdapter sda = new MySqlDataAdapter(query, config.con);
            int i = Convert.ToInt32(sda.SelectCommand.ExecuteScalar());
            config.con.Close();
            DateTime sekarang = DateTime.Now;
            i++;
            tbwoNo.Text = "WO" + sekarang.ToString("yy") + sekarang.ToString("MM") + sekarang.ToString("dd") + i.ToString("000");

        }

        private void dgvProduct_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
               


                bool delete = (bool)dgvProduct.Rows[0].Cells[0].Value;

            // if the checkbox cell is checked

            if (delete == true)
            {
                DataGridViewRow rowToRemove = dgvProduct.Rows[0];

                dgvProduct.Rows.Remove(rowToRemove);
            }

        }

        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvProduct_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            bool delete = (bool)dgvProduct.SelectedRows[0].Cells[0].Value;

            // if the checkbox cell is checked

            if (delete == true)
            {
                DataGridViewRow rowToRemove = dgvWorkOrder.SelectedRows[0];

                dgvWorkOrder.Rows.Remove(rowToRemove);

                dgvProduct.SelectedRows[0].Cells[0].Value = false;
            }
            else
            {
                dgvProduct.SelectedRows[0].Cells[0].Value = true;
                vData_idRecipe = dgvProduct.SelectedRows[0].Cells[1].Value.ToString();
                vData_kodeRecipe = dgvProduct.SelectedRows[0].Cells[2].Value.ToString();
                vData_productName =  dgvProduct.SelectedRows[0].Cells[4].Value.ToString();
                vData_noBatch = dgvProduct.SelectedRows[0].Cells[5].Value.ToString();
                vData_expDate = dgvProduct.SelectedRows[0].Cells[6].Value.ToString();
                vData_kodeNIE = dgvProduct.SelectedRows[0].Cells[7].Value.ToString();
                vData_qtyTarget = dgvProduct.SelectedRows[0].Cells[8].Value.ToString();

                tampil_dataGtin();
                tampil_data();
            }
        }

        private void tampil_dataGtin()
        {
            string[] vDataExp = vData_expDate.Split('-');
            string thn = vDataExp[0].ToString().Substring(2, 2);
            string bln = vDataExp[1].ToString();
            string tgl = vDataExp[2].ToString();
            string ExpDate = thn + bln + tgl;
            vDataDescGtin = "(90)" + vData_kodeNIE + ";(10)" + vData_noBatch + ";(17)" + ExpDate + ";(21)";
            vDataCodeGtin = "90" + vData_kodeNIE + "10" + vData_noBatch + "17" + ExpDate + "21";

        }

        private void tampil_data()
        {
            //hitungQtyBatch();

            if (Convert.ToInt32(vData_qtyTarget) == 0)
            {
                MessageBox.Show("Qty Batch zero", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {


                dgvWorkOrder.ColumnCount = 10;
                dgvWorkOrder.Columns[0].Name = "Wo No";
                dgvWorkOrder.Columns[0].Width = 100;
                dgvWorkOrder.Columns[1].Name = "ID Recipe";
                dgvWorkOrder.Columns[1].Width = 100;
                dgvWorkOrder.Columns[2].Name = "Kode Recipe";
                dgvWorkOrder.Columns[2].Width = 100;
                dgvWorkOrder.Columns[3].Name = "Nama Produk";
                dgvWorkOrder.Columns[3].Width = 100;
                dgvWorkOrder.Columns[4].Name = "No. Batch";
                dgvWorkOrder.Columns[4].Width = 100;
                dgvWorkOrder.Columns[5].Name = "Exp Date";
                dgvWorkOrder.Columns[5].Width = 100;
                dgvWorkOrder.Columns[6].Name = "Kode NIE";
                dgvWorkOrder.Columns[6].Width = 100;
                dgvWorkOrder.Columns[7].Name = "Target Recipe";
                dgvWorkOrder.Columns[7].Width = 100;
                dgvWorkOrder.Columns[8].Name = "GTIN Code";
                dgvWorkOrder.Columns[8].Width = 100;
                dgvWorkOrder.Columns[9].Name = "GTIN Code Desc";
                dgvWorkOrder.Columns[9].Width = 100;

                string[] row = new string[] { vData_woNo, vData_idRecipe , vData_kodeRecipe, vData_productName, vData_noBatch, vData_expDate, vData_kodeNIE, vData_qtyTarget, vDataCodeGtin, vDataDescGtin };
                dgvWorkOrder.Rows.Add(row);

            }
            //dgvGenCode.Rows[Vtotal_Count].Selected = true;

            //int nRowIndex = dgvGenCode.Rows.Count - 1;
            //int nColumnIndex = 3;

            //dgvGenCode.Rows[nRowIndex].Selected = true;
            //dgvGenCode.Rows[nRowIndex].Cells[nColumnIndex].Selected = true;

            //highlightrow1(dgvGenCode);
        }

        private void hitungQtyBatch()
        {
            config.Init_Con();
            config.con.Open();
            string query = "select count(batch) from tblgeneratecode WHERE batch='" + vData_noBatch + "'";
            MySqlDataAdapter sda = new MySqlDataAdapter(query, config.con);
            //vData_qtyTarget = sda.SelectCommand.ExecuteScalar();
            config.con.Close();

            
        }

        private void saveWo()
        {
            config.Init_Con();
            
            foreach (DataGridViewRow row in dgvWorkOrder.Rows)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd = config.con.CreateCommand();
                    if (row.IsNewRow) continue;
                    cmd.Parameters.AddWithValue("@wo_no", row.Cells[0].Value);
                    cmd.Parameters.AddWithValue("@idRecipe", row.Cells[1].Value);
                    cmd.Parameters.AddWithValue("@kodeRecipe", row.Cells[2].Value);
                    cmd.Parameters.AddWithValue("@namaProduk", row.Cells[3].Value);
                    cmd.Parameters.AddWithValue("@noBatch", row.Cells[4].Value);
                    cmd.Parameters.AddWithValue("@expDate", row.Cells[5].Value);
                    cmd.Parameters.AddWithValue("@kodeNIE", row.Cells[6].Value);
                    cmd.Parameters.AddWithValue("@targetRecipe", row.Cells[7].Value);
                    cmd.Parameters.AddWithValue("@codeGTIN", row.Cells[8].Value);
                    cmd.Parameters.AddWithValue("@codeGTINdesc", row.Cells[9].Value);

                    cmd.CommandText = "INSERT INTO `tblworkorder`(`wo_no`, `idRecipe`, `kodeRecipe`, `namaProduk`, `noBatch`, `expDate`, `kodeNIE`, `qty_Target`, `GTIN_code`, `GTIN_Desc`)VALUES(@wo_no, @idRecipe, @kodeRecipe, @namaProduk, @noBatch, @expDate, @kodeNIE, @targetRecipe, @codeGTIN, @codeGTINdesc)";
                    config.con.Open();
                    cmd.ExecuteNonQuery();
                    config.con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            MessageBox.Show("Data Wo Save", "Successfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }

        private void btnSaveWo_Click(object sender, EventArgs e)
        {
            saveWo();
            dgvWorkOrder.Rows.Clear();
            dgvProduct.DataSource = "";
            btnAddWo.Enabled = true;
            btnSaveWo.Enabled = false;
        }

        private void btn_MainMenu_Click(object sender, EventArgs e)
        {
            FormMain MainMenu = new FormMain();
            MainMenu.Show();
            this.Hide();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            panel1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel1.Width, panel1.Height, 20, 20));
            panel2.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel2.Width, panel2.Height, 20, 20));
            btnAddWo.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnAddWo.Width, btnAddWo.Height, 20, 20));
            btnSaveWo.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnSaveWo.Width, btnSaveWo.Height, 20, 20));
            btn_MainMenu.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn_MainMenu.Width, btn_MainMenu.Height, 20, 20));
            dgvProduct.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, dgvProduct.Width, dgvProduct.Height, 20, 20));
            dgvWorkOrder.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, dgvWorkOrder.Width, dgvWorkOrder.Height, 20, 20));

            lblUser.Text = varGlobal.Username;
            dgvProduct.Enabled = false;
            btnSaveWo.Enabled = false;

        }

        private void Form5_Resize(object sender, EventArgs e)
        {
            resize_Control(btnAddWo, recBut1);
            resize_Control(btnSaveWo, recBut2);
            resize_Control(btn_MainMenu, recBut3);
            resize_Control(btnMin, recBut4);
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
