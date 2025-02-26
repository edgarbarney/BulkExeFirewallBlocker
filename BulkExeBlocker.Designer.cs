using System.Diagnostics;

namespace CSharpFormsTest
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
			SuspendLayout();
			// 
			// runScriptButton
			// 
			runScriptButton.Location = new Point(12, 270);
			runScriptButton.Name = "runScriptButton";
			runScriptButton.Size = new Size(776, 168);
			runScriptButton.TabIndex = 0;
			runScriptButton.Text = "Block!";
			runScriptButton.UseVisualStyleBackColor = true;
			runScriptButton.Click += RunScriptButton_Click;
			// 
			// directoryTextbox
			// 
			directoryTextbox.Location = new Point(12, 32);
			directoryTextbox.Name = "directoryTextbox";
			directoryTextbox.Size = new Size(776, 27);
			directoryTextbox.TabIndex = 1;
			// 
			// rulePrefixTextbox
			// 
			rulePrefixTextbox.Location = new Point(12, 171);
			rulePrefixTextbox.Name = "rulePrefixTextbox";
			rulePrefixTextbox.Size = new Size(776, 27);
			rulePrefixTextbox.TabIndex = 1;
			rulePrefixTextbox.TextChanged += RulePrefixTextbox_OnTextChanged;
			// 
			// directoryLabel
			// 
			directoryLabel.AutoSize = true;
			directoryLabel.Location = new Point(12, 9);
			directoryLabel.Name = "directoryLabel";
			directoryLabel.Size = new Size(73, 20);
			directoryLabel.TabIndex = 2;
			directoryLabel.Text = "Directory:";
			// 
			// rulePrefixLabel
			// 
			rulePrefixLabel.AutoSize = true;
			rulePrefixLabel.Location = new Point(12, 148);
			rulePrefixLabel.Name = "rulePrefixLabel";
			rulePrefixLabel.Size = new Size(155, 20);
			rulePrefixLabel.TabIndex = 2;
			rulePrefixLabel.Text = "Visible Tag (Optional):";
			// 
			// rulePrefixHintLabel
			// 
			rulePrefixHintLabel.AutoSize = true;
			rulePrefixHintLabel.Location = new Point(12, 128);
			rulePrefixHintLabel.Name = "rulePrefixHintLabel";
			rulePrefixHintLabel.Size = new Size(427, 20);
			rulePrefixHintLabel.TabIndex = 2;
			rulePrefixHintLabel.Text = "NOTE: In tag, It's a good practice to use seperators like { } or ( ) ";
			// 
			// directoryBrowseButton
			// 
			directoryBrowseButton.Location = new Point(12, 65);
			directoryBrowseButton.Name = "directoryBrowseButton";
			directoryBrowseButton.Size = new Size(776, 45);
			directoryBrowseButton.TabIndex = 0;
			directoryBrowseButton.Text = "Browse";
			directoryBrowseButton.UseVisualStyleBackColor = true;
			directoryBrowseButton.Click += DirectoryBrowseButton_Click;
			// 
			// rulePrefixPreviewHintLabel
			// 
			rulePrefixPreviewHintLabel.AutoSize = true;
			rulePrefixPreviewHintLabel.Location = new Point(12, 212);
			rulePrefixPreviewHintLabel.Name = "rulePrefixPreviewHintLabel";
			rulePrefixPreviewHintLabel.Size = new Size(190, 20);
			rulePrefixPreviewHintLabel.TabIndex = 2;
			rulePrefixPreviewHintLabel.Text = "Your rules will look like this:";
			// 
			// rulePrefixPreviewLabel
			// 
			rulePrefixPreviewLabel.AutoSize = true;
			rulePrefixPreviewLabel.Location = new Point(12, 232);
			rulePrefixPreviewLabel.Name = "rulePrefixPreviewLabel";
			rulePrefixPreviewLabel.Size = new Size(25, 20);
			rulePrefixPreviewLabel.TabIndex = 2;
			rulePrefixPreviewLabel.Text = "    ";
			// 
			// BulkExeBlocker
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(rulePrefixHintLabel);
			Controls.Add(rulePrefixPreviewLabel);
			Controls.Add(rulePrefixPreviewHintLabel);
			Controls.Add(rulePrefixLabel);
			Controls.Add(directoryLabel);
			Controls.Add(rulePrefixTextbox);
			Controls.Add(directoryTextbox);
			Controls.Add(directoryBrowseButton);
			Controls.Add(runScriptButton);
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
	}
}
