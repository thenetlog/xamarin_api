using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace Report.ViewModels
{
    public class OpeningViewModel : BaseViewModel
    {
        public OpeningViewModel()
        {
            Title = "Opening";

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://xamarin.com/platform")));
        }

        public ICommand OpenWebCommand { get; }
    }
}