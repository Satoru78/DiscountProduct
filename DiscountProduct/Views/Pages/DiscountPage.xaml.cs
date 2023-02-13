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
using DiscountProduct.Context;
using DiscountProduct.Model;

namespace DiscountProduct.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для DiscountPage.xaml
    /// </summary>
    public partial class DiscountPage : Page
    {
        public Product SelectedProduct { get; set; }
        public DiscountPage(Product product)
        {
            InitializeComponent();
            SelectedProduct = product;
            this.DataContext = this;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DiscountDateProduct.ItemsSource = Data.pde.DiscountDate.Where(item => item.ID == SelectedProduct.IDDiscount).ToList();
           
        }

        private void BackBth_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
