﻿using System;
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
using System.Windows.Shapes;

namespace ForestPropertyManagement.Views.Product
{
    /// <summary>
    /// Interaction logic for Detail.xaml
    /// </summary>
    public partial class Detail : Window
    {
        public Detail(string formerName, string info)
        {
            InitializeComponent();
            FormerNameText.Text = formerName;
            InfoText.Text = info;
        }
    }
}
