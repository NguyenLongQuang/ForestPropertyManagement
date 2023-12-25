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
            {
                ViewModels.FacilityViewModel.SelectedGroupId = Model.List[Model.SelectedIndex].Id;
                MVC.Execute("Facility/SelectedGroupIndex");
            }
        }
        private void FacilityMap_Click(object sender, RoutedEventArgs e)
        {
            if (Model.SelectedIndex >= 0)
            {
                ViewModels.FacilityAddressViewModel.SelectedGroupId = Model.List[Model.SelectedIndex].Id;
                MVC.Execute("FacilityAddress/SelectedGroupIndex");
            }
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
