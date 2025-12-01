namespace taschenrechner
{
    /// <summary>
    /// Entry point for the calculator application.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Enable high DPI support for modern displays
            ApplicationConfiguration.Initialize();
            
            // Start the calculator form
            Application.Run(new Form1());
        }
    }
}
