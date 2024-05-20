using Supermarket.DBContext;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Models.BusinessLogicLayer
{
    internal class ReceiptBLL
    {
        private supermarketDBContext context = new supermarketDBContext();
        public ObservableCollection<Receipt> ReceiptList { get; set; }

        public ReceiptBLL()
        {
            ReceiptList = new ObservableCollection<Receipt>();

        }
        public void AddMethod(object obj)
        {

        }
        public void UpdateMethod(object obj)
        {

        }
        public void DeleteMethod(object obj)
        {
        }
    }
}
