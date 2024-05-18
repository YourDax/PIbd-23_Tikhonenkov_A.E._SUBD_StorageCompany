namespace StorageCompanyView
{
	partial class FormMain
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
			dataGridView1 = new DataGridView();
			dataGridView2 = new DataGridView();
			menuStrip1 = new MenuStrip();
			продуктыToolStripMenuItem = new ToolStripMenuItem();
			клиентыToolStripMenuItem = new ToolStripMenuItem();
			поставщикиToolStripMenuItem = new ToolStripMenuItem();
			button1 = new Button();
			button2 = new Button();
			label1 = new Label();
			label2 = new Label();
			((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
			((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
			menuStrip1.SuspendLayout();
			SuspendLayout();
			// 
			// dataGridView1
			// 
			dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridView1.Location = new Point(12, 53);
			dataGridView1.Name = "dataGridView1";
			dataGridView1.RowTemplate.Height = 25;
			dataGridView1.Size = new Size(776, 185);
			dataGridView1.TabIndex = 0;
			// 
			// dataGridView2
			// 
			dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridView2.Location = new Point(12, 269);
			dataGridView2.Name = "dataGridView2";
			dataGridView2.RowTemplate.Height = 25;
			dataGridView2.Size = new Size(776, 185);
			dataGridView2.TabIndex = 1;
			// 
			// menuStrip1
			// 
			menuStrip1.Items.AddRange(new ToolStripItem[] { продуктыToolStripMenuItem, клиентыToolStripMenuItem, поставщикиToolStripMenuItem });
			menuStrip1.Location = new Point(0, 0);
			menuStrip1.Name = "menuStrip1";
			menuStrip1.Size = new Size(800, 24);
			menuStrip1.TabIndex = 2;
			menuStrip1.Text = "menuStrip1";
			// 
			// продуктыToolStripMenuItem
			// 
			продуктыToolStripMenuItem.Name = "продуктыToolStripMenuItem";
			продуктыToolStripMenuItem.Size = new Size(74, 20);
			продуктыToolStripMenuItem.Text = "Продукты";
			продуктыToolStripMenuItem.Click += ПродуктыToolStripMenuItem_Click;
			// 
			// клиентыToolStripMenuItem
			// 
			клиентыToolStripMenuItem.Name = "клиентыToolStripMenuItem";
			клиентыToolStripMenuItem.Size = new Size(67, 20);
			клиентыToolStripMenuItem.Text = "Клиенты";
			клиентыToolStripMenuItem.Click += КлиентыToolStripMenuItem_Click;
			// 
			// поставщикиToolStripMenuItem
			// 
			поставщикиToolStripMenuItem.Name = "поставщикиToolStripMenuItem";
			поставщикиToolStripMenuItem.Size = new Size(89, 20);
			поставщикиToolStripMenuItem.Text = "Поставщики";
			поставщикиToolStripMenuItem.Click += ПоставщикиToolStripMenuItem_Click;
			// 
			// button1
			// 
			button1.Location = new Point(635, 27);
			button1.Name = "button1";
			button1.Size = new Size(153, 23);
			button1.TabIndex = 3;
			button1.Text = "Создать поставку";
			button1.UseVisualStyleBackColor = true;
			button1.Click += ButtonCreateSupply_Click;
			// 
			// button2
			// 
			button2.Location = new Point(635, 245);
			button2.Name = "button2";
			button2.Size = new Size(153, 23);
			button2.TabIndex = 4;
			button2.Text = "Создать продажу";
			button2.UseVisualStyleBackColor = true;
			button2.Click += ButtonCreateSale_Click;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
			label1.Location = new Point(346, 24);
			label1.Name = "label1";
			label1.Size = new Size(94, 25);
			label1.TabIndex = 5;
			label1.Text = "Поставки";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
			label2.Location = new Point(346, 241);
			label2.Name = "label2";
			label2.Size = new Size(93, 25);
			label2.TabIndex = 6;
			label2.Text = "Продажи";
			// 
			// FormMain
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 467);
			Controls.Add(label2);
			Controls.Add(label1);
			Controls.Add(button2);
			Controls.Add(button1);
			Controls.Add(dataGridView2);
			Controls.Add(dataGridView1);
			Controls.Add(menuStrip1);
			MainMenuStrip = menuStrip1;
			Name = "FormMain";
			Text = "FormMain";
			((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
			((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
			Load += FormMain_Load;
			menuStrip1.ResumeLayout(false);
			menuStrip1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private DataGridView dataGridView1;
		private DataGridView dataGridView2;
		private MenuStrip menuStrip1;
		private ToolStripMenuItem продуктыToolStripMenuItem;
		private ToolStripMenuItem клиентыToolStripMenuItem;
		private ToolStripMenuItem поставщикиToolStripMenuItem;
		private Button button1;
		private Button button2;
		private Label label1;
		private Label label2;
	}
}