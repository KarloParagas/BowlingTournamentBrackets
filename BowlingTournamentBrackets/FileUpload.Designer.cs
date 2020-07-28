namespace BowlingTournamentBrackets
{
    partial class FileUpload
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
            this.label1 = new System.Windows.Forms.Label();
            this.UploadBtn = new System.Windows.Forms.Button();
            this.ChooseFileBtn = new System.Windows.Forms.Button();
            this.UploadTxt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Choose a text file to process:";
            // 
            // UploadBtn
            // 
            this.UploadBtn.Location = new System.Drawing.Point(303, 69);
            this.UploadBtn.Name = "UploadBtn";
            this.UploadBtn.Size = new System.Drawing.Size(75, 23);
            this.UploadBtn.TabIndex = 1;
            this.UploadBtn.Text = "Upload";
            this.UploadBtn.UseVisualStyleBackColor = true;
            this.UploadBtn.Click += new System.EventHandler(this.UploadBtn_Click);
            // 
            // ChooseFileBtn
            // 
            this.ChooseFileBtn.Location = new System.Drawing.Point(202, 69);
            this.ChooseFileBtn.Name = "ChooseFileBtn";
            this.ChooseFileBtn.Size = new System.Drawing.Size(75, 23);
            this.ChooseFileBtn.TabIndex = 0;
            this.ChooseFileBtn.Text = "Browse Files";
            this.ChooseFileBtn.UseVisualStyleBackColor = true;
            this.ChooseFileBtn.Click += new System.EventHandler(this.ChooseFileBtn_Click);
            // 
            // UploadTxt
            // 
            this.UploadTxt.Location = new System.Drawing.Point(161, 34);
            this.UploadTxt.Name = "UploadTxt";
            this.UploadTxt.Size = new System.Drawing.Size(260, 20);
            this.UploadTxt.TabIndex = 4;
            this.UploadTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FileUpload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(433, 104);
            this.Controls.Add(this.UploadTxt);
            this.Controls.Add(this.ChooseFileBtn);
            this.Controls.Add(this.UploadBtn);
            this.Controls.Add(this.label1);
            this.Name = "FileUpload";
            this.Text = "Upload File";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button UploadBtn;
        private System.Windows.Forms.Button ChooseFileBtn;
        private System.Windows.Forms.TextBox UploadTxt;
    }
}