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

namespace PIT_TK_Petrov_122_1var
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculateResult_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int task1 = int.Parse(Task1Box.Text);
                int task2 = int.Parse(Task2Box.Text);
                int task3 = int.Parse(Task3Box.Text);
                int task4 = int.Parse(Task4Box.Text);

                int total;
                string grade = GradingLogic.CalculateGrade(task1, task2, task3, task4, out total);
                ResultText.Text = $"Сумма баллов: {total}\nОценка: {grade}";
            }
            catch (ArgumentOutOfRangeException ex)
            {
                ResultText.Text = "Ошибка: баллы не соответствуют допустимому диапазону.";
            }
            catch
            {
                ResultText.Text = "Ошибка: введите корректные числовые значения.";
            }
        }

        public static class GradingLogic
        {
            public static string CalculateGrade(int task1, int task2, int task3, int task4, out int total)
            {
                if (task1 < 0 || task1 > 10 ||
                    task2 < 0 || task2 > 50 ||
                    task3 < 0 || task3 > 30 ||
                    task4 < 0 || task4 > 10)
                {
                    throw new ArgumentOutOfRangeException("Одно или несколько значений выходят за допустимые пределы.");
                }

                total = task1 + task2 + task3 + task4;

                if (total >= 70) return "5 (отлично)";
                else if (total >= 40) return "4 (хорошо)";
                else if (total >= 20) return "3 (удовлетворительно)";
                else return "2 (неудовлетворительно)";
            }
        }
    }
}