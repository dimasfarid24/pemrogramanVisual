namespace aplikasiToko.Views
{
    partial class Parent
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
            this.Menustrip = new System.Windows.Forms.MenuStrip();
            this.loginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transaksiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.penjualanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pembelianToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pengaturanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.barangToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supplierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pelangganToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.penggunaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.laporanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.penjualanToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pembelianToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Menustrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // Menustrip
            // 
            this.Menustrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loginToolStripMenuItem,
            this.transaksiToolStripMenuItem,
            this.pengaturanToolStripMenuItem,
            this.laporanToolStripMenuItem,
            this.logoutToolStripMenuItem});
            this.Menustrip.Location = new System.Drawing.Point(0, 0);
            this.Menustrip.Name = "Menustrip";
            this.Menustrip.Size = new System.Drawing.Size(1059, 28);
            this.Menustrip.TabIndex = 1;
            this.Menustrip.Text = "MenuStrip";
            this.Menustrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // loginToolStripMenuItem
            // 
            this.loginToolStripMenuItem.Name = "loginToolStripMenuItem";
            this.loginToolStripMenuItem.Size = new System.Drawing.Size(58, 24);
            this.loginToolStripMenuItem.Text = "Login";
            this.loginToolStripMenuItem.Click += new System.EventHandler(this.loginToolStripMenuItem_Click);
            // 
            // transaksiToolStripMenuItem
            // 
            this.transaksiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.penjualanToolStripMenuItem,
            this.pembelianToolStripMenuItem});
            this.transaksiToolStripMenuItem.Enabled = false;
            this.transaksiToolStripMenuItem.Name = "transaksiToolStripMenuItem";
            this.transaksiToolStripMenuItem.Size = new System.Drawing.Size(80, 24);
            this.transaksiToolStripMenuItem.Text = "Transaksi";
            this.transaksiToolStripMenuItem.Click += new System.EventHandler(this.transaksiToolStripMenuItem_Click);
            // 
            // penjualanToolStripMenuItem
            // 
            this.penjualanToolStripMenuItem.Name = "penjualanToolStripMenuItem";
            this.penjualanToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.penjualanToolStripMenuItem.Text = "Penjualan";
            this.penjualanToolStripMenuItem.Click += new System.EventHandler(this.penjualanToolStripMenuItem_Click);
            // 
            // pembelianToolStripMenuItem
            // 
            this.pembelianToolStripMenuItem.Name = "pembelianToolStripMenuItem";
            this.pembelianToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.pembelianToolStripMenuItem.Text = "Pembelian";
            this.pembelianToolStripMenuItem.Click += new System.EventHandler(this.pembelianToolStripMenuItem_Click);
            // 
            // pengaturanToolStripMenuItem
            // 
            this.pengaturanToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.barangToolStripMenuItem,
            this.supplierToolStripMenuItem,
            this.pelangganToolStripMenuItem,
            this.penggunaToolStripMenuItem});
            this.pengaturanToolStripMenuItem.Enabled = false;
            this.pengaturanToolStripMenuItem.Name = "pengaturanToolStripMenuItem";
            this.pengaturanToolStripMenuItem.Size = new System.Drawing.Size(95, 24);
            this.pengaturanToolStripMenuItem.Text = "Pengaturan";
            // 
            // barangToolStripMenuItem
            // 
            this.barangToolStripMenuItem.Name = "barangToolStripMenuItem";
            this.barangToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.barangToolStripMenuItem.Text = "Produk";
            this.barangToolStripMenuItem.Click += new System.EventHandler(this.barangToolStripMenuItem_Click_1);
            // 
            // supplierToolStripMenuItem
            // 
            this.supplierToolStripMenuItem.Name = "supplierToolStripMenuItem";
            this.supplierToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.supplierToolStripMenuItem.Text = "Supplier";
            this.supplierToolStripMenuItem.Click += new System.EventHandler(this.supplierToolStripMenuItem_Click);
            // 
            // pelangganToolStripMenuItem
            // 
            this.pelangganToolStripMenuItem.Name = "pelangganToolStripMenuItem";
            this.pelangganToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.pelangganToolStripMenuItem.Text = "Pelanggan";
            this.pelangganToolStripMenuItem.Click += new System.EventHandler(this.pelangganToolStripMenuItem_Click);
            // 
            // penggunaToolStripMenuItem
            // 
            this.penggunaToolStripMenuItem.Name = "penggunaToolStripMenuItem";
            this.penggunaToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.penggunaToolStripMenuItem.Text = "Pengguna";
            this.penggunaToolStripMenuItem.Click += new System.EventHandler(this.penggunaToolStripMenuItem_Click);
            // 
            // laporanToolStripMenuItem
            // 
            this.laporanToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.penjualanToolStripMenuItem1,
            this.pembelianToolStripMenuItem1});
            this.laporanToolStripMenuItem.Enabled = false;
            this.laporanToolStripMenuItem.Name = "laporanToolStripMenuItem";
            this.laporanToolStripMenuItem.Size = new System.Drawing.Size(75, 24);
            this.laporanToolStripMenuItem.Text = "Laporan";
            // 
            // penjualanToolStripMenuItem1
            // 
            this.penjualanToolStripMenuItem1.Name = "penjualanToolStripMenuItem1";
            this.penjualanToolStripMenuItem1.Size = new System.Drawing.Size(152, 24);
            this.penjualanToolStripMenuItem1.Text = "Penjualan";
            this.penjualanToolStripMenuItem1.Click += new System.EventHandler(this.penjualanToolStripMenuItem1_Click);
            // 
            // pembelianToolStripMenuItem1
            // 
            this.pembelianToolStripMenuItem1.Name = "pembelianToolStripMenuItem1";
            this.pembelianToolStripMenuItem1.Size = new System.Drawing.Size(152, 24);
            this.pembelianToolStripMenuItem1.Text = "Pembelian";
            this.pembelianToolStripMenuItem1.Click += new System.EventHandler(this.pembelianToolStripMenuItem1_Click);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Enabled = false;
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(68, 24);
            this.logoutToolStripMenuItem.Text = "Logout";
            // 
            // Parent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1059, 633);
            this.Controls.Add(this.Menustrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.Menustrip;
            this.Name = "Parent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AplikasiKU";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Parent_Load);
            this.Menustrip.ResumeLayout(false);
            this.Menustrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem loginToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem penjualanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pembelianToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem barangToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem supplierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pelangganToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem penggunaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem penjualanToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem pembelianToolStripMenuItem1;
        public System.Windows.Forms.ToolStripMenuItem transaksiToolStripMenuItem;
        public System.Windows.Forms.MenuStrip Menustrip;
        public System.Windows.Forms.ToolStripMenuItem pengaturanToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem laporanToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
    }
}