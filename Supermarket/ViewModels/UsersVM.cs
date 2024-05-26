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
    internal class UsersVM : BasePropertyChanged
    {
        private ObservableCollection<Account> _productsToShow;
        private readonly AccountBLL _productBLL;
        private Account _selectedProduct;
        private Account _product;

        public ObservableCollection<Account> ProductsToShow
        {
            get => _productsToShow;
            set
            {
                _productsToShow = value;
                OnPropertyChanged(nameof(ProductsToShow));
            }
        }

        public Account Product
        {
            get => _product;
            set
            {
                _product = value;
                OnPropertyChanged(nameof(Product));
            }
        }

        public Account SelectedProduct
        {
            get => _selectedProduct;
            set
            {
                _selectedProduct = value;
                OnPropertyChanged(nameof(SelectedProduct));
                if (_selectedProduct != null)
                {
                    Product = new Account
                    {
                        AccountId = _selectedProduct.AccountId,
                        Name = _selectedProduct.Name,
                        Role = _selectedProduct.Role,
                        Password = _selectedProduct.Password,
                        Username = _selectedProduct.Username,
                        isDeleted = _selectedProduct.isDeleted
                    };
                }
            }
        }

        public UsersVM()
        {
            _productBLL = new AccountBLL();
            _product = new Account();
            ProductsToShow = _productBLL.GetAllAccounts();
            AddCommand = new RelayCommand(AddProductToDatabase);
            EditCommand = new RelayCommand(EditProduct);
            DeleteCommand = new RelayCommand(DeleteProductFromDatabase);
        }

        public void AddProductToDatabase()
        {
            if (Product.AccountId==0)
            {
                MessageBox.Show("Barcode cannot be empty", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(Product.Name))
            {
                MessageBox.Show("Name cannot be empty", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(Product.Username))
            {
                MessageBox.Show("Username empty", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(Product.Password))
            {
                MessageBox.Show("Please select a password", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (Product.Role != "Administrator")
            {
                if (Product.Role != "Casier")
                {
                    MessageBox.Show("Choose Administrator/Casier", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }

            _productBLL.AddUser(Product);
            ProductsToShow = _productBLL.GetAllAccounts();
        }

        public void EditProduct()
        {
            if (Product.AccountId == 0)
            {
                MessageBox.Show("Barcode cannot be empty", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(Product.Name))
            {
                MessageBox.Show("Name cannot be empty", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(Product.Username))
            {
                MessageBox.Show("Username empty", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(Product.Password))
            {
                MessageBox.Show("Please select a password", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (Product.Role != "Administrator")
            {
                if (Product.Role != "Casier")
                {
                MessageBox.Show("Choose Administrator/Casier", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
                }
            }

            _productBLL.EditUser(Product);
            ProductsToShow = _productBLL.GetAllAccounts();
        }

        public void DeleteProductFromDatabase()
        {
            _productBLL.DeleteUser(SelectedProduct);
            ProductsToShow = _productBLL.GetAllAccounts();
        }

        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
    }
}
