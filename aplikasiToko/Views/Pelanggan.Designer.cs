namespace aplikasiToko.Views
{
    partial class Pelanggan
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.hapuskan = new System.Windows.Forms.Button();
            this.editkan = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbFemale = new System.Windows.Forms.RadioButton();
            this.cbMale = new System.Windows.Forms.RadioButton();
            this.tambahkan = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.inAlamat = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.inTelp = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.inEmail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNama = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtKodePelanggan = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.AutoSize = true;
            this.groupBox2.Controls.Add(this.hapuskan);
            this.groupBox2.Controls.Add(this.editkan);
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(27, 332);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(990, 332);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Daftar Pelanggan";
            // 
            // hapuskan
            // 
            this.hapuskan.BackColor = System.Drawing.Color.Red;
            this.hapuskan.Enabled = false;
            this.hapuskan.Location = new System.Drawing.Point(705, 20);
            this.hapuskan.Name = "hapuskan";
            this.hapuskan.Size = new System.Drawing.Size(124, 41);
            this.hapuskan.TabIndex = 2;
            this.hapuskan.Text = "Hapus";
            this.hapuskan.UseVisualStyleBackColor = false;
            this.hapuskan.Click += new System.EventHandler(this.hapuskan_Click);
            // 
            // editkan
            // 
            this.editkan.BackColor = System.Drawing.Color.OliveDrab;
            this.editkan.Location = new System.Drawing.Point(835, 20);
            this.editkan.Name = "editkan";
            this.editkan.Size = new System.Drawing.Size(124, 41);
            this.editkan.TabIndex = 1;
            this.editkan.Text = "Edit";
            this.editkan.UseVisualStyleBackColor = false;
            this.editkan.Click += new System.EventHandler(this.editkan_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(30, 67);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(929, 238);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick_1);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.cbFemale);
            this.groupBox1.Controls.Add(this.cbMale);
            this.groupBox1.Controls.Add(this.tambahkan);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.inAlamat);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.inTelp);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.inEmail);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtNama);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtKodePelanggan);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(27, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(990, 287);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tambah Pelanggan";
            // 
            // cbFemale
            // 
            this.cbFemale.AutoSize = true;
            this.cbFemale.Checked = true;
            this.cbFemale.Location = new System.Drawing.Point(322, 136);
            this.cbFemale.Name = "cbFemale";
            this.cbFemale.Size = new System.Drawing.Size(130, 28);
            this.cbFemale.TabIndex = 4;
            this.cbFemale.TabStop = true;
            this.cbFemale.Text = "Perempuan";
            this.cbFemale.UseVisualStyleBackColor = true;
            // 
            // cbMale
            // 
            this.cbMale.AutoSize = true;
            this.cbMale.Location = new System.Drawing.Point(209, 136);
            this.cbMale.Name = "cbMale";
            this.cbMale.Size = new System.Drawing.Size(107, 28);
            this.cbMale.TabIndex = 3;
            this.cbMale.Text = "Laki - laki";
            this.cbMale.UseVisualStyleBackColor = true;
            // 
            // tambahkan
            // 
            this.tambahkan.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.tambahkan.Location = new System.Drawing.Point(835, 219);
            this.tambahkan.Name = "tambahkan";
            this.tambahkan.Size = new System.Drawing.Size(124, 41);
            this.tambahkan.TabIndex = 8;
            this.tambahkan.Text = "Tambah";
            this.tambahkan.UseVisualStyleBackColor = false;
            this.tambahkan.Click += new System.EventHandler(this.tambahkan_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 135);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(127, 24);
            this.label6.TabIndex = 10;
            this.label6.Text = "Jenis Kelamin";
            // 
            // inAlamat
            // 
            this.inAlamat.Location = new System.Drawing.Point(659, 97);
            this.inAlamat.Multiline = true;
            this.inAlamat.Name = "inAlamat";
            this.inAlamat.Size = new System.Drawing.Size(300, 98);
            this.inAlamat.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(526, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 24);
            this.label5.TabIndex = 8;
            this.label5.Text = "Alamat";
            // 
            // inTelp
            // 
            this.inTelp.Location = new System.Drawing.Point(659, 56);
            this.inTelp.Name = "inTelp";
            this.inTelp.Size = new System.Drawing.Size(300, 28);
            this.inTelp.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(526, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 24);
            this.label4.TabIndex = 6;
            this.label4.Text = "Telp";
            // 
            // inEmail
            // 
            this.inEmail.Location = new System.Drawing.Point(205, 168);
            this.inEmail.Name = "inEmail";
            this.inEmail.Size = new System.Drawing.Size(300, 28);
            this.inEmail.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "Email";
            // 
            // txtNama
            // 
            this.txtNama.Location = new System.Drawing.Point(205, 100);
            this.txtNama.Name = "txtNama";
            this.txtNama.Size = new System.Drawing.Size(300, 28);
            this.txtNama.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nama";
            // 
            // txtKodePelanggan
            // 
            this.txtKodePelanggan.Location = new System.Drawing.Point(205, 58);
            this.txtKodePelanggan.Name = "txtKodePelanggan";
            this.txtKodePelanggan.Size = new System.Drawing.Size(300, 28);
            this.txtKodePelanggan.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kode Pelanggan";
            // 
            // Pelanggan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 689);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Pelanggan";
            this.Text = "Pelanggan";
            this.Load += new System.EventHandler(this.Pelanggan_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button hapuskan;
        private System.Windows.Forms.Button editkan;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton cbFemale;
        private System.Windows.Forms.RadioButton cbMale;
        private System.Windows.Forms.Button tambahkan;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox inAlamat;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox inTelp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox inEmail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNama;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtKodePelanggan;
        private System.Windows.Forms.Label label1;
    }
}