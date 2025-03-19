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
    /// Логика взаимодействия для HumanWindow.xaml
    /// </summary>
    public partial class HumanWindow : Window
    {
        private FamousHuman famousHuman = new FamousHuman();
        private int? idRole = null;
        public HumanWindow(FamousHuman FamousHuman, int? IdRole)
        {
            InitializeComponent();

            this.famousHuman = FamousHuman;
            this.idRole = IdRole;

            if (idRole == null)
            {
                btnEdit.Visibility = Visibility.Collapsed;
                btnDel.Visibility = Visibility.Collapsed;
            }
            else
            {
                btnEdit.Visibility = Visibility.Visible;
                btnDel.Visibility = Visibility.Visible;
            }

            using (FamousPeopleDBEntities db = new FamousPeopleDBEntities())
            {
                try
                {
                    imgFlower.Source = new BitmapImage(new Uri(db.FamousHuman.FirstOrDefault(u => u.Id == famousHuman.Id).Image));
                    errorImgLabel.Visibility = Visibility.Collapsed;
                }
                catch
                {
                    imgFlower.Source = null;
                    errorImgLabel.Visibility = Visibility.Visible;
                }
                nameTB.Text = "ФИО:\n" + db.FamousHuman.FirstOrDefault(u => u.Id == famousHuman.Id).LastName +
                     " " + db.FamousHuman.FirstOrDefault(u => u.Id == famousHuman.Id).FirstName +
                     " " + db.FamousHuman.FirstOrDefault(u => u.Id == famousHuman.Id).Patronymic;

              
                if (db.FamousHuman.FirstOrDefault(u => u.Id == famousHuman.Id).DeathDate != null && db.FamousHuman.FirstOrDefault(u => u.Id == famousHuman.Id).BirthDate != null)
                {
                    dateTB.Text = "Даты: " + db.FamousHuman.FirstOrDefault(u => u.Id == famousHuman.Id).BirthDate.Value.ToShortDateString() +
                   " - " + db.FamousHuman.FirstOrDefault(u => u.Id == famousHuman.Id).DeathDate.Value.ToShortDateString();
                }
                else if(db.FamousHuman.FirstOrDefault(u => u.Id == famousHuman.Id).BirthDate != null)
                {
                    dateTB.Text = "Дата рождения: " + db.FamousHuman.FirstOrDefault(u => u.Id == famousHuman.Id).BirthDate.Value.ToShortDateString();
                }
               
                desTB.Text = "Описание:\n" + db.FamousHuman.FirstOrDefault(u => u.Id == famousHuman.Id).Description;
                
               
            }
        }

        // Удаление
        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            using (FamousPeopleDBEntities db = new FamousPeopleDBEntities())
            {
                if (MessageBox.Show("Вы уверены, что хотите удалить?", "Предупреждение", MessageBoxButton.YesNo, MessageBoxImage.Question) ==
                        MessageBoxResult.Yes)
                {
                   
                    var delHuman = db.FamousHuman.FirstOrDefault(u => u.Id == famousHuman.Id);
                    db.FamousHuman.Remove(delHuman);
                    db.SaveChanges();
                   
                    this.Close();
                }
            }
        }

        // Редактировать
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            AddHumanWindow addHumanWindow;
            addHumanWindow = new AddHumanWindow(famousHuman, false);          
            this.Close();
            addHumanWindow.ShowDialog();
        }
    }
}
