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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Практическая_работа__12
{
    /// <summary>
    /// Логика взаимодействия для NumberTwo.xaml
    /// </summary>
    public partial class NumberTwo : Window
    {
        public NumberTwo()
        {
            InitializeComponent();
        }

        private DispatcherTimer timer;

        /// <summary>
        /// Модуль запускающий таймер при открытии второстепенного окна программы который будет показывать дату и время
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WindowNumberTwo_Loaded(object sender, RoutedEventArgs e)
        {
            timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 0, 0, 0);
            timer.IsEnabled = true;
        }

        /// <summary>
        /// Модуль, реализующий таймер для обновления времени и даты во второстепенном окне программы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            DateTime d = DateTime.Now;
            time.Text = d.ToString("HH:mm:ss");
            data.Text = d.ToString("dd.MM.yyyy");
        }

        /// <summary>
        /// Модуль закрытия программы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            NumberTwo numberTwo = new NumberTwo();
            numberTwo.Owner = this;
            this.Close();
        }

        /// <summary>
        /// Модуль выводящий информацию о задании для разработки программы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInfoProga_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Второе задание: \nДана масса M в килограммах. Используя опера-\nцию деления целых чисел, найти количество \n" +
                "полных тонн и килограмм (1 тонна = 1000 кг).", "О программе", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        /// <summary>
        /// Модуль производящий вычисления в программе по заданию
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCalc_Click(object sender, RoutedEventArgs e)
        {
            tbM.Focus();
            if (tbM.Text != "")
            {
                int value, tonni, kg;
                if (Int32.TryParse(tbM.Text, out value) == true)
                {
                    NumberTwoClass numberTwoClass = new NumberTwoClass();

                    tonni = numberTwoClass.CalcTonni(value, out tonni);
                    kg = numberTwoClass.CalcKg(value, out kg);

                    tbTonni.Text = Convert.ToString(tonni);
                    tbKg.Text = Convert.ToString(kg);
                }
                else MessageBox.Show("Введены некорректные значения!", "Ошибка: ", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else MessageBox.Show("Отсутствуют данные для рассчёта!", "Ошибка: ", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        /// <summary>
        /// Модуль очищающий все поля в программе и фокусирующийся на блоке ввода данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            tbM.Clear();
            tbKg.Clear();
            tbTonni.Clear();
            tbM.Focus();
        }

        /// <summary>
        /// Модуль очищающий поля результата при изменении исходных данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbM_TextChanged(object sender, TextChangedEventArgs e)
        {
            tbKg.Clear();
            tbTonni.Clear();
        }
    }
}
