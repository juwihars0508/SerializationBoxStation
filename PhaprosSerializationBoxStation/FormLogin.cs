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
    public partial class FormLogin : Form
    {
        private Size formOriginalSize;
        private Rectangle recBut1;
        private Rectangle recBut2;
        private Rectangle recTxt1;
        private Rectangle recLbl1;
        private Rectangle recLbl2;
        private Rectangle recLbl3;
        private Rectangle recLbl4;
        private Rectangle recLbl5;
        private Rectangle recPnl1;
        private Rectangle recPnl2;
        private Rectangle recPnl3;
        private Rectangle recPnl4;
        private Rectangle recCbBox;
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

        public FormLogin()
        {
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;

            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            this.Resize += Form2_Resize;
            formOriginalSize = this.Size;
            recBut1 = new Rectangle(btn_IN.Location, btn_IN.Size);
            recBut2 = new Rectangle(btnMin.Location, btnMin.Size);
            recTxt1 = new Rectangle(tbPass.Location, tbPass.Size);
            recPnl1 = new Rectangle(panel1.Location, panel1.Size);
            recPnl2 = new Rectangle(panel2.Location, panel2.Size);
            recPnl3 = new Rectangle(panel3.Location, panel3.Size);
            recPnl4 = new Rectangle(panel4.Location, panel4.Size);
            recLbl1 = new Rectangle(label1.Location, label1.Size);
            recLbl2 = new Rectangle(label2.Location, label2.Size);
            recLbl3 = new Rectangle(label3.Location, label3.Size);
            recLbl4 = new Rectangle(label4.Location, label4.Size);
            recLbl5 = new Rectangle(label5.Location, label5.Size);
            recCbBox = new Rectangle(CB_User.Location, CB_User.Size);
            recPicBox1 = new Rectangle(pictureBox1.Location, pictureBox1.Size);
        }

        public string Vuser;
        public string Vpass;

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btn_IN_Click(object sender, EventArgs e)
        {
            if (CB_User.Text== "Administrator"  && tbPass.Text =="admin123" )
            {
                varGlobal.Username = CB_User.Text;
                FormMain mainMenu = new FormMain();
                mainMenu.Show();
                this.Hide();

            }
            else if (CB_User.Text == "Supervisor" && tbPass.Text == "spv123")
            {
                varGlobal.Username = CB_User.Text;
                FormMain mainMenu = new FormMain();
                mainMenu.Show();
                this.Hide();
            }
            else if (CB_User.Text == "Operator 1" && tbPass.Text == "opt123")
            {
                varGlobal.Username = CB_User.Text;
                FormMain mainMenu = new FormMain();
                mainMenu.Show();
                this.Hide();
            }
            else if (CB_User.Text == "Operator 2" && tbPass.Text == "opt321")
            {
                varGlobal.Username = CB_User.Text;
                FormMain mainMenu = new FormMain();
                mainMenu.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Username or Password NotFound", "Perhatian..", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            btn_IN.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn_IN.Width, btn_IN.Height, 10, 10));
            //int h = Screen.PrimaryScreen.WorkingArea.Height;
            //int w = Screen.PrimaryScreen.WorkingArea.Width;
            //this.ClientSize = new Size(900, 1444);
            //Clear all Data
            CB_User.Items.Clear();

            //init Data
            List<varDataState> list = new List<varDataState>();
            list.Add(new varDataState() { ID = "01", Name = "Administrator" });
            list.Add(new varDataState() { ID = "02", Name = "Supervisor" });
            list.Add(new varDataState() { ID = "03", Name = "Operator 1" });
            list.Add(new varDataState() { ID = "04", Name = "Operator 2" });

            //set display member and value member for combobox
            CB_User.DataSource = list;
            CB_User.ValueMember = "ID";
            CB_User.DisplayMember = "Name";

        }

        private void GetItemsButton_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string name in CB_User.Items)
            {
                sb.Append(name);
                sb.Append(" ");
            }
            MessageBox.Show(sb.ToString());
        }

       
        private void CB_User_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(CB_User.Text);
        }

        private void CB_User_SelectionChangeCommitted(object sender, EventArgs e)
        {
            varDataState obj = CB_User.SelectedItem as varDataState;
            if (obj != null)
                Vuser = obj.Name;
        }

        private void Form2_Resize(object sender, EventArgs e)
        {
            //resize_Control(pictureBox1, recCbBox);
            resize_Control(btn_IN, recBut1);
            resize_Control(btnMin, recBut2);
            resize_Control(tbPass, recTxt1);
            resize_Control(label1, recLbl1);
            resize_Control(label2, recLbl2);
            resize_Control(label3, recLbl3);
            resize_Control(label4, recLbl4);
            resize_Control(label5, recLbl5);
            resize_Control(panel1, recPnl1);
            resize_Control(panel2, recPnl2);
            resize_Control(panel3, recPnl3);
            resize_Control(panel4, recPnl4);
            resize_Control(CB_User, recCbBox);
            resize_Control(pictureBox1, recPicBox1);
            
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to close appliaction?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
