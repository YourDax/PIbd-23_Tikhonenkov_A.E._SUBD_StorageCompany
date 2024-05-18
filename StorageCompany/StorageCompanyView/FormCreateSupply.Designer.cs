namespace StorageCompanyView
{
	partial class FormCreateSupply
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
			labelCount = new Label();
			comboBoxWood = new ComboBox();
			buttonCancel = new Button();
			buttonSave = new Button();
			textBoxCount = new TextBox();
			labelWood = new Label();
			labelClient = new Label();
			comboBoxClient = new ComboBox();
			SuspendLayout();
			// 
			// labelCount
			// 
			labelCount.AutoSize = true;
			labelCount.Location = new Point(20, 102);
			labelCount.Name = "labelCount";
			labelCount.Size = new Size(78, 15);
			labelCount.TabIndex = 1;
			labelCount.Text = "Количество :";
			// 
			// comboBoxWood
			// 
			comboBoxWood.DropDownStyle = ComboBoxStyle.DropDownList;
			comboBoxWood.FormattingEnabled = true;
			comboBoxWood.Location = new Point(124, 12);
			comboBoxWood.Name = "comboBoxWood";
			comboBoxWood.Size = new Size(300, 23);
			comboBoxWood.TabIndex = 4;
			// 
			// buttonCancel
			// 
			buttonCancel.Location = new Point(249, 141);
			buttonCancel.Name = "buttonCancel";
			buttonCancel.Size = new Size(94, 36);
			buttonCancel.TabIndex = 8;
			buttonCancel.Text = "Отмена";
			buttonCancel.UseVisualStyleBackColor = true;
			buttonCancel.Click += ButtonCancel_Click;
			// 
			// buttonSave
			// 
			buttonSave.Location = new Point(107, 141);
			buttonSave.Name = "buttonSave";
			buttonSave.Size = new Size(94, 36);
			buttonSave.TabIndex = 7;
			buttonSave.Text = "Сохранить";
			buttonSave.UseVisualStyleBackColor = true;
			buttonSave.Click += ButtonSave_Click;
			// 
			// textBoxCount
			// 
			textBoxCount.Location = new Point(124, 99);
			textBoxCount.Name = "textBoxCount";
			textBoxCount.Size = new Size(300, 23);
			textBoxCount.TabIndex = 5;
			// 
			// labelWood
			// 
			labelWood.AutoSize = true;
			labelWood.Location = new Point(20, 15);
			labelWood.Name = "labelWood";
			labelWood.Size = new Size(56, 15);
			labelWood.TabIndex = 3;
			labelWood.Text = "Продукт:";
			// 
			// labelClient
			// 
			labelClient.AutoSize = true;
			labelClient.Location = new Point(20, 59);
			labelClient.Name = "labelClient";
			labelClient.Size = new Size(73, 15);
			labelClient.TabIndex = 9;
			labelClient.Text = "Поставщик:";
			// 
			// comboBoxClient
			// 
			comboBoxClient.DropDownStyle = ComboBoxStyle.DropDownList;
			comboBoxClient.FormattingEnabled = true;
			comboBoxClient.Location = new Point(124, 56);
			comboBoxClient.Name = "comboBoxClient";
			comboBoxClient.Size = new Size(300, 23);
			comboBoxClient.TabIndex = 10;
			// 
			// FormCreateSupply
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(452, 198);
			Controls.Add(comboBoxClient);
			Controls.Add(labelClient);
			Controls.Add(labelCount);
			Controls.Add(comboBoxWood);
			Controls.Add(buttonCancel);
			Controls.Add(buttonSave);
			Controls.Add(textBoxCount);
			Controls.Add(labelWood);
			Margin = new Padding(4, 3, 4, 3);
			Name = "FormCreateSupply";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Заказ";
			Load += FormCreateSupply_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion
		private Label labelCount;
		private ComboBox comboBoxWood;
		private Button buttonCancel;
		private Button buttonSave;
		private TextBox textBoxCount;
		private Label labelWood;
		private Label labelClient;
		private ComboBox comboBoxClient;
	}
}