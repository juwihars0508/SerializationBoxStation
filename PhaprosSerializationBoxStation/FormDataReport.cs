using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using MySql.Data.MySqlClient;
using PhaprosSerializationBoxStation.Includes;

namespace PhaprosSerializationBoxStation
{
    public partial class FormDataReport : Form
    {
        public FormDataReport()
        {
            InitializeComponent();
        }

        public string vDataStatus;

        SQLConfig config = new SQLConfig();


        private void FormDataReport_Load(object sender, EventArgs e)
        {
            pnlReportGeneral.Visible = true;
            pnlReportBPOM.Visible = false;
            btnRptGnrl.BackColor = Color.DeepSkyBlue;
            btnRptBpom.BackColor = Color.Gray;
            btnRptReprint.BackColor = Color.Gray;
            loadWONo_Print();
        }

        private void loadWONo_Reprint()
        {
            cbWoReprint.Items.Clear();
            config.Init_Con();
            config.con.Open();
            //string sql = "";
            string sql = "select woNo from tblhistory_reprint GROUP BY woNo";
            MySqlCommand cmd = new MySqlCommand(sql, config.con);
            MySqlDataReader dr;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                cbWoReprint.Items.Add(dr[0].ToString());


            }

            dr.Close();
            config.con.Close();
            cbWoReprint.SelectedIndex = 0;
        }

        private void loadWONo_Print()
        {
            cb_wo.Items.Clear();
            config.Init_Con();
            config.con.Open();
            //string sql = "";
            string sql = "select wo_no from tblhistory_print GROUP BY wo_no";
            MySqlCommand cmd = new MySqlCommand(sql, config.con);
            MySqlDataReader dr;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                cb_wo.Items.Add(dr[0].ToString());


            }

            dr.Close();
            config.con.Close();
            cb_wo.SelectedIndex = 0;

            
        }

        private void loadData()
        {
            config.Init_Con();
            config.con.Open();
            string sql = "SELECT ACTION AS 'Action', product AS 'ID Kemasan', data_print AS 'Barcode' ,  kodeNIE AS  'NIE', ' ' AS 'Lot No'  ,  expDate AS 'Exp Date' ,  noBatch AS 'Batch No' , ' ' as 'GTIN'  , is_Active AS  'IS_ACTIVE',   is_Sample AS 'IS_SAMPLE',  is_Reject AS 'IS_REJECT',   mfdDate AS 'MFG DATE', GTIN_code as 'SEKUNDER' ,   ' ' as'TERSiER' FROM viewdatareportserialization";
            config.Load_DTG(sql, dataGridView1);
            config.con.Close();
        }

        private void btn_MainMenu_Click(object sender, EventArgs e)
        {
            FormMain formMain = new FormMain();
            formMain.Show();
            this.Hide();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            // creating Excel Application  
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            // creating new WorkBook within Excel application  
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            // creating new Excelsheet in workbook  
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            // see the excel sheet behind the program  
            app.Visible = true;
            // get the reference of first sheet. By default its name is Sheet1.  
            // store its reference to worksheet  
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            // changing the name of active sheet  
            worksheet.Name = "Report Serialisasi BPOM";
            // storing header part in Excel  
            for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
            }
            // storing Each row and column value to excel sheet  
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                }
            }
            // save the application  
            workbook.SaveAs(@"reports\output.xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            // Exit from the application  
            app.Quit();

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (vDataStatus == "true")
            {
                //Report Good
                config.Init_Con();
                config.con.Open();
                string sql = "Select wo_no as 'WO NO', noBatch as 'Batch No', product as 'Product', data_print as 'Datamatrix', status as 'Status' from tblhistory_print where status=1";
                config.Load_DTG(sql, dgvRptGnrl);
                config.con.Close();
            }
            else if (vDataStatus == "false")
            {
                //Report All
                config.Init_Con();
                config.con.Open();
                string sql = "Select wo_no as 'WO NO', noBatch as 'Batch No', product as 'Product', data_print as 'Datamatrix', status as 'Status' from tblhistory_print";
                config.Load_DTG(sql, dgvRptGnrl);
                config.con.Close();
            }
            else
            {
                MessageBox.Show("Pilih Salah satu");
            }
        }

        private void btnRptGnrl_Click(object sender, EventArgs e)
        {
            pnlReportBPOM.Visible = false;
            pnlRptRePrint.Visible = false;
            pnlReportGeneral.Visible = true;
            btnRptGnrl.BackColor = Color.DeepSkyBlue;
            btnRptBpom.BackColor = Color.Gray;
            btnRptReprint.BackColor = Color.Gray;
            loadWONo_Print();
        }

        private void btnRptBpom_Click(object sender, EventArgs e)
        {
            loadData();
            pnlReportBPOM.Visible = true;
            pnlReportGeneral.Visible = false;
            pnlRptRePrint.Visible = false;
            btnRptBpom.BackColor = Color.DeepSkyBlue;
            btnRptGnrl.BackColor = Color.Gray;
            btnRptReprint.BackColor = Color.Gray;
        }

        private void CbAll_CheckedChanged(object sender, EventArgs e)
        {
            if(CbAll.Checked == true)
            {
                vDataStatus = "false";
            }
            else
            {
                vDataStatus = "";
            }

        }

        private void CbGood_CheckedChanged(object sender, EventArgs e)
        {
            if(CbGood.Checked == true)
            {
                vDataStatus = "true";
            }
            else
            {
                vDataStatus = "";
            }
        }

        private void btnSearchReprint_Click(object sender, EventArgs e)
        {
            config.Init_Con();
            config.con.Open();
            string sql = "Select woNo as 'WO NO', productName as 'Product Name', noBatch as 'Batch No', dataSerial as 'Datamatrix', create_Date as 'Create Date' from tblhistory_reprint where woNo='"+ cbWoReprint.Text +"'";
            config.Load_DTG(sql, dgvReprint);
            config.con.Close();
        }

        private void btnRptReprint_Click(object sender, EventArgs e)
        {
            pnlReportBPOM.Visible = false;
            pnlRptRePrint.Visible = true;
            pnlReportGeneral.Visible = false;
            btnRptGnrl.BackColor = Color.Gray;
            btnRptBpom.BackColor = Color.Gray;
            btnRptReprint.BackColor = Color.DeepSkyBlue;
            loadWONo_Reprint();
        }
    }

}

