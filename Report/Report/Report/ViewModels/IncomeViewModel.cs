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
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Report.ViewModels
{
    public class IncomeViewModel : BaseViewModel
    {

        public ObservableCollection<Income> Items { get; set; }
        public Command LoadItemsCommand { get; set; }
        public IDataStore<Income> DataStore => DependencyService.Get<IDataStore<Income>>() ?? new MockIncome();

        public IncomeViewModel()
        {
            Title = "Income";
            Items = new ObservableCollection<Income>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewIncomePage, Income>(this, "AddIncome", async (obj, income) =>
            {
                var _item = income as Income;
                Items.Add(_item);
                await DataStore.AddItemAsync(_item);
            });

            MessagingCenter.Subscribe<IncomeDetailPage, Income>(this, "UpdateIncome", async (obj, income) =>
            {
                var incUp = income as Income;
                var _inc = Items.Where((Income arg) => arg.IncomeId == incUp.IncomeId).FirstOrDefault();
                Items.Remove(_inc);
                Items.Add(incUp);
                await DataStore.UpdateItemAsync(incUp);
            });

            MessagingCenter.Subscribe<IncomeDetailPage, Income>(this, "DeleteIncome", async (obj, income) =>
            {
                var incDel = income as Income;
                var id = incDel.IncomeId.ToString();
                var _inc = Items.Where((Income arg) => arg.IncomeId == id).FirstOrDefault();
                Items.Remove(_inc);
                await DataStore.DeleteItemAsync(id);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                //List<Income> Items = new List<Income>();
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                
                foreach (Income item in items)
                {
                    //Items.Add(new Income());
                    //Items = new ObservableCollection<Income>(items);
                    Items.Add(item);
                    
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