using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModiriateAnbar.UserControls
{
    public partial class ucCategory : UserControl
    {
        public ucCategory()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
         AddCategory(txtTitle.Text,txtDescription.Text);
            MessageBox.Show("Add Category Succ..");
        }

        private void AddCategory(string title,string desciption)
        {
            //step1 : create sqlconnection
            using (SqlConnection sqlConnection = new SqlConnection())
            {
                sqlConnection.ConnectionString = "Data Source=.; Initial Catalog=CsharpSampleDB; Integrated Security=true";

                //step2 : create sqlcommand
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                //sqlInjection Attack
                //sqlCommand.CommandText = $"insert Categories(CategoryName,Description)values({title},{desciption})";

                sqlCommand.CommandText = "insert Categories(CategoryName,Description)values(@CategoryName,@Description)";
                //set paramiters
                sqlCommand.Parameters.AddWithValue("CategoryName", title);
                sqlCommand.Parameters.AddWithValue("Description", desciption);

                //step3 : open sqlconnection
                sqlConnection.Open();

                //step4 :execute sqlcommand nonquery
                sqlCommand.ExecuteNonQuery();

                //step5 : close sqlconnection
                sqlConnection.Close();
            }
        }
    }
}
