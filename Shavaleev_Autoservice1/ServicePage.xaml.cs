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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Shavaleev_Autoservice1
{
    /// <summary>
    /// Логика взаимодействия для ServicePage.xaml
    /// </summary>
    public partial class ServicePage : Page
    {
        public void UpdateServices()
        {
            var currentServices = ShaveleevAutoserviceEntities.GetContext().Service.ToList();

            if (ComboType.SelectedIndex == 0)
            {
                currentServices = currentServices.Where(p => (Convert.ToInt32(p.Discount) >= 0 && Convert.ToInt32(p.Discount) <= 100)).ToList();
            }

            if (ComboType.SelectedIndex == 1)
            {
                currentServices = currentServices.Where(p => (Convert.ToInt32(p.Discount) >= 0 && Convert.ToInt32(p.Discount) <= 5)).ToList();
            }

            if (ComboType.SelectedIndex == 2)
            {
                currentServices = currentServices.Where(p => (Convert.ToInt32(p.Discount) >= 5 && Convert.ToInt32(p.Discount) <= 15)).ToList();
            }
            if (ComboType.SelectedIndex == 3)
            {
                currentServices = currentServices.Where(p => (Convert.ToInt32(p.Discount) >= 15 && Convert.ToInt32(p.Discount) <= 30)).ToList();
            }
            if (ComboType.SelectedIndex == 4)
            {
                currentServices = currentServices.Where(p => (Convert.ToInt32(p.Discount) >= 30 && Convert.ToInt32(p.Discount) <= 70)).ToList();
            }
            if (ComboType.SelectedIndex == 5)
            {
                currentServices = currentServices.Where(p => (Convert.ToInt32(p.Discount) >= 70 && Convert.ToInt32(p.Discount) <= 100)).ToList();
            }

            currentServices = currentServices.Where(p => p.Title.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();
            ServiceListView.ItemsSource = currentServices.ToList();

            if (RButtonDown.IsChecked.Value)
            {
                ServiceListView.ItemsSource = currentServices.OrderByDescending(p => p.Cost).ToList();
            }

            if (RButtonUp.IsChecked.Value)
            {
                ServiceListView.ItemsSource = currentServices.OrderBy(p => p.Cost).ToList();
            }
        }

        public ServicePage()
        {
            InitializeComponent();
            var currentServices = ShaveleevAutoserviceEntities.GetContext().Service.ToList();

            ServiceListView.ItemsSource = currentServices;
            ComboType.SelectedIndex = 0;
            UpdateServices();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditPage());
        }

        private void ComboType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateServices();

        }

        private void RButtonUp_Checked(object sender, RoutedEventArgs e)
        {
            UpdateServices();

        }

        private void RButtonDown_Checked(object sender, RoutedEventArgs e)
        {
            UpdateServices();

        }

        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateServices();

        }
    }
}