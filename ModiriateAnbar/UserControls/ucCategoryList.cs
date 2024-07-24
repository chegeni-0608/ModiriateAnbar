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
    public partial class ucCategoryList : UserControl
    {
     
        private object categories;

        public ucCategoryList()
        {
            InitializeComponent();
        }

        private void ucCategoryList_Load(object sender, EventArgs e)
        {
            fillgridview();
        }

        private void fillgridview()
        {
            var category=new List<Category>();

            //step 1
            using (SqlConnection 
                sqlConnection = new SqlConnection("Data Source=.; Initial Catalog=CsharpSampleDB; Integrated Security=True")) 
            {
                //step 2 
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlConnection;
                cmd.CommandText = "Select CategoryID,CategoryName,Description from Categories";

                // step 3
                sqlConnection.Open();

                // step 4
                SqlDataReader reader = cmd.ExecuteReader();
                Category model;
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        model = new Category();
                        model.CategoryId = Convert.ToInt32(reader["CategoryID"]);
                        model.CategoryName = reader["CategoryName"].ToString();
                        model.Description = reader["Description"].ToString();

                        category.Add(model);
                    }
                }

                reader.Close();
                sqlConnection.Close();
            }

            dataGridView1.DataSource= category;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show("Row Index" + e.RowIndex);
            //MessageBox.Show("COlumn Index" + e.ColumnIndex);
            int CategoryId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["CategoryId"].Value);
            //remove
            if (e.ColumnIndex == 1)
            {
                if (MessageBox.Show("در صورت حذف قابل بازیابی نمی باشد", "هشدار", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                
                    DeleteCategory(CategoryId);
                    fillgridview();
                }
            }
            //Edit
            if (e.ColumnIndex == 0)
            {
                // MessageBox.Show("edit click");
                

                var frmMain = Application.OpenForms["frmMain"];
                frmMain.Controls["pnlMain"].Controls.Clear();

                ucCategory uc=new ucCategory(CategoryId);
                frmMain.Controls["pnlMain"].Controls.Add(uc);


            }
        }


        private void DeleteCategory(int categoryId)
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

                sqlCommand.CommandText = "Delete Categories Where CategoryId=@CategoryId";
                //set paramiters
                sqlCommand.Parameters.AddWithValue("CategoryId", categoryId);

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
