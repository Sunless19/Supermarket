using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supermarket.ViewModels;

namespace Supermarket.Models.BusinessLogicLayer
{
    internal class ProducerBLL
    {
        public ObservableCollection<Producer> ProducerList { get; set; }

        public ProducerBLL()
        {
            ProducerList = new ObservableCollection<Producer>();

        }
        public ObservableCollection<Producer> GetProducerDetails()
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("GetProducerDetails", con);
                    ObservableCollection<Producer> result = new ObservableCollection<Producer>();
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Producer producer= new Producer();
                        producer.ProducerId = (int)reader[0];
                        producer.Name = reader.GetString(1);
                        result.Add(producer);
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

        public ObservableCollection<Producer> GetProducers()
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("GetProducers", con);
                    ObservableCollection<Producer> result = new ObservableCollection<Producer>();
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Producer producer = new Producer();
                        producer.ProducerId = (int)reader[0];
                        producer.Name = reader.GetString(1);
                        producer.Country=reader.GetString(2);
                        producer.isDeleted = (bool)reader[3];
                        result.Add(producer);
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
        public void DeleteProducer(Producer producer)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("DeleteProducer", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID", producer.ProducerId);

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
        public void AddProducer(Producer producer)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("AddProducer", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID", producer.ProducerId);
                    cmd.Parameters.AddWithValue("@Name", producer.Name);
                    cmd.Parameters.AddWithValue("@country", producer.Country);
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
        public void EditProducer(Producer producer)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("EditProducer", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID", producer.ProducerId);
                    cmd.Parameters.AddWithValue("@Name", producer.Name);
                    cmd.Parameters.AddWithValue("@country", producer.Country);

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
