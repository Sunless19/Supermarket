using Supermarket.DBContext;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Models.BusinessLogicLayer
{
    internal class CategoryBLL
    {
        private supermarketDBContext context = new supermarketDBContext();
        public ObservableCollection<Category> AccountsList { get; set; }

        public CategoryBLL()
        {
            AccountsList = new ObservableCollection<Category>();

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
