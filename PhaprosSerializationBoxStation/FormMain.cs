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

namespace PhaprosSerializationBoxStation
{
    public partial class FormMain : Form
    {
        private Size formOriginalSize;
        private Rectangle recBut1;
        private Rectangle recBut2;
        private Rectangle recBut3;
        private Rectangle recBut4;
        private Rectangle recBut5;
        private Rectangle recBut6;
        private Rectangle recBut7;
        private Rectangle recLbl1;
        private Rectangle recLbl2;
        private Rectangle recLbl3;
        private Rectangle recPnl1;
        private Rectangle recPnl2;
        private Rectangle recPicBox1;

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

        public FormMain()
        {
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            this.Resize += Form7_Resize;
            formOriginalSize = this.Size;
            recBut1 = new Rectangle(btn_LogOut.Location, btn_LogOut.Size);
            recBut2 = new Rectangle(btn_MenuDataPrint.Location, btn_MenuDataPrint.Size);
            recBut3 = new Rectangle(btn_MenuCreateSKU.Location, btn_MenuCreateSKU.Size);
            recBut4 = new Rectangle(btn_MenuGenerateSKU.Location, btn_MenuGenerateSKU.Size);
            recBut5 = new Rectangle(btn_MenuCreateWO.Location, btn_MenuCreateWO.Size);
            recBut6 = new Rectangle(btn_MenuReport.Location, btn_MenuReport.Size);
            recBut7 = new Rectangle(btnMin.Location, btnMin.Size);
            recLbl1 = new Rectangle(label1.Location, label1.Size);
            recLbl2 = new Rectangle(lblUser.Location, lblUser.Size);
            recLbl3 = new Rectangle(lblTime.Location, lblTime.Size);
            recPnl1 = new Rectangle(panel1.Location, panel1.Size);
            recPnl2 = new Rectangle(panel2.Location, panel2.Size);
            recPicBox1 = new Rectangle(pictureBox2.Location, pictureBox2.Size);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_LogOut_Click(object sender, EventArgs e)
        {
            FormLogin frmLogin = new FormLogin();
            frmLogin.Show();
            this.Hide();
        }

        private void btn_MenuDataPrint_Click(object sender, EventArgs e)
        {
            FormDataPrint frmPrintData = new FormDataPrint();
            frmPrintData.Show();
            this.Hide();
        }

        private void btn_MenuGenerateSKU_Click(object sender, EventArgs e)
        {
            FormTargetRecipe formTargetRecipe = new FormTargetRecipe();
            formTargetRecipe.Show();
            this.Hide();
        }

        private void btn_MenuCreateSKU_Click(object sender, EventArgs e)
        {
            FormDataSku frmCreateSKU = new FormDataSku();
            frmCreateSKU.Show();
            this.Hide();
        }

        private void btn_MenuCreateWO_Click(object sender, EventArgs e)
        {
            FormDataWO frmCreateWO = new FormDataWO();
            frmCreateWO.Show();
            this.Hide();
        }

        private void btn_MenuReport_Click(object sender, EventArgs e)
        {
            FormDataReport frmReport = new FormDataReport();
            frmReport.Show();
            this.Hide();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            lblUser.Text = varGlobal.Username;
            panel2.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel2.Width, panel2.Height, 20, 20));
            panel3.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel3.Width, panel3.Height, 20, 20));
            btn_LogOut.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn_LogOut.Width, btn_LogOut.Height, 20, 20));
            btn_MenuDataPrint.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn_MenuDataPrint.Width, btn_MenuDataPrint.Height, 20, 20));
            btn_MenuCreateSKU.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn_MenuCreateSKU.Width, btn_MenuCreateSKU.Height, 20, 20));
            btn_MenuGenerateSKU.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn_MenuGenerateSKU.Width, btn_MenuGenerateSKU.Height, 20, 20));
            btn_MenuCreateWO.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn_MenuCreateWO.Width, btn_MenuCreateWO.Height, 20, 20));
            btn_MenuReport.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn_MenuReport.Width, btn_MenuReport.Height, 20, 20));
            btn_MenuReprint.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn_MenuReprint.Width, btn_MenuReprint.Height, 20, 20));

        }

        private void Form7_Resize(object sender, EventArgs e)
        {
            resize_Control(btn_LogOut, recBut1);
            resize_Control(btn_MenuDataPrint, recBut2);
            resize_Control(btn_MenuCreateSKU, recBut3);
            resize_Control(btn_MenuGenerateSKU, recBut4);
            resize_Control(btn_MenuCreateWO, recBut5);
            resize_Control(btn_MenuReport, recBut6);
            resize_Control(btnMin, recBut7);
            resize_Control(label1, recLbl1);
            resize_Control(lblUser, recLbl2);
            resize_Control(lblTime, recLbl3);
            resize_Control(panel1, recPnl1);
            resize_Control(panel2, recPnl2);
            resize_Control(pictureBox2, recPicBox1);
            
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
