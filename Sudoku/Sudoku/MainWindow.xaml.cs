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

namespace Sudoku
{
    public partial class MainWindow : Window
    {
        const int n = 9; // размер карты
        
        // Изначальная карта
        int[,] matrix = {
            {1, 2, 3, 4, 5, 6, 7, 8, 9},
            {4, 5, 6, 7, 8, 9, 1, 2, 3},
            {7, 8, 9, 1, 2, 3, 4, 5, 6},
            {2, 3, 4, 5, 6, 7, 8, 9, 1},
            {5, 6, 7, 8, 9, 1, 2, 3, 4},
            {8, 9, 1, 2, 3, 4, 5, 6, 7},
            {3, 4, 5, 6, 7, 8, 9, 1, 2},
            {6, 7, 8, 9, 1, 2, 3, 4, 5},
            {9, 1, 2, 3, 4, 5, 6, 7, 8},
        };

        // Для перемешивания
        int temp = 0;
        int[,] arr_rows_area = new int[3, n];
        int[,] arr_columns_area = new int[n, 3];

        Button[,] buttons = new Button[n, n]; // массив кнопок
        Random random = new Random(); // рандом
        bool check_fill = false;
        int cnt = 0;

        public MainWindow()
        {
            InitializeComponent();
            shuffle();
        }

        /// <summary>
        /// Перемешивание
        /// </summary>
        private void shuffle()
        {
            for (int i = 0; i < 100; i++)
            {
                int r = random.Next(1, 6);

                switch (r)
                {
                    case 1:
                        transposing();
                        break;
                    case 2:
                        swap_rows_small();
                        break;
                    case 3:
                        swap_colums_small();
                        break;
                    case 4:
                        swap_rows_area();
                        break;
                    case 5:
                        swap_colums_area();
                        break;
                }
            }
        }

        /// <summary>
        /// Транспонирование таблицы
        /// </summary>
        private void transposing()
        { 
            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    matrix[i, j] ^= matrix[j, i];
                    matrix[j, i] ^= matrix[i, j];
                    matrix[i, j] ^= matrix[j, i];
                }
            }
        }

        /// <summary>
        /// Обмен двух строк в пределах одного района
        /// </summary>
        private void swap_rows_small()
        {

            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    temp = matrix[i, j];
                    matrix[i, j] = matrix[i + 2, j];
                    matrix[i + 2, j] = temp;
                }
            }
        }

        /// <summary>
        /// Обмен двух столбцов в пределах одного района
        /// </summary>
        private void swap_colums_small()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    temp = matrix[i, j];
                    matrix[i, j] = matrix[i, j + 2];
                    matrix[i, j + 2] = temp;
                }
            }
        }

        /// <summary>
        /// Обмен двух районов по горизонтали
        /// </summary>
        private void swap_rows_area()
        {
            int[,] arr_rows_area = new int[3, n];

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < n; j++)
                    arr_rows_area[i, j] = matrix[i, j];

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = matrix[i + 3, j];
                    matrix[i + 3, j] = arr_rows_area[i, j];
                }
            }
        }

        /// <summary>
        /// Обмен двух районов по вертикали
        /// </summary>
        private void swap_colums_area()
        {
            int[,] arr_colums_area = new int[n, 3];
            
            for (int i = 0; i < n; i++)
                for (int j = 0; j < 3; j++)
                    arr_columns_area[i, j] = matrix[i, j];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    matrix[i, j] = matrix[i, j + 3];
                    matrix[i, j + 3] = arr_columns_area[i, j];
                }
            }
        }
 
        /// <summary>
        /// Заполнение
        /// </summary>
        private void fill()
        {
            check_fill = true; // Для проверки, заполнена ли карта

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {   
                    buttons[i, j] = new Button();
                    buttons[i, j].Name = null;
                    buttons[i, j].Width = 40d;
                    buttons[i, j].Margin = new Thickness(10);
                    buttons[i, j].HorizontalContentAlignment = HorizontalAlignment.Center;
                    buttons[i, j].VerticalContentAlignment = VerticalAlignment.Center;
                    buttons[i, j].FontWeight = FontWeights.Bold;
                    buttons[i, j].BorderBrush = Brushes.Black;
                    buttons[i, j].BorderThickness = new Thickness(2);
                    buttons[i, j].Content = matrix[i, j].ToString();
                    GridNum.Children.Add(buttons[i, j]);
                    Grid.SetRow(buttons[i, j], i);
                    Grid.SetColumn(buttons[i, j], j);
                    //buttons[i, j].Click += Button_Click;
                    buttons[i, j].Tag = Grid.GetRow(buttons[i, j]).ToString() + Grid.GetColumn(buttons[i, j]).ToString();
                }
            }
        }

        /// <summary>
        /// Контекстное меню, открывающееся при нажатии на изначально пустую после заполнения кнопку
        /// </summary>
        private ContextMenu GetContextMenu()
        {
            ContextMenu cm = new ContextMenu();
            MenuItem I1, I2, I3, I4, I5, I6, I7, I8, I9;
            int val = 1;

            I1 = new MenuItem(); I2 = new MenuItem(); I3 = new MenuItem();
            I4 = new MenuItem(); I5 = new MenuItem(); I6 = new MenuItem();
            I7 = new MenuItem(); I8 = new MenuItem(); I9 = new MenuItem();

            cm.Items.Add(I1); cm.Items.Add(I2); cm.Items.Add(I3);
            cm.Items.Add(I4); cm.Items.Add(I5); cm.Items.Add(I6);
            cm.Items.Add(I7); cm.Items.Add(I8); cm.Items.Add(I9);

            var allItems = cm.Items.Cast<MenuItem>().ToArray();
            foreach (var Item in allItems)
            {
                Item.Header = val.ToString();
                Item.Click += menu1_Click;
                val++;
            }

            return cm;
        }

        /// <summary>
        /// Проверка допустимости вставляемого значения и его вставка
        /// </summary>
        /// <param name="sender">Объект по которому проиошел клик</param>
        /// <param name="e">Событие</param>
        private void menu1_Click(object sender, RoutedEventArgs e)
        {
            MenuItem item = (MenuItem)sender;
            ContextMenu cm = (ContextMenu)item.Parent;
            Button btn = (Button)cm.PlacementTarget;
            btn.Content = item.Header.ToString();
            string[] arr = new string[9];
            int x = Grid.GetColumn(btn);
            int y = Grid.GetRow(btn);
            //lb1.Content = y.ToString() + " " + x.ToString();

            string s;
            int k = 0;
            int box_x = 0, box_y = 0;

            // Проверка строки
            for (int i = y; i < y+1; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (buttons[i, j].Content == null)
                        s = "null";
                    else if (j != x)
                        s = buttons[i, j].Content.ToString();
                    else
                        s = "j";

                    if (s == item.Header.ToString())
                    {
                        btn.Content = "";
                        k++;
                        break;
                    }
                }
            }

            // Проверка столбца
            for (int i = 0; i < 9; i++)
            {
                for (int j = x; j < x+1; j++)
                {
                    if (buttons[i, j].Content == null)
                        s = "null";
                    else if (i != y)
                        s = buttons[i, j].Content.ToString();
                    else
                        s = "j";

                    if (s == item.Header.ToString())
                    {
                        btn.Content = "";
                        k++;
                        break;
                    }
                }
            }

            // Проверка области
  
            if (x < 3) box_x = 0;
            else if (x < 6) box_x = 3;
            else if (x < 9) box_x = 6;

            if (y < 3) box_y = 0;
            else if (y < 6) box_y = 3;
            else if (y < 9) box_y = 6;

            for (int i = box_y; i < box_y + 3; i++)
            {
                for (int j = box_x; j < box_x + 3; j++)
                {
                    if (buttons[i, j].Content == null) s = "null";
                    else if (i != y) s = buttons[i, j].Content.ToString();
                    else s = "j";

                    if (s == item.Header.ToString())
                    {
                        btn.Content = "";
                        k++;
                        break;
                    }
                }
            }

            if (k == 0)
                btn.Content = item.Header.ToString();

            win();
        }

        /// <summary>
        /// Проверка на прохождение игры
        /// </summary>
        private void win()
        {
            int check_win = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (buttons[i, j] == null)
                    {
                        check_win++;
                        break;
                    }                   
                }
            }

            if (check_win == 81)
            {
                clear();
                MessageBox.Show("Е БОЙ, ВЫ ПОБЕДИЛИ СЭР", "ПОБЕДА");
            }
        }

        /// <summary>
        /// У</summary>
        private void cell_removal()
        {
            int deleter_i = random.Next(9);
            int deleter_j = random.Next(9);

            if (buttons[deleter_i, deleter_j].Content == null)
                return;
            else
            {
                buttons[deleter_i, deleter_j].Content = null;
                buttons[deleter_i, deleter_j].ContextMenu = GetContextMenu();
                buttons[deleter_i, deleter_j].Foreground = Brushes.Green;
                cnt++;
            }
        }


        /// <summary>
        /// Очищение карты
        /// </summary>
        private void clear()
        {
            GridNum.Children.Remove(btn_l);
            GridNum.Children.Remove(btn_m);
            GridNum.Children.Remove(btn_h);
            if (check_fill == true)
            {
                check_fill = false;
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        buttons[i, j].Content = null;
                    }
                }
            }
        }


        /// <summary>
        /// Кнопка с легким уровнем сложности
        /// </summary>
        /// <param name="sender">Объект по которому проиошел клик</param>
        /// <param name="e">Событие</param>

        private void btn_l_Click(object sender, RoutedEventArgs e)
        {
            clear();
            fill();
            while (cnt <= 20)
                cell_removal();
        }

        /// <summary>
        /// Кнопка со средним уровнем сложности
        /// </summary>
        /// <param name="sender">Объект по которому проиошел клик</param>
        /// <param name="e">Событие</param>
        private void btn_m_Click(object sender, RoutedEventArgs e)
        {
            clear();
            fill();
            while (cnt <= 36)
                cell_removal();
        }

        /// <summary>
        /// Кнопка с высоким уровнем сложности
        /// </summary>
        /// <param name="sender">Объект по которому проиошел клик</param>
        /// <param name="e">Событие</param>
        private void btn_h_Click(object sender, RoutedEventArgs e)
        {
            clear();
            fill();
            while (cnt <= 54)
                cell_removal();
        }
    }
}