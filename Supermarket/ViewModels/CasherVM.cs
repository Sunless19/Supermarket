using System;
using System.Collections.ObjectModel;
using System.Linq;
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
                OnPropertyChanged(nameof(Category));

            }
        }
        public ObservableCollection<Product> Products
        {
            get => _products;
            set
            {
                _products = value;
                OnPropertyChanged(nameof(Products));

            }
        }
        private ObservableCollection<Stock> Stocks
        {
            get => _stocks;
            set
            {
                _stocks = value;
                OnPropertyChanged(nameof(Stocks));
            }
        }
        public ObservableCollection<Product> ProductsToShow
        {
            get => _productsToShow;
            set
            {
                _productsToShow = value;
                OnPropertyChanged(nameof(ProductsToShow));
            }
        }
        public ICommand SearchCommand { get; }
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
            SearchCommand = new RelayCommand(SearchProducts);
        }
        private Category _selectedCategory;
        public Category SelectedCategory
        {
            get => _selectedCategory;
            set
            {
                _selectedCategory = value;
                OnPropertyChanged(nameof(SelectedCategory));
            }
        }

        private Producer _selectedProducer;
        public Producer SelectedProducer
        {
            get => _selectedProducer;
            set
            {
                _selectedProducer = value;
                OnPropertyChanged(nameof(SelectedProducer));
            }
        }
        private Product _selectedProductName;
        public Product SelectedProductName
        {
            get => _selectedProductName;
            set
            {
                _selectedProductName = value;
                OnPropertyChanged(nameof(SelectedProductName));
            }
        }
        private DateTime _selectedTime;
        public DateTime SelectedTime
        {
            get => _selectedTime;
            set
            {
                _selectedTime = value;
                OnPropertyChanged(nameof(SelectedTime));
            }
        }

        

        
        private void SearchProducts()
        {
            var filteredProducts = new ObservableCollection<Product>(_products);

            if (SelectedCategory != null)
            {
                filteredProducts = new ObservableCollection<Product>(
                    filteredProducts.Where(p => p.CategoryName == SelectedCategory.Name));
            }

            if (SelectedProducer != null)
            {
                filteredProducts = new ObservableCollection<Product>(
                    filteredProducts.Where(p => p.ProducerName == SelectedProducer.Name));
            }
            try
            {

            if (SelectedProductName != null)
            {
                filteredProducts = new ObservableCollection<Product>(
                    filteredProducts.Where(p => p.Name==SelectedProductName.Name));
                
            }
            if (SelectedProductName != null)
            {
                filteredProducts = new ObservableCollection<Product>(
                    filteredProducts.Where(p => p.Barcode == SelectedProductName.Barcode));

            }
            }
            catch (Exception ex) { Console.WriteLine(ex); }

            if (SelectedTime != DateTime.MinValue)
            {
                filteredProducts = new ObservableCollection<Product>(
                    filteredProducts.Where(p => p.ExpiryDate < SelectedTime));
            }

            ProductsToShow = filteredProducts;
        }
        private void LoadProducts()
        {
            Products = _productBLL.GetAllProducts();
            Products = _productBLL.GetStockProducts();
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