using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;



namespace ArchiverApp
{
    public partial class Form1 : Form
    {
        private List<string> selectedFiles = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnChooseFiles_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Multiselect = true;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    selectedFiles.Clear();
                    listBoxFiles.Items.Clear();
                    selectedFiles.AddRange(ofd.FileNames);
                    listBoxFiles.Items.AddRange(ofd.FileNames);
                }
            }
        }

        private void btnSaveArchive_Click(object sender, EventArgs e)
        {
            if (selectedFiles.Count == 0)
            {
                MessageBox.Show("Не обрано жодного файлу!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "ZIP archive|*.zip";
                sfd.Title = "Зберегти архів";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    string zipPath = sfd.FileName;

                    using (FileStream zipToOpen = new FileStream(zipPath, FileMode.Create))
                    using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Create))
                    {
                        foreach (string filePath in selectedFiles)
                        {
							//                     string entryName = Path.GetFileName(filePath);
							//object value = archive.CreateEntryFromFile(filePath, entryName);
							ZipArchiveEntry entry = archive.CreateEntry(Path.GetFileName(filePath));
							using (Stream entryStream = entry.Open())
							using (FileStream fileStream = File.OpenRead(filePath))
							{
								fileStream.CopyTo(entryStream);
							}

						}
					}

                    textBoxArchivePath.Text = zipPath;
                    MessageBox.Show("Архів створено успішно!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
