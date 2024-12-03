using System;
using System.Windows.Forms;

namespace POO_25453_TP
{
    static class Program
    {
        [STAThread]
        static void Main()
        {

            ApplicationConfiguration.Initialize();
            Application.Run(new LoginSelectionForm());
        }
    }
}
