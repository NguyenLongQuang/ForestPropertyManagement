using ForestPropertyManagement.Views;
using ForestPropertyManagement;
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
using Models;

namespace ForestPropertyManagement.Views.ProductReport
{
    /// <summary>
    /// Interaction logic for All.xaml
    /// </summary>
    public partial class GroupByProduct : UserControl
    {
        public GroupByProduct()
        {
            InitializeComponent();
            //title.text
        }
        internal ViewModels.ProductReportViewModel Model => ((ViewModels.ProductReportViewModel)DataContext);
        private void Return_Click(object sender, RoutedEventArgs e)
        {
            if (Model != null)
            {
                MVC.Execute("Product/GroupByCategoryIndex", 3);
            }
        }
        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = SearchTextBox.Text.ToLower();

            Model.filteredItems = Model.List
               .Where(item => item.RecordDateDDMMYY.ToLower().Contains(searchText))
               .ToList();

            ListView.ItemsSource = Model.filteredItems;
        }

        private void Selected(object sender, RoutedEventArgs e)
        {
            if (Model != null)
            {
                Model.SelectedIndex = ListView.SelectedIndex;
            }
        }
    }

    public class GroupByProductIndex : BaseView<GroupByProduct>
    {
        int ProductId;
        public GroupByProductIndex(int productId) { ProductId = productId; }
        protected override void RenderCore()
        {
            var model = new ViewModels.ProductReportViewModel { GroupProductId = ProductId };
            Action bind = () => {
                MainContent.DataContext = null;
                MainContent.DataContext = model;
            };

            model.OnChanged += (s, e) => bind();
            bind();
        }
    }


}
