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
using MySql.Data.MySqlClient;
using PhaprosSerializationBoxStation.Includes;

namespace PhaprosSerializationBoxStation
{
    public partial class FormTargetRecipe : Form
    {
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

        public FormTargetRecipe()
        {
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            int vWidth = 1524;
            int vHeight = 924;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        SQLConfig config = new SQLConfig();
        usableFunction usableFunction = new usableFunction();

        private void FormTargetRecipe_Load(object sender, EventArgs e)
        {
            //FormTargetRecipe formTargetRecipe = new FormTargetRecipe();
            //formTargetRecipe.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, formTargetRecipe.Width, formTargetRecipe.Height, 20, 20));
            panel1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel1.Width, panel1.Height, 20, 20));
            panel2.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel2.Width, panel2.Height, 20, 20));
            btn_MainMenu.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn_MainMenu.Width, btn_MainMenu.Height, 20, 20));
            btnAdd.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnAdd.Width, btnAdd.Height, 20, 20));
            btnEdit.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnEdit.Width, btnEdit.Height, 20, 20));
            btnCancel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnCancel.Width, btnCancel.Height, 20, 20));
            btnDelete.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnDelete.Width, btnDelete.Height, 20, 20));
            dgvGenCode.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, dgvGenCode.Width, dgvGenCode.Height, 20, 20));

            kodeotomatis();
            tampil_data();
            distext();
            dgvGenCode.Enabled = false;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (btnAdd.Text == "Add")
            {
                //enabText();
                tbRecipeCode.Enabled = true;
                tbQtyTarget.Enabled = true;
                dgvProduk.Visible = true;
                dgvGenCode.Visible = false;
                tbQtyTarget.Focus();
                btnAdd.Text = "Save";
                btnDelete.Enabled = false;
                btnEdit.Enabled = false;
            }
            else if (btnAdd.Text == "Save")
            {
                if (tbProductCode.TextLength == 0)
                {
                    MessageBox.Show(" Kode Produk Tidak Boleh Kosong!!!", "Error Entry!!..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (tbProductName.TextLength == 0)
                {
                    MessageBox.Show(" Nama Produk Tidak Boleh Kosong!!!", "Error Entry!!..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (tbBatch.TextLength == 0)
                {
                    MessageBox.Show(" No. Batch Tidak Boleh Kosong!!!", "Error Entry!!..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (tbQtyTarget.TextLength == 0)
                {
                    MessageBox.Show(" Target Qty Boleh Kosong!!!", "Error Entry!!..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    simpanData();
                    tampil_data();
                    distext();
                    clearText();
                    dgvProduk.Visible = false;
                    dgvGenCode.Visible = true;
                    btnAdd.Text = "Add";
                    btnDelete.Enabled = true;
                    btnEdit.Enabled = true;
                }
            }
        }

        private void enabText()
        {
            tbRecipeCode.Enabled = true;
            tbProductCode.Enabled = true;
            tbProductName.Enabled = true;
            tbBatch.Enabled = true;
            tbQtyTarget.Enabled = true;
        }

        private void distext()
        {
            tbRecipeCode.Enabled = false;
            tbProductCode.Enabled = false;
            tbProductName.Enabled = false;
            tbQtyTarget.Enabled = false;
            tbBatch.Enabled = false;
            
        }

        private void clearText()
        {
            tbProductCode.Text = "";
            tbProductName.Text = "";
            tbRecipeCode.Text = "";
            tbQtyTarget.Text = "";
            tbBatch.Text = "";
            
        }

        private void simpanData()
        {
            config.Init_Con();
            config.con.Open();
            string query = "insert into tbltargetrecipe(idRecipe, kodeRecipe, kodeProduk, namaProduk, noBatch, targetRecipe)values('" + lb_IDRecipe.Text + "', '" + tbRecipeCode.Text + "','" + tbProductCode.Text + "','" + tbProductName.Text + "','" + tbBatch.Text + "','" + tbQtyTarget.Text + "')";
            MySqlCommand cmd = new MySqlCommand(query, config.con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Data Target Recipe Berhasil dibuat!");
            config.con.Close();
            kodeotomatis();
        }

        private void deleteData()
        {
            config.Init_Con();
            config.con.Open();
            string query = "Delete from tbltargetrecipe where idRecipe='" + lb_IDRecipe.Text + "'";
            MySqlCommand cmd = new MySqlCommand(query, config.con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Data Target Recipe Telah Di Hapus");
            config.con.Close();
            kodeotomatis();
        }

        private void tampil_data()
        {
            config.Init_Con();
            config.con.Open();
            string query = "SELECT idRecipe AS 'ID Recipe', kodeRecipe AS 'Kode Recipe',kodeProduk AS 'Kode Produk',namaProduk AS 'Nama Produk', noBatch AS 'No Batch', targetRecipe AS 'Qty Target Recipe' FROM tbltargetrecipe";
            MySqlDataAdapter sda = new MySqlDataAdapter(query, config.con);
            sda.SelectCommand.ExecuteNonQuery();
            DataTable dataTable = new DataTable();
            sda.Fill(dataTable);
            dgvGenCode.DataSource = dataTable;
            config.con.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            btnAdd.Enabled = false;
            btnDelete.Enabled = false;
            if (btnEdit.Text == "Edit")
            {
                btnEdit.Text = "Save";
                string message = "Apakah Kamu Mau Edit Data?";
                string title = "Edit Data";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    //enabText();
                    tbQtyTarget.Enabled = true;
                    dgvGenCode.Enabled = true;
                    


                }
                else
                {
                    
                    btnEdit.Text = "Edit";
                    dgvGenCode.Enabled = false;
                    btnAdd.Enabled = true;
                    btnDelete.Enabled = true;
                }

            }
            else if (btnEdit.Text == "Save")
            {
                if (tbQtyTarget.TextLength == 0)
                {
                    MessageBox.Show(" Qty Target  Tidak Boleh Kosong!!!", "Silahkan Pilih Data Pada Tabel!!..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                    
                }
                else
                {
                    UpdateData();
                    tampil_data();
                    clearText();

                    tbQtyTarget.Enabled = false;
                    btnEdit.Text = "Edit";
                    dgvGenCode.Enabled = false;
                    btnAdd.Enabled = true;
                    btnDelete.Enabled = true;
                }
            }
            else
            {
                btnEdit.Text = "&Save";
            }


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnCancel.Enabled = false;

            if (btnDelete.Text == "Delete")
            {
                btnDelete.Text = "Delete Data";
                string message = "Are You Sure Want to Delete Data?";
                string title = "Confirmation";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {

                    dgvGenCode.Enabled = true;


                }
                else
                {
                    btnDelete.Text = "Delete";
                    dgvGenCode.Enabled = false;
                    btnAdd.Enabled = true;
                    btnEdit.Enabled = true;
                    btnCancel.Enabled = true;
                }
            }
            else if (btnDelete.Text == "Delete Data")
            {
                if (tbRecipeCode.Text.Length == 0 && tbQtyTarget.Text.Length == 0)
                {
                    MessageBox.Show("Silahkan Pilih Data Pada Tabel!!..", "Error Delete..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    deleteData();
                    tampil_data();
                    clearText();
                    btnDelete.Text = "Delete";
                    dgvGenCode.Enabled = false;
                    btnAdd.Enabled = true;
                    btnEdit.Enabled = true;
                    btnCancel.Enabled = true;
                }

            }
            else
            {
                btnDelete.Text = "Delete";
            }


        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btn_MainMenu_Click(object sender, EventArgs e)
        {
            FormMain formMain = new FormMain();
            formMain.Show();
            this.Hide();
        }

        private void tbRecipeCode_TextChanged(object sender, EventArgs e)
        {
            config.Init_Con();
            config.con.Open();
            string sql = "Select kodeRecipe, kodeProduk, namaProduk, noBatch from tbldatarecipe where kodeRecipe LIKE '%" + tbRecipeCode.Text + "%' OR  namaProduk LIKE '%" + tbRecipeCode.Text + "%'  ";
            MySqlDataAdapter sda = new MySqlDataAdapter(sql, config.con);
            DataSet ds = new DataSet();
            sda.Fill(ds, "abc");
            dgvProduk.DataSource = ds;
            dgvProduk.DataMember = "abc";
            config.con.Close();
        }

        private void dgvProduk_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            tbRecipeCode.Text = dgvProduk.SelectedRows[0].Cells[0].Value.ToString();
            tbProductCode.Text = dgvProduk.SelectedRows[0].Cells[1].Value.ToString();
            tbProductName.Text = dgvProduk.SelectedRows[0].Cells[2].Value.ToString();
            tbBatch.Text = dgvProduk.SelectedRows[0].Cells[3].Value.ToString();
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            distext();
            clearText();
            btnAdd.Text = "Add";
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            dgvGenCode.Visible = true;
            dgvProduk.Visible = false;
        }

        private void PilihData()
        {
            tbRecipeCode.Text = dgvGenCode.SelectedRows[0].Cells[0].Value.ToString();
            tbProductCode.Text = dgvGenCode.SelectedRows[0].Cells[1].Value.ToString();
            tbProductName.Text = dgvGenCode.SelectedRows[0].Cells[2].Value.ToString();
            tbBatch.Text = dgvGenCode.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void dgvProduk_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbRecipeCode.Text = dgvProduk.SelectedRows[0].Cells[0].Value.ToString();
            tbProductCode.Text = dgvProduk.SelectedRows[0].Cells[1].Value.ToString();
            tbProductName.Text = dgvProduk.SelectedRows[0].Cells[2].Value.ToString();
            tbBatch.Text = dgvProduk.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void dgvGenCode_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lb_IDRecipe.Text = dgvGenCode.SelectedRows[0].Cells[0].Value.ToString();
            tbRecipeCode.Text = dgvGenCode.SelectedRows[0].Cells[1].Value.ToString();
            tbProductCode.Text = dgvGenCode.SelectedRows[0].Cells[2].Value.ToString();
            tbProductName.Text = dgvGenCode.SelectedRows[0].Cells[3].Value.ToString();
            tbBatch.Text = dgvGenCode.SelectedRows[0].Cells[4].Value.ToString();
            tbQtyTarget.Text = dgvGenCode.SelectedRows[0].Cells[5].Value.ToString();
        }

        public void UpdateData()
        {
            config.Init_Con();
            config.con.Open();
            MySqlCommand cmd = new MySqlCommand("update tbltargetrecipe set  targetRecipe='" + tbQtyTarget.Text + "' where idRecipe='" + lb_IDRecipe.Text + "'", config.con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Data Berhasil diUpdate!");

            config.con.Close();
            kodeotomatis();
        }

        public void kodeotomatis()
        {
            int tambahsatu;
            string kode;
            config.Init_Con();
            config.con.Open();
            MySqlCommand cmd = new MySqlCommand("select idRecipe from tbltargetrecipe where idRecipe in(select max(idRecipe) from tbltargetrecipe) order by idRecipe desc", config.con);
            MySqlDataReader sdr = cmd.ExecuteReader();
            sdr.Read();
            if (sdr.HasRows)
            {
                tambahsatu = Convert.ToInt32(sdr[0].ToString().Substring(sdr[0].ToString().Length - 4, 4)) + 1;
                string gabung = "0000" + tambahsatu;
                kode = "RQ" + gabung.Substring(gabung.ToString().Length - 4, 4);
            }
            else
            {
                kode = "RQ0001";
            }
            sdr.Close();
            lb_IDRecipe.Text = kode;
            config.con.Close();
        }
    }
}
