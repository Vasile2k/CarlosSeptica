using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarlosSeptica
{
    public partial class InterfaceForm : Form
    {
        public InterfaceForm()
        {
            InitializeComponent();
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Brushes.Black);
            e.Graphics.DrawLine(pen, 0, 0, 100, 100);
            Card c = new Card(CardNumber.CARD_7);

            c.Draw(e.Graphics, 150, 350, true);
            c.Draw(e.Graphics, 150, 550, false);
        }
    }
}
