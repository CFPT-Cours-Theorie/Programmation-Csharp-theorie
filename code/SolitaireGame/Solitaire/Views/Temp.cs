using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Solitaire.Views
{
    public partial class Temp : Form
    {
        public Temp()
        {
            InitializeComponent();
        }

        private void Temp_Load(object sender, EventArgs e)
        {
            //
            picBx_imgTest.BorderStyle = BorderStyle.FixedSingle;
        }

        private void picBx_imgTest_Paint(object sender, PaintEventArgs e)
        {
            int borderWidth = 4; // épaisseur voulue
            Color borderColor = Color.Red;

            using (Pen pen = new Pen(borderColor, borderWidth))
            {
                e.Graphics.DrawRectangle(
                    pen,
                    borderWidth / 2,
                    borderWidth / 2,
                    picBx_imgTest.Width - borderWidth,
                    picBx_imgTest.Height - borderWidth
                );
            }
        }
    }
}
