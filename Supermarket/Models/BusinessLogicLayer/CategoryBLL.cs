using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Models.BusinessLogicLayer
{
    internal class CategoryBLL
    {
        public ObservableCollection<Category> AccountsList { get; set; }

        public CategoryBLL()
        {
            AccountsList = new ObservableCollection<Category>();
            
        }
        public ObservableCollection<Category> GetCategory()
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("GetCategoryDetails", con);
                    ObservableCollection<Category> result = new ObservableCollection<Category>();
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Category category = new Category();
                        category.CategoryId = (int)reader[0];
                        category.Name= reader.GetString(1);
                        result.Add(category);
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
        public void AddMethod(object obj)
        {

        }
        public void UpdateMethod(object obj)
        {

        }
        public void DeleteMethod(object obj)
        {
        }
    }
}
