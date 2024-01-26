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
    public partial class FormDataSku : Form
    {
        private Size formOriginalSize;
        private Rectangle recBut1;
        private Rectangle recBut2;
        private Rectangle recBut3;
        private Rectangle recBut4;
        private Rectangle recBut5;
        private Rectangle recPnl1;
        private Rectangle recPnl2;
        private Rectangle recPicBox1;
        private Rectangle recDgv1;
        private Rectangle recTxt1;
        private Rectangle recTxt2;
        private Rectangle recTxt3;
        private Rectangle recTxt4;
        private Rectangle recLblH1;
        private Rectangle recLblH2;
        private Rectangle recLblH3;
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

        public FormDataSku()
        {
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            //this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            this.Resize += Form1_Resize;
            formOriginalSize = this.Size;
            recBut1 = new Rectangle(btnAdd.Location, btnAdd.Size);
            recBut2 = new Rectangle(btnEdit.Location, btnEdit.Size);
            recBut3 = new Rectangle(btnDelete.Location, btnDelete.Size);
            recBut4 = new Rectangle(btn_MainMenu.Location, btn_MainMenu.Size);
            recBut5 = new Rectangle(btnMin.Location, btnMin.Size);
            recPnl1 = new Rectangle(panel2.Location, panel2.Size);
            recPnl2 = new Rectangle(panel3.Location, panel3.Size);
            recPicBox1 = new Rectangle(pictureBox1.Location, pictureBox1.Size);
            recDgv1 = new Rectangle(dgvSKU.Location, dgvSKU.Size);
            recTxt1 = new Rectangle(tbProductCode.Location, tbProductCode.Size);
            recTxt2 = new Rectangle(tbProductName.Location, tbProductName.Size);
            recTxt3 = new Rectangle(tbBatch.Location, tbBatch.Size);
            recTxt4 = new Rectangle(tbExpDate.Location, tbExpDate.Size);
            recLblH1 = new Rectangle(label7.Location, label7.Size);
            recLblH2 = new Rectangle(lblUser.Location, lblUser.Size);
            recLblH3 = new Rectangle(lblTime.Location, lblTime.Size);
            recLbl1 = new Rectangle(label11.Location, label11.Size);
            recLbl2 = new Rectangle(label12.Location, label12.Size);
            recLbl3 = new Rectangle(label16.Location, label16.Size);
            recLbl4 = new Rectangle(label19.Location, label19.Size);
            recLbl5 = new Rectangle(label23.Location, label23.Size);
            recLbl6 = new Rectangle(lbDataCode.Location, lbDataCode.Size);
            recLbl7 = new Rectangle(lbDataCodeGtin.Location, lbDataCodeGtin.Size);
            recLbl8 = new Rectangle(label24.Location, label24.Size);
            recLbl9 = new Rectangle(label10.Location, label10.Size);
            recLbl10 = new Rectangle(label13.Location, label13.Size);
            recLbl11 = new Rectangle(label14.Location, label14.Size);
            recLbl12 = new Rectangle(label17.Location, label17.Size);
            recLbl13 = new Rectangle(label20.Location, label20.Size);
        }

        SQLConfig config = new SQLConfig();
        usableFunction usableFunction = new usableFunction();

        public string VdataCodeGtin;  

        private void Form1_Load(object sender, EventArgs e)
        {
            panel2.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel2.Width, panel2.Height, 20, 20));
            panel3.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel3.Width, panel3.Height, 20, 20));
            dgvSKU.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, dgvSKU.Width, dgvSKU.Height, 20, 20));
            btn_MainMenu.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn_MainMenu.Width, btn_MainMenu.Height, 20, 20));
            btnAdd.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnAdd.Width, btnAdd.Height, 20, 20));
            //btnEdit.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnEdit.Width, btnEdit.Height, 20, 20));
            //btnDelete.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnDelete.Width, btnDelete.Height, 20, 20));
            
            tampil_data_SKU();
            readData_product();
            kode_autoGenerate();

            lblUser.Text = varGlobal.Username;
        }

        private void kode_autoGenerate()
        {
            config.Init_Con();
            config.con.Open();
            string query = "select count(kodeRecipe) from tbldatarecipe";
            MySqlDataAdapter sda = new MySqlDataAdapter(query, config.con);
            int i = Convert.ToInt32(sda.SelectCommand.ExecuteScalar());
            config.con.Close();
            DateTime sekarang = DateTime.Now;
            i++;
            tbRecipeCode.Text = "RC" + sekarang.ToString("yy") + sekarang.ToString("MM") + sekarang.ToString("dd") + i.ToString("000");

        }

        private void time_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            

            if (btnAdd.Text == "Add" )
            {
                enabText();
                dgvProduk.Visible = true;
                dgvSKU.Visible = false;
                tbProductCode.Focus();
                btnAdd.Text = "Save"; 
            }
            else if (btnAdd.Text == "Save")
            {
                if (tbProductCode.TextLength == 0)
                {
                    MessageBox.Show(" Product Code Tidak Boleh Kosong!!!", "Error Entry!!..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (tbProductName.TextLength == 0)
                {
                    MessageBox.Show(" Product Name Tidak Boleh Kosong!!!", "Error Entry!!..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (tbBatch.TextLength == 0)
                {
                    MessageBox.Show(" Batch Tidak Boleh Kosong!!!", "Error Entry!!..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (tbExpDate.TextLength == 0)
                {
                    MessageBox.Show(" Exp Date Tidak Boleh Kosong!!!", "Error Entry!!..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    simpanData();
                    kode_autoGenerate();
                    tampil_data_SKU();
                    distext();
                    clearText();
                    dgvProduk.Visible = false;
                    dgvSKU.Visible = true;
                }
            }
        }

        private void enabText()
        {
            tbProductCode.Enabled = true;
            tbMfgDate.Enabled = true;
            tbBatch.Enabled = true;
            tbExpDate.Enabled = true;
        }

        private void distext()
        {
            tbProductCode.Enabled = false;
            tbProductName.Enabled = false;
            tbMfgDate.Enabled = false;
            tbBatch.Enabled = false;
            tbExpDate.Enabled = false;
        }

        private void clearText()
        {
            tbProductCode.Text = "";
            tbProductName.Text = "";
            tbMfgDate.Text = "";
            tbKodeNIE.Text = "";
            tbBatch.Text = "";
            tbExpDate.Text = "";
        }

        private void simpanData()
        {
            config.Init_Con();
            config.con.Open();
            string query = "insert into tbldatarecipe(kodeRecipe, kodeProduk, namaProduk, kodeNIE, noBatch, mfdDate, expDate)values('" + tbRecipeCode.Text + "','" + tbProductCode.Text + "','" +tbProductName.Text  + "','" + tbKodeNIE.Text + "','" + tbBatch.Text + "', '" + tbMfgDate.Text + "','"+ tbExpDate.Text  +"')";
            MySqlCommand cmd = new MySqlCommand(query, config.con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Data Recipe Berhasil dibuat!");
            config.con.Close();
        }

        private void readData_product()
        {
            config.Init_Con();
            config.con.Open();
            string sql = "select kodeProduk from tblproduk ";
            MySqlCommand cmd = new MySqlCommand(sql, config.con);
            MySqlDataReader dr;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cbProductCode.Items.Add(dr[0].ToString());
            }
            dr.Close();

            config.con.Close();
        }

        private void tampil_data_SKU()
        {
            config.Init_Con();
            config.con.Open();
            string query = "SELECT kodeProduk AS 'Kode Produk',namaProduk AS 'Nama Produk',kodeNIE as 'Kode NIE', noBatch AS 'No Batch',mfdDate as 'MFG Date' ,expDate AS 'Expired Date' FROM tbldatarecipe";
            MySqlDataAdapter sda = new MySqlDataAdapter(query,config.con);
            sda.SelectCommand.ExecuteNonQuery();
            DataTable dataTable = new DataTable();
            sda.Fill(dataTable);
            dgvSKU.DataSource = dataTable;
            config.con.Close();
        }

        private void dgvSKU_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string VkodeNIE = dgvSKU.SelectedRows[0].Cells[2].Value.ToString();
            string VData_ProductName = dgvSKU.SelectedRows[0].Cells[1].Value.ToString();
            string VData_Batch = dgvSKU.SelectedRows[0].Cells[3].Value.ToString();
            string VData_Expiry = dgvSKU.SelectedRows[0].Cells[5].Value.ToString();
            string[] vDataExp = VData_Expiry.Split('-');
            string thn = vDataExp[0].ToString().Substring(2,2);
            string bln = vDataExp[1].ToString();
            string tgl = vDataExp[2].ToString();
            string ExpDate = thn + bln + tgl;
            lbDataCode.Text = "(90)" + VkodeNIE + "(10)" + VData_Batch + "(17)" + ExpDate;
            VdataCodeGtin = "90" + VkodeNIE + "10" + VData_Batch + "17" + ExpDate;
            lbDataCodeGtin.Text = VdataCodeGtin;
        }

        private void btn_MainMenu_Click(object sender, EventArgs e)
        {
            FormMain MainMenu = new FormMain();
            MainMenu.Show();
            this.Hide();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            resize_Control(btnAdd, recBut1);
            resize_Control(btnEdit, recBut2);
            resize_Control(btnDelete, recBut3);
            resize_Control(btn_MainMenu, recBut4);
            resize_Control(btnMin, recBut5);
            resize_Control(panel2, recPnl1);
            resize_Control(panel3, recPnl2);
            resize_Control(pictureBox1, recPicBox1);
            resize_Control(dgvSKU, recDgv1);
            resize_Control(tbProductCode, recTxt1);
            resize_Control(tbProductName, recTxt2);
            resize_Control(tbBatch, recTxt3);
            resize_Control(tbExpDate, recTxt4);
            resize_Control(label7, recLblH1);
            resize_Control(lblUser, recLblH2);
            resize_Control(lblTime, recLblH3);
            resize_Control(label11, recLbl1);
            resize_Control(label12, recLbl2);
            resize_Control(label16, recLbl3);
            resize_Control(label19, recLbl4);
            resize_Control(label23, recLbl5);
            resize_Control(lbDataCode, recLbl6);
            resize_Control(lbDataCodeGtin, recLbl7);
            resize_Control(label24, recLbl8);
            resize_Control(label10, recLbl9);
            resize_Control(label13, recLbl10);
            resize_Control(label14, recLbl11);
            resize_Control(label17, recLbl12);
            resize_Control(label20, recLbl13);
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

        private void tbProductCode_TextChanged(object sender, EventArgs e)
        {
            config.Init_Con();
            config.con.Open();
            string sql = "Select kodeProduk, namaProduk, bentukSediaan, kodeNIE from tblproduk where kodeProduk like '%" + tbProductCode.Text + "%'or namaProduk like '%" + tbProductCode.Text + "%' ";
            MySqlDataAdapter sda = new MySqlDataAdapter(sql, config.con);
            DataSet ds = new DataSet();
            sda.Fill(ds, "abc");
            dgvProduk.DataSource = ds;
            dgvProduk.DataMember = "abc";
            config.con.Close();
        }

        private void dgvProduk_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            tbProductCode.Text = dgvProduk.SelectedRows[0].Cells[0].Value.ToString();
            tbProductName.Text = dgvProduk.SelectedRows[0].Cells[1].Value.ToString();
            tbKodeNIE.Text = dgvProduk.SelectedRows[0].Cells[3].Value.ToString();

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void tbProductName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void tbKodeNIE_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void tbBatch_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
