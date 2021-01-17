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
        public static InterfaceForm interfaceForm;

        [STAThread]
        public static void Main()
        {
            game = new Game();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            interfaceForm = new InterfaceForm();
            Application.Run(interfaceForm);
        }
    }
}
