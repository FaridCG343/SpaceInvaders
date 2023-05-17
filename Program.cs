using SpaceInvaders.Models;

namespace SpaceInvaders
{
    internal static class Program
    {
        public static Form level;
        public static FormMenu menu = new();
        public static Nave nave = new();
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(menu);
        }
    }
}