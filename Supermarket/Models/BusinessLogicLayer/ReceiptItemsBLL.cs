using Supermarket.DBContext;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Models.BusinessLogicLayer
{
    internal class ReceiptItemsBLL
    {
        private supermarketDBContext context = new supermarketDBContext();
        public ObservableCollection<ReceiptItems> ReceiptItemsList { get; set; }

        public ReceiptItemsBLL()
        {
            ReceiptItemsList = new ObservableCollection<ReceiptItems>();

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
