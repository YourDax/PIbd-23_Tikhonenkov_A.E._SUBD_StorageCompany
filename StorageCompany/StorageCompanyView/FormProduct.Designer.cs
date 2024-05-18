namespace StorageCompanyView
{
	partial class FormProduct
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
			label2 = new Label();
			button1 = new Button();
			comboBox1 = new ComboBox();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(12, 9);
			label1.Name = "label1";
			label1.Size = new Size(59, 15);
			label1.TabIndex = 0;
			label1.Text = "Название";
			// 
			// textBox1
			// 
			textBox1.Location = new Point(12, 27);
			textBox1.Name = "textBox1";
			textBox1.Size = new Size(177, 23);
			textBox1.TabIndex = 1;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(12, 65);
			label2.Name = "label2";
			label2.Size = new Size(27, 15);
			label2.TabIndex = 2;
			label2.Text = "Тип";
			// 
			// button1
			// 
			button1.Location = new Point(61, 112);
			button1.Name = "button1";
			button1.Size = new Size(75, 23);
			button1.TabIndex = 6;
			button1.Text = "Сохранить";
			button1.UseVisualStyleBackColor = true;
			button1.Click += ButtonSave_Click;
			// 
			// comboBox1
			// 
			comboBox1.FormattingEnabled = true;
			comboBox1.Location = new Point(12, 83);
			comboBox1.Name = "comboBox1";
			comboBox1.Size = new Size(177, 23);
			comboBox1.TabIndex = 7;
			// 
			// FormProduct
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(204, 144);
			Controls.Add(comboBox1);
			Controls.Add(button1);
			Controls.Add(label2);
			Controls.Add(textBox1);
			Controls.Add(label1);
			Name = "FormProduct";
			Text = "FormProduct";
			Load += FormProduct_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
		private TextBox textBox1;
		private Label label2;
		private Button button1;
		private ComboBox comboBox1;
	}
}