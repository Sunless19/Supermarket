# Supermarket Management Application

## Description

This project aims to develop an application for managing a supermarket. The application will be created using C#, the WPF framework, and SQLServer for the database. The application will follow the MVVM (Model-View-ViewModel) design pattern.

## Data to be Stored

- **Products**: (product name, barcode, category, manufacturer)
- **Manufacturers**: (manufacturer name, country of origin)
- **Product Categories**: (food, clothing, stationery, etc.)
- **Product Stocks**: (quantity, unit of measure, supply date, expiration date, purchase price, sale price)
- **Users**: (username, password, user type)
- **Receipts**: (receipt issuance date, cashier who issued it, list of products sold with quantities and subtotals, total amount received)
- **Offers**: (offer reason (product expiring/stock clearance), product for which the offer applies, discount percentage, valid from date, valid until date) – optional functionality

## User Types

The application will have two types of users: administrators and cashiers.

### Administrator Functionality Requirements

- Add, modify, delete, and view: users, categories, manufacturers, products, stocks, etc.
- Data cannot be deleted from the database but will become inactive (logical deletion from the database).
- When entering a stock, only the purchase price will be manually filled in, and the sale price will be automatically calculated based on a formula (purchase price + commercial markup, saved in the configuration file or in the database).
- The purchase price of a product cannot be modified after its entry date into the supermarket; only the sale price can be modified (which cannot be lower than the purchase price).
- Fields in the input, modification, and deletion forms must be validated.
- Data search actions.

### Cashier Functionality Requirements

- Product search action:
  - Search product by: name, barcode (a string of digits that can be represented as varchar in the database), expiration date, manufacturer, category.
- Issuing and viewing the contents of a receipt.
  - Products added to the receipt will be displayed along with their prices, correctly calculated (subtotals and total amount on receipts will be calculated at the time of display).
 - Once a receipt is confirmed, it can no longer be modified.
- A stock becomes inactive when there are no more products in it. A product type can appear in multiple stocks; stocks are depleted in the order they were brought into the store. If a product's validity period expires, then its stock becomes inactive.

## Technologies Used

- **Backend**: C#, WPF, SQLServer
- **Frontend**: XAML for WPF (with MVVM pattern)

## Installation and Usage

To install and run the application on your local machine, follow these steps:

1. Clone this repository to your local computer.
2. Set up and run the application in Visual Studio.
3. Ensure that the SQLServer database is started and properly configured.
4. Use the application through the WPF interface on your local machine.
