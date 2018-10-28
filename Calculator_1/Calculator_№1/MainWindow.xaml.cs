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

namespace Calculator_1
{
    public partial class MainWindow : Window
    {
        string left_op = ""; // Левый операнд
        string right_op = ""; // Правый операнд
        string operation = ""; // Знак операции

        public MainWindow()
        {
            InitializeComponent();
            // Добавляем обработчик для всех кнопок на сетке
            foreach (UIElement c in Main_Grid.Children)
            {
                if (c is Button)
                {
                    ((Button)c).Click += Button_Click;
                }
            }
        }

        /// <summary>
        /// Клик для всех кнопок
        /// </summary>
        /// <param name="sender">Объект по которому проиошел клик</param>
        /// <param name="e">Событие</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Текст кнопки
            string s = (sender as Button).Content.ToString();
            // Добавляем текст в текстовое поле
            textBlock.Text += s;
            int num;
            // Преобразоваем его в число
            bool result = Int32.TryParse(s, out num);
            // Если текст число...
            if (result == true)
            {
                // Если операция не задана
                if (operation == "")
                {
                    // Добавляем к левому операнду
                    left_op += s;
                }
                else
                {
                    // Иначе к правому
                    right_op += s;
                }
            }
            // Если было введено не число
            else
            {
                // Если равно, то выводим результат операции
                if (s == "=")
                {
                    UpVal_RightOp();
                    textBlock.Text += right_op;
                    operation = "";
                }
                // Очищаем все переменные и текстовое поле
                else if (s == "NULL")
                {
                    left_op = "";
                    right_op = "";
                    operation = "";
                    textBlock.Text = "";
                }
                // Получаем операцию
                else
                {
                    // Если правый операнд уже имеется, то присваиваем его значение левому а правый очищаем
                    if (right_op != "")
                    {
                        UpVal_RightOp();
                        left_op = right_op;
                        right_op = "";
                    }
                    operation = s;
                }
            }
        }


        /// <summary>
        /// Обновление значения правого операнда
        /// </summary>
        private void UpVal_RightOp()
        {
            int num1 = Int32.Parse(left_op);
            int num2 = Int32.Parse(right_op);
            // И выполняем операцию
            switch (operation)
            {
                case "+":
                    right_op = (num1 + num2).ToString();
                    break;
                case "-":
                    right_op = (num1 - num2).ToString();
                    break;
                case "*":
                    right_op = (num1 * num2).ToString();
                    break;
                case "/":
                    right_op = (num1 / num2).ToString();
                    break;
            }
        }
    }
}