using System;
using System.Windows.Forms;

namespace QuickWatchEx.TestUI {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var dbgWatch = new DebugControllerMock();

            Application.Run(new QuickWatch.QuickWatch(dbgWatch, "Expression"));
        }
    }
}
