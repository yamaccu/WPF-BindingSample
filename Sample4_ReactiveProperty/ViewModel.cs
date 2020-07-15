using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Reactive.Bindings;


namespace Sample4_ReactiveProperty
{
    class ViewModel : INotifyPropertyChanged
    {
        //メモリリーク対策(?)
        public event PropertyChangedEventHandler PropertyChanged;

        //カウンターのバインディング先、RaisePropertyChange不要
        public ReactiveProperty<string> Counter { get; set; } = new ReactiveProperty<string>("0");

        //ボタンのコマンドのバインディング先
        public ReactiveCommand OneUpCommand { get; set; } = new ReactiveCommand();
        public ReactiveCommand OneDownCommand { get; set; } = new ReactiveCommand();

        //コンストラクタでReactiveCommandに処理を登録
        public ViewModel()
        {
            OneUpCommand.Subscribe(_ => OneUp());
            OneDownCommand.Subscribe(_ => OneDown());
        }

        //ボタンのコマンド処理
        private void OneUp()
        {
            //変数を使う場合は.Valueをつける（Xaml側でバインディングするときも.Valueが必要）
            Counter.Value = (Convert.ToString(Convert.ToInt32(Counter.Value) + 1));
        }

        private void OneDown()
        {
            Counter.Value = (Convert.ToString(Convert.ToInt32(Counter.Value) - 1));
        }
    }
}
