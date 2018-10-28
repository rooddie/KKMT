using System;
using System.Collections.Generic;
using System.Windows.Input;
using System.Windows;
using System.Windows.Controls;
using System.Windows;
using ELW.Library.Math;
using ELW.Library.Math.Exceptions;
using ELW.Library.Math.Expressions;
using ELW.Library.Math.Tools;

namespace Calculator228
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            logo.HorizontalContentAlignment = HorizontalAlignment.Center;

        }

        /// <summary>
        /// Вычисление ввеенного выражение
        /// </summary>
        /// <param name="sender">Объект по которому проиошел клик</param>
        /// <param name="e">Событие</param>
        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Парсим строку с математическим выражением
                PreparedExpression preparedExpression = ToolsHelper.Parser.Parse(textBox.Text);
                // Компиляция распарсеных данных
                CompiledExpression compiledExpression = ToolsHelper.Compiler.Compile(preparedExpression);
                // Создание списка переменных
                List<VariableValue> variables = new List<VariableValue>();

                // Рассчёт
                double res = ToolsHelper.Calculator.Calculate(compiledExpression, variables);
                // Отображение результата
                result.Content = String.Format("Результат: {0}", res);
            }
            catch (CompilerSyntaxException ex)
            {
                result.Content = String.Format("Ошибка синтаксиса: {0}", ex.Message);
            }
            catch (MathProcessorException ex)
            {
                result.Content = String.Format("Ошибка: {0}", ex.Message);
            }
            catch (ArgumentException)
            {
                result.Content = "Ошибка в входных данных";
            }
        }

        // Проверка вводимых символов
        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int val;
            if (!Int32.TryParse(e.Text, out val) && e.Text != "-" && e.Text != "+" && e.Text != "*" 
                && e.Text != "/" && e.Text != "." && e.Text != "(" && e.Text != ")") 
            {
                e.Handled = true; // отклоняем ввод
            }
        }

        // Отслеживание нажатий на пробелы и enter 
        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true; // если пробел, отклоняем ввод
            }

            if (e.Key == Key.Enter)
            {
                button_Click(sender, e); // если enter, запускаем функцию
            }
        }

    }
}
