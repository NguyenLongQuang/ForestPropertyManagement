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

namespace ForestPropertyManagement.Views.Product
{
    /// <summary>
    /// Interaction logic for All.xaml
    /// </summary>
    public partial class GroupByCategory : UserControl
    {
        public GroupByCategory()
        {
            InitializeComponent();
            //title.text
        }
        internal ViewModels.ProductViewModel Model => ((ViewModels.ProductViewModel)DataContext);
        private void Return_Click(object sender, RoutedEventArgs e)
        {
            if (Model != null)
            {
                MVC.Execute("Category");
            }
        }

        private void Detail_Click(object sender, RoutedEventArgs e)
        {
            if (Model.SelectedIndex >= 0)
            {
                string selectedFormerName = Model.Selected.FormerName;
                string selectedInfo = $"Danh mục sản phẩm: {Model.Selected.GetCategory().FormerName}\n" +
                    $"Thông tin chi tiết: {Model.Selected.Info}\n";

                Detail detailView = new Detail(selectedFormerName, selectedInfo);
                detailView.Show();
            }
        }
        private void Report_Click(object sender, RoutedEventArgs e)
        {
            if(Model.SelectedIndex >= 0)
            {
                MVC.Execute("ProductReport/GroupByProductIndex", Model.Selected.Id);
            }
        }
        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = SearchTextBox.Text.ToLower();

            Model.filteredItems = Model.List
                .Where(item => item.FormerName.ToLower().Contains(searchText))
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

    public class GroupByCategoryIndex : BaseView<GroupByCategory>
    {
        int CategoryId;
        public GroupByCategoryIndex(int categoryId) { CategoryId = categoryId; }
        protected override void RenderCore()
        {
            var model = new ViewModels.ProductViewModel { GroupCategoryId = CategoryId };
            Action bind = () => {
                MainContent.DataContext = null;
                MainContent.DataContext = model;

                MainContent.AnimalReport.IsEnabled = false;
                if (model.GroupCategoryId == 3)
                    MainContent.AnimalReport.IsEnabled = true;
            };

            model.OnChanged += (s, e) => bind();
            bind();
        }
    }


}
