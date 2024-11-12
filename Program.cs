using System;
using System.Windows.Forms;

namespace _25453_TP_POO
{
    static class Program
    {
        [STAThread]
        static void Main()
        {

            ApplicationConfiguration.Initialize();
            Application.Run(new LandPage());
        }
    }
}
