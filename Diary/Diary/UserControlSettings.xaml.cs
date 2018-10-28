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
using System.Globalization;

namespace Diary
{
    /// <summary>
    /// Логика взаимодействия для UserControlSettings.xaml
    /// </summary>
    public partial class UserControlSettings : UserControl
    {
        public static UserControlSettings UCS { get; set; }

        public UserControlSettings()
        {
            InitializeComponent();
            ReadSettings("read");
            UCS = this;
        }

        /// <summary>
        /// Считывание настроек и установка значений в чекбоксах, а также изменение настроек
        /// </summary>
        /// <param name="action">Действие</param>
        public void ReadSettings(string action)
        {
            XDocument xDoc = XDocument.Load("settings.xml"); // Загрузка файла настроек
            
            // Обновляет значения в чекбоксах, на соответствующие настройкам
            if (action == "read") 
            {
                foreach (XElement xNode in xDoc.Root.Nodes())
                {
                    if (xNode.Attribute("name").Value == "Theme")
                    {
                        if (xNode.Attribute("value").Value == "Light")
                        {
                            LightCheckBox.IsChecked = true;
                            DarkCheckBox.IsChecked = false;
                        }
                        if (xNode.Attribute("value").Value == "Dark")
                        {
                            DarkCheckBox.IsChecked = true;
                            LightCheckBox.IsChecked = false;
                        }
                    }

                    if (xNode.Attribute("name").Value == "WindowState")
                    {
                        if (xNode.Attribute("value").Value == "WindowedMode")
                        {
                            WindowedMode.IsChecked = true;
                            FullScreen.IsChecked = false;
                        }
                        if (xNode.Attribute("value").Value == "FullScreen")
                        {
                            FullScreen.IsChecked = true;
                            WindowedMode.IsChecked = false;
                        }
                    }

                    if (xNode.Attribute("name").Value == "Language")
                    {
                        if (xNode.Attribute("value").Value == "Ru")
                        {
                            ru_RU.IsChecked = true;
                            en_US.IsChecked = false;
                        }
                        if (xNode.Attribute("value").Value == "En")
                        {
                            en_US.IsChecked = true;
                            ru_RU.IsChecked = false;
                        }
                    }
                }
            }

            // Изменение темы
            if (action == "Theme")
            {
                foreach (XElement xNode in xDoc.Root.Nodes())
                {
                    if (xNode.Attribute("name").Value == "Theme")
                    {
                        try
                        {
                            if (LightCheckBox.IsChecked == true)
                                xNode.Attribute("value").Value = "Light";

                            if (DarkCheckBox.IsChecked == true)
                                xNode.Attribute("value").Value = "Dark".ToString();
                        }
                        catch { }
                    }
                }
                xDoc.Save("settings.xml");
                MainWindow.MW.ReadSettings();
            }

            // Изменение состояние экрана
            if (action == "WindowState")
            {
                foreach (XElement xNode in xDoc.Root.Nodes())
                {
                    if (xNode.Attribute("name").Value == "WindowState")
                    {
                        try
                        {
                            if (WindowedMode.IsChecked == true)
                                xNode.Attribute("value").Value = "WindowedMode";

                            if (FullScreen.IsChecked == true)
                                xNode.Attribute("value").Value = "FullScreen";
                        }
                        catch { }
                    }
                }
                xDoc.Save("settings.xml");
                MainWindow.MW.ReadSettings();
            }

            // Изменение языка
            if (action == "Lang")
            {
                foreach (XElement xNode in xDoc.Root.Nodes())
                {
                    if (xNode.Attribute("name").Value == "Language")
                    {
                        if (ru_RU.IsChecked == true)
                            xNode.Attribute("value").Value = "Ru";

                        if (en_US.IsChecked == true)
                            xNode.Attribute("value").Value = "En";
                    }
                } 
                xDoc.Save("settings.xml");
                MainWindow.MW.ReadSettings();
            }
        }

        #region Работа с чекбоксами

