using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace control
{
    public partial class Form1 : Form
    {
        private ColorDialog colorDialog1;
        private FontDialog fontDialog1;
        private Timer timer1;

        public Form1()
        {
            InitializeComponent();
            colorDialog1 = new ColorDialog();
            fontDialog1 = new FontDialog();
            timer1 = new Timer();
        }

        private void ButtonOpenFileDialog_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                PictureBox pictureBox1 = (PictureBox)this.Controls.OfType<PictureBox>().FirstOrDefault();
                if (pictureBox1 != null)
                {
                    pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                }
            }
        }

        private void выходToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void цветТекстаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            label1.ForeColor = colorDialog1.Color;
        }

        private void шрифтToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            label1.Font = fontDialog1.Font;
        }

        private void часыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Interval = 1000;
            timer1.Tick += delegate { label2.Text = DateTime.Now.ToLongTimeString() + "далее время по частям:" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.ToString(); };
        }

        private void расчетОстаткаВремениToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            DateTime dt1 = dateTimePicker1.Value;
            label2.Text = "До даты " + dt1.ToLongDateString() + " осталось " + (dt1 - DateTime.Now).Days + " дней";
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            ListView lv1 = new ListView();
            lv1.Name = "lv1";
            lv1.Size = new Size(360, 160);
            lv1.Location = new Point(50, 200);
            lv1.View = View.Details;
            lv1.Columns.Add("тип элемента", 240);
            lv1.Columns.Add("имя элемента", 120);
            Controls.Add(lv1);
            foreach (Control c1 in Controls)
            {
                string[] s2 = new string[2];
                s2[0] = c1.GetType().ToString();
                s2[1] = c1.Name;
                ListViewItem lvi1 = new ListViewItem(s2);
                lv1.Items.Add(lvi1);
            }
        }
    }
}