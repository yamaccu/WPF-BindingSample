using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Sample1_DataBinding
{
    class ViewModel : ViewModelBase
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

}