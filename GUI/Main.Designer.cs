using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace GUI
{
    public class RoundedButton : Button
    {
        public RoundedButton()
        {
            this.Size = new Size(52, 52);
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);

            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, this.Width, this.Height);
            this.Region = new Region(path);

            using (Pen pen = new Pen(Color.Transparent, 0))
            {
                pen.Alignment = PenAlignment.Inset;
                pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                pevent.Graphics.DrawEllipse(pen, 1, 1, this.Width - 2, this.Height - 2);
            }
        }
    }

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
            selectorPanel = new Panel();
            report_button = new RoundedButton();
            selector_panel_buttons = new ImageList(components);
            settings_button = new RoundedButton();
            redaction_options_button = new RoundedButton();
            options_panel_tooltip = new ToolTip(components);
            splitContainer1 = new SplitContainer();
            fileSelectorLabel = new Label();
            fileListView = new ListView();
            filePathHeader = new ColumnHeader();
            fileSizeHeader = new ColumnHeader();
            fileExtensionHeader = new ColumnHeader();
            selectorPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // selectorPanel
            // 
            selectorPanel.BackColor = Color.FromArgb(43, 45, 48);
            selectorPanel.Controls.Add(report_button);
            selectorPanel.Controls.Add(settings_button);
            selectorPanel.Controls.Add(redaction_options_button);
            selectorPanel.Dock = DockStyle.Left;
            selectorPanel.Location = new Point(0, 0);
            selectorPanel.Name = "selectorPanel";
            selectorPanel.Size = new Size(77, 732);
            selectorPanel.TabIndex = 0;
            // 
            // report_button
            // 
            report_button.FlatStyle = FlatStyle.Flat;
            report_button.ImageIndex = 2;
            report_button.ImageList = selector_panel_buttons;
            report_button.Location = new Point(12, 12);
            report_button.Name = "report_button";
            report_button.Size = new Size(48, 48);
            report_button.TabIndex = 3;
            options_panel_tooltip.SetToolTip(report_button, "Show reports page");
            report_button.UseVisualStyleBackColor = true;
            report_button.Click += report_button_Click;
            report_button.MouseEnter += report_button_MouseEnter;
            report_button.MouseLeave += report_button_MouseLeave;
            // 
            // selector_panel_buttons
            // 
            selector_panel_buttons.ColorDepth = ColorDepth.Depth32Bit;
            selector_panel_buttons.ImageStream = (ImageListStreamer)resources.GetObject("selector_panel_buttons.ImageStream");
            selector_panel_buttons.TransparentColor = Color.Transparent;
            selector_panel_buttons.Images.SetKeyName(0, "icons8-lock-48.png");
            selector_panel_buttons.Images.SetKeyName(1, "icons8-settings-48.png");
            selector_panel_buttons.Images.SetKeyName(2, "icons8-report-48.png");
            // 
            // settings_button
            // 
            settings_button.FlatAppearance.BorderColor = Color.FromArgb(43, 45, 48);
            settings_button.FlatStyle = FlatStyle.Flat;
            settings_button.ImageIndex = 1;
            settings_button.ImageList = selector_panel_buttons;
            settings_button.Location = new Point(12, 618);
            settings_button.Name = "settings_button";
            settings_button.Size = new Size(48, 48);
            settings_button.TabIndex = 2;
            options_panel_tooltip.SetToolTip(settings_button, "Display the settings");
            settings_button.UseVisualStyleBackColor = true;
            settings_button.Click += settings_button_Click;
            settings_button.MouseEnter += settings_button_MouseEnter;
            settings_button.MouseLeave += settings_button_MouseLeave;
            // 
            // redaction_options_button
            // 
            redaction_options_button.FlatAppearance.BorderColor = Color.FromArgb(43, 45, 48);
            redaction_options_button.FlatStyle = FlatStyle.Flat;
            redaction_options_button.ImageIndex = 0;
            redaction_options_button.ImageList = selector_panel_buttons;
            redaction_options_button.Location = new Point(12, 672);
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
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(77, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(fileSelectorLabel);
            splitContainer1.Panel1.Controls.Add(fileListView);
            splitContainer1.Size = new Size(1192, 732);
            splitContainer1.SplitterDistance = 397;
            splitContainer1.TabIndex = 1;
            // 
            // fileSelectorLabel
            // 
            fileSelectorLabel.Dock = DockStyle.Fill;
            fileSelectorLabel.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            fileSelectorLabel.Location = new Point(0, 0);
            fileSelectorLabel.Name = "fileSelectorLabel";
            fileSelectorLabel.Size = new Size(1192, 397);
            fileSelectorLabel.TabIndex = 0;
            fileSelectorLabel.Text = "Click to Select or Drag and Drop Files";
            fileSelectorLabel.TextAlign = ContentAlignment.MiddleCenter;
            fileSelectorLabel.Click += fileSelectorLabel_Click;
            // 
            // fileListView
            // 
            fileListView.Columns.AddRange(new ColumnHeader[] { filePathHeader, fileSizeHeader, fileExtensionHeader });
            fileListView.Dock = DockStyle.Fill;
            fileListView.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            fileListView.Location = new Point(0, 0);
            fileListView.Name = "fileListView";
            fileListView.Size = new Size(1192, 397);
            fileListView.TabIndex = 1;
            fileListView.UseCompatibleStateImageBehavior = false;
            fileListView.View = View.Details;
            fileListView.Visible = false;
            // 
            // filePathHeader
            // 
            filePathHeader.Text = "File Path";
            // 
            // fileSizeHeader
            // 
            fileSizeHeader.Text = "File Size";
            // 
            // fileExtensionHeader
            // 
            fileExtensionHeader.Text = "File Extension";
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1269, 732);
            Controls.Add(splitContainer1);
            Controls.Add(selectorPanel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Main";
            Text = "Data Redaction Toolkit";
            selectorPanel.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
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

        private Panel selectorPanel;
        private ImageList selector_panel_buttons;
        private ToolTip options_panel_tooltip;
        private SplitContainer splitContainer1;
        private Label fileSelectorLabel;
        private RoundedButton redaction_options_button;
        private RoundedButton settings_button;
        private RoundedButton report_button;
        private ListView fileListView;
        private ColumnHeader filePathHeader;
        private ColumnHeader fileSizeHeader;
        private ColumnHeader fileExtensionHeader;
    }
}
