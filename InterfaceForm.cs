using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
            CarlosSeptica.game.Draw(e.Graphics);
        }

        private void updateTimer_Tick(object sender, EventArgs e)
        {
            CarlosSeptica.game.Update();
            pictureBox.Refresh();
            Debug.WriteLine("Update loop!");
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            CarlosSeptica.game.Start();
            buttonStart.Enabled = false;
            buttonStart.Visible = false;
        }
    }
}
