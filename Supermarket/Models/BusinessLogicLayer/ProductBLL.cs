using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace Supermarket.Models.BusinessLogicLayer
{
    internal class ProductBLL
    {
        public ProductBLL() { }
        public ObservableCollection<Product> GetAllProducts()
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("GetProductDetails", con);
                    ObservableCollection<Product> result = new ObservableCollection<Product>();
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader.GetString(0) != null)
                        {
                            Product product = new Product();
                            product.Barcode = reader.GetString(0);
                            product.Name = reader.GetString(1);
                            product.CategoryId = (int)reader[2];
                            product.ProducerId = (int)reader[3];
                            product.isDeleted = (bool)reader[4];
                            result.Add(product);
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
        public ObservableCollection<Product> GetStockProducts()
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("GetSearchProducts", con);
                    ObservableCollection<Product> result = new ObservableCollection<Product>();
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader.GetString(0) != null)
                        {
                            Product product = new Product();
                            product.Name= reader.GetString(0);
                            product.CategoryName = reader.GetString(1);
                            product.ProducerName = reader.GetString(2);
                            product.Barcode = reader.GetString(3);
                            product.Unit= reader.GetString(4);
                            product.SellingPrice = (decimal)reader[5];
                            product.ExpiryDate = (DateTime)reader[6];
                            product.Quantity = (int)reader[7];
                            result.Add(product);
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
        
        public void DeleteProduct(Product product)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("DeleteProduct", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Barcode", product.Barcode);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
        public void EditProduct(Product product)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("EditProduct", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Barcode", product.Barcode);
                    cmd.Parameters.AddWithValue("@Name", product.Name);
                    cmd.Parameters.AddWithValue("@CategoryID", product.CategoryId);
                    cmd.Parameters.AddWithValue("@ProducerID", product.ProducerId);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
        public void AddProduct(Product product)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("AddProduct", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Barcode", product.Barcode);
                    cmd.Parameters.AddWithValue("@Name", product.Name);
                    cmd.Parameters.AddWithValue("@CategoryID", product.CategoryId);
                    cmd.Parameters.AddWithValue("@ProducerID", product.ProducerId);
                    cmd.Parameters.AddWithValue("@Deleted", false);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
    }
}