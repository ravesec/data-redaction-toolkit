namespace GUI
{
    public partial class Main : Form
    {
        private Button _selectedButton = null;

        public Main()
        {
            InitializeComponent();
        }

        // Method to change the color of selected button
        private void SelectButton(Button button)
        {
            if (_selectedButton != null)
            {
                // Reset the previous selected button back to it's default color
                _selectedButton.BackColor = Color.Transparent;
            }

            // Set the new selected button
            _selectedButton = button;
            if (_selectedButton != null)
            {
                // Change the color of the selected button
                _selectedButton.BackColor = System.Drawing.ColorTranslator.FromHtml("#4b4c4f");
            }
        }

        private void redaction_options_button_Click_1(object sender, EventArgs e)
        {
            SelectButton(sender as Button);
        }

        private void redaction_options_button_MouseEnter(object sender, EventArgs e)
        {
            if (_selectedButton != redaction_options_button)
            {
                redaction_options_button.BackColor = System.Drawing.ColorTranslator.FromHtml("#4b4c4f");
            }
        }

        private void redaction_options_button_MouseLeave(object sender, EventArgs e)
        {
            if (_selectedButton != redaction_options_button)
            {
                redaction_options_button.BackColor = Color.Transparent;
            }
        }

        private void settings_button_Click(object sender, EventArgs e)
        {
            SelectButton(sender as Button);
        }

        private void settings_button_MouseEnter(object sender, EventArgs e)
        {
            if (_selectedButton != settings_button)
            {
                settings_button.BackColor = System.Drawing.ColorTranslator.FromHtml("#4b4c4f");
            }
        }

        private void settings_button_MouseLeave(object sender, EventArgs e)
        {
            if (_selectedButton != settings_button)
            {
                settings_button.BackColor = Color.Transparent;
            }
        }

        private void fileSelectorLabel_Click(object sender, EventArgs e)
        {
            using var openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true; // Allow selection of multiple files

            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;

            // Hide the drag and drop label, then show the fileListView
            fileSelectorLabel.Visible = false;
            fileListView.Visible = true;

            // Add selected files to list view
            var files = openFileDialog.FileNames;
            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);
                var item = new ListViewItem(new[]
                {
                    fileInfo.Name,
                    fileInfo.Length.ToString(),
                    fileInfo.Extension
                });
                fileListView.Items.Add(item);
            }
        }
    }
}
