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

namespace ForestPropertyManagement.Views.Facility
{
    /// <summary>
    /// Interaction logic for All.xaml
    /// </summary>
    public partial class GroupByCategory : UserControl
    {
        public GroupByCategory()
        {
            
            InitializeComponent();
        }
        internal ViewModels.FacilityViewModel Model => ((ViewModels.FacilityViewModel)DataContext);

        private void Detail_Click(object sender, RoutedEventArgs e)
        {
            if (Model.SelectedIndex >= 0){
                string selectedFormerName = Model.List[Model.SelectedIndex].FormerName;
                string selectedInfo = $"Địa chỉ: {Model.List[Model.SelectedIndex].GetFullDetail[0].FormerName}\n" +
                    $"Hình thức hoạt động: {Model.List[Model.SelectedIndex].GetFullDetail[1].FormerName}\n";

                Detail detailView = new Detail(selectedFormerName, selectedInfo);
                detailView.Show();
            }
        }
        private void Return_Click(object sender, RoutedEventArgs e)
        {
            if (Model != null)
            {
                MVC.Execute("Category");
            }
        }
        private void ProductStats_Click(object sender, RoutedEventArgs e)
        {
            if (Model.SelectedIndex >= 0){
                MVC.Execute("Product/GroupByFacilityIndex", Model.List[Model.SelectedIndex].Id, Model.GroupCategoryId);
            }
        }
        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = SearchTextBox.Text.ToLower();
            var filteredItems = Model.List
                .Where(item => item.FormerName.ToLower().Contains(searchText))
                .ToList();

            ListView.ItemsSource = filteredItems;
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
        public GroupByCategoryIndex(int Id) { CategoryId = Id; }
        protected override void RenderCore()
        {
            var model = new ViewModels.FacilityViewModel { GroupCategoryId = CategoryId <= 0 ? 1 : CategoryId };
            Action bind = () => {
                MainContent.DataContext = null;
                MainContent.DataContext = model;
                MainContent.title.Content = new ViewModels.CategoryViewModel().List[CategoryId].FormerName;
            };

            model.OnChanged += (s, e) => bind();
            bind();
        }
    }


}