        /// <summary>
        /// Изменение свойства IsCheked у чекбоксов отвечающих за тему
        /// </summary>
        /// <param name="sender">Передающийся объект</param>
        /// <param name="e">Событие</param>
        private void ThemeCBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox chBox = (CheckBox)sender;
            string theme = chBox.Tag.ToString();

            switch (theme)
            {
                case "light":
                    DarkCheckBox.IsChecked = false;
                    break;
                case "dark":
                    LightCheckBox.IsChecked = false;
                    break;
                default:
                    break;
            }
            ReadSettings("Theme");
        }

        /// <summary>
        /// Изменение свойства IsCheked у чекбоксов отвечающих за тему
        /// </summary>
        /// <param name="sender">Передающийся объект</param>
        /// <param name="e">Событие</param>
        private void ThemeCBox_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox chBox = (CheckBox)sender;

            if (chBox.Name == "LightCheckBox" && DarkCheckBox.IsChecked == false)
                chBox.IsChecked = true;

            else if (chBox.Name == "DarkCheckBox" && LightCheckBox.IsChecked == false)
                chBox.IsChecked = true;
            
        }

        /// <summary>
        /// Изменение свойства IsCheked у чекбоксов отвечающих за режим экрана
        /// </summary>
        /// <param name="sender">Передающийся объект</param>
        /// <param name="e">Событие</param>
        private void WindowStateCBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox chBox = (CheckBox)sender;
            string theme = chBox.Tag.ToString();

            switch (theme)
            {
                case "Normal":
                    FullScreen.IsChecked = false;
                    break;
                case "Maximize":
                    WindowedMode.IsChecked = false;
                    break;
                default:
                    break;
            }

            if (chBox.Tag.ToString() == "Normal")
                MainWindow.MW.WindowState = WindowState.Normal;

            else if (chBox.Tag.ToString() == "Maximize")
                MainWindow.MW.WindowState = WindowState.Maximized;             

            double width = MainWindow.MW.GridMain.ActualWidth;
            double height = MainWindow.MW.GridMain.ActualHeight;

            this.Width = width;
            this.Height = height;
            SettingsGrid.Width = width;
            SettingsGrid.Height = height;

            ReadSettings("WindowState");
        }

        /// <summary>
        /// Изменение свойства IsCheked у чекбоксов отвечающих за режим экрана
        /// </summary>
        /// <param name="sender">Передающийся объект</param>
        /// <param name="e">Событие</param>
        private void WindowStateCBox_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox chBox = (CheckBox)sender;

            if (chBox.Name == "WindowedMode" && FullScreen.IsChecked == false)
                chBox.IsChecked = true;

            else if (chBox.Name == "FullScreen" && WindowedMode.IsChecked == false)
                chBox.IsChecked = true;
        }

        /// <summary>
        /// Изменение свойства IsCheked у чекбоксов отвечающих за язык
        /// </summary>
        /// <param name="sender">Передающийся объект</param>
        /// <param name="e">Событие</param>
        private void Language_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox chBox = sender as CheckBox;

            if (chBox.Name.ToString() == "ru_RU")
            {
                ru_RU.IsChecked = true;
                en_US.IsChecked = false;
            }

            if (chBox.Name.ToString() == "en_US")
            {
                en_US.IsChecked = true;
                ru_RU.IsChecked = false;
            }



            if (chBox != null)
            {
                foreach (var lang in App.Languages)
                {
                    if (lang.ToString() == chBox.Tag.ToString())
                        App.Language = lang;
                }
            }

            ReadSettings("Lang");
        }

        /// <summary>
        /// Изменение свойства IsCheked у чекбоксов отвечающих за язык
        /// </summary>
        /// <param name="sender">Передающийся объект</param>
        /// <param name="e">Событие</param>
        private void Language_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox chBox = (CheckBox)sender;

            if (chBox.Name == "ru_RU" && en_US.IsChecked == false)
                chBox.IsChecked = true;

            else if (chBox.Name == "en_US" && ru_RU.IsChecked == false)
                chBox.IsChecked = true;

        }

        #endregion
    }
}
