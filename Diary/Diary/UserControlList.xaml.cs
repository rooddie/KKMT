using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MaterialDesignThemes;
using MaterialDesignXaml;
using MaterialDesignColors;
using MaterialDesignThemes.Wpf;
using System.Xml;
using System.Xml.Linq;
using System.IO;

namespace Diary
{
    /// <summary>
    /// Логика взаимодействия для UserControlHome.xam
    /// </summary>
    public partial class UserControlList : UserControl
    {     
        public static UserControlList UCL { get; set; }

        // public List<int> id = new List<int>();
        public List<string> title = new List<string>(); // Список заголовков
        public List<string> description = new List<string>(); // Список описаний
        public List<string> datatime = new List<string>(); // Список полных дат (дата и время)
        public List<int> checkBoxes = new List<int>(); // Список чекбоксов

        public static List<string> eventDate = new List<string>(); // Список с указанными датами для событий
        public static List<string> eventTime = new List<string>(); // Список с указанным временем для событий
        public static List<string> eventName = new List<string>(); // Список с указанными названиями событий

        
        int CountSelectedChBoxes; // считает сколько выделенно заметок в данных момент
        //public int n = 0; //

        public UserControlList()
        {
            InitializeComponent();

            #region Установка размеров окна

            double width = MainWindow.MW.GridMain.ActualWidth;
            double height = MainWindow.MW.GridMain.ActualHeight;

            this.Width = width;
            this.Height = height;

            ListGrid.Width = width;
            ListGrid.Height = height;

            #endregion

            UCL = this;
            readFile();
            Fill_notes();
        }

        /// <summary>
        /// Функция чтения xml файла
        /// </summary>
        public void readFile()
        {
            string appPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
            NotesData.Source = new Uri(appPath + @"\notes.xml");

            //id.Clear();
            title.Clear();
            description.Clear();
            datatime.Clear();
            checkBoxes.Clear();
            eventDate.Clear();
            eventTime.Clear();
            eventName.Clear();

            XmlTextReader reader = new XmlTextReader("notes.xml");
            while (reader.Read())
            {
                if (reader.Name == "title")
                    title.Add(reader.ReadInnerXml().ToString());
                if (reader.Name == "description")
                    description.Add(reader.ReadInnerXml().ToString());
                if (reader.Name == "datatime")
                    datatime.Add(reader.ReadInnerXml().ToString());
            }
            reader.Close();
        }

        /// <summary>
        /// Добавление заметок в приложение
        /// </summary>
        public void Fill_notes()
        {
            for (int i = 0; i < title.Count; i++)
            {
                // Создание конструкции для отображения запланированных событий
                Expander expander = new Expander();
                StackPanel stackPanel = new StackPanel();
                TextBlock textBlock_0 = new TextBlock();
                TextBlock textBlock_1 = new TextBlock();
                TextBlock textBlock_2 = new TextBlock();
                CheckBox checkBox = new CheckBox();

                // Установка параметров и стилей для элементов
                textBlock_1.Style = Application.Current.FindResource("MaterialDesignBody") as Style;
                textBlock_1.Text = title[i];
                textBlock_1.FontWeight = FontWeights.Bold;
                textBlock_1.FontFamily = new System.Windows.Media.FontFamily("Bernier Regular");
                textBlock_1.FontSize = 48;
                textBlock_1.Margin = new Thickness(5);
                
                textBlock_2.Style = Application.Current.FindResource("MaterialDesignBody") as Style;
                textBlock_2.Opacity = 68;
                textBlock_2.Text = description[i];
                textBlock_2.TextWrapping = TextWrapping.Wrap;
                textBlock_2.FontSize = 28;
                textBlock_2.FontFamily = new System.Windows.Media.FontFamily("Times New Roman");

                textBlock_0.FontSize = 20;
                textBlock_0.FontFamily = new System.Windows.Media.FontFamily("Times New Roman");
                textBlock_0.Text = datatime[i];

                stackPanel.Orientation = Orientation.Vertical;
                stackPanel.Margin = new Thickness(24, 8, 24, 16);

                checkBox.Style = Application.Current.FindResource("MaterialDesignCheckBox") as Style;
                checkBox.HorizontalAlignment = HorizontalAlignment.Right;
                checkBox.Tag = i.ToString();
                checkBox.Checked += checkBox_Checked;
                checkBox.Unchecked += checkBox_Unchecked;

                expander.HorizontalAlignment = HorizontalAlignment.Stretch;
                expander.Header = textBlock_0;
                expander.FontSize = 55;
                expander.Foreground = Brushes.Black;
                expander.FontFamily = new System.Windows.Media.FontFamily("Times New Roman");

                stackPanel.Children.Add(textBlock_1);
                stackPanel.Children.Add(textBlock_2);
                stackPanel.Children.Add(checkBox);
                expander.Content = stackPanel;
                StPList.Children.Add(expander);
                //StPList.Children.Add(checkBox);

                string[] datetime_split = datatime[i].Split(' ');
                eventDate.Add(datetime_split[0]);
                eventTime.Add(datetime_split[1]);
                eventName.Add(title[i]);

            }
        }

        /// <summary>
        /// Удаление выбранных событий
        /// </summary>
        /// <param name="sender">Объект по которому проиошел клик</param>
        /// <param name="e">Событие</param>
        private void RemoveEvent_Click(object sender, RoutedEventArgs e)
        {
            checkBoxes.Sort();
            DelBtn.Badge = null;

            XDocument xDoc = XDocument.Load("notes.xml");
            foreach (int item in checkBoxes)
            {
                foreach (XElement xNode in xDoc.Root.Nodes())
                {
                    if (xNode.Attribute("id").Value == item.ToString())
                    {
                        xNode.Remove();
                    }     
                }
            }

            // Обновление аттрибута id в xml файле
            int x = 0;
            foreach (XElement xNode in xDoc.Root.Nodes())
            {
                xNode.Attribute("id").Value = x.ToString();
                x++;
            }
            try
            {
                xDoc.Save("notes.xml");
            }
            catch
            {
                MessageBox.Show("Повторите попытку через несколько секунд", "Оповещение");
            }

            StPList.Children.Clear();
            readFile();
            Fill_notes();
        }

        /// <summary>
        /// CheckBox.IsCheked = true
        /// </summary>
        /// <param name="sender">Объект по которому проиошел клик</param>
        /// <param name="e">Событие</param>
        private void checkBox_Checked(object sender, RoutedEventArgs e)
        {
            CountSelectedChBoxes++;
            DelBtn.Badge = CountSelectedChBoxes;
            var checkBox = (sender as CheckBox);
            if (checkBox.IsChecked == true)
                checkBoxes.Add(Convert.ToInt16(checkBox.Tag));
        }

        /// <summary>
        /// CheckBox.IsCheked = false
        /// </summary>
        /// <param name="sender">Объект по которому проиошел клик</param>
        /// <param name="e">Событие</param>
        private void checkBox_Unchecked(object sender, RoutedEventArgs e)
        {
            CountSelectedChBoxes--;
            if (Convert.ToInt16(DelBtn.Badge) > 1)
                DelBtn.Badge = CountSelectedChBoxes;
            else
                DelBtn.Badge = null;

            var checkBox = (sender as CheckBox);
            if (checkBox.IsChecked == false)
                checkBoxes.Remove(Convert.ToInt16(checkBox.Tag));
        }
    }
}