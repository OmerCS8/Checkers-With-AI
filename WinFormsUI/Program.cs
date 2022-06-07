using System;
using System.Windows.Forms;
using System.Configuration;


namespace WinFormsUI
{
    internal static class Program
    {
        //[STAThread]
        static void Main()
        {
            //// see https://aka.ms/applicationconfiguration.
            //ApplicationConfiguration.Initialize();
            //Application.Run(new FormWelcome());
            new FormWelcome().ShowDialog();
        }
    }
}