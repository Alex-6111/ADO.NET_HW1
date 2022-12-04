using ADO.NET_HW1;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.DirectoryServices.ActiveDirectory;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Windows;
using System.Windows.Documents;

namespace ADO.NET_HW1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Goods> goods;
        public MainWindow()
        {

            InitializeComponent();
            goods = new List<Goods>();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                string connectionString = @"Data Source=WIN-KT8KRQ87C7Q\SQLEXPRESS;Initial Catalog=VegetablesAndFruits;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                string command = @"SELECT * FROM GOODS";
                SqlCommand sqlCommand = new SqlCommand(command, connection);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    goods.Add(new Goods(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(4)));
                }
                dgMain.ItemsSource = goods;
                connection.Close();
            }
            catch (SqlException ex)
            {
                StringBuilder errorMessages = new StringBuilder();
                for (int i = 0; i < ex.Errors.Count; i++)
                {
                    errorMessages.Append("Index #" + i + "\n" +
                        "Message: " + ex.Errors[i].Message + "\n" +
                        "LineNumber: " + ex.Errors[i].LineNumber + "\n" +
                        "Source: " + ex.Errors[i].Source + "\n" +
                        "Procedure: " + ex.Errors[i].Procedure + "\n");
                }
                MessageBox.Show(errorMessages.ToString());
            }
        }

        private void Add_click(object sender, RoutedEventArgs e)
        {
            goods.Add(new Goods(int.Parse(tbId.Text), tbName.Text, tbType.Text, tbCalories.Text, int.Parse(tbCalories.Text)));
            dgMain.ItemsSource = null;
            dgMain.ItemsSource = goods;
        }
        private void Click_Max(object sender, RoutedEventArgs e)
        {
            string connectionString = @"Data Source=WIN-KT8KRQ87C7Q\SQLEXPRESS;Initial Catalog=VegetablesAndFruits;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            string sqlExpression = "SELECT * FROM GOODS";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                object count = command.ExecuteScalar();

                command.CommandText = "SELECT MAX(CaloricContent) FROM GOODS";
                object maxCalories = command.ExecuteScalar();
                MessageBox.Show(maxCalories.ToString());

            }
        }
        private void Click_Min(object sender, RoutedEventArgs e)
        {
            string connectionString = @"Data Source=WIN-KT8KRQ87C7Q\SQLEXPRESS;Initial Catalog=VegetablesAndFruits;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            string sqlExpression = "SELECT * FROM GOODS";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                object count = command.ExecuteScalar();

                command.CommandText = "SELECT MIN(CaloricContent) FROM GOODS";
                object minCalories = command.ExecuteScalar();
                MessageBox.Show(minCalories.ToString());

            }
        }
        private void Click_Avg(object sender, RoutedEventArgs e)
        {
            string connectionString = @"Data Source=WIN-KT8KRQ87C7Q\SQLEXPRESS;Initial Catalog=VegetablesAndFruits;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            string sqlExpression = "SELECT * FROM GOODS";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                object count = command.ExecuteScalar();

                command.CommandText = "SELECT AVG(CaloricContent) FROM GOODS";
                object avgCalories = command.ExecuteScalar();
                MessageBox.Show(avgCalories.ToString());

            }
        }     
    }
}
