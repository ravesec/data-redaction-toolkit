namespace GUI
{
    public partial class Main : Form
    {
        private Button selectedButton = null;

        public Main()
        {
            InitializeComponent();
        }

        // Method to change the color of selected button
        private void SelectButton(Button button)
        {
            if (selectedButton != null)
            {
                // Reset the previous selected button back to it's default color
                selectedButton.BackColor = Color.Transparent;
            }

            // Set the new selected button
            selectedButton = button;
            if (selectedButton != null)
            {
                // Change the color of the selected button
                selectedButton.BackColor = System.Drawing.ColorTranslator.FromHtml("#3574f0");
            }
        }

        private void redaction_options_button_Click_1(object sender, EventArgs e)
        {
            SelectButton(sender as Button);
        }

        private void redaction_options_button_MouseEnter(object sender, EventArgs e)
        {
            if (selectedButton != redaction_options_button)
            {
                redaction_options_button.BackColor = System.Drawing.ColorTranslator.FromHtml("#4b4c4f");
            }
        }

        private void redaction_options_button_MouseLeave(object sender, EventArgs e)
        {
            if (selectedButton != redaction_options_button)
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
            if (selectedButton != settings_button)
            {
                settings_button.BackColor = System.Drawing.ColorTranslator.FromHtml("#4b4c4f");
            }
        }

        private void settings_button_MouseLeave(object sender, EventArgs e)
        {
            if (selectedButton != settings_button)
            {
                settings_button.BackColor = Color.Transparent;
            }
        }
    }
}
