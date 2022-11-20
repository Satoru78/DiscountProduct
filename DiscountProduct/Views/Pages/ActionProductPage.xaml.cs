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
    /// Логика взаимодействия для ActionProductPage.xaml
    /// </summary>
    public partial class ActionProductPage : Page
    {
        public Product Product { get; set; }
        public List<CategoryProduct> CategoryProducts { get; set; }
        public List<Unit> Units { get; set; }
        public List<DiscountDate> DiscountDates { get; set; }
        public ActionProductPage(Product product)
        {
            InitializeComponent();
            Product = product;
            CategoryProducts = Data.pde.CategoryProduct.ToList();
            Units = Data.pde.Unit.ToList();
            DiscountDates = Data.pde.DiscountDate.ToList();
            this.DataContext = this;
        }

        private void BtnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Product.ID == 0)
                {
                    Data.pde.Product.Add(Product);
                }               
                Data.pde.SaveChanges();
                MessageBox.Show("Данные сохранены", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService.GoBack();
            }
            catch
            {
                MessageBox.Show("Произошла неизвестная ошибка , проверьте заполнены ли все поля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
