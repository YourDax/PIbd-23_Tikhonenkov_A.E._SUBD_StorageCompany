using Microsoft.Extensions.Logging;
using StorageCompanyContracts.BindingModels;
using StorageCompanyContracts.BusinessLogicsContracts;
using StorageCompanyContracts.SearchModels;
using StorageCompanyDataModels.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace StorageCompanyView
{
	public partial class FormProduct : Form
	{
		private readonly ILogger _logger;

		private readonly IProductLogic _logic;

		private int? _id;

		public int Id { set { _id = value; } }

		public FormProduct(ILogger<FormProduct> logger, IProductLogic logic)
		{
			InitializeComponent();
			_logger = logger;
			_logic = logic;
		}

		private void FormProduct_Load(object sender, EventArgs e)
		{
			if (_id.HasValue)
			{
				try
				{
					_logger.LogInformation("Получение клиента");
					var view = _logic.ReadElement(new ProductSearchModel { Id = _id.Value });
					if (view != null)
					{
						textBox1.Text = view.ProductName;
					}
				}
				catch (Exception ex)
				{
					_logger.LogError(ex, "Ошибка получения компклиентаонента");
					MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			else
			{
				comboBox1.DataSource = Enum.GetValues(typeof(ProductType));
			}
		}

		private void ButtonSave_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(textBox1.Text))
			{
				MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (comboBox1.SelectedValue == null)
			{
				MessageBox.Show("Заполните тип", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			_logger.LogInformation("Сохранение клиента");
			try
			{
				var model = new ProductBindingModel
				{
					Id = _id ?? 0,
					ProductName = textBox1.Text,
					ProductType = (ProductType)comboBox1.SelectedItem,
					ProductNum = 0
				};
				var operationResult = _id.HasValue ? _logic.Update(model) : _logic.Create(model);
				if (!operationResult)
				{
					throw new Exception("Ошибка при сохранении. Дополнительная информация в логах.");
				}
				MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
				DialogResult = DialogResult.OK;
				Close();
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Ошибка сохранения компонента");
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
