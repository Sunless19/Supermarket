﻿
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Supermarket.Models.BusinessLogicLayer
{
    internal class StockBLL
    {
        public StockBLL()
        {

        }

        public ObservableCollection<Stock> GetStockProducts()
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("GetStockProducts", con);
                    ObservableCollection<Stock> result = new ObservableCollection<Stock>();
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader.GetString(0) != null)
                        {
                            Stock stock = new Stock();
                            stock.BarCode = reader.GetString(1);
                            stock.Quantity = (int)reader[2];
                            stock.Unit = reader.GetString(3);
                            stock.ExpirationDate = (DateTime)reader[4];
                            stock.SelllingPrice = (decimal)reader[5];
                            result.Add(stock);
                        }
                    }
                    reader.Close();
                    return result;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    return null;
                }
            }
        }
        public void UpdateStock(string Barcode, int Quantity)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("UpdateStock", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Adaugă parametrii
                    cmd.Parameters.AddWithValue("@Barcode", Barcode);
                    cmd.Parameters.AddWithValue("@QuantityChange", Quantity);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    // Tratează eroarea în mod corespunzător
                }
            }
        }

        public ObservableCollection<Stock> GetStocks()
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("GetStocks", con);
                    ObservableCollection<Stock> result = new ObservableCollection<Stock>();
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader != null)
                        {
                            Stock stock = new Stock();
                            stock.StockId = (int)reader[0];
                            stock.BarCode = reader.GetString(1);
                            stock.Quantity = (int)reader[2];
                            stock.Unit = reader.GetString(3);
                            stock.PurchasePrice = (decimal)reader[4];
                            stock.ExpirationDate = (DateTime)reader[5];
                            stock.DateOfSupply = (DateTime)reader[6];
                            stock.SelllingPrice = (decimal)reader[7];
                            stock.isDeleted = (bool)reader[8];
                            if (stock.isDeleted == false)
                            {
                                result.Add(stock);
                            }
                        }
                    }
                    reader.Close();
                    return result;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    return null;
                }
            }
        }
        public void AddStock(Stock stock, string Barcode)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("AddStock", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Adaugă parametrii
                    cmd.Parameters.AddWithValue("@Barcode", Barcode);
                    cmd.Parameters.AddWithValue("@Quantity", stock.Quantity);
                    cmd.Parameters.AddWithValue("@Unit", stock.Unit);
                    cmd.Parameters.AddWithValue("@SupplyDate", stock.DateOfSupply);
                    cmd.Parameters.AddWithValue("@ExpiryDate", stock.ExpirationDate);
                    cmd.Parameters.AddWithValue("@PurchasePrice", stock.PurchasePrice);
                    cmd.Parameters.AddWithValue("@SellingPrice", stock.SelllingPrice);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    // Tratează eroarea în mod corespunzător
                }
            }
        }
        public void DeleteStock(Stock stock,string Barcode)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("DeleteStock", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Adaugă parametrii
                    cmd.Parameters.AddWithValue("@Barcode", Barcode);
                    cmd.Parameters.AddWithValue("@Deleted", stock.isDeleted);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    // Tratează eroarea în mod corespunzător
                }
            }
        }
        public void EditStock(Stock stock, string Barcode)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("EditStock", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Adaugă parametrii
                    cmd.Parameters.AddWithValue("@ID", stock.StockId);
                    cmd.Parameters.AddWithValue("@Barcode", Barcode);
                    cmd.Parameters.AddWithValue("@PurchasePrice", stock.PurchasePrice);
                    cmd.Parameters.AddWithValue("@Unit", stock.Unit);
                    cmd.Parameters.AddWithValue("@Quantity", stock.Quantity);
                    cmd.Parameters.AddWithValue("@SellingPrice", stock.SelllingPrice);
                    cmd.Parameters.AddWithValue("@DateOfSupply", stock.DateOfSupply);
                    cmd.Parameters.AddWithValue("@ExpirationDate", stock.ExpirationDate);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    // Tratează eroarea în mod corespunzător
                }
            }
        }

    }
}
