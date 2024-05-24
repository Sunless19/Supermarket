using Supermarket.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supermarket.Models;
using System.Collections.ObjectModel;
using Supermarket.Models.BusinessLogicLayer;
using WpfMVVMAgendaEF.Helpers;
using System.Windows.Input;

namespace Supermarket.ViewModels
{
    internal class StocksVM : BasePropertyChanged
    {
        private ObservableCollection<Stock> _productsToShow;
        private readonly StockBLL _stockBLL;
        private Stock _selectedStock;
        private Stock _stock;
        private string _newValue;
        public string NewValue
        {
            get { return _newValue; }
            set
            {
                _newValue = value;
                OnPropertyChanged(nameof(NewValue));
            }
        }
        public ICommand AddCommand { get; set; }
        public StocksVM()
        {
            _stockBLL = new StockBLL();
            ProductsToShow = _stockBLL.GetStocks();
            _stock = new Stock();
            AddCommand = new RelayCommand(AddStockToDatabase);
        }
        private void AddStockToDatabase(object parameter)
        {
            if(NewValue!=null)
            {
            _stockBLL.AddStock(Stock,NewValue);
            ProductsToShow = _stockBLL.GetStocks();
            }
        }

        public Stock SelectedStock
        {
            get => _selectedStock;
            set
            {
                _selectedStock = value;
                OnPropertyChanged(nameof(SelectedStock));
                if (_selectedStock != null)
                {
                    _stock.Unit = _selectedStock.Unit;
                    _stock.StockId = _selectedStock.StockId;
                    _stock.BarCode = _selectedStock.BarCode;
                    _stock.PurchasePrice = _selectedStock.PurchasePrice;
                    _stock.ExpirationDate = _selectedStock.ExpirationDate;
                    _stock.DateOfSupply = _selectedStock.DateOfSupply;
                    _stock.SelllingPrice = _selectedStock.SelllingPrice;
                    _stock.Quantity = _selectedStock.Quantity;
                    OnPropertyChanged(nameof(Stock));
                }
            }
        }

        public Stock Stock
        {
            get => _stock;
            set
            {
                _stock = value;
                OnPropertyChanged(nameof(Stock));
            }
        }

        public ObservableCollection<Stock> ProductsToShow
        {
            get => _productsToShow;
            set
            {
                _productsToShow = value;
                OnPropertyChanged(nameof(ProductsToShow));
            }
        }
    }
}
