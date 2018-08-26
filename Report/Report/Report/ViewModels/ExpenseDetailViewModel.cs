using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Report.Models;
using Report.Views;
using Xamarin.Forms;

namespace Report.ViewModels
{
    public class ExpenseDetailViewModel : BaseViewModel
    {
        public Expense Expense { get; set; }
        

        public ExpenseDetailViewModel(Expense expense = null)
        {
            Title = expense?.Particular;
            Expense = expense;
            
        }
       
    }
}
