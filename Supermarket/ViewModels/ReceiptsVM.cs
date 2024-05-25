using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supermarket.Models;
using Supermarket.Views;
using Supermarket.Helper;
using Supermarket.Models.BusinessLogicLayer;

namespace Supermarket.ViewModels
{
    internal class ReceiptsVM : BasePropertyChanged
    {
        private ObservableCollection<Receipt> _receiptsToShow;
        private ObservableCollection<ReceiptItems> _productsToShow;
        private ObservableCollection<ReceiptItems> _itemsToShow;
        private readonly ReceiptBLL _receiptBLL;
        private readonly ReceiptItemsBLL _receiptItemsBLL;
        private Receipt _selectedReceipt;

        public ObservableCollection<ReceiptItems> ProductsToShow
        {
            get => _productsToShow;
            set
            {
                _productsToShow = value;
                OnPropertyChanged(nameof(ProductsToShow));
                UpdateItemsToShow();
            }
        }

        public ObservableCollection<ReceiptItems> ItemsToShow
        {
            get => _itemsToShow;
            set
            {
                _itemsToShow = value;
                OnPropertyChanged(nameof(ItemsToShow));
            }
        }

        public ObservableCollection<Receipt> ReceiptsToShow
        {
            get => _receiptsToShow;
            set
            {
                _receiptsToShow = value;
                OnPropertyChanged(nameof(ReceiptsToShow));
            }
        }

        public Receipt SelectedReceipt
        {
            get => _selectedReceipt;
            set
            {
                _selectedReceipt = value;
                OnPropertyChanged(nameof(SelectedReceipt));
                UpdateItemsToShow();
            }
        }

        public ReceiptsVM()
        {
            _receiptBLL = new ReceiptBLL();
            _receiptItemsBLL = new ReceiptItemsBLL();
            ReceiptsToShow = _receiptBLL.GetReceipts();
            ProductsToShow = _receiptItemsBLL.GetProductsOnReceipt();
        }

        private void UpdateItemsToShow()
        {
            if (_selectedReceipt != null)
            {
                ItemsToShow = new ObservableCollection<ReceiptItems>(
                    ProductsToShow.Where(p => p.ReceiptId == _selectedReceipt.ReceiptId)
                );
            }
            else
            {
                ItemsToShow = new ObservableCollection<ReceiptItems>();
            }
        }
    }
}