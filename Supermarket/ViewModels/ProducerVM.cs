using Supermarket.Models.BusinessLogicLayer;
using Supermarket.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using WpfMVVMAgendaEF.Helpers;
using Supermarket.Helper;

namespace Supermarket.ViewModels
{
    internal class ProducerVM : BasePropertyChanged
    {
        private ObservableCollection<Producer> _productsToShow;
        private readonly ProducerBLL _productBLL;
        private Producer _selectedProduct;
        private Producer _product;

        public ObservableCollection<Producer> ProductsToShow
        {
            get => _productsToShow;
            set
            {
                _productsToShow = value;
                OnPropertyChanged(nameof(ProductsToShow));
            }
        }

        public Producer Product
        {
            get => _product;
            set
            {
                _product = value;
                OnPropertyChanged(nameof(Product));
            }
        }

        public Producer SelectedProduct
        {
            get => _selectedProduct;
            set
            {
                _selectedProduct = value;
                OnPropertyChanged(nameof(SelectedProduct));
                if (_selectedProduct != null)
                {
                    Product = new Producer
                    {
                        ProducerId=SelectedProduct.ProducerId,
                        Name=SelectedProduct.Name,
                        Country=SelectedProduct.Country,
                        isDeleted=SelectedProduct.isDeleted
                    };
                }
            }
        }

        public ProducerVM()
        {
            _productBLL = new ProducerBLL();
            _product = new Producer();
            ProductsToShow = _productBLL.GetProducers();
            AddCommand = new RelayCommand(AddProductToDatabase);
            EditCommand = new RelayCommand(EditProduct);
            DeleteCommand = new RelayCommand(DeleteProductFromDatabase);
        }

        public void AddProductToDatabase()
        {
            if (Product.ProducerId == 0)
            {
                MessageBox.Show("ID cannot be empty", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(Product.Name))
            {
                MessageBox.Show("Name cannot be empty", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(Product.Country))
            {
                MessageBox.Show("Country cannot be empty", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            _productBLL.AddProducer(Product);
            ProductsToShow = _productBLL.GetProducers();
        }

        public void EditProduct()
        {
            if (Product.ProducerId == 0)
            {
                MessageBox.Show("ID cannot be empty", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(Product.Name))
            {
                MessageBox.Show("Name cannot be empty", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(Product.Country))
            {
                MessageBox.Show("Country cannot be empty", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            _productBLL.EditProducer(Product);
            ProductsToShow = _productBLL.GetProducers();
        }

        public void DeleteProductFromDatabase()
        {
            _productBLL.DeleteProducer(SelectedProduct);
            ProductsToShow = _productBLL.GetProducers();
        }

        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
    }
}
