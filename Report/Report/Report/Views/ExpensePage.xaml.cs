using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Report.Models;
using Report.Views;
using Report.ViewModels;

namespace Report.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExpensePage : ContentPage
    {
        ExpenseViewModel viewModel;
        //test
        //List<Expense> expenses;

        public ExpensePage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ExpenseViewModel();
            //expenses = new List<Expense>();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var expense = args.SelectedItem as Expense;
            if (expense == null)
                return;

            await Navigation.PushAsync(new ExpenseDetailPage(new ExpenseDetailViewModel(expense)));

            // Manually deselect item.
            ExpenseListView.SelectedItem = null;
        }

        async void AddItem_Clickeds(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewExpensePage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Expenses.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }

        
    }
}