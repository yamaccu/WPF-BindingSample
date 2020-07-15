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

namespace Sample0_NotDataBinding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //クリックイベントでカウントアップ、カウントダウンを実装
        private void OneUp_Click(object sender, RoutedEventArgs e)
        {
            Counter.Text = Convert.ToString(Convert.ToInt32(Counter.Text) + 1);
        }

        private void OneDown_Click(object sender, RoutedEventArgs e)
        {
            Counter.Text = Convert.ToString(Convert.ToInt32(Counter.Text) - 1);
        }
    }
}
