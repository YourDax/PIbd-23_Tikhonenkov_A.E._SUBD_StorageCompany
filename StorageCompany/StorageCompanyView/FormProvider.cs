using Microsoft.Extensions.Logging;
using StorageCompanyContracts.BindingModels;
using StorageCompanyContracts.BusinessLogicsContracts;
using StorageCompanyContracts.SearchModels;
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
	public partial class FormProvider : Form
	{
		private readonly ILogger _logger;

		private readonly IProviderLogic _logic;

		private int? _id;

		public int Id { set { _id = value; } }

		public FormProvider(ILogger<FormProvider> logger, IProviderLogic logic)
		{
			InitializeComponent();
			_logger = logger;
			_logic = logic;
		}

		private void FormProvider_Load(object sender, EventArgs e)
		{
			if (_id.HasValue)
			{
				try
				{
					_logger.LogInformation("Получение клиента");
					var view = _logic.ReadElement(new ProviderSearchModel { Id = _id.Value });
					if (view != null)
					{
						textBox1.Text = view.ProviderFIO;
						textBox2.Text = view.Email;
						textBox3.Text = view.Password;
					}
				}
				catch (Exception ex)
				{
					_logger.LogError(ex, "Ошибка получения компклиентаонента");
					MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void ButtonSave_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(textBox1.Text))
			{
				MessageBox.Show("Заполните ФИО", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (string.IsNullOrEmpty(textBox2.Text))
			{
				MessageBox.Show("Заполните email", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (string.IsNullOrEmpty(textBox3.Text))
			{
				MessageBox.Show("Заполните пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			_logger.LogInformation("Сохранение клиента");
			try
			{
				var model = new ProviderBindingModel
				{
					Id = _id ?? 0,
					ProviderFIO = textBox1.Text,
					Email = textBox2.Text,
					Password = textBox3.Text,
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
