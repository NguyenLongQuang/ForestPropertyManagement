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

namespace ForestPropertyManagement.Views.FacilityAddress
{
    /// <summary>
    /// Interaction logic for All.xaml
    /// </summary>
    public partial class SelectedGroup : UserControl
    {
        public SelectedGroup()
        {
            InitializeComponent();
        }
        internal ViewModels.FacilityAddressViewModel Model => ((ViewModels.FacilityAddressViewModel)DataContext);

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            if (Model != null)
            {
                MVC.Execute("Category");
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

    public class SelectedGroupIndex : BaseView<SelectedGroup>
    {
        int CategoryId;
        public SelectedGroupIndex(int Id) { CategoryId = Id; }
        protected override void RenderCore()
        {
            var model = new ViewModels.FacilityAddressViewModel { SelectedGroupId = CategoryId <= 0 ? 1 : CategoryId };
            Action bind = () => {
                MainContent.DataContext = null;
                MainContent.DataContext = model;
            };

            model.OnChanged += (s, e) => bind();
            bind();
        }
    }
}
