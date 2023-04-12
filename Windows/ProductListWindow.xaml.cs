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
using ООО_Посуда.Models;
using ООО_Посуда.UserControls;

namespace ООО_Посуда.Windows
{
    /// <summary>
    /// Логика взаимодействия для ProductListWindow.xaml
    /// </summary>
    public partial class ProductListWindow : Window
    {
        public static tradeContext DbContext;
        User User;

        public ProductListWindow(User user)
        {
            InitializeComponent();

            DbContext = new tradeContext();
            User = user;

            LoadComboBoxes();
            UpdateListView();
        }

        private void LoadComboBoxes()
        {
            FilterComboBox.Items.Add("Все");
            
            foreach (string manufacture in DbContext.Manufactures.Select(m => m.ManufacturerName).ToList())
            {
                FilterComboBox.Items.Add(manufacture);
            }

            SotringComboBox.Items.Add("Без сортировки");
            SotringComboBox.Items.Add("Стоимость ↑");
            SotringComboBox.Items.Add("Стоимость ↓");

            FilterComboBox.SelectedIndex = 0;
            SotringComboBox.SelectedIndex = 0;
        }

        /// <summary>
        /// Метод для обновления ListView
        /// </summary>
        private void UpdateListView()
        {
            ProductListView.Items.Clear();
            
            List<Product> displayProduct = new List<Product>();
            displayProduct = DbContext.Products.ToList();

            // Поиск
            if (!string.IsNullOrWhiteSpace(SearchTextBox.Text))
            {
                displayProduct = displayProduct.Where(p =>
                p.ProductName.ToLower().Contains(SearchTextBox.Text.ToLower()) ||
                p.ProductDescription.ToLower().Contains(SearchTextBox.Text.ToLower()) ||
                p.ProductManufacturer.ManufacturerName.ToLower().Contains(SearchTextBox.Text.ToLower()) ||
                p.ProductCost.ToString().ToLower().Contains(SearchTextBox.Text.ToLower())).ToList();
            }

            // Фильтрация
            switch (FilterComboBox.SelectedIndex)
            {
                default:
                    displayProduct = displayProduct.Where(p =>
                    p.ProductManufacturer.IdManufactures == FilterComboBox.SelectedIndex).ToList();
                    break;

            }

            // Сортировка
            switch (SotringComboBox.SelectedIndex)
            {
                case 1:
                    displayProduct = displayProduct.OrderBy(p =>
                    p.ProductCost).ToList();
                    break;
                case 2:
                    displayProduct = displayProduct.OrderByDescending(p =>
                    p.ProductCost).ToList();
                    break;
            }

            foreach(Product product in displayProduct)
            {
                ProductListView.Items.Add(new ProductUserControl(product)
                {
                    Width = GetOptimizedWidth()
                });
            }

            ProductsCountLabel.Content = $"Выведено {ProductListView.Items.Count} из {DbContext.Products.Count()}";

            if (ProductListView.Items.Count == 0)
            {
                EmptyProductsLabel.Visibility = Visibility.Visible;
            }
            else
            {
                EmptyProductsLabel.Visibility = Visibility.Collapsed;
            }
        }

        private double GetOptimizedWidth()
        {
            if (WindowState == WindowState.Maximized)
            {
                return RenderSize.Width - 55;
            }
            else
            {
                return Width - 55;
            }
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateListView();
        }

        private void FilterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateListView();
        }

        private void SotringComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateListView();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Событие вызываемое при изменении окна
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            UpdateListView();
        }
    }
}
