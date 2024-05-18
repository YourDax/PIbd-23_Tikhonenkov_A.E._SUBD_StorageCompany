using Microsoft.Extensions.Logging;
using StorageCompanyContracts.BindingModels;
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
	public partial class FormCreateSupply : Form
	{
		private readonly ILogger _logger;
		private readonly IProductLogic _logicW;
		private readonly IProviderLogic _logicC;
		private readonly ISupplyLogic _logicO;
		public FormCreateSupply(ILogger<FormCreateSupply> logger, IProductLogic logicP, ISupplyLogic logicO, IProviderLogic logicC)
		{
			InitializeComponent();
			_logger = logger;
			_logicW = logicP;
			_logicO = logicO;
			_logicC = logicC;
		}
		private void FormCreateSupply_Load(object sender, EventArgs e)
		{
			_logger.LogInformation("Загрузка изделий для заказа");
			try
			{
				var list = _logicW.ReadList(null);
				if (list != null)
				{
					comboBoxWood.DisplayMember = "ProductName";
					comboBoxWood.ValueMember = "Id";
					comboBoxWood.DataSource = list;
					comboBoxWood.SelectedItem = null;
				}
				_logger.LogInformation("Изделия загружены");
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Ошибка загрузки изделий");
				MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
			   MessageBoxIcon.Error);
			}
			_logger.LogInformation("Загрузка изделий для заказа");
			try
			{
				var list = _logicC.ReadList(null);
				if (list != null)
				{
					comboBoxClient.DisplayMember = "ProviderFIO";
					comboBoxClient.ValueMember = "Id";
					comboBoxClient.DataSource = list;
					comboBoxClient.SelectedItem = null;
				}
				_logger.LogInformation("Изделия загружены");
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Ошибка загрузки изделий");
				MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
			   MessageBoxIcon.Error);
			}
		}

		private void ButtonSave_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(textBoxCount.Text))
			{
				MessageBox.Show("Заполните поле Количество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (comboBoxWood.SelectedItem == null)
			{
				MessageBox.Show("Выберите изделие", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (comboBoxClient.SelectedItem == null)
			{
				MessageBox.Show("Выберите изделие", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			_logger.LogInformation("Создание заказа");
			try
			{
				var operationResult = _logicO.Create(new SupplyBindingModel
				{
					ProductId = Convert.ToInt32(comboBoxWood.SelectedValue),
					ProviderId = Convert.ToInt32(comboBoxClient.SelectedValue),
					SupplyNum = Convert.ToInt32(textBoxCount.Text)
				});
				if (!operationResult)
				{
					throw new Exception("Ошибка при создании заказа. Дополнительная информация в логах.");
				}
				MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
				DialogResult = DialogResult.OK;
				Close();
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Ошибка создания заказа");
				MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		private void ButtonCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}
	}
}
