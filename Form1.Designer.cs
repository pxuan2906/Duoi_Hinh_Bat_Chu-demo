namespace Game_Duoi_Hinh_Bat_Chu
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ptrHinhAnh = new System.Windows.Forms.PictureBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnHint = new System.Windows.Forms.Button();
            this.btn_Diem = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ptrHinhAnh)).BeginInit();
            this.SuspendLayout();
            // 
            // ptrHinhAnh
            // 
            this.ptrHinhAnh.Location = new System.Drawing.Point(518, 272);
            this.ptrHinhAnh.Name = "ptrHinhAnh";
            this.ptrHinhAnh.Size = new System.Drawing.Size(741, 422);
            this.ptrHinhAnh.TabIndex = 0;
            this.ptrHinhAnh.TabStop = false;
            
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Times New Roman", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnExit.Location = new System.Drawing.Point(57, 34);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(83, 45);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "X";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnHint
            // 
            this.btnHint.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnHint.Location = new System.Drawing.Point(363, 34);
            this.btnHint.Name = "btnHint";
            this.btnHint.Size = new System.Drawing.Size(144, 47);
            this.btnHint.TabIndex = 2;
            this.btnHint.Text = "Gợi Ý";
            this.btnHint.UseVisualStyleBackColor = true;
            this.btnHint.Click += new System.EventHandler(this.btnHint_Click);
            // 
            // btn_Diem
            // 
            this.btn_Diem.Font = new System.Drawing.Font("Times New Roman", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btn_Diem.Location = new System.Drawing.Point(733, 40);
            this.btn_Diem.Name = "btn_Diem";
            this.btn_Diem.Size = new System.Drawing.Size(144, 49);
            this.btn_Diem.TabIndex = 3;
            this.btn_Diem.Text = "diem";
            this.btn_Diem.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1304, 749);
            this.Controls.Add(this.btn_Diem);
            this.Controls.Add(this.btnHint);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.ptrHinhAnh);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.ptrHinhAnh)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox ptrHinhAnh;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnHint;
        private System.Windows.Forms.Button btn_Diem;
    }
}

