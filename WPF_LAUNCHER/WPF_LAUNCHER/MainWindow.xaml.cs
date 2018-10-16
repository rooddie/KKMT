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
using static WPF_LAUNCHER.Calc1;
using static WPF_LAUNCHER.Calc2;
using static WPF_LAUNCHER.FormGame15;
using static WPF_LAUNCHER.SapperMain;
using static WPF_LAUNCHER.Sudoku;


namespace WPF_LAUNCHER
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow MW { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void button_Сalc1_Click(object sender, RoutedEventArgs e)
        {
            Calc1 calc1_start = new Calc1();
            calc1_start.Show();
            //this.Close();
        }

        private void button_Calc2_Click(object sender, RoutedEventArgs e)
        {
            Calc2 calc2_start = new Calc2();
            calc2_start.Show();
            //this.Close();
        }

        private void button_15_Click(object sender, RoutedEventArgs e)
        {
            FormGame15 Game15 = new FormGame15();
            Game15.Show();

        }

        private void button_skd_Click(object sender, RoutedEventArgs e)
        {
            Sudoku Sudoku = new Sudoku();
            Sudoku.Show();
            //this.Close();
        }

        private void button_sap_Click(object sender, RoutedEventArgs e)
        {
            SapperMain sap = new SapperMain();
            sap.Show();
            //this.Close();
        }
    }
}
