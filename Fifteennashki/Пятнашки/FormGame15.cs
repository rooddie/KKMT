using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Пятнашки
{
    public partial class FormGame15 : Form
    {
        Game game;
        int counter = 0;
        bool start = false;

        public FormGame15()
        {
            InitializeComponent();
            game = new Game(4);
        }

        private void button0_Click(object sender, EventArgs e)
        {
            counter++;
            int position = Convert.ToInt32(((Button)sender).Tag);
            if (start)
            {
                game.shift(position);
                refresh();
            }
            if (game.check_map())
            {
                MessageBox.Show("ПОЗДРАВЛЯЮ, ВЫ ЗАТАЩИЛИ КАТКУ!!! Количество ходов - " + counter.ToString(), "CООБЩЕНИЕ");
                start_game();
            }
        }

        private Button Button (int position)
        {
            switch (position)
            {
                case 0:
                    return button0;
                case 1:
                    return button1;
                case 2:
                    return button2;
                case 3:
                    return button3;
                case 4:
                    return button4;
                case 5:
                    return button5;
                case 6:
                    return button6;
                case 7:
                    return button7;
                case 8:
                    return button8;
                case 9:
                    return button9;
                case 10:
                    return button10;
                case 11:
                    return button11;
                case 12:
                    return button12;
                case 13:
                    return button13;
                case 14:
                    return button14;
                case 15:
                    return button15;
                default:
                    return null;
            }
        }

        private void FormGame15_Load(object sender, EventArgs e)
        {
            
            //start_game();
        }

        // Кнопка в меню. Запускает игру.
		private void menu_start_Click_1(object sender, EventArgs e)
        {
            start_game();
        }

        private void start_game()
        {
            start = true;
            game.start();
            for (int j = 0; j < 100; j++)
            {
                game.shift_random();
            }
            refresh();
        }
	
		// Обновление содержимого кнопок
        private void refresh()
        {
            for (int position = 0; position < 16; position++)
            {
                int ggn = game.get_number(position);
                Button(position).Text = ggn.ToString();
                Button(position).Visible = (ggn > 0);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
