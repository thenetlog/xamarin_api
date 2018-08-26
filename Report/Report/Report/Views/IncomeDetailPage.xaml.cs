using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Report.Models;
using Report.ViewModels;

namespace Report.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IncomeDetailPage : ContentPage
    {
        IncomeDetailViewModel viewModel;

        public IncomeDetailPage(IncomeDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public IncomeDetailPage()
        {
            InitializeComponent();

            var item = new Income
            {
                IncomeId = string.Empty,
                DonarName = string.Empty,
                Amount = string.Empty
            };

            viewModel = new IncomeDetailViewModel(item);
            BindingContext = viewModel;
        }

        async void UpdateClicked(object sender, EventArgs e)
        {
            bool valad = true;

            var incUp = viewModel.Item;
            await DisplayAlert("Warning", $"Update this ID: {incUp.IncomeId} ?", "Yes", "No");

            if(valad == true)
            {
                MessagingCenter.Send(this, "UpdateIncome", incUp);
                await DisplayAlert("Warning", $"Update Complete", "Ok");
                await Navigation.PopAsync();
            }
        }

        async void DeleteClicked(object sender, EventArgs e)
        {
            bool valad = true;

            var incDel = viewModel.Item;
            await DisplayAlert("Warning", $"Are you want to Delete ID: {incDel.IncomeId} ?", "Yes", "No");

            if (valad == true)
            {
                MessagingCenter.Send(this, "DeleteIncome", incDel);
                await DisplayAlert("Warning", $"Delete Successful", "Ok");
                await Navigation.PopAsync();
            }
        }

    }
}