using System.Diagnostics;

namespace BulkExeBlocker
{
	partial class BulkExeBlocker
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
			runScriptButton = new Button();
			directoryTextbox = new TextBox();
			rulePrefixTextbox = new TextBox();
			directoryLabel = new Label();
			rulePrefixLabel = new Label();
			rulePrefixHintLabel = new Label();
			directoryBrowseButton = new Button();
			rulePrefixPreviewHintLabel = new Label();
			rulePrefixPreviewLabel = new Label();
			mainProgressBar = new ProgressBar();
			SuspendLayout();
			// 
			// runScriptButton
			// 
			runScriptButton.Location = new Point(10, 202);
			runScriptButton.Margin = new Padding(3, 2, 3, 2);
			runScriptButton.Name = "runScriptButton";
			runScriptButton.Size = new Size(730, 97);
			runScriptButton.TabIndex = 0;
			runScriptButton.Text = "Block!";
			runScriptButton.UseVisualStyleBackColor = true;
			runScriptButton.Click += RunScriptButton_Click;
			// 
			// directoryTextbox
			// 
			directoryTextbox.Location = new Point(10, 24);
			directoryTextbox.Margin = new Padding(3, 2, 3, 2);
			directoryTextbox.Name = "directoryTextbox";
			directoryTextbox.Size = new Size(730, 23);
			directoryTextbox.TabIndex = 1;
			// 
			// rulePrefixTextbox
			// 
			rulePrefixTextbox.Location = new Point(10, 128);
			rulePrefixTextbox.Margin = new Padding(3, 2, 3, 2);
			rulePrefixTextbox.Name = "rulePrefixTextbox";
			rulePrefixTextbox.Size = new Size(730, 23);
			rulePrefixTextbox.TabIndex = 1;
			rulePrefixTextbox.TextChanged += RulePrefixTextbox_OnTextChanged;
			// 
			// directoryLabel
			// 
			directoryLabel.AutoSize = true;
			directoryLabel.Location = new Point(10, 7);
			directoryLabel.Name = "directoryLabel";
			directoryLabel.Size = new Size(58, 15);
			directoryLabel.TabIndex = 2;
			directoryLabel.Text = "Directory:";
			// 
			// rulePrefixLabel
			// 
			rulePrefixLabel.AutoSize = true;
			rulePrefixLabel.Location = new Point(10, 111);
			rulePrefixLabel.Name = "rulePrefixLabel";
			rulePrefixLabel.Size = new Size(122, 15);
			rulePrefixLabel.TabIndex = 2;
			rulePrefixLabel.Text = "Visible Tag (Optional):";
			// 
			// rulePrefixHintLabel
			// 
			rulePrefixHintLabel.AutoSize = true;
			rulePrefixHintLabel.Location = new Point(10, 96);
			rulePrefixHintLabel.Name = "rulePrefixHintLabel";
			rulePrefixHintLabel.Size = new Size(336, 15);
			rulePrefixHintLabel.TabIndex = 2;
			rulePrefixHintLabel.Text = "NOTE: In tag, It's a good practice to use seperators like { } or ( ) ";
			// 
			// directoryBrowseButton
			// 
			directoryBrowseButton.Location = new Point(10, 49);
			directoryBrowseButton.Margin = new Padding(3, 2, 3, 2);
			directoryBrowseButton.Name = "directoryBrowseButton";
			directoryBrowseButton.Size = new Size(730, 34);
			directoryBrowseButton.TabIndex = 0;
			directoryBrowseButton.Text = "Browse";
			directoryBrowseButton.UseVisualStyleBackColor = true;
			directoryBrowseButton.Click += DirectoryBrowseButton_Click;
			// 
			// rulePrefixPreviewHintLabel
			// 
			rulePrefixPreviewHintLabel.AutoSize = true;
			rulePrefixPreviewHintLabel.Location = new Point(10, 159);
			rulePrefixPreviewHintLabel.Name = "rulePrefixPreviewHintLabel";
			rulePrefixPreviewHintLabel.Size = new Size(152, 15);
			rulePrefixPreviewHintLabel.TabIndex = 2;
			rulePrefixPreviewHintLabel.Text = "Your rules will look like this:";
			// 
			// rulePrefixPreviewLabel
			// 
			rulePrefixPreviewLabel.AutoSize = true;
			rulePrefixPreviewLabel.Location = new Point(10, 174);
			rulePrefixPreviewLabel.Name = "rulePrefixPreviewLabel";
			rulePrefixPreviewLabel.Size = new Size(19, 15);
			rulePrefixPreviewLabel.TabIndex = 2;
			rulePrefixPreviewLabel.Text = "    ";
			// 
			// mainProgressBar
			// 
			mainProgressBar.Location = new Point(12, 304);
			mainProgressBar.Name = "mainProgressBar";
			mainProgressBar.Size = new Size(728, 32);
			mainProgressBar.TabIndex = 3;
			// 
			// BulkExeBlocker
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(752, 345);
			Controls.Add(mainProgressBar);
			Controls.Add(rulePrefixHintLabel);
			Controls.Add(rulePrefixPreviewLabel);
			Controls.Add(rulePrefixPreviewHintLabel);
			Controls.Add(rulePrefixLabel);
			Controls.Add(directoryLabel);
			Controls.Add(rulePrefixTextbox);
			Controls.Add(directoryTextbox);
			Controls.Add(directoryBrowseButton);
			Controls.Add(runScriptButton);
			Margin = new Padding(3, 2, 3, 2);
			Name = "BulkExeBlocker";
			Text = "Bulk Exe Blocker";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button runScriptButton;
		private TextBox directoryTextbox;
		private TextBox rulePrefixTextbox;
		private Label directoryLabel;
		private Label rulePrefixLabel;
		private Label rulePrefixHintLabel;
		private Button directoryBrowseButton;
		private Label rulePrefixPreviewHintLabel;
		private Label rulePrefixPreviewLabel;
		private ProgressBar mainProgressBar;
	}
}
