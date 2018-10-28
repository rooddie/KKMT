using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Пятнашки
{
    class Game
    {
        int size;
        int[,] map;
        int space_x, space_y;
        static Random rand = new Random();

        public Game(int size)
        {
            if (size < 2) size = 2;
            if (size > 5) size = 5;
            this.size = size;
            map = new int[size, size];
        }

        /// <summary>
        /// Подготовка поля к игре
        /// </summary>
        public void start()
        {
            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    map[x, y] = coords_to_position(x, y) + 1;
                }
            }
            space_x = size - 1;
            space_y = size - 1;
            map[space_x, space_y] = 0;
        }

        /// <summary>
        /// Сдвиг
        /// </summary>
        /// <param name="position">Позиция объекта</param>
        public void shift (int position)
        {
            int x, y;
            position_to_coords(position, out x, out y);
            if (Math.Abs(space_x - x) + Math.Abs(space_y - y) != 1)
            {
                return;
            }
            map[space_x, space_y] = map[x, y];
            map[x, y] = 0;
            space_x = x;
            space_y = y;
        }

        /// <summary>
        /// Перемещение кнопок случайным образом
        /// </summary>
		public void shift_random()
        {
            //shift(rand.Next(0, size * size));
            int a = rand.Next(0, 4);
            int x = space_x;
            int y = space_y;
            switch (a)
            {
                case 0:
                    x--;
                    break;
                case 1:
                    x++;
                    break;
                case 2:
                    y--;
                    break;
                case 3:
                    y++;
                    break;
            }
            shift(coords_to_position(x, y));
        }

        /// <summary>
        /// Проверка на прохождение игры
        /// </summary>
        public bool check_map()
        {
            if (!(space_x == size - 1 && space_y == size - 1))
                return false;

            for (int x = 0; x < size; x++)
                for (int y = 0; y < size; y++)
                    if (!(x == size - 1 && y == size - 1))
                        if (map[x, y] != coords_to_position(x, y) + 1)
                            return false;
            return true;
        }

        /// <summary>
        /// Получение значения на кнопке
        /// </summary>
        /// <param name="position">Позиция объекта</param>

        public int get_number(int position)
        {
            int x, y;
            position_to_coords(position, out x, out y);
            if (x < 0 || x >= size) return 0;
            if (y < 0 || y >= size) return 0;
            return map[x, y];
        }

        /// <summary>
        /// Перевод координат в позицию
        /// </summary>
        /// <param name="x">Координата х</param>
        /// <param name="y">Координата у</param>
		private int coords_to_position(int x, int y)
        {
            if (x < 0) x = 0;
            if (x > size - 1) x = size - 1;
            if (y < 0) y = 0;
            if (y > size - 1) y = size - 1;

            return y * size + x;
        }

        /// <summary>
        /// Получение координат из позиции
        /// </summary>
        /// <param name="position">Позиция объекта</param>
        /// <param name="x">Координата х</param>
        /// <param name="y">Координата у</param>
        private void position_to_coords(int position, out int x, out int y)
        {
            if (position < 0) position = 0;
            if (position > size * size - 1) position = size * size - 1;

            x = position % size;
            y = position / size;
        }
    }
}
