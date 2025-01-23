using DevExpress.Data.NetCompatibility.Extensions;
using ModelEntities;
using Presenter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ViewContract;

namespace HASPKey
{
    public partial class LogBookForm : DevExpress.XtraEditors.XtraForm, ILogView
    {
        public bool error = false;
        private const string errorStr = "Ошибка";

        private int currentPage = 1;
        private const int rowsPerPage = 30;
        private BindingList<ModelViewLog> pagedData;
        private List<ModelViewLog> fullData;
        private List<ModelViewLog> filteredData;

        public LogBookForm(bool search)
        {
            InitializeComponent();
            LogPresenter presenterLog = new LogPresenter(this);

            comboSorting.SelectedIndexChanged += ComboSorting_SelectedIndexChanged;
        }

        public LogBookForm() : this(false)
        { }

        public void Bind(List<ModelViewLog> entity)
        {
            fullData = entity ?? new List<ModelViewLog>();
            filteredData = fullData;
            currentPage = 1;
            UpdatePage();
        }

        public void MessageError(string errorText)
        {
            MessageBox.Show(errorText, errorStr, MessageBoxButtons.OK, MessageBoxIcon.Error);
            error = true;
        }

        private void UpdatePage()
        {
            if (filteredData == null)
            {
                pagedData = new BindingList<ModelViewLog>();
                logbookBindingSource.DataSource = pagedData;
                UpdatePagination();
                return;
            }

            int start = (currentPage - 1) * rowsPerPage;
            int count = Math.Min(rowsPerPage, filteredData.Count - start);

            if (start < filteredData.Count && count > 0)
            {
                pagedData = new BindingList<ModelViewLog>(filteredData.GetRange(start, count));
                logbookBindingSource.DataSource = pagedData;
            }
            else
            {
                pagedData = new BindingList<ModelViewLog>();
                logbookBindingSource.DataSource = pagedData;
            }

            UpdatePagination();
        }

        private void UpdatePagination()
        {
            paginationPanel.Controls.Clear();

            int totalPages = (int)Math.Ceiling((double)filteredData.Count / rowsPerPage);

            for (int i = 1; i <= totalPages; i++)
            {
                if (i == 1 || i == totalPages || (i >= currentPage - 1 && i <= currentPage + 1))
                {
                    Button pageButton = new Button
                    {
                        Text = i.ToString(),
                        Width = 40,
                        Height = 30,
                        Tag = i,
                        BackColor = i == currentPage ? System.Drawing.Color.LightBlue : System.Drawing.Color.White
                    };

                    pageButton.Click += PageButton_Click;
                    paginationPanel.Controls.Add(pageButton);
                }
                else if ((i == currentPage - 2 && i > 1) || (i == currentPage + 2 && i < totalPages))
                {
                    Label ellipsisLabel = new Label
                    {
                        Text = "...",
                        Width = 40,
                        Height = 30,
                        TextAlign = ContentAlignment.MiddleCenter,
                    };

                    paginationPanel.Controls.Add(ellipsisLabel);
                }
            }
            paginationPanel.Padding = new Padding((paginationPanel.Width - paginationPanel.Controls.Cast<Control>().Sum(c => c.Width + c.Margin.Horizontal)) / 2, 0, 0, 0);
        }

        private void PageButton_Click(object sender, EventArgs e)
        {
            if (sender is Button button && int.TryParse(button.Tag.ToString(), out int page))
            {
                currentPage = page;
                UpdatePage();
            }
        }

        private void ComboSorting_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboSorting.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(selectedValue))
            {
                switch (selectedValue)
                {
                    case "Вход в программу":
                        filteredData = FilterLogs("Вход в программу", "Вход в программу");
                        break;

                    case "Удаления":
                        filteredData = FilterLogs("-удалено-", "-удалено-");
                        break;

                    case "Обновления":
                        filteredData = FilterLogs("-обновлено-", "-обновлено-");
                        break;

                    case "Добавления":
                        filteredData = FilterLogs("-добавлено-", "-добавлено-");
                        break;

                    default:
                        filteredData = fullData;
                        break;
                }
            }
            else
            {
                filteredData = fullData;
            }

            currentPage = 1;
            UpdatePage();
        }

        private List<ModelViewLog> FilterLogs(string searchKeyword, string actionKeyword)
        {
            return fullData
                .Where(log => !string.IsNullOrEmpty(log.Actions) && log.Actions.Contains(searchKeyword, StringComparison.OrdinalIgnoreCase))
                .Select(log => new ModelViewLog
                {
                    Id = log.Id,
                    User = log.User,
                    LoginTime = log.LoginTime,
                    Actions = string.Join("; ", log.Actions
                        .Split(new[] { '.', ';' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(action => action.Trim())
                        .Where(action => action.Contains(actionKeyword, StringComparison.OrdinalIgnoreCase)))
                })
                .ToList();
        }

        private void ButtonAll_Click(object sender, EventArgs e)
        {
            filteredData = fullData;
            currentPage = 1;
            UpdatePage();
        }
    }
}
