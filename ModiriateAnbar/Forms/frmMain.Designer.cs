namespace ModiriateAnbar.Forms
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.btnProductCategory = new System.Windows.Forms.Button();
            this.btnEmpioyeeList = new System.Windows.Forms.Button();
            this.btnProductList = new System.Windows.Forms.Button();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.btnAddNewCategory = new System.Windows.Forms.Button();
            this.pnlSidebar.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.pnlSidebar.Controls.Add(this.btnAddNewCategory);
            this.pnlSidebar.Controls.Add(this.btnProductCategory);
            this.pnlSidebar.Controls.Add(this.btnEmpioyeeList);
            this.pnlSidebar.Controls.Add(this.btnProductList);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlSidebar.Location = new System.Drawing.Point(867, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(181, 450);
            this.pnlSidebar.TabIndex = 0;
            // 
            // btnProductCategory
            // 
            this.btnProductCategory.Location = new System.Drawing.Point(18, 87);
            this.btnProductCategory.Name = "btnProductCategory";
            this.btnProductCategory.Size = new System.Drawing.Size(151, 31);
            this.btnProductCategory.TabIndex = 2;
            this.btnProductCategory.Text = "لیست گروه ها";
            this.btnProductCategory.UseVisualStyleBackColor = true;
            this.btnProductCategory.Click += new System.EventHandler(this.btnProductCategory_Click);
            // 
            // btnEmpioyeeList
            // 
            this.btnEmpioyeeList.Location = new System.Drawing.Point(18, 50);
            this.btnEmpioyeeList.Name = "btnEmpioyeeList";
            this.btnEmpioyeeList.Size = new System.Drawing.Size(151, 31);
            this.btnEmpioyeeList.TabIndex = 1;
            this.btnEmpioyeeList.Text = "لیست کارمندان";
            this.btnEmpioyeeList.UseVisualStyleBackColor = true;
            this.btnEmpioyeeList.Click += new System.EventHandler(this.btnEmpioyeeList_Click);
            // 
            // btnProductList
            // 
            this.btnProductList.Location = new System.Drawing.Point(18, 12);
            this.btnProductList.Name = "btnProductList";
            this.btnProductList.Size = new System.Drawing.Size(151, 32);
            this.btnProductList.TabIndex = 0;
            this.btnProductList.Text = "لیست محصولات";
            this.btnProductList.UseVisualStyleBackColor = true;
            this.btnProductList.Click += new System.EventHandler(this.btnProductList_Click);
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.Silver;
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 411);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(867, 39);
            this.pnlFooter.TabIndex = 1;
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(867, 411);
            this.pnlMain.TabIndex = 3;
            // 
            // btnAddNewCategory
            // 
            this.btnAddNewCategory.Location = new System.Drawing.Point(18, 124);
            this.btnAddNewCategory.Name = "btnAddNewCategory";
            this.btnAddNewCategory.Size = new System.Drawing.Size(151, 33);
            this.btnAddNewCategory.TabIndex = 3;
            this.btnAddNewCategory.Text = "افزودن گروه جدید";
            this.btnAddNewCategory.UseVisualStyleBackColor = true;
            this.btnAddNewCategory.Click += new System.EventHandler(this.btnAddNewCategory_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1048, 450);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlSidebar);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmMain";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "نرم افزار مدیریت انبار";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlSidebar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Button btnEmpioyeeList;
        private System.Windows.Forms.Button btnProductList;
        private System.Windows.Forms.Button btnProductCategory;
        public System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Button btnAddNewCategory;
    }
}