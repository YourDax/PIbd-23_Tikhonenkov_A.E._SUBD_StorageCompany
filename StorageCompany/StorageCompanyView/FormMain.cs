using Microsoft.Extensions.Logging;
using StorageCompanyContracts.BusinessLogicsContracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StorageCompanyView
{
	public partial class FormMain : Form
	{
		private readonly ILogger _logger;
		private readonly ISaleLogic _saleLogic;
		private readonly ISupplyLogic _supplyLogic;
		public FormMain(ILogger<FormMain> logger, ISaleLogic saleLogic, ISupplyLogic supplyLogic)
		{
			InitializeComponent();
			_logger = logger;
			_saleLogic = saleLogic;
			_supplyLogic = supplyLogic;
		}
		private void FormMain_Load(object sender, EventArgs e)
		{
			LoadData();
		}
		private void LoadData()
		{
			_logger.LogInformation("Загрузка продаж");
			try
			{
				var list = _saleLogic.ReadList(null);
				if (list != null)
				{
					dataGridView2.DataSource = list;

				}
				_logger.LogInformation("Загрузка продаж");
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Ошибка загрузки продаж");
				MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			_logger.LogInformation("Загрузка поставок");
			try
			{
				var list = _supplyLogic.ReadList(null);
				if (list != null)
				{
					dataGridView1.DataSource = list;

				}
				_logger.LogInformation("Загрузка поставок");
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Ошибка загрузки поставок");
				MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		private void КлиентыToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var service = Program.ServiceProvider?.GetService(typeof(FormClients));
			if (service is FormClients form)
			{
				form.ShowDialog();
			}
		}
		private void ПоставщикиToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var service = Program.ServiceProvider?.GetService(typeof(FormProviders));
			if (service is FormProviders form)
			{
				form.ShowDialog();
			}
		}
		private void ПродуктыToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var service = Program.ServiceProvider?.GetService(typeof(FormProducts));
			if (service is FormProducts form)
			{
				form.ShowDialog();
			}
		}
		private void ButtonCreateSale_Click(object sender, EventArgs e)
		{
			var service = Program.ServiceProvider?.GetService(typeof(FormCreateSale));
			if (service is FormCreateSale form)
			{
				form.ShowDialog();
				LoadData();
			}
		}
		private void ButtonCreateSupply_Click(object sender, EventArgs e)
		{
			var service = Program.ServiceProvider?.GetService(typeof(FormCreateSupply));
			if (service is FormCreateSupply form)
			{
				form.ShowDialog();
				LoadData();
			}
		}
	}
}
