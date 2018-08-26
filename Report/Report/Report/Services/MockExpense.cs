using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Report.Models;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(Report.Services.MockExpense))]
namespace Report.Services
{
    public class MockExpense : IDataStores<Expense>
    {
        List<Expense> expenses;
        

        public MockExpense()
        {
            expenses = new List<Expense>();
            
            var mockItemss = new List<Expense>
            {

                new Expense { ExpenseId = "1", TransactionDate = DateTime.Now, Particular = "exp1", Amount = "1000" },

            };

            foreach (var expense in mockItemss)
            {
                expenses.Add(expense);
            }
        }

        public async Task<bool> AddItemAsynce(Expense expense)
        {
            expenses.Add(expense);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsynce(string id)
        {
            var _etem = expenses.Where((Expense arg) => arg.ExpenseId == id).FirstOrDefault();
            expenses.Remove(_etem);

            return await Task.FromResult(true);
            
        }

        public async Task<Expense> GetItemAsynce(string id)
        {
            return await Task.FromResult(expenses.FirstOrDefault(s => s.ExpenseId == id));
        }

        public async Task<IEnumerable<Expense>> GetItemsAsynce(bool forceRefresh = false)
        {
            return await Task.FromResult(expenses);
        }

        public async Task<bool> UpdateItemAsynce(Expense expense)
        {
            var _etem = expenses.Where((Expense arg) => arg.ExpenseId == expense.ExpenseId).FirstOrDefault();
            expenses.Remove(_etem);
            expenses.Add(expense);

            return await Task.FromResult(true);
        }

        
    }
}