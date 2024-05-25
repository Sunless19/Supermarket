using Supermarket.Helper;
using Supermarket.Models;
using Supermarket.Models.BusinessLogicLayer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfMVVMAgendaEF.Helpers;

namespace Supermarket.ViewModels
{
    internal class ProductsVM : BasePropertyChanged
    {
        private ObservableCollection<Product> _productsToShow;
        private readonly ProductBLL _productBLL;
        private Product _selectedProduct;
        private Product _product;

        public ObservableCollection<Product> ProductsToShow
        {
            get => _productsToShow;
            set
            {
                _productsToShow = value;
                OnPropertyChanged(nameof(ProductsToShow));
            }
        }

        public Product Product
        {
            get => _product;
            set
            {
                _product = value;
                OnPropertyChanged(nameof(Product));
            }
        }

        public Product SelectedProduct
        {
            get => _selectedProduct;
            set
            {
                _selectedProduct = value;
                OnPropertyChanged(nameof(SelectedProduct));
                if (_selectedProduct != null)
                {
                    Product = new Product
                    {
                        ProductId = _selectedProduct.ProductId,
                        ProducerId = _selectedProduct.ProducerId,
                        Barcode = _selectedProduct.Barcode,
                        Name = _selectedProduct.Name,
                        CategoryId = _selectedProduct.CategoryId,
                        isDeleted = _selectedProduct.isDeleted
                    };
                }
            }
        }

        public ProductsVM()
        {
            _productBLL = new ProductBLL();
            _product = new Product();
            ProductsToShow = _productBLL.GetAllProducts();
            AddCommand = new RelayCommand(AddProductToDatabase);
            EditCommand = new RelayCommand(EditProduct);
            DeleteCommand = new RelayCommand(DeleteProductFromDatabase);
        }

        public void AddProductToDatabase()
        {
            if (string.IsNullOrWhiteSpace(Product.Barcode))
            {
                MessageBox.Show("Barcode cannot be empty", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(Product.Name))
            {
                MessageBox.Show("Name cannot be empty", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (Product.CategoryId == 0)
            {
                MessageBox.Show("CategoryId must be selected", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (Product.ProducerId == 0)
            {
                MessageBox.Show("ProducerId must be selected", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            _productBLL.AddProduct(Product);
            ProductsToShow = _productBLL.GetAllProducts();
        }

        public void EditProduct()
        {
            if (string.IsNullOrWhiteSpace(Product.Barcode))
            {
                MessageBox.Show("Barcode cannot be empty", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(Product.Name))
            {
                MessageBox.Show("Name cannot be empty", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (Product.CategoryId == 0)
            {
                MessageBox.Show("CategoryId must be selected", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (Product.ProducerId == 0)
            {
                MessageBox.Show("ProducerId must be selected", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            _productBLL.EditProduct(Product);
            ProductsToShow = _productBLL.GetAllProducts();
        }

        public void DeleteProductFromDatabase()
        {
            _productBLL.DeleteProduct(SelectedProduct);
            ProductsToShow = _productBLL.GetAllProducts();
        }

        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
    }
}
