using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Практическая_работа__12
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private DispatcherTimer timer;

        /// <summary>
        /// Модуль запускающий таймер при открытии главного окна программы который будет показывать дату и время
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 0, 0, 0);
            timer.IsEnabled = true;
        }

        /// <summary>
        /// Модуль, реализующий таймер для обновления времени и даты в главном окне
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
        /// Модуль открывающий второстепенное окно программы для первого номера задания
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenWindowOneNumber_Click(object sender, RoutedEventArgs e)
        {
            NumberOne numberone = new NumberOne();
            numberone.Owner = this;
            numberone.Show();
            this.IsEnabled = false;
            numberone.Closed += (s, args) => this.IsEnabled = true;
        }

        /// <summary>
        /// Модуль открывающий второстепенное окно программы для второго номера задания
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenWindowTwoNumber_Click(object sender, RoutedEventArgs e)
        {
            NumberTwo numbertwo = new NumberTwo();
            numbertwo.Owner = this;
            numbertwo.Show();
            this.IsEnabled = false;
            numbertwo.Closed += (s, args) => this.IsEnabled = true;
        }

        MessageBoxResult closeProg;

        /// <summary>
        /// Модуль выводящий сообщение при закрытии главного окна программы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_CLosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            closeProg = MessageBox.Show("Вы дейстительно хотите закрыть программу?", "Выход из программы:", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(closeProg == MessageBoxResult.No)
                e.Cancel = true;
        }

        /// <summary>
        /// Модуль закрывающий главное окно программы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCloseMainWindow_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Модуль выводящий информацию о задании для разработки программы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInfoProga_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Первое задание:\nДана длина ребра куба А. Найти объем куба V \nи площадь его поверхности S.\n\n" +
                "Второе задание: \nДана масса M в килограммах. Используя опера-\nцию деления целых чисел, найти количество \n" +
                "полных тонн и килограмм (1 тонна = 1000 кг).", "О программе", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        /// <summary>
        /// Модуль выводящий информацию о разработчике программы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInfoCreator_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Жаров Артём Андреевич \nГруппа ИСП-31", "О создателе", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}