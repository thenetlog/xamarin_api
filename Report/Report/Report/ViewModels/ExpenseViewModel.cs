using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using Report.Models;
using Report.Views;
using Report.Services;
using System.Linq;
using System.Collections.Generic;

namespace Report.ViewModels
{
    public class ExpenseViewModel : BaseViewModel
    {
        //private IEnumerable<Expense> expenses;

        public ObservableCollection<Expense> Expenses { get; set; }
        public Command LoadItemsCommand { get; set; }
        public string E { get; }

        public ExpenseViewModel()
        {
            Title = "Expense";
            Expenses = new ObservableCollection<Expense>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewExpensePage, Expense>(this, "AddExpense", async (obj, expense) =>
            {
                var _etem = expense as Expense;
                Expenses.Add(_etem);
                await DataStores.AddItemAsynce(_etem);
            });
            MessagingCenter.Subscribe<ExpenseDetailPage, Expense>(this, "UpdateExpense", async (obj, expense) =>
            {
                var expUp = expense as Expense;
                var expDel = Expenses.Where((Expense arg) => arg.ExpenseId == expUp.ExpenseId).FirstOrDefault();
                Expenses.Remove(expDel);
                Expenses.Add(expUp);
                await DataStores.UpdateItemAsynce(expUp);
            });

            MessagingCenter.Subscribe<ExpenseDetailPage, Expense>(this, "DeleteExpense", async (obj, expense) =>
            {
                var expDel = expense as Expense;
                var id = expDel.ExpenseId.ToString();
                var eDel = Expenses.Where((Expense arg) => arg.ExpenseId == id).FirstOrDefault();
                Expenses.Remove(eDel);
                await DataStores.DeleteItemAsynce(id);
            });



        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Expenses.Clear();
                var etems = await DataStores.GetItemsAsynce(true);
                foreach (var etem in etems)
                {
                    Expenses.Add(etem);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}