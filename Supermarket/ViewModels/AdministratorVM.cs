using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfMVVMAgendaEF.Helpers;
using Supermarket.Views;

namespace Supermarket.ViewModels
{
    class AdministratorVM
    {
        public AdministratorVM()
        {
        }
        public ICommand usersView;
        public ICommand productsView;
        public ICommand producersView;
        public ICommand stocksView;
        public ICommand receiptsView;
        public ICommand categoriesView;

        #region Commands
        public ICommand UsersView
        {
            get
            {
                if (usersView == null)
                    usersView = new RelayCommand(OpenUsersView);
                return usersView;
            }
        }
        public ICommand ProductsView
        {
            get
            {
                if(productsView == null)
                    productsView= new RelayCommand(OpenProductsView);
                return productsView;
            }
        }
        public ICommand StocksView
        {
            get
            {
                if(stocksView == null)
                    stocksView = new RelayCommand(OpenStocksView);
                return stocksView;
            }
        }
        public ICommand ProducersView
        {
            get
            {
                if(producersView == null)
                    producersView=new RelayCommand(OpenProducersView);
                return producersView;
            }
        }
        public ICommand ReceiptsView
        {
            get
            {
                if(receiptsView==null)
                    receiptsView=new RelayCommand(OpenReceiptsView);
                return receiptsView;
            }
        }
        public ICommand CategoriesView
        {
            get
            {
                if(categoriesView==null)
                    categoriesView= new RelayCommand(OpenCategoriesView);
                return categoriesView;
            }
        }

        #endregion

        #region OpenWindows
        private void OpenUsersView()
        {
            var window = new UsersView();
            window.ShowDialog();
        }

        private void OpenProductsView()
        {
            var window = new ProductsView();
            window.ShowDialog();
        }

        private void OpenProducersView()
        {
            var window = new ProducersView();
            window.ShowDialog();
        }

        private void OpenStocksView()
        {
            var window = new StocksView();
            window.ShowDialog();
        }

        private void OpenReceiptsView()
        {
            var window = new ReceiptsView();
            window.ShowDialog();
        }

        private void OpenCategoriesView()
        {
            var window = new CategoriesView();
            window.ShowDialog();
        }
        #endregion
    }
}
