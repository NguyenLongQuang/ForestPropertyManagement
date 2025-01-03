﻿using ForestPropertyManagement.Views;
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
    public partial class RecentDate : UserControl
    {
        public RecentDate()
        {
            InitializeComponent();
        }
        internal ViewModels.FacilityViewModel Model => ((ViewModels.FacilityViewModel)DataContext);

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            if(Model != null)
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

    public class RecentDateIndex : BaseView<RecentDate>
    {
        int CategoryId;
        DateTime StartDate;
        DateTime StopDate;
        public RecentDateIndex(int Id, DateTime startDate, DateTime stopDate) { CategoryId = Id; StartDate = startDate; StopDate = stopDate; }
        protected override void RenderCore()
        {
            var model = new ViewModels.FacilityViewModel { GroupCategoryId = CategoryId <= 0 ? 1 : CategoryId, StartDate = StartDate, StopDate = StopDate };
            Action bind = () => {
                MainContent.DataContext = null;
                MainContent.DataContext = model;
            };

            model.OnChanged += (s, e) => bind();
            bind();
        }
    }


}
