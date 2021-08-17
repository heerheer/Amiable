using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Amiable.UITest
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private static MainWindow _instance;
        public static MainWindow Instance
        {
            get
            {
                if (_instance is null)
                {
                    _instance = new MainWindow();
                    _instance.Closed += delegate (object sender, System.EventArgs e)
                    {
                        _instance = null;
                    };
                }
                _instance.Show();
                return _instance;
            }

        }


        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
