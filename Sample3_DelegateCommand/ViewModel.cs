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
        public ICommand OneUpCommand { get; set; }
        public ICommand OneDownCommand { get; set; }

        //コンストラクターでコマンドに処理を追加
        public ViewModel()
        {
            OneUpCommand = new DelegateCommand(OneUp);
            OneDownCommand = new DelegateCommand(OneDown);
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
    public class DelegateCommand : ICommand
    {
        //returenがない場合はActionを使う
        private Action execute;

        //returnがある場合はFuncを使う
        private Func<bool> canExecute;

        /// <summary>
        /// 渡されたExecuteメソッドを実行するインスタンスを作成
        /// </summary>
        /// <param name="execute">Executeメソッドで実行する処理</param>
        public DelegateCommand(Action execute) : this(execute, () => true)
        {
        }

        /// <summary>
        /// 渡されたExecuteメソッド・CanExecuteメソッドを実行するインスタンスを作成
        /// </summary>
        /// <param name="execute">Executeメソッドで実行する処理</param>
        /// <param name="canExecute">CanExecuteメソッドで実行する処理</param>
        public DelegateCommand(Action execute, Func<bool> canExecute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("execute");
            }

            if (canExecute == null)
            {
                throw new ArgumentNullException("canExecute");
            }

            this.execute = execute;
            this.canExecute = canExecute;
        }

        /// <summary>
        /// コマンドを実行
        /// </summary>
        public void Execute()
        {
            execute();
        }

        /// <summary>
        /// コマンドが実行可能かどうか
        /// </summary>
        /// <returns>実行可能な場合はtrue</returns>
        public bool CanExecute()
        {
            return canExecute();
        }

        /// <summary>
        /// ICommand.CanExecuteの明示的な宣言
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        bool ICommand.CanExecute(object parameter)
        {
            return CanExecute();
        }

        /// <summary>
        /// CanExecuteの結果に変更があったことを通知するイベント
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// ICommand.Executeの明示的な宣言
        /// </summary>
        /// <param name="parameter"></param>
        void ICommand.Execute(object parameter)
        {
            Execute();
        }
    }
}

