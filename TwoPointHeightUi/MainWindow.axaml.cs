using Avalonia.Controls;

namespace TwoPointHeightUi
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {


            InitializeComponent();

            Closing += (s, e) =>
            {
                Hide();
                e.Cancel = true;
            };

            CanResize = false;
            
        }


    }
}