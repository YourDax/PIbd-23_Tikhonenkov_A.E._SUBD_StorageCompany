namespace StorageCompanyView
{
	partial class FormClient
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
			label1 = new Label();
			textBox1 = new TextBox();
			textBox2 = new TextBox();
			label2 = new Label();
			textBox3 = new TextBox();
			label3 = new Label();
			button2 = new Button();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(12, 9);
			label1.Name = "label1";
			label1.Size = new Size(34, 15);
			label1.TabIndex = 0;
			label1.Text = "ФИО";
			// 
			// textBox1
			// 
			textBox1.Location = new Point(12, 27);
			textBox1.Name = "textBox1";
			textBox1.Size = new Size(177, 23);
			textBox1.TabIndex = 1;
			// 
			// textBox2
			// 
			textBox2.Location = new Point(12, 83);
			textBox2.Name = "textBox2";
			textBox2.Size = new Size(177, 23);
			textBox2.TabIndex = 3;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(12, 65);
			label2.Name = "label2";
			label2.Size = new Size(36, 15);
			label2.TabIndex = 2;
			label2.Text = "Email";
			// 
			// textBox3
			// 
			textBox3.Location = new Point(12, 138);
			textBox3.Name = "textBox3";
			textBox3.Size = new Size(177, 23);
			textBox3.TabIndex = 5;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(12, 120);
			label3.Name = "label3";
			label3.Size = new Size(38, 15);
			label3.TabIndex = 4;
			label3.Text = "label3";
			// 
			// button2
			// 
			button2.Location = new Point(61, 179);
			button2.Name = "button2";
			button2.Size = new Size(75, 23);
			button2.TabIndex = 7;
			button2.Text = "Сохранить";
			button2.UseVisualStyleBackColor = true;
			button2.Click += ButtonSave_Click;
			// 
			// FormClient
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(204, 228);
			Controls.Add(button2);
			Controls.Add(textBox3);
			Controls.Add(label3);
			Controls.Add(textBox2);
			Controls.Add(label2);
			Controls.Add(textBox1);
			Controls.Add(label1);
			Name = "FormClient";
			Text = "FormClient";
			Load += FormClient_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
		private TextBox textBox1;
		private TextBox textBox2;
		private Label label2;
		private TextBox textBox3;
		private Label label3;
		private Button button2;
	}
}