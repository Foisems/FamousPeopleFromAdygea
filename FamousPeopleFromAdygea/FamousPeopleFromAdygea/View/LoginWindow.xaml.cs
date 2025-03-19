using FamousPeopleFromAdygea.Model;
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
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }
        private MainWindow mainWindow = new MainWindow(null);

        // Вход с авторизацией
        private void EnterAdmin_Click(object sender, RoutedEventArgs e)
        {
            using (FamousPeopleDBEntities db = new FamousPeopleDBEntities())
            {
                var user = db.User.FirstOrDefault(u => u.Password.Equals(passwordPB.Password)
                && u.Login.Equals(loginTB.Text));

                bool isEnter = false;
                if (user != null)
                {
                    isEnter = true;
                    if (user.IdRole == 1)
                    {
                        mainWindow = new MainWindow(1);

                    }
                    mainWindow.Show();
                    this.Hide();
                }

                if (!isEnter)
                {
                    MessageBox.Show("Неверный логин или пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        // Вход без авторизации
        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.Show();
            this.Hide();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            App.Current.Shutdown();
        }
    }
}
