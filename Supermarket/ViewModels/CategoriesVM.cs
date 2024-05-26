using Supermarket.Helper;
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

namespace Supermarket.ViewModels
{
    internal class CategoriesVM :BasePropertyChanged
    {
        private ObservableCollection<Category> _productsToShow;
        private readonly CategoryBLL _productBLL;
        private Category _selectedProduct;
        private Category _product;

        public ObservableCollection<Category> ProductsToShow
        {
            get => _productsToShow;
            set
            {
                _productsToShow = value;
                OnPropertyChanged(nameof(ProductsToShow));
            }
        }

        public Category Product
        {
            get => _product;
            set
            {
                _product = value;
                OnPropertyChanged(nameof(Product));
            }
        }

        public Category SelectedProduct
        {
            get => _selectedProduct;
            set
            {
                _selectedProduct = value;
                OnPropertyChanged(nameof(SelectedProduct));
                if (_selectedProduct != null)
                {
                    Product = new Category
                    {
                        CategoryId = SelectedProduct.CategoryId,
                        Name = SelectedProduct.Name,
                        isDeleted = SelectedProduct.isDeleted
                    };
                }
            }
        }

        public CategoriesVM()
        {
            _productBLL = new CategoryBLL();
            _product = new Category();
            ProductsToShow = _productBLL.GetCategory();
            AddCommand = new RelayCommand(AddProductToDatabase);
            EditCommand = new RelayCommand(EditProduct);
            DeleteCommand = new RelayCommand(DeleteProductFromDatabase);
        }

        public void AddProductToDatabase()
        {
            if (Product.CategoryId == 0)
            {
                MessageBox.Show("ID cannot be empty", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(Product.Name))
            {
                MessageBox.Show("Name cannot be empty", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            _productBLL.AddCategory(Product);
            ProductsToShow = _productBLL.GetCategory();
        }

        public void EditProduct()
        {
            if (Product.CategoryId == 0)
            {
                MessageBox.Show("ID cannot be empty", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(Product.Name))
            {
                MessageBox.Show("Name cannot be empty", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            _productBLL.EditCategory(Product); 
            ProductsToShow = _productBLL.GetCategory();
        }

        public void DeleteProductFromDatabase()
        {
            _productBLL.DeleteCategory(SelectedProduct);
            ProductsToShow = _productBLL.GetCategory();
        }

        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
    }
}
