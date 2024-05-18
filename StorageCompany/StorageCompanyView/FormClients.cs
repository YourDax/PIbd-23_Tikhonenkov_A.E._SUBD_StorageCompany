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
	public partial class FormClients : Form
	{
		private readonly ILogger _logger;
		private readonly IClientLogic _logic;
		public FormClients(ILogger<FormClients> logger, IClientLogic logic)
		{
			InitializeComponent();
			_logger = logger;
			_logic = logic;
		}
		private void FormClients_Load(object sender, EventArgs e)
		{
			LoadData();
		}
		private void LoadData()
		{
			try
			{
				var list = _logic.ReadList(null);
				if (list != null)
				{
					dataGridView.DataSource = list;

				}
				_logger.LogInformation("Загрузка клиентов");
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Ошибка загрузки клиентов");
				MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		private void buttonAdd_Click(object sender, EventArgs e)
		{
			var service = Program.ServiceProvider?.GetService(typeof(FormClient));
			if (service is FormClient form)
			{
				if (form.ShowDialog() == DialogResult.OK)
				{
					LoadData();
				}
			}
		}

		private void buttonUpd_Click(object sender, EventArgs e)
		{
			if (dataGridView.SelectedRows.Count == 1)
			{
				var service = Program.ServiceProvider?.GetService(typeof(FormClient));
				if (service is FormClient form)
				{
					form.Id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells["Id"].Value);
					if (form.ShowDialog() == DialogResult.OK)
					{
						LoadData();
					}
				}
			}
		}

		private void buttonDel_Click(object sender, EventArgs e)
		{
			if (dataGridView.SelectedRows.Count == 1)
			{
				if (MessageBox.Show("Удалить запись?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells["Id"].Value);
					_logger.LogInformation("Удаление компонента");
					try
					{
						if (!_logic.Delete(new ClientBindingModel { Id = id }))
						{
							throw new Exception("Ошибка при удалении. Дополнительная информация в логах.");
						}
						LoadData();
					}
					catch (Exception ex)
					{
						_logger.LogError(ex, "Ошибка удаления компонента");
						MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
		}

		private void buttonRef_Click(object sender, EventArgs e)
		{
			LoadData();
		}
	}
}
