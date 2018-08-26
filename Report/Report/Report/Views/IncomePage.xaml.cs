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
using System.Collections.ObjectModel;

namespace Report.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IncomePage : ContentPage
    {
        IncomeViewModel viewModel;

        public IncomePage()
        {
            InitializeComponent();

            BindingContext = viewModel = new IncomeViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Income;
            if (item == null)
                return;

            await Navigation.PushAsync(new IncomeDetailPage(new IncomeDetailViewModel(item)));

            // Manually deselect item.
            IncomeListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewIncomePage()));
        }

        protected override void OnAppearing()
        {
            
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}