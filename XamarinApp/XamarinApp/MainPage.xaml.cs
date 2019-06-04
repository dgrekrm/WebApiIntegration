using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinApp.Managers;

namespace XamarinApp {
    public partial class MainPage : ContentPage {
        public MainPage() {
            this.IsBusy = true;
            Thread.Sleep(5 * 1000);
            InitializeComponent();
            var result = new BookManager().GetBooks();
            if(!result.Item1) ErrorMessage.Text = result.Item2;
            Books.BindingContext = result.Item3;
            this.IsBusy = false;
        }
    }
}
