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
using System.Xml;
using System.Xml.Linq;
using System.IO;

namespace Diary
{
    /// <summary>
    /// Логика взаимодействия для UserControlCreate.xam
    /// </summary>
    public partial class UserControlCreate : UserControl
    {
        public static UserControlCreate UCC { get; set; }

        public UserControlCreate()
        {
            InitializeComponent();
            UCC = this;

            #region Установка размеров окна

            double width = MainWindow.MW.GridMain.ActualWidth;
            double height = MainWindow.MW.GridMain.ActualHeight;

            this.Width = width;
            this.Height = height;

            CreateGrid.Width = width;
            CreateGrid.Height = height;

            #endregion
        }

        /// <summary>
        /// Добавление события
        /// </summary>
        /// <param name="sender">Объект по которому проиошел клик</param>
        /// <param name="e">Событие</param>
        public void AddEvent_Click(object sender, RoutedEventArgs e)
        {
            string titBox, disBox, date, time; // Переменные для получение введенных пользователем данных 

            #region Checking the entered data

            if (titleBox.Text != "")
                titBox = titleBox.Text;
            else
                titBox = "Заголовок отсутствует";

            if (descriptionBox.Text != "")
                disBox = descriptionBox.Text;
            else
                disBox = "Описание отсутствует";

            if (datepicker.Text != "")
                date = datepicker.Text;
            else
                date = "Дата не выбрана";

            if (timepicker.Text != null)
                time = timepicker.Text;
            else
                time = "Время не выбрано";

            #endregion

            XmlDocument doc = new XmlDocument();
            doc.Load("notes.xml");
            
            int idLastNote = 0; //

            XmlTextReader reader = new XmlTextReader("notes.xml");
            while (reader.Read())
            {
                //Console.WriteLine(reader.Name);
                if (reader.Name == "Note")
                    idLastNote++;
            }
            reader.Close();
            idLastNote /= 2;

            #region Adding a note in xml

            XmlElement newNote = doc.CreateElement("Note");
            newNote.SetAttribute("id", idLastNote.ToString());

            XmlElement newTitle = doc.CreateElement("title");
            newTitle.InnerText = titBox;
            newNote.AppendChild(newTitle);

            XmlElement newdescription = doc.CreateElement("description");
            newdescription.InnerText = disBox;
            newNote.AppendChild(newdescription);

            XmlElement newDatetime = doc.CreateElement("datatime");
            newDatetime.InnerText = date + " " + time;
            newNote.AppendChild(newDatetime);

            doc.DocumentElement.AppendChild(newNote);
            doc.Save("notes.xml");

            #endregion
        }
    }
}
