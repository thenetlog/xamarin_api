using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Report.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OpeningPage : ContentPage
    {
        public OpeningPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            string Date2 = Date1.Date.ToString("dd-MM-yyyy");
            string Donar2 = Donar1.Text;
            string Amount2 = Amount1.Text;

            var res = DisplayAlert("Opening", "Date: " + Date2 + "\n" + "DonarName: " + Donar2 + "\n" + "Amount: " + Amount2, "OK");
        }
    }
}