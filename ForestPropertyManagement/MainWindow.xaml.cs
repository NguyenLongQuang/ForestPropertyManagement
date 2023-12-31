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

namespace ForestPropertyManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ContentView view = new ContentView();

            MVC.Register(this, result => {
                view = (ContentView)result.View;

                MainContent.Child = (UIElement)view.GetContent();
                if (view.Title != null)
                {
                    MainCaption.Content = view.Title;
                }
            });

            foreach (Button btn in MainActions.Children)
            {
                btn.Click += (s, e) =>
                {
                    MVC.Execute(btn.Name);

                    if (view.Title != null)
                    {
                        MainCaption.Content = view.Title;
                    }

                };
            }
        }

        //private void Group_Click(object sender, RoutedEventArgs e)
        //{

        //}
    }
}
