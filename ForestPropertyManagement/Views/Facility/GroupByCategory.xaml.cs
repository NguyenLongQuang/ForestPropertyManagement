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
using System.Collections;
using Models;
using System.Security.Cryptography;

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
                string selectedFormerName = Model.Selected.FormerName;
                string selectedInfo = $"Địa chỉ: {Model.Selected.GetFullDetail()[0].FormerName}\n" +
                    $"Hình thức hoạt động: {Model.Selected.GetFullDetail()[1].FormerName}\n";

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
                MVC.Execute("Product/GroupByFacilityIndex", Model.Selected.Id, Model.GroupCategoryId);
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

        private void AddNewFacility_Click(object sender, RoutedEventArgs e)
        {
            if (Model != null)
            {          
                AddFacility addFacility = new AddFacility(Model.GroupCategoryId);
                addFacility.ShowDialog();

                if (addFacility.GetNewItem().IsValid())
                {
                    Model.AddIncrement(addFacility.GetNewItem());

                    int aId = new FacilityList().Find(item => item.FormerName == addFacility.GetNewItem().FormerName).Id;

                    var offer = new ViewModels.OfferingViewModel();
                    foreach (var p in addFacility.fProductList)
                    {
                        offer.Add( new Offering { AId = aId, BId = p.Id});
                    }
                }
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
            };

            model.OnChanged += (s, e) => bind();
            bind();
        }
    }


}
