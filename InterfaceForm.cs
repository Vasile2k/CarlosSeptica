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
        private int selectedDifficulty = -1;

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
            //Debug.WriteLine("Update loop!");
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            CarlosSeptica.game.Start();
            
            buttonStart.Enabled = false;
            buttonStart.Visible = false;

            selectedDifficulty = GetSelectedDifficulty();
            difficulty.Enabled = false;
            difficulty.Visible = false;
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            Point coordinates = me.Location;

            CarlosSeptica.game.OnPlayerClick(coordinates.X, coordinates.Y);
        }

        public int GetDifficulty()
        {
            if(selectedDifficulty != -1)
            {
                return selectedDifficulty;
            }
            throw new Exception("Difficulty not selected!");
        }

        private int GetSelectedDifficulty()
        {
            if (radioButtonEz.Checked)
            {
                return 0;
            }
            if (radioButtonMedium.Checked)
            {
                return 1;
            }
            if (radioButtonHard.Checked)
            {
                return 2;
            }
            if (radioButtonImmortal.Checked)
            {
                return 3;
            }
            return -1;
        }
    }
}
