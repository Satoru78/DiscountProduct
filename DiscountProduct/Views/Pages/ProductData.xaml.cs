using DiscountProduct.Context;
using DiscountProduct.Model;
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

namespace DiscountProduct.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProductData.xaml
    /// </summary>
    public partial class ProductData : Page
    {
        public List<Product> Products { get; set;}
        public Product Product { get; set; }
        public Unit Unit { get; set; }
        public DiscountDate DiscountDate { get; set; }
        public CategoryProduct CategoryProduct { get; set; }
        public ProductData(Product product)
        {
            InitializeComponent();
            Product = product;
            this.DataContext = this;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Products = Data.pde.Product.ToList();
            ProductsData.ItemsSource = Products;
        }


        private void DeletyeProduct_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = (Product)ProductsData.SelectedItem;
            if (selectedItem != null)
            {
                Data.pde.Product.Remove(selectedItem);
                Data.pde.SaveChanges();
                Page_Loaded(null, null);
            }
            MessageBox.Show("Данные удалены", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ActionProductPage(new Model.Product()));
        }

        private void EditProduct_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = (Product)ProductsData.SelectedItem;
            if (selectedItem != null)
            {
                NavigationService.Navigate(new ActionProductPage(selectedItem));
            }
        }

        private void DicsPage_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DiscountPage(new Model.DiscountDate()));
        }
    }
}
