
namespace ArchiverApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.btnChooseFiles = new System.Windows.Forms.Button();
            this.listBoxFiles = new System.Windows.Forms.ListBox();
            this.btnSaveArchive = new System.Windows.Forms.Button();
            this.textBoxArchivePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnChooseFiles
            // 
            this.btnChooseFiles.Location = new System.Drawing.Point(30, 25);
            this.btnChooseFiles.Name = "btnChooseFiles";
            this.btnChooseFiles.Size = new System.Drawing.Size(200, 30);
            this.btnChooseFiles.TabIndex = 0;
            this.btnChooseFiles.Text = "Обрати файли";
            this.btnChooseFiles.UseVisualStyleBackColor = true;
            this.btnChooseFiles.Click += new System.EventHandler(this.btnChooseFiles_Click);
            // 
            // listBoxFiles
            // 
            this.listBoxFiles.FormattingEnabled = true;
            this.listBoxFiles.HorizontalScrollbar = true;
            this.listBoxFiles.ItemHeight = 16;
            this.listBoxFiles.Location = new System.Drawing.Point(30, 70);
            this.listBoxFiles.Name = "listBoxFiles";
            this.listBoxFiles.Size = new System.Drawing.Size(500, 180);
            this.listBoxFiles.TabIndex = 1;
            // 
            // btnSaveArchive
            // 
            this.btnSaveArchive.Location = new System.Drawing.Point(30, 270);
            this.btnSaveArchive.Name = "btnSaveArchive";
            this.btnSaveArchive.Size = new System.Drawing.Size(200, 30);
            this.btnSaveArchive.TabIndex = 2;
            this.btnSaveArchive.Text = "Зберегти архів";
            this.btnSaveArchive.UseVisualStyleBackColor = true;
            this.btnSaveArchive.Click += new System.EventHandler(this.btnSaveArchive_Click);
            // 
            // textBoxArchivePath
            // 
            this.textBoxArchivePath.Location = new System.Drawing.Point(30, 330);
            this.textBoxArchivePath.Name = "textBoxArchivePath";
            this.textBoxArchivePath.ReadOnly = true;
            this.textBoxArchivePath.Size = new System.Drawing.Size(500, 22);
            this.textBoxArchivePath.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 310);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Шлях до збереження:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 380);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxArchivePath);
            this.Controls.Add(this.btnSaveArchive);
            this.Controls.Add(this.listBoxFiles);
            this.Controls.Add(this.btnChooseFiles);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Архіватор файлів";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnChooseFiles;
        private System.Windows.Forms.ListBox listBoxFiles;
        private System.Windows.Forms.Button btnSaveArchive;
        private System.Windows.Forms.TextBox textBoxArchivePath;
        private System.Windows.Forms.Label label1;
    }
}
