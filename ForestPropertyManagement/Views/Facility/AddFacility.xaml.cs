using Models;
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

namespace ForestPropertyManagement.Views.Facility
{
    /// <summary>
    /// Interaction logic for AddOffering.xaml
    /// </summary>
    public partial class AddFacility : Window
    {
        List<Models.Product> ProductList;
        List<District> DistrictList;
        List<BusinessStructure> BusinessStructureList;
        public List<string> DistrictNames { get { return DistrictList.Select(item => item.FormerName).ToList(); } }
        public List<string> BusinessStructureNames { get { return BusinessStructureList.Select(item => item.FormerName).ToList(); } }
        public List<string> ProductNames { get { return ProductList.Select(item => item.FormerName).ToList(); } }

        internal List<Models.Product> fProductList;
        public Models.Facility NewItem { get; set; }

        int CategoryId;
        public AddFacility(int categoryId)
        {
            InitializeComponent();
            CategoryId = categoryId;

            DistrictList = new Provider().Select<District>($"SELECT * FROM {typeof(District).Name}");
            BusinessStructureList = new Provider().Select<BusinessStructure>($"SELECT * FROM {typeof(BusinessStructure).Name}");
            ProductList = new Provider().Select<Models.Product>($"SELECT * FROM {typeof(Models.Product).Name} WHERE CategoryId = {CategoryId}");

            fProductList = new List<Models.Product>();
            NewItem = new Models.Facility();
            DistrictComboBox.ItemsSource = DistrictNames;
            BusinessStructureComboBox.ItemsSource = BusinessStructureNames;

        }

        public Models.Facility GetNewItem()
        {
            return NewItem;
        }
        public List<int> ProductIds()
        {
            return fProductList.Select(item => item.Id).ToList();
        }
        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {

            ComboBox productComboBox = new ComboBox
            {
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(10),
                ItemsSource = ProductNames
            };

            productComboBox.SelectionChanged += ProductComboBox_SelectionChanged;

            productStackPanel.Children.Add(productComboBox);
          
            productPopup.IsOpen = true;
        }
        private void ProductComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            if (comboBox.SelectedIndex > 0)
            {
                fProductList.Add(ProductList[comboBox.SelectedIndex]);
            }
        }

        private void AddFacility_Click(object sender, RoutedEventArgs e)
        {
            // them dieu kien addfacility
            NewItem.FormerName = InputFormerName.Text;
            NewItem.EstablishedDate = EstablishedDatePicker.SelectedDate ?? DateTime.Now;
            NewItem.DissolvedDate = NewItem.EstablishedDate.AddYears(50);
            NewItem.DistrictId = DistrictList[DistrictComboBox.SelectedIndex].Id;
            NewItem.BusinessStructureId = BusinessStructureList[BusinessStructureComboBox.SelectedIndex].Id;

            this.Close();
        }


    }
}
