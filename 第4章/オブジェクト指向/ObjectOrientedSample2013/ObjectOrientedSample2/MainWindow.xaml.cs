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

namespace ObjectOrientedSample
{
    // ステップアップ課題 4.10  ー オブジェクト指向の例

    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        } // end constructor

        private MainWindow parent;
        private List<MainWindow> opendWindows = new List<MainWindow>();

        private void Window_Closed(object sender, EventArgs e)
        {
            foreach (var w in this.opendWindows)
            {
                w.Close();
            }

            if (this.parent != null) this.parent.Close();
        } // end sub

        private void OpenNewWindowButton_Click(object sender, RoutedEventArgs e)
        {
            var w = new MainWindow();
            this.opendWindows.Add(w);
            w.parent = this;
            w.Show();

        } // end sub

    } // end class
} // end namespace
