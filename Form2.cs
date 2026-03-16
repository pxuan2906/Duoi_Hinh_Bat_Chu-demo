using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_Duoi_Hinh_Bat_Chu
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = Color.DarkGray;
            btn.FlatAppearance.MouseDownBackColor = Color.DarkTurquoise;

            btn.BackColor = Color.LightGreen;
            btn.ForeColor = Color.White;

            btn.Font = new System.Drawing.Font("Time New Roman", 17.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            btn.Cursor = Cursors.Hand;
            btn.TabStop = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.ShowDialog();
            
        }
        
    }
}
