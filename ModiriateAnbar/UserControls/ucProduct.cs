using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModiriateAnbar.UserControls
{
    public partial class ucProduct : UserControl
    {
        public ucProduct()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            FillGridView(
                txtCategoryName.Text,
                txtProductName.Text,
                string.IsNullOrEmpty(txtFromPrice.Text) ? (int?) null : Convert.ToInt32 (txtFromPrice.Text),
                string.IsNullOrEmpty(txtToPrice.Text) ? (int?) null : Convert.ToInt32 (txtToPrice.Text));
        }
        private void FillGridView(string categoryName, string productName, int? fromPrice, int? toPrice)
        {

            string connectionString = ConfigurationManager.AppSettings["CsharpSampleDBConnectionString"];

            using (
                SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand();
                command.Connection = sqlConnection;
                command.CommandText = "sp_GetProducts";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CategoryName", categoryName);
                command.Parameters.AddWithValue("@ProductName", productName);
                if (fromPrice != null)
                    command.Parameters.AddWithValue("@fromprice", fromPrice);
                if (toPrice != null)
                    command.Parameters.AddWithValue("@toPrice", toPrice);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.SelectCommand = command;
                DataTable dtProduct = new DataTable();
                adapter.Fill(dtProduct);


                dataGridView1.DataSource = dtProduct;
            }
            
        }
    }
}
