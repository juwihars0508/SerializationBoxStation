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
using PhaprosSerializationBoxStation.Includes;

namespace PhaprosSerializationBoxStation
{
    public partial class FormReport : Form
    {
        private Size formOriginalSize;
        private Rectangle recBut1;
        private Rectangle recBut2;
        private Rectangle recBut3;
        private Rectangle recPicBox1;
        private Rectangle recPnl1;
        private Rectangle recLblH1;
        private Rectangle recLblH2;
        private Rectangle recLblH3;
        private Rectangle recRptView;

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

        public FormReport()
        {
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            this.Resize += Form6_Resize;
            formOriginalSize = this.Size;
            recBut1 = new Rectangle( button1.Location, button1.Size);
            recBut2 = new Rectangle(btn_MainMenu.Location, btn_MainMenu.Size);
            recBut3 = new Rectangle(btnMin.Location, btnMin.Size);
            recPicBox1 = new Rectangle(pictureBox1.Location, pictureBox1.Size);
            recPnl1 = new Rectangle(panel2.Location, panel2.Size);
            recLblH1 = new Rectangle(label7.Location, label7.Size);
            recLblH2 = new Rectangle(lblUser.Location, lblUser.Size);
            recLblH3 = new Rectangle(lblTime.Location, lblTime.Size);
            recRptView = new Rectangle(crystalReportViewer1.Location, crystalReportViewer1.Size);

        }

        SQLConfig config = new SQLConfig();
        string sql;
        private void reports(string sql, string rptname)
        {

            try
            {

                config.loadReports(sql);

                string reportname = rptname;


                CrystalDecisions.CrystalReports.Engine.ReportDocument reportdoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();

                string strReportPath = Application.StartupPath + "\\reports\\" + reportname + ".rpt";


                reportdoc.Load(strReportPath);
                reportdoc.SetDataSource(config.dt);

                crystalReportViewer1.ReportSource = reportdoc;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "No crystal reports installed. Pls. contact administrator.");
            }


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void btn_MainMenu_Click(object sender, EventArgs e)
        {
            FormMain MainMenu = new FormMain();
            MainMenu.Show();
            this.Hide();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            btn_MainMenu.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn_MainMenu.Width, btn_MainMenu.Height, 20, 20));
            button1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button1.Width, button1.Height, 20, 20));
            panel2.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel2.Width, panel2.Height, 20, 20));
            lblUser.Text = varGlobal.Username;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sql = "SELECT * FROM viewdatareportserialization";
            reports(sql, "CrptHistory_Print");
        }

        private void Form6_Resize(object sender, EventArgs e)
        {
            resize_Control(button1, recBut1);
            resize_Control(btn_MainMenu, recBut2);
            resize_Control(btnMin, recBut3);
            resize_Control(pictureBox1, recPicBox1);
            resize_Control(panel2, recPnl1);
            resize_Control(label7, recLblH1);
            resize_Control(lblUser, recLblH2);
            resize_Control(lblTime, recLblH3);
            resize_Control(crystalReportViewer1, recRptView);
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
