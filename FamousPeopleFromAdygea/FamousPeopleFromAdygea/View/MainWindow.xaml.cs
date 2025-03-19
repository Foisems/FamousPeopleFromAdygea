using FamousPeopleFromAdygea.Model;
using FamousPeopleFromAdygea.View;
using FamousPeopleFromAdygea;
using Microsoft.Win32;
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

namespace FamousPeopleFromAdygea.View
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int? idRole = null;
        public MainWindow(int? IdRole = null)
        {
            InitializeComponent();

            dataGrid.ItemsSource = FamousPeopleDBEntities.GetContext().FamousHuman.ToList();

            idRole = IdRole;

            if (idRole == null)
            {
                btnAddHuman.Visibility = Visibility.Collapsed;
                btnUpdateHuman.Visibility = Visibility.Collapsed;
            }
        }

      

        private void btnOpenHuman_Click(object sender, RoutedEventArgs e)
        {
            FamousHuman famousHuman = (sender as Button).DataContext as FamousHuman;

            HumanWindow humanWindow = new HumanWindow(famousHuman, idRole);
            humanWindow.ShowDialog();
        }

        private void btnAddHuman_Click(object sender, RoutedEventArgs e)
        {
            AddHumanWindow addHumanWindow = new AddHumanWindow(null, true);
            addHumanWindow.ShowDialog();
        }

        // Обновление списка
        private void btnUpdateHuman_Click(object sender, RoutedEventArgs e)
        {
            using (FamousPeopleDBEntities db = new FamousPeopleDBEntities())
            {
                dataGrid.ItemsSource = null;
                dataGrid.ItemsSource = db.FamousHuman.ToList();
            }
        }

        // Выйти из профиля
        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
        }

        

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            App.Current.Shutdown();
        }
    }
}
