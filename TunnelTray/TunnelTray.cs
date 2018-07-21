using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace TunnelTray
{
    public class TunnelTray : Form
    {
        private NotifyIcon TrayIcon;
        private ContextMenu TrayMenu;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TunnelTray());
        }

        public TunnelTray()
        {
            // Create a simple tray menu with only one item.
            TrayMenu = new ContextMenu();
            TrayMenu.MenuItems.Add("Exit", OnExit);

            // Create a tray icon. In this example we use a
            // standard system icon for simplicity, but you
            // can of course use your own custom icon too.
            TrayIcon = new NotifyIcon();
            TrayIcon.Text = "MyTrayApp";
            TrayIcon.Icon = new Icon(SystemIcons.Application, 40, 40);

            // Add menu to tray icon and show it.
            TrayIcon.ContextMenu = TrayMenu;
            TrayIcon.Visible = true;
        }

        protected override void OnLoad(EventArgs e)
        {
            Visible = false; // Hide form window.
            ShowInTaskbar = false; // Remove from taskbar.

            base.OnLoad(e);
        }

        private void OnExit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        protected override void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {
                // Release the icon resource.
                TrayIcon.Dispose();
            }

            base.Dispose(isDisposing);
        }
    }
}
