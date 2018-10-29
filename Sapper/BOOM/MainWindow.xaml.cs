using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Effects;
using static BOOM.Sapper;

namespace BOOM
{
    public partial class MainWindow : Window
    {
        public static MainWindow MW { get; private set; }

        bool fill = false;

        public MainWindow()
        {
            InitializeComponent();
            label_title.HorizontalContentAlignment = HorizontalAlignment.Center;
            label_title.VerticalContentAlignment = VerticalAlignment.Center;
            MW = this;
        }

        /// <summary>
        /// Заполнение сетки
        /// </summary>
        public void Fill()
        {
            // заполнение кнопок
            for (int i = 1; i <= map_rows; i++)
                for (int j = 1; j <= map_columns; j++)
                {
                    buttons[i, j] = new Button();
                    buttons[i, j].HorizontalContentAlignment = HorizontalAlignment.Center;
                    buttons[i, j].VerticalContentAlignment = VerticalAlignment.Center;
                    buttons[i, j].FontWeight = FontWeights.Bold;
                    buttons[i, j].Background = Brushes.LightGray;
                    buttons[i, j].Effect =
                                        new DropShadowEffect
                                        {
                                            Color = new Color { A = 255, R = 55, G = 55, B = 255 },
                                            Direction = 320,
                                            ShadowDepth = 0,
                                            Opacity = 1
                                        };
                    buttons[i, j].FontSize = 20;
                    
                    buttons[i, j].Click += Button_Click;
                    buttons[i, j].MouseRightButtonDown += Button_Right_Click;
                    Main_Grid.Children.Add(buttons[i, j]);
                    Grid.SetRow(buttons[i, j], i-1);
                    Grid.SetColumn(buttons[i, j], j-1);
                    if (i == 0 || j == 0 || i == map_rows+1 || j == map_columns+1)
                        buttons[i, j].Visibility = Visibility.Hidden;
                }
        }

        /// <summary>
        /// Установка флага
        /// </summary>
        /// <param name="sender">Объект по которому проиошел клик</param>
        /// <param name="e">Событие</param>
        private void Button_Right_Click(object sender, MouseEventArgs e)
        {
            set_flags++;
            int row = 1 + Grid.GetRow((sender as Button)),
                col = 1 + Grid.GetColumn((sender as Button));

            if (Pole[row, col] == 9)
                bombs_found++;

            if ((sender as Button).Content == null)
            {
                (sender as Button).Tag = "checked";
                BitmapImage bomb = new BitmapImage();
                bomb.BeginInit();
                bomb.UriSource = new Uri("/Resources/flag.png", UriKind.RelativeOrAbsolute);
                bomb.EndInit();
                (sender as Button).Content = new Image() { Source = bomb };
                (sender as Button).Padding = new Thickness(5);
                (sender as Button).Background = Brushes.AliceBlue;
            }

            else if ((sender as Button).Tag.ToString() == "checked")
            {
                (sender as Button).Content = null;
                (sender as Button).Background = Brushes.LightGray;
            }
        }

        /// <summary>
        /// Открытие ячейки
        /// </summary>
        /// <param name="sender">Объект по которому проиошел клик</param>
        /// <param name="e">Событие</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            (sender as Button).Effect = null;
            (sender as Button).IsEnabled = false;

            int row = 1 + Grid.GetRow((sender as Button)),
                col = 1 + Grid.GetColumn((sender as Button));

            if (fill == false)
            {
                fill = true;
                if (Pole[row, col] == 9)
                {
                    Pole[row, col] = 0;
                    for (int row_b = 1; row_b <= map_rows; row_b++)
                        for (int col_b = 1; col_b <= map_columns; col_b++)
                            if (Pole[row_b, col_b] != 9)
                            {
                                int bombs_near = 0;

                                if (Pole[row_b - 1, col_b - 1] == 9) bombs_near++;
                                if (Pole[row_b - 1, col_b] == 9) bombs_near++;
                                if (Pole[row_b - 1, col_b + 1] == 9) bombs_near++;
                                if (Pole[row_b, col_b - 1] == 9) bombs_near++;
                                if (Pole[row_b, col_b + 1] == 9) bombs_near++;
                                if (Pole[row_b + 1, col_b - 1] == 9) bombs_near++;
                                if (Pole[row_b + 1, col_b] == 9) bombs_near++;
                                if (Pole[row_b + 1, col_b + 1] == 9) bombs_near++;

                                Pole[row_b, col_b] = bombs_near;
                            }
                }
            }

            if (Pole[row, col] == 9) gameOver();
            else if (Pole[row, col] == 0) {
                (sender as Button).Content = "";
                open_cell(row, col);
            }
            else (sender as Button).Content = Pole[row, col];

            (sender as Button).Tag = "open";
        
            color_content(row, col);
            win();    
        }

        /// <summary>
        /// Очищает карту
        /// </summary>
        public void clear_map()
        {
            Main_Grid.Children.Clear();
        }

        /// <summary>
        /// Выбор сложности
        /// </summary>
        /// <param name="sender">Объект по которому проиошел клик</param>
        /// <param name="e">Событие</param>
        private void Choise_difficulty(object sender, RoutedEventArgs e)
        {
            Button btn = (sender as Button);
            difficulty = Convert.ToInt16(btn.Tag);
            Sapper.set_difficulty(difficulty);
        }
    }
}
