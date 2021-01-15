using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarlosSeptica
{
    public static class CarlosSeptica
    {
        public static Game game;

        [STAThread]
        public static void Main()
        {
            game = new Game();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new InterfaceForm());
        }
    }
}
