using FamousPeopleFromAdygea.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Security.Cryptography;
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
    /// Логика взаимодействия для AddHumanWindow.xaml
    /// </summary>
    public partial class AddHumanWindow : Window
    {
        private FamousHuman famousHuman = new FamousHuman();
        private bool isAdd = true;

        public AddHumanWindow(FamousHuman FamousHuman, bool IsAdd)
        {
            InitializeComponent();
           
            this.famousHuman = FamousHuman;
            this.isAdd = IsAdd;
           
            if (isAdd)
            {
                this.Title = "Добавление";
            }
            else
            {
                this.Title = "Редактирование";
                tbFirstName.Text = famousHuman.FirstName;
                tbSurname.Text = famousHuman.LastName;
                tbPatronymic.Text = famousHuman.Patronymic;
                dpBirthDate.SelectedDate = famousHuman.BirthDate;
                dpDeathDate.SelectedDate = famousHuman.DeathDate;
                tbDes.Text = famousHuman.Description;
                pathTB.Text = famousHuman.Image;
            }
        }

        private void addPathBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select a picture";
            ofd.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (ofd.ShowDialog() == true)
            {
                pathTB.Text = ofd.FileName;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var newHuman = new FamousHuman();

            if (!isAdd)
            {
                
                if (famousHuman.Id != null)
                {
                    newHuman.Id = famousHuman.Id;
                }
                
            }


            bool firstNameL = tbFirstName.Text.Length > 0 && tbFirstName.Text.Trim().Length != 0;
            bool lastNameL = tbSurname.Text.Length > 0 && tbSurname.Text.Trim().Length != 0;

         
            bool birthDateL = dpBirthDate.SelectedDate != null;
    

            bool desL = tbDes.Text.Length > 0 && tbDes.Text.Trim().Length != 0;
      

            if (!firstNameL)
            {
                MessageBox.Show("Введите имя", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {

                newHuman.FirstName = tbFirstName.Text;
                
            }
            if (!lastNameL)
            {
                MessageBox.Show("Введите фамилию", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {

                newHuman.LastName = tbSurname.Text;

            }
            if (!birthDateL)
            {
                MessageBox.Show("Введите дату рождения", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {

                newHuman.BirthDate = dpBirthDate.SelectedDate;

            }
            if (!desL)
            {
                MessageBox.Show("Введите описание", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                newHuman.Description = tbDes.Text;
            }
            newHuman.Patronymic = tbPatronymic.Text;
            newHuman.DeathDate = dpDeathDate.SelectedDate;
            newHuman.Image = pathTB.Text;

            if (newHuman.LastName != null && newHuman.FirstName != null &&  newHuman.Description != null && dpBirthDate.SelectedDate != null)
            {
                using (FamousPeopleDBEntities db = new FamousPeopleDBEntities())
                {
                    db.FamousHuman.AddOrUpdate(newHuman);
                    db.SaveChanges();
                }
                this.Close();
            }

        }
    }
}
