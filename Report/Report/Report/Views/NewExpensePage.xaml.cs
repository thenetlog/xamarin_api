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
    public partial class NewExpensePage : ContentPage
    {
        public Expense Expense { get; set; }


        public NewExpensePage()
        {
            InitializeComponent();
            
           
                Expense = new Expense
                {
                    ExpenseId = string.Empty,
                    TransactionDate = DateTime.Now,
                    Particular = string.Empty,
                    Amount = string.Empty
                };
                      

            BindingContext = this;
        }

        async void Save_Clickeds(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddExpense", Expense);
            await Navigation.PopModalAsync();
        }
    }
}