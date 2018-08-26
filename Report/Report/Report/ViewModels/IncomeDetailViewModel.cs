using System;
using System.Collections.Generic;
using System.Text;
using Report.Models;

namespace Report.ViewModels
{
    public class IncomeDetailViewModel : BaseViewModel
    {
        public Income Item { get; set; }
        public IncomeDetailViewModel(Income item = null)
        {
            Title = item?.DonarName;
            Item = item;
        }
    }
}
