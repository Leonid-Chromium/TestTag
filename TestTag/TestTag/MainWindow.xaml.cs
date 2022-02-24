using System;
using System.Data;
using System.Diagnostics;
using System.Windows;

namespace TestTag
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public void DTtoTrace(DataTable dataTable)
        {
            Trace.WriteLine("");
            Trace.WriteLine("Общая информация");
            Trace.WriteLine(String.Format("x = " + dataTable.Columns.Count));
            Trace.WriteLine(String.Format("y = " + dataTable.Rows.Count));

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                Trace.Write("|");
                for (int j = 0; j < dataTable.Columns.Count; j++)
                {
                    Trace.Write(String.Format("{0,3}", dataTable.Rows[i].ItemArray[j].ToString()));
                    Trace.Write("|");
                }
                Trace.WriteLine("");
            }

            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                Trace.WriteLine(String.Format(dataTable.Columns[i].ColumnName + " " + dataTable.Columns[i].DataType));
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Id", typeof(int));
            dataTable.Columns.Add("Tags", typeof(Tag[]));

            DataTable sqlDataTable = new DataTable();

            SQLClass sql = new SQLClass();
            sqlDataTable = sql.ReturnDT(@"SELECT Clients.Id, Tags.Name, Tags.Color FROM TagsClients
LEFT JOIN Clients ON Clients.Id = TagsClients.IdClient
LEFT JOIN Tags ON Tags.Id = TagsClients.IdTag");

            DTtoTrace(sqlDataTable);

            dataTable.Rows.Add(1, new Tag[] { new Tag("test1", "#bbccdd"), new Tag("test2", "#bbacdd") });
            dataTable.Rows.Add(2, new Tag[] { new Tag("test1", "#bbccdd"), new Tag("test2", "#bbacdd") });
            dataTable.Rows.Add(3, new Tag[] { new Tag("test1", "#bbccdd"), new Tag("test2", "#bbacdd") });
            dataTable.Rows.Add(4, new Tag[] { new Tag("test1", "#bbccdd"), new Tag("test2", "#bbacdd") });
            dataTable.Rows.Add(5, new Tag[] { new Tag("test1", "#bbccdd"), new Tag("test2", "#bbacdd") });


            //Отрисовка
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                ClientCard clientCard = new ClientCard(dataTable.Rows[i].ItemArray[0].ToString(), dataTable.Rows[i].ItemArray[1] as Tag[]);
                MainStack.Children.Add(clientCard);
                Trace.WriteLine("добавили");
            }
        }
    }
}
