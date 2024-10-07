
namespace GUI
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            panel1 = new Panel();
            settings_button = new Button();
            imageList1 = new ImageList(components);
            redaction_options_button = new Button();
            options_panel_tooltip = new ToolTip(components);
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(43, 45, 48);
            panel1.Controls.Add(settings_button);
            panel1.Controls.Add(redaction_options_button);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(77, 732);
            panel1.TabIndex = 0;
            // 
            // settings_button
            // 
            settings_button.FlatAppearance.BorderColor = Color.FromArgb(43, 45, 48);
            settings_button.FlatStyle = FlatStyle.Flat;
            settings_button.ImageIndex = 1;
            settings_button.ImageList = imageList1;
            settings_button.Location = new Point(12, 66);
            settings_button.Name = "settings_button";
            settings_button.Size = new Size(48, 48);
            settings_button.TabIndex = 2;
            options_panel_tooltip.SetToolTip(settings_button, "Display the settings");
            settings_button.UseVisualStyleBackColor = true;
            settings_button.Click += settings_button_Click;
            settings_button.MouseEnter += settings_button_MouseEnter;
            settings_button.MouseLeave += settings_button_MouseLeave;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "icons8-lock-48.png");
            imageList1.Images.SetKeyName(1, "icons8-settings-48.png");
            // 
            // redaction_options_button
            // 
            redaction_options_button.FlatAppearance.BorderColor = Color.FromArgb(43, 45, 48);
            redaction_options_button.FlatStyle = FlatStyle.Flat;
            redaction_options_button.ImageIndex = 0;
            redaction_options_button.ImageList = imageList1;
            redaction_options_button.Location = new Point(12, 12);
            redaction_options_button.Name = "redaction_options_button";
            redaction_options_button.Size = new Size(48, 48);
            redaction_options_button.TabIndex = 1;
            options_panel_tooltip.SetToolTip(redaction_options_button, "Shows redaction options");
            redaction_options_button.UseVisualStyleBackColor = true;
            redaction_options_button.Click += redaction_options_button_Click_1;
            redaction_options_button.MouseEnter += redaction_options_button_MouseEnter;
            redaction_options_button.MouseLeave += redaction_options_button_MouseLeave;
            // 
            // options_panel_tooltip
            // 
            options_panel_tooltip.ToolTipTitle = "Options Panel";
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1269, 732);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Main";
            Text = "Data Redaction Toolkit";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        private void Redaction_options_button_MouseLeave(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void redaction_options_button_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private Panel panel1;
        private ImageList imageList1;
        private Button redaction_options_button;
        private ToolTip options_panel_tooltip;
        private Button settings_button;
    }
}
