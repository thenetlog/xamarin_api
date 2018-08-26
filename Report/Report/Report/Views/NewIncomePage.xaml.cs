using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Report.Models;

namespace Report.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewIncomePage : ContentPage
    {
        public Income Income { get; set; }

        public NewIncomePage()
        {
            InitializeComponent();

            Income = new Income
            {
                IncomeId = string.Empty,
                TransactionDate = DateTime.Now,
                DonarName = string.Empty,
                Amount = string.Empty
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddIncome", Income);
            await Navigation.PopModalAsync();
        }
    }
}