using Autodesk.Revit.UI;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System;
using System.Runtime.InteropServices;

namespace RevaloniaAddin.Addins.Views
{
    public partial class MainWindow : Window
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, int uFlags);
        static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        private const int SWP_NOSIZE = 0x0001;
        private const int SWP_NOZORDER = 0x0004;
        private const int SWP_SHOWWINDOW = 0x0040;
        private const int SWP_NOMOVE = 0x0002;

        public MainWindow()
        {
            AvaloniaXamlLoader.Load(this);
            AddinCommand.WindowManager.AddinWindow.Add(this);

            Closing += (s, e) =>
            {
                Hide();
                e.Cancel = true;
            };

            IntPtr handle = this.PlatformImpl.Handle.Handle;

            SetWindowPos(handle, HWND_TOPMOST, 500, 500, 200, 300, SWP_NOMOVE | SWP_NOSIZE | SWP_SHOWWINDOW);


        }

    }
}
