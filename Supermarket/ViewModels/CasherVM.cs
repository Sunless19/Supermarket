using System.Collections.ObjectModel;
using System.Windows.Input;
using Supermarket.Helper;
using Supermarket.Models;
using Supermarket.Models.BusinessLogicLayer;
using Supermarket.Views;
using WpfMVVMAgendaEF.Helpers;

namespace Supermarket.ViewModels
{
    internal class CasherVM : BasePropertyChanged
    {
        private readonly ProductBLL _productBLL;
        private readonly StockBLL _stockBLL;
        private readonly CategoryBLL _categoryBLL;
        private readonly ProducerBLL _producerBLL;
        private ObservableCollection<Stock> _stocks;
        private ObservableCollection<Product> _products;
        private ObservableCollection<Category> _category;
        private ObservableCollection<Producer> _producer;

        private ObservableCollection<Product> _productsToShow;
        public ObservableCollection<Producer> Producer
        {
            get => _producer;
            set
            {
                _producer = value;

            }
        }
        public ObservableCollection<Category> Category
        {
            get => _category;
            set
            {
                _category = value;

            }
        }
        public ObservableCollection<Product> Products
        {
            get => _products;
            set
            {
                _products = value;

            }
        }
        private ObservableCollection<Stock> Stocks
        {
            get => _stocks;
            set
            {
                _stocks = value;
            }
        }
        public ObservableCollection<Product> ProductsToShow
        {
            get => _productsToShow;
            set
            {
                _productsToShow = value;
                OnPropertyChanged(nameof(Products));
            }
        }

        public CasherVM()
        {
            _productBLL = new ProductBLL();
            _stockBLL = new StockBLL();
            _categoryBLL=new CategoryBLL();
            _producerBLL = new ProducerBLL();
            LoadProducts();
            LoadStocks();
            LoadCategory();
            LoadProducer();
        }

        private void LoadProducts()
        {
            Products = _productBLL.GetAllProducts();
        }
        private void LoadStocks()
        {
            Stocks = _stockBLL.GetStockProducts();
        }

        private void LoadCategory()
        {
            Category = _categoryBLL.GetCategory();
        }

        private void LoadProducer()
        {
            Producer = _producerBLL.GetProducerDetails();
        }

    }
}