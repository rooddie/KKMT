using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WPF_LAUNCHER
{
    class Sapper
    {
        public static int
          map_rows = 10, // кол-во клеток по вертикали
          map_columns = 10, // кол-во клеток по горизонтали
          number_bombs = 25, // кол-во мин
          difficulty = 0; // сложность

        public static int bombs_found;  // кол-во найденных мин
        public static int set_flags; // кол-во поставленных флагов

        // игровое (минное) поле
        public static int[,] Pole;
        public static Button[,] buttons;

        // устанавливает сложность
        public static void set_difficulty(int difficulty)
        {
            if (difficulty == 1)
            {
                int row_column_count = 10;

                Pole = new int[map_rows + 2, map_columns + 2];
                buttons = new Button[map_rows + 2, map_columns + 2];

                grid_make(row_column_count);
                NewGame();
                SapperMain.MW.Fill();
            }

            if (difficulty == 2)
            {
                int row_column_count = 15;

                map_rows = 15;
                map_columns = 15;
                number_bombs = 50;

                Pole = new int[map_rows + 2, map_columns + 2];
                buttons = new Button[map_rows + 2, map_columns + 2];

                grid_make(row_column_count);
                NewGame();
                SapperMain.MW.Fill();
            }

            if (difficulty == 3)
            {
                int row_column_count = 25;

                map_rows = 25;
                map_columns = 25;
                number_bombs = 70;

                Pole = new int[map_rows + 2, map_columns + 2];
                buttons = new Button[map_rows + 2, map_columns + 2];

                grid_make(row_column_count);
                NewGame();
                SapperMain.MW.Fill();
            }

        }

        // в зависимости от сложности, устанавливает дополнительные столбц и строки в таблице
        public static void grid_make(int row_column_count)
        {
            while (row_column_count > 0)
            {
                ColumnDefinition c1 = new ColumnDefinition();
                c1.Width = new GridLength(120, GridUnitType.Star);

                RowDefinition r1 = new RowDefinition();
                r1.Height = new GridLength(120, GridUnitType.Star);

                SapperMain.MW.Main_Grid.RowDefinitions.Add(r1);
                SapperMain.MW.Main_Grid.ColumnDefinitions.Add(c1);
                row_column_count--;
            }
        }

        // запуск новой игры
        public static void NewGame()
        {

            int n = 0;       // количество проставленных мин
            int row, col;    // индексы клетки
            int bombs_near;  // количествово мин в соседних клетках

            // очистить поле
            SapperMain.MW.clear_map();

            for (row = 0; row <= map_rows + 1; row++)
            {
                Pole[row, 0] = -3;
                Pole[row, map_columns + 1] = -3;
            }

            for (col = 0; col <= map_columns + 1; col++)
            {
                Pole[0, col] = -3;
                Pole[map_rows + 1, col] = -3;
            }
            
            // инициализация генератора случайных чисел
            Random rand = new Random();

            // расставим мины
            do
            {
                row = rand.Next(map_rows) + 1;
                col = rand.Next(map_columns) + 1;

                if (Pole[row, col] != 9)
                {
                    Pole[row, col] = 9;
                    n++;
                }
            }
            while (n != number_bombs);

            // вычисление количества мин в соседних клетках
            for (row = 1; row <= map_rows; row++)
                for (col = 1; col <= map_columns; col++)
                    if (Pole[row, col] != 9)
                    {
                        bombs_near = 0;

                        if (Pole[row - 1, col - 1] == 9) bombs_near++;
                        if (Pole[row - 1, col] == 9) bombs_near++;
                        if (Pole[row - 1, col + 1] == 9) bombs_near++;
                        if (Pole[row, col - 1] == 9) bombs_near++;
                        if (Pole[row, col + 1] == 9) bombs_near++;
                        if (Pole[row + 1, col - 1] == 9) bombs_near++;
                        if (Pole[row + 1, col] == 9) bombs_near++;
                        if (Pole[row + 1, col + 1] == 9) bombs_near++;

                        Pole[row, col] = bombs_near;
                    }

            number_bombs = 0;   // нет обнаруженных мин
            set_flags = 0;      // нет поставленных флагов
        }

        // открытие соседних клеток
        public static void open_cell(int row, int col)
        {
            if (Pole[row, col] == 0)
            {
                color_content(row, col);
                buttons[row, col].Effect = null;
                buttons[row, col].IsEnabled = false;
                Pole[row, col] = 100;
                buttons[row, col].Content = "";
                buttons[row, col].Tag = "open";

                open_cell(row, col - 1);
                open_cell(row - 1, col);
                open_cell(row, col + 1);
                open_cell(row + 1, col);
            }

            else
                if ((Pole[row, col] < 100) && (Pole[row, col] != -3))
            {
                color_content(row, col);
                buttons[row, col].Effect = null;
                buttons[row, col].IsEnabled = false;
                Pole[row, col] += 100;
                buttons[row, col].Content = Pole[row, col] - 100;
                buttons[row, col].Tag = "open";  
            }
        }

        // раскрашивание контента
        public static void color_content(int row, int col)
        {
            if (Pole[row, col] == 9) buttons[row, col].Background = Brushes.Red;
            else if (Pole[row, col] == 0) buttons[row, col].Foreground = Brushes.Black;
            else if (Pole[row, col] == 1) buttons[row, col].Foreground = Brushes.Blue;
            else if (Pole[row, col] == 2) buttons[row, col].Foreground = Brushes.Green;
            else if (Pole[row, col] == 3) buttons[row, col].Foreground = Brushes.Red;
            else if (Pole[row, col] == 4) buttons[row, col].Foreground = Brushes.HotPink;
            else if (Pole[row, col] == 5) buttons[row, col].Foreground = Brushes.Indigo;
            else if (Pole[row, col] == 6) buttons[row, col].Foreground = Brushes.LemonChiffon;
            else if (Pole[row, col] == 7) buttons[row, col].Foreground = Brushes.Gold;
            else if (Pole[row, col] == 8) buttons[row, col].Foreground = Brushes.Firebrick;
        }

        // Конец игры, активируется при попадании на мину.
        public static void gameOver()
        {
            for (int i = 1; i <= map_rows; i++)
            {
                for (int j = 1; j <= map_columns; j++)
                {
                    if (Pole[i, j] == 9)
                    {
                        BitmapImage bomb = new BitmapImage();
                        bomb.BeginInit();
                        bomb.UriSource = new Uri("/Resources/bomb.png", UriKind.RelativeOrAbsolute);
                        bomb.EndInit();
                        buttons[i, j].Content = new Image() { Source = bomb };
                        if (difficulty == 3)
                            buttons[i, j].Padding = new Thickness(5);
                        else
                            buttons[i, j].Padding = new Thickness(10);
                        buttons[i, j].Background = Brushes.Red;
                    }
                }
            }
            MessageBox.Show("Вы проиграли :(                                                \n\nНайдено мин: " 
                + bombs_found.ToString() + "\n\nПоставлено флажков: " + set_flags.ToString(), "Поражение");
            System.Windows.Application.Current.Shutdown(); // закрывает приложение
        }

        // проверка на победу
        public static void win()
        {
            int cnt = 0; // количество открытых клеток

            for (int i = 1; i <= map_rows; i++)
                for (int j = 1; j <= map_columns; j++)
                    if (buttons[i, j].Tag != null && buttons[i, j].Tag.ToString() == "open")
                        cnt++;

            if (cnt == (map_rows * map_columns) - 1)
            {
                MessageBox.Show("Вы выиграли! :)                                                \n\nНайдено мин: "
                    + bombs_found.ToString() + "\n\nПоставлено флажков: " + set_flags.ToString(), "Победа");
                System.Windows.Application.Current.Shutdown(); // закрывает приложение
            }
        }
    }
}