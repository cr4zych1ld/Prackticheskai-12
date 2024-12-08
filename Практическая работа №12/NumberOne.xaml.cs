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
    /// Логика взаимодействия для NumberOne.xaml
    /// </summary>
    public partial class NumberOne : Window
    {
        public NumberOne()
        {
            InitializeComponent();
        }

        private DispatcherTimer timer;

        /// <summary>
        /// Модуль запускающий таймер при открытии второстепенного окна программы который будет показывать дату и время
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WindowNumberOne_Loaded(object sender, RoutedEventArgs e)
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
            NumberOne numberOne = new NumberOne();
            numberOne.Owner = this;
            this.Close();
        }

        /// <summary>
        /// Модуль выводящий информацию о задании для разработки программы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInfoProga_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Первое задание:\nДана длина ребра куба А. Найти объем куба V \nи площадь его поверхности S.", "О программе", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        /// <summary>
        /// Модуль производящий вычисления в программе по заданию
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCalc_Click(object sender, RoutedEventArgs e)
        {
            tbA.Focus();
            if (tbA.Text != "")
            {
                int value, ob, pl;
                if(Int32.TryParse(tbA.Text, out value) == true)
                {
                    NumberOneClass numberOneClass = new NumberOneClass();

                    ob = numberOneClass.CalcOb(value, out ob);
                    pl = numberOneClass.CalcPl(value, out pl);

                    tbV.Text = Convert.ToString(ob);
                    tbS.Text = Convert.ToString(pl);
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
            tbA.Clear();
            tbV.Clear();
            tbS.Clear();
            tbA.Focus();
        }

        /// <summary>
        /// Модуль очищающий поля результата при изменении исходных данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbA_TextChanged(object sender, TextChangedEventArgs e)
        {
            tbV.Clear();
            tbS.Clear();
        }
    }
}
