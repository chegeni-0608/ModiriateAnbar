using ModiriateAnbar.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
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
            // fillgridview();
            fillgridviewWithSqlDataAdapter();
        }

        //private void fillgridview()

       // private void fillgridviewWithSqlDataAdapter(string code, string CategoryName = null)

        private void fillgridviewWithSqlDataAdapter(string CategoryName="")
        {
            var category=new List<Category>();

            //step 1
            using (SqlConnection 
                sqlConnection = new SqlConnection("Data Source=.; Initial Catalog=CsharpSampleDB; Integrated Security=True")) 
            {
                //step 2
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlConnection;
                //cmd.CommandText = "Select CategoryID,CategoryName,Description from Categories";
                cmd.CommandText = "sp_GetCategories";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CategoryName", CategoryName);



                //step 3 
                SqlDataAdapter adapter= new SqlDataAdapter();
                adapter.SelectCommand = cmd;

                DataSet ds = new DataSet();
                adapter.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];

            }

            
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
                    fillgridviewWithSqlDataAdapter();
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
         //   fillgridviewWithSqlDataAdapter(
         //txtCategoryName.Text,
         //txtProductName.Text,
         //txtfromprice.Text,
         //txttoPrice.text)


         //      );
        }
        private void FillGridView(string CategoryName,string ProductName,int? fromPrice,int? toPrice)
        {
            using (var sqlConnection=new SqlConnection(""))
            {
               var Command= new SqlCommand();
                Command.Connection = sqlConnection;
                Command.CommandText = "sp_products";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.AddWithValue("@CategoryName",CategoryName);
                Command.Parameters.AddWithValue("@ProductName",ProductName);
                Command.Parameters.AddWithValue("@fromprice",fromPrice);
                Command.Parameters.AddWithValue("@toPrice",toPrice);

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = Command;
                DataTable dtProduct = new DataTable();
                adapter.Fill(dtProduct);


                dataGridView1.DataSource = dtProduct;

            }
        }
    }
}
