﻿using System.Windows;
using BeautyStore.Pages;

namespace BeautyStore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new ShopPage());
        }

        private void AuthorizationButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AuthorizationPage());
        }
    }
}