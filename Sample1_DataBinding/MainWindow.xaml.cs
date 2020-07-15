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

namespace Sample1_DataBinding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // ViewModelオブジェクトの生成
        ViewModel viewModel = new ViewModel();

        public MainWindow()
        {
            InitializeComponent();

            // データコンテキストの設定
            DataContext = viewModel;
        }

        //クリックイベントでViewModelのカウントアップ、カウントダウンメソッドを実行
        private void OneUp_Click(object sender, RoutedEventArgs e)
        {
            viewModel.OneUp();
        }

        private void OneDown_Click(object sender, RoutedEventArgs e)
        {
            viewModel.OneDown();
        }
    }
}
