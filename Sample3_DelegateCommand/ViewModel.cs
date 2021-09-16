using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Windows.Input;

namespace Sample3_DelegateCommand
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
        public Command OneUpCommand { get; set; }
        public Command OneDownCommand { get; set; }

        //コンストラクターでコマンドに処理を追加
        public ViewModel()
        {
            OneUpCommand = new Command(OneUp);
            OneDownCommand = new Command(OneDown);
        }


        /// <summary>
        /// 1 UPの処理
        /// </summary>
        public void OneUp()
        {
            var numValue = Convert.ToString(Convert.ToInt32(Counter) + 1);
            Counter = numValue;
        }

        /// <summary>
        /// 1 Downの処理
        /// </summary>
        public void OneDown()
        {
            var numValue = Convert.ToString(Convert.ToInt32(Counter) - 1);
            Counter = numValue;
        }

    }


    /// <summary>
    /// INotifyPropertyChanged
    /// プロパティに変更があったらViewへ通知する
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
    /// デリゲートでICommandを実装
    /// </summary>
    public class Command : ICommand
    {
        private Action execute;
        private bool canExecute = true;

        public Command(Action execute)
        {
            this.execute = execute;
        }

        public void Execute(object parameter)
        {
            execute();
        }

        public bool CanExecute(object parameter)
        {
            return canExecute;
        }

        public void SetCanExecute(bool canExecute)
        {
            this.canExecute = canExecute;
            if (CanExecuteChanged != null)
            {
                CanExecuteChanged(this, EventArgs.Empty);
            }
        }

        public event EventHandler CanExecuteChanged;
    }
}

