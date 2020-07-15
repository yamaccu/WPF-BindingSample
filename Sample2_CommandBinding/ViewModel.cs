using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Windows.Input;

namespace Sample2_CommandBinding
{
    public class ViewModel : ViewModelBase
    {
        //カウンターのバインディング先の変数
        private string counter = "0";
        public string Counter
        {
            get { return counter; }
            set
            {
                counter = value;
                RaisePropertyChanged("Counter");
            }
        }

        //カウントアップ、カウントダウンボタンのコマンドのバインディング先
        public ICommand OneUpCommand { get; set; }
        public ICommand OneDownCommand { get; set; }

        //コンストラクターでコマンドに処理を追加
        public ViewModel()
        {
            OneUpCommand = new OneUpCommandImpl(this);
            OneDownCommand = new OneDownCommandImpl(this);
        }


        /// <summary>
        /// 1 UPの処理
        /// </summary>
        public void OneUp()
        {
            Counter = (Convert.ToString(Convert.ToInt32(Counter) + 1));
        }

        /// <summary>
        /// 1 Downの処理
        /// </summary>
        public void OneDown()
        {
            Counter = (Convert.ToString(Convert.ToInt32(Counter) - 1));
        }

    }


    /// <summary>
    /// INotifyPropertyChanged
    /// プロパティに変更があったら、値をDataContext経由でViewへ通知する
    /// </summary>
    public class ViewModelBase : INotifyPropertyChanged
    {
        /// <summary>
        /// プロパティの変更を通知
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// PropertyChangedイベントを実行
        /// </summary>
        /// <param name="propertyName">プロパティ名</param>
        protected virtual void RaisePropertyChanged(string propertyName)
        {
            var h = this.PropertyChanged;
            if (h != null)
            {
                h(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <summary>
    /// 1 UPのIComand
    /// </summary>
    public class OneUpCommandImpl : ICommand
    {
        public OneUpCommandImpl(ViewModel viewmodel)
        {
            vm = viewmodel;
        }

        private ViewModel vm;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        //処理の実体
        public void Execute(object parameter)
        {
            vm.OneUp();
        }
    }

    /// <summary>
    /// 1 DownのICommand
    /// </summary>
    public class OneDownCommandImpl : ICommand
    {
        public OneDownCommandImpl(ViewModel viewmodel)
        {
            vm = viewmodel;
        }

        private ViewModel vm;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        //処理の実体
        public void Execute(object parameter)
        {
            vm.OneDown();

        }
    }
}
