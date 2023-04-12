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
using ООО_Посуда.Models;

namespace ООО_Посуда.UserControls
{
    /// <summary>
    /// Логика взаимодействия для ProductUserControl.xaml
    /// </summary>
    public partial class ProductUserControl : UserControl
    {
        public Product Product;
        public ProductUserControl(Product product)
        {
            InitializeComponent();

            Product = product;

            LoadLabels();
            LoadImage();
        }

        /// <summary>
        /// Функция для заполнения Label
        /// </summary>
        private void LoadLabels()
        {
            ProductNameLabel.Content = $"Наименование: {Product.ProductName}";
            ProductDescLabel.Content = $"Описание: {Product.ProductDescription}";
            ProductManufacturerLabel.Content = $"Производитель: {Product.ProductManufacturer.ManufacturerName}";
            ProductCostLabel.Content = $"Наименование: {Product.ProductCost}";
            QuantityInStockLabel.Content = $"На складе: {Product.ProductQuantityInStock}";

            if (Product.ProductQuantityInStock <= 0)
            {
                Background = new SolidColorBrush(Colors.Gray);
            }
        }

        private void LoadImage()
        {
            if (Product.ProductPhoto != null && Product.ProductPhoto.Length > 0)
            {
                ProductImage.Source = new BitmapImage(new Uri(System.IO.Path.Combine(Environment.CurrentDirectory,
                    "Images/", Product.ProductPhoto), UriKind.Absolute));
            }
            else
            {
                ProductImage.Source = new BitmapImage(new Uri(System.IO.Path.Combine(Environment.CurrentDirectory,
                    "Images/picture.png"), UriKind.Absolute));
            }
        }
    }
}
