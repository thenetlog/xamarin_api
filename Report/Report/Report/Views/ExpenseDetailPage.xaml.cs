using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Report.Models;
using Report.ViewModels;
using Report.Services;
using System.Diagnostics;

namespace Report.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExpenseDetailPage : ContentPage
    {
        public IDataStores<Expense> DataStores => DependencyService.Get<IDataStores<Expense>>() ?? new MockExpense();
        public Expense expense { get; set; }

        ExpenseDetailViewModel viewModel;

        //public object DataStores { get; private set; }

        public ExpenseDetailPage(ExpenseDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
            
        }

        public ExpenseDetailPage()
        {
            InitializeComponent();

            var expense = new Expense
            {
                ExpenseId = string.Empty,
                Particular = string.Empty,
                Amount = string.Empty
            };

            viewModel = new ExpenseDetailViewModel(expense);
            BindingContext = viewModel;
        }

        async void UpdateClicked(object sender, EventArgs e)
        {
            bool valad = true;

            var expUp = viewModel.Expense;
            await DisplayAlert("Warning", $"Update this ID: {expUp.ExpenseId} ?", "Yes", "No");

            if( valad == true )
            {
                MessagingCenter.Send(this, "UpdateExpense", expUp);
                await DisplayAlert("Warning", $"Update Complete", "Ok");
                await Navigation.PopAsync();
            }
        }

         async void DeleteClicked(object sender, EventArgs e)
        {
                bool valad = true;

                var expDel = viewModel.Expense;
                await DisplayAlert("Warning", $"Are u want to Delete ID: {expDel.ExpenseId} ?", "Yes", "No");

                if (valad == true)
                {
                    MessagingCenter.Send(this, "DeleteExpense", expDel);
                    await DisplayAlert("Warning", $"Delete Successful", "Ok");
                    await Navigation.PopAsync();
                }

        }
        
    }
}

//BindingContext = this;
//var expense = (Xamarin.Forms.Button)sender;
//var expense = sender as Button;
//var expense1 = expense.Command.ToString();
//if (await DisplayAlert("Warning", $"Are you sure want to delete ID: {g} ?", "Yes", "No"))

//MessagingCenter.Send(expense, "DeleteExpense");
//await Navigation.PopModalAsync();