using ModiriateAnbar.Models;
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
        int _categoryId = 0;
        public ucCategory()
        {
            InitializeComponent();
        }

        public ucCategory(int categotyId)
        {
            InitializeComponent();
            _categoryId = categotyId;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_categoryId > 0)
            {
                //Update
                UpdateCategory(_categoryId, txtTitle.Text, txtDescription.Text);
                MessageBox.Show("Update  Category Succ..");

            }
            else
            {
                //Insert
                AddCategory(txtTitle.Text, txtDescription.Text);
                MessageBox.Show("Add Category Succ..");
            }
            var frmMain = Application.OpenForms["frmMain"];
            frmMain.Controls["pnlMain"].Controls.Clear();

            var uc = new ucCategoryList();  
            frmMain.Controls["pnlMain"].Controls.Add(uc);

        }

        private void AddCategory(string title, string desciption)
        {

        }

        private void UpdateCategory(int categoryId, string title, string desciption)
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

                sqlCommand.CommandText = "Update Categories Set CategoryName=@CategoryName,Descriptio=@Description Where CategryId=@categryId";
                //set paramiters
                sqlCommand.Parameters.AddWithValue("categoryId",categoryId);
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

        private void ucCategory_Load(object sender, EventArgs e)
        {
            //edit
            if (-_categoryId < 0)
            {
                // MessageBox.Show("Test category data");
                GetCategory(_categoryId);
            }
        }

        private void GetCategory(int categoryId)
        {
            //step 1
            using (SqlConnection
                sqlConnection = new SqlConnection("Data Source=.; Initial Catalog=CsharpSampleDB; Integrated Security=True"))
            {
                //step 2 
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlConnection;
                cmd.CommandText = "Select CategoryID,CategoryName,Description from Categories Where CategoryId = @CategoryId";
                cmd.Parameters.AddWithValue("CategoryId",categoryId);

                // step 3
                sqlConnection.Open();

                // step 4
                SqlDataReader reader = cmd.ExecuteReader();

                if(reader.Read())   
                {
                    txtTitle.Text = reader["CategoryName"].ToString();
                    txtDescription.Text = reader["Description"].ToString(); 
                }

                reader.Close();
                sqlConnection.Close();
            }
        }
    }
}
