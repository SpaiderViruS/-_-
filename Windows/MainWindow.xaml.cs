using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using ООО_Посуда.Models;
using ООО_Посуда.Windows;

namespace ООО_Посуда
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public tradeContext DbContext;
        private int _errorCount = 0;

        /// <summary>
        /// Конструктор MainWindow
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            DbContext = new tradeContext();
        }

        /// <summary>
        /// Событие вызываемое при нажатии на кнопку
        /// </summary>
        /// <param name="sender">Объект вызывавший событие</param>
        /// <param name="e">Аргументы события</param>
        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(LoginTextBox.Text) && !string.IsNullOrEmpty(Password_PasswordBox.Password))
            {
                User user = DbContext.Users.Where(u =>
                u.UserLogin == LoginTextBox.Text && u.UserPassword == Password_PasswordBox.Password).FirstOrDefault();

                if (user != null)
                {
                    MessageBox.Show($"Вы успешно авторизовались, " +
                        $"как {user.UserRoleNavigation.RoleName} {user.UserName} {user.UserSurname} {user.UserPatronymic}",
                        "Информация", MessageBoxButton.OK, MessageBoxImage.Information);

                    ProductListWindow productListWindow = new ProductListWindow(user);
                    productListWindow.Show();

                    Close();
                }
                else
                {
                    setError("Неверный логин/пароль");
                    _errorCount++;
                }
            }
            else
            {
                setError("Заполните поля");
            }
            if (_errorCount == 5)
            {
                _errorCount = 0;
                MessageBox.Show("Превышено число попыток входа, система заблокирована на 10 сек",
                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                Thread.Sleep(10 * 1000);
            }
        }

        private void setError(string err)
        {
            MessageBox.Show(err, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void EnterAsGuest_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Вы авторизовались, как гость", "Информация",
                MessageBoxButton.OK, MessageBoxImage.Information);

            ProductListWindow productListWindow = new ProductListWindow(null);
            productListWindow.Show();

            Close();
        }
    }
}
