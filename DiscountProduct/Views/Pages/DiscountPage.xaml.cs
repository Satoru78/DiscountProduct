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
        public List<DiscountDate> DiscountDates { get; set; }
        public DiscountDate DiscountDate { get; set; }
        public DiscountPage(DiscountDate discountDate)
        {
            InitializeComponent();
            DiscountDate = discountDate;
            this.DataContext = this;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DiscountDates = Data.pde.DiscountDate.ToList();
            DiscountDateProduct.ItemsSource = DiscountDates;
        }
    }
}
