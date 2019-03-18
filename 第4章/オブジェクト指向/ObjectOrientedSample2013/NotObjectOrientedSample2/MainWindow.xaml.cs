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

namespace NotObjectOrientedSample
{
    // ステップアップ課題 4.10  ー オブジェクト指向ではない例

    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            OpendWindows.CloseChildren(this);
            OpendWindows.CloseParent(this);
        }

        private void OpenNewWindowButton_Click(object sender, RoutedEventArgs e)
        {
            OpendWindows.OpenNewChild(this);
        }

    }
}
