using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Drawing;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Xml.Linq;
using System.Windows.Forms;
namespace Diary
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        NotifyIcon ni = new NotifyIcon(); // позволяет задать значок, 
                                          //который будет отображаться при запуске приложения в панели задач.

       
        public static MainWindow MW { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            ReadSettings();
            MW = this;
            DateNow.Content = DateTime.Now.ToString("dd.MMMM.yyyy | HH:mm");

            #region Create a NotifyIcon and a DispatcherTimer

            ni.Icon = SystemIcons.Application;
            ni.Visible = true;
            ni.BalloonTipText = "stick your finger in my ass";
            ni.DoubleClick +=
                delegate (object sender, EventArgs args)
                {
                    this.Show();
                    this.WindowState = WindowState.Normal;
                };

            // Таймер. Проверяет текущую дату и дату запланированных событий.
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(DispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 59);
            dispatcherTimer.Start();
            
            #endregion
        }

        /// <summary>
        /// Считывание настроек указанных в settings.xml
        /// </summary>
        public void ReadSettings()
        {
            var uri = new Uri("App.xaml", UriKind.Relative);
            XDocument xDoc = XDocument.Load("settings.xml");

            foreach (XElement xNode in xDoc.Root.Nodes())
            {
                if (xNode.Attribute("value").Value == "Light")
                {
                    ImgTheme.Tag = "light";
                    uri = new Uri("Light.xaml", UriKind.Relative);
                    var bitmap = new BitmapImage(new Uri("/Resources/sun.png", UriKind.Relative));
                    ImgTheme.Source = bitmap;
                }

                if (xNode.Attribute("value").Value == "Dark")
                {         
                    ImgTheme.Tag = "dark";
                    uri = new Uri("Dark.xaml", UriKind.Relative);
                    var bitmap = new BitmapImage(new Uri("/Resources/moon.png", UriKind.Relative));
                    ImgTheme.Source = bitmap;
                }

                if (xNode.Attribute("value").Value == "FullScreen")
                    WindowState = WindowState.Maximized;
            }
            // очищаем коллекцию ресурсов приложения
            System.Windows.Application.Current.Resources.Clear();
            // загружаем словарь ресурсов
            ResourceDictionary resourceDict = System.Windows.Application.LoadComponent(uri) as ResourceDictionary;
            // добавляем загруженный словарь ресурсов
            System.Windows.Application.Current.Resources.MergedDictionaries.Add(resourceDict);



        }

        /// <summary>
        /// Функция проверки даты событий
        /// </summary>
        /// <param name="sender">Передающийся объект</param>
        /// <param name="e">Событие</param>
        public void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            DateNow.Content = DateTime.Now.ToString("dd.MMMM.yyyy | HH:mm");
            UserControlList ucl = new UserControlList();

            for (int i = 0; i < UserControlList.eventDate.Count(); i++)
            {
                if (DateTime.Now.ToString("dd.MM.yyy") == UserControlList.eventDate[i] && DateTime.Now.ToString("HH:mm") == UserControlList.eventTime[i])
                {
                    ni.BalloonTipText = UserControlList.eventName[i].ToString();
                    ni.ShowBalloonTip(1000);
                }

            }
        }

        /// <summary>
        /// Сворачивание в трей
        /// </summary>
        /// <param name="e">Событие</param>
        protected override void OnStateChanged(EventArgs e)
        {
            if (WindowState == WindowState.Minimized) // WindowState - текущее состояние окна (свернуто, развернуто) 
                this.Hide();

            base.OnStateChanged(e);
        }


        /// <summary>
        /// Клик на кнопку открытия меню
        /// </summary>
        /// <param name="sender">Объект по которому проиошел клик</param>
        /// <param name="e">Событие</param>
        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            recBag.Visibility = Visibility.Visible;
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Клик на кнопку закрытия меню
        /// </summary>
        /// <param name="sender">Объект по которому проиошел клик</param>
        /// <param name="e">Событие</param>
        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            recBag.Visibility = Visibility.Collapsed;
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Переход между пунктами меню
        /// </summary>
        /// <param name="sender">Объект по которому проиошел клик</param>
        /// <param name="e">Событие</param>
        public void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            System.Windows.Controls.UserControl usc = null;
            GridMain.Children.Clear();

            switch (((System.Windows.Controls.ListViewItem)((System.Windows.Controls.ListView)sender).SelectedItem).Name)
            {
                case "ItemList":
                    usc = new UserControlList();
                    GridMain.Children.Add(usc);
                    break;
                case "ItemCreate":
                    usc = new UserControlCreate();
                    GridMain.Children.Add(usc);
                    break;
               case "ItemSettings":
                    usc = new UserControlSettings();
                    GridMain.Children.Add(usc);
                    break; 
                default:
                    break;
            }
        }

        /// <summary>
        /// Кнопка перехода в окно настроек
        /// </summary>
        /// <param name="sender">Объект по которому проиошел клик</param>
        /// <param name="e">Событие</param>
        private void ButtonSettings_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.UserControl usc = null;
            GridMain.Children.Clear();
            usc = new UserControlSettings();
            GridMain.Children.Add(usc);
        }

        /// <summary>
        /// Кнопка выхода из приложения
        /// </summary>
        /// <param name="sender">Объект по которому проиошел клик</param>
        /// <param name="e">Событие</param>
        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = System.Windows.MessageBox.Show("Вы уверены, что хотите выйти?", "Выход",
                MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                ni.Dispose();
                this.Close();
            }

        }

        /// <summary>
        /// Кнопка сворачивания окна
        /// </summary>
        /// <param name="sender">Объект по которому проиошел клик</param>
        /// <param name="e">Событие</param>
        private void Button_Click_Minimize(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        /// <summary>
        /// Перетаскивание окна
        /// </summary>
        /// <param name="sender">Объект по которому проиошел клик</param>
        /// <param name="e">Событие</param>
        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        /// <summary>
        /// Удаление иконки из трея при закрытии окна.
        /// </summary>
        /// <param name="sender">Объект по которому проиошел клик</param>
        /// <param name="e">Событие</param>
        private void Window_Closed(object sender, EventArgs e)
        {
            ni.Dispose();
        }
    }
}