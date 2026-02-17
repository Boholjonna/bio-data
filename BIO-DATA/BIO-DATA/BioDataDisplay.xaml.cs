using System;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace BIO_DATA
{
    public partial class BioDataDisplay : Window
    {
        public BioDataDisplay()
        {
            InitializeComponent();
        }

        public void SetBioData(string name, string gender, string birthdate, string address, 
                             string email, string phone, string nationality, string education, 
                             string skills, string experience, string references)
        {
            // Clear any existing content
            InfoPanel.Children.Clear();

            // Add each piece of information to the panel
            AddInfoItem("Full Name:", name);
            AddInfoItem("Gender:", gender);
            AddInfoItem("Date of Birth:", birthdate);
            AddInfoItem("Address:", address);
            AddInfoItem("Email:", email);
            AddInfoItem("Phone:", phone);
            AddInfoItem("Nationality:", nationality);
            AddInfoItem("Education:", education);
            AddInfoItem("Skills:", skills);
            AddInfoItem("Experience:", experience);
            AddInfoItem("References:", references);
        }

        private void AddInfoItem(string label, string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return;

            var grid = new Grid();
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, System.Windows.GridUnitType.Auto) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, System.Windows.GridUnitType.Star) });
            grid.Margin = new Thickness(0, 0, 0, 10);

            var labelTextBlock = new TextBlock
            {
                Text = label,
                FontWeight = FontWeights.Bold,
                Margin = new Thickness(0, 0, 10, 0),
                VerticalAlignment = System.Windows.VerticalAlignment.Top
            };

            var valueTextBlock = new TextBlock
            {
                Text = value,
                TextWrapping = System.Windows.TextWrapping.Wrap
            };

            Grid.SetColumn(labelTextBlock, 0);
            Grid.SetColumn(valueTextBlock, 1);

            grid.Children.Add(labelTextBlock);
            grid.Children.Add(valueTextBlock);

            InfoPanel.Children.Add(grid);
        }

        private void DownloadButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var saveFileDialog = new Microsoft.Win32.SaveFileDialog
                {
                    FileName = "BioData",
                    DefaultExt = ".txt",
                    Filter = "Text documents (.txt)|*.txt"
                };

                if (saveFileDialog.ShowDialog() == true)
                {
                    var sb = new StringBuilder();
                    sb.AppendLine("BIO DATA");
                    sb.AppendLine("========");
                    sb.AppendLine();

                    foreach (Grid grid in InfoPanel.Children)
                    {
                        if (grid.Children.Count >= 2 && 
                            grid.Children[0] is TextBlock label && 
                            grid.Children[1] is TextBlock value)
                        {
                            sb.AppendLine($"{label.Text} {value.Text}");
                        }
                        sb.AppendLine();
                    }

                    File.WriteAllText(saveFileDialog.FileName, sb.ToString());
                    MessageBox.Show("Bio Data saved successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving file: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
