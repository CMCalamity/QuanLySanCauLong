namespace QuanLyBanHang
{
    partial class FormQR
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
            pictureBox1 = new PictureBox();
            label1 = new Label();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.z7822781251329_f1b62956d0b969a07b9126ed6e29d52f;
            pictureBox1.Location = new Point(265, 35);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(267, 209);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(289, 247);
            label1.Name = "label1";
            label1.Size = new Size(219, 20);
            label1.TabIndex = 1;
            label1.Text = "Vui lòng quét mã để thanh toán";
            // 
            // button1
            // 
            button1.Location = new Point(316, 270);
            button1.Name = "button1";
            button1.Size = new Size(164, 29);
            button1.TabIndex = 2;
            button1.Text = "Đóng";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // FormQR
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Name = "FormQR";
            Text = "FormQR";
            Load += FormQR_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private Button button1;
    }
}