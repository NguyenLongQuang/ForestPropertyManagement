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
    public partial class GroupByFacility : UserControl
    {
        public GroupByFacility()
        {
            InitializeComponent();
            //title.text
        }
        internal ViewModels.ProductViewModel Model => ((ViewModels.ProductViewModel)DataContext);
        private void Return_Click(object sender, RoutedEventArgs e)
        {
            if (Model != null)
            {
                MVC.Execute("Facility/GroupByCategoryIndex", Model.GroupCategoryId);
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

    public class GroupByFacilityIndex : BaseView<GroupByFacility>
    {
        int FacilityId;
        int CategoryId;
        public GroupByFacilityIndex(int facilityId,int categoryId) { FacilityId = facilityId; CategoryId = categoryId; }
        protected override void RenderCore()
        {
            var model = new ViewModels.ProductViewModel { GroupFacilityId = FacilityId <= 0 ? 1 : FacilityId, GroupCategoryId = CategoryId };
            Action bind = () => {
                MainContent.DataContext = null;
                MainContent.DataContext = model;
            };

            model.OnChanged += (s, e) => bind();
            bind();
        }
    }


}
