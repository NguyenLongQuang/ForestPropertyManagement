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

namespace ForestPropertyManagement.Views.Category
{
    /// <summary>
    /// Interaction logic for All.xaml
    /// </summary>
    public partial class All : UserControl
    {
        public All()
        {
            InitializeComponent();
        }
        internal ViewModels.CategoryViewModel Model => ((ViewModels.CategoryViewModel)DataContext);
        private void FacilityStats_Click(object sender, RoutedEventArgs e)
        {
            if (Model.SelectedIndex >= 0)
                MVC.Execute("Facility/GroupByCategoryIndex", Model.List[Model.SelectedIndex].Id);
        }
        private void FacilityMap_Click(object sender, RoutedEventArgs e)
        {
            if (Model.SelectedIndex >= 0)
                MVC.Execute("FacilityAddress/SelectedGroupIndex", Model.List[Model.SelectedIndex].Id);
        }
        private void FacilityReportMonth_Click(object sender, RoutedEventArgs e)
        {
            if (Model.SelectedIndex >= 0)
                MVC.Execute("Facility/RecentDateIndex", Model.List[Model.SelectedIndex].Id, new DateTime(2023, 12, 1), new DateTime(2023, 12, 31));
        }
        private void FacilityReportQuarter_Click(object sender, RoutedEventArgs e)
        {
            if (Model.SelectedIndex >= 0)
                MVC.Execute("Facility/RecentDateIndex", Model.List[Model.SelectedIndex].Id, new DateTime(2023, 10, 1), new DateTime(2023, 12, 31));
        }
        private void FacilityReportYear_Click(object sender, RoutedEventArgs e)
        {
            if (Model.SelectedIndex >= 0)
                MVC.Execute("Facility/RecentDateIndex", Model.List[Model.SelectedIndex].Id, new DateTime(2023, 1, 1), new DateTime(2023, 12, 31));
        }
        private void Selected(object sender, RoutedEventArgs e)
        {
            if (Model != null)
            {
                Model.SelectedIndex = ListView.SelectedIndex;
            }
        }
    }

    public class Index : BaseView<All>
    {
        protected override void RenderCore()
        {
            var model = new ViewModels.CategoryViewModel();
            Action bind = () => {
                MainContent.DataContext = null;
                MainContent.DataContext = model;
            };

            model.OnChanged += (s, e) => bind();
            bind();
        }
    }
}
