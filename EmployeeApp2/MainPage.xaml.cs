﻿using EmployeeApp2.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace EmployeeApp2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        // tietomalli ComboBox-elementtiin (kuvat)
        public EmployeeImageViewModel ImageViewModel { get; set; }
        // tietomalli GridView-elementtiin (Employee-objektit)
        public EmployeeViewModel ViewModel { get; set; }

        // konstruktori
        public MainPage()
        {
            this.InitializeComponent();
            // ComboBox-kontrollin view model
            this.ImageViewModel = new EmployeeImageViewModel();
            // GridView:n view model
            this.ViewModel = new EmployeeViewModel();
        }

        // New-Button control is clicked
        private void NewEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            // add a new employee
            EmployeeImage employeeImage = (EmployeeImage)ImageComboBox.SelectedValue;
            ViewModel.AddEmployee(FirstnameTextBox.Text, LastnameTextBox.Text, JobTitleTextBox.Text, employeeImage);

            // empty UI fields
            FirstnameTextBox.Text = "";
            LastnameTextBox.Text = "";
            JobTitleTextBox.Text = "";
            ImageComboBox.SelectedIndex = -1;

            // select firstname
            FirstnameTextBox.Focus(FocusState.Programmatic);
        }

        private void DeleteEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            // get selected employee from GridView
            Employee employee = (Employee) EmployeesGridView.SelectedItem;
            // delete employee from view model
            ViewModel.RemoveEmployee(employee);
        }

        private void ModifyEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            // get selected employee from gridview
            Employee employee = (Employee) EmployeesGridView.SelectedItem;
            // modify employee properties
            employee.Firstname = FirstnameTextBox.Text;
            employee.Lastname = LastnameTextBox.Text;
            employee.JobTitle = JobTitleTextBox.Text;
            // get selected image from ComboBox
            EmployeeImage employeeImage = (EmployeeImage) ImageComboBox.SelectedItem;
            // modify employee image
            employee.Image = employeeImage;
        }

        private void EmployeesGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            // selected employee from GridView
            Employee employee = (Employee) e.ClickedItem;
            // update "Form" fields UI
            FirstnameTextBox.Text = employee.Firstname;
            LastnameTextBox.Text = employee.Lastname;
            JobTitleTextBox.Text = employee.JobTitle;
            ImageComboBox.SelectedValue = employee.Image;
        }
    }
}
