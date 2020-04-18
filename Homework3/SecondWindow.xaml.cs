//Bao Tran
//Homework 3

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Linq;
using System.ComponentModel;

namespace HelloWorld
{
    /// <summary>
    /// Interaction logic for SecondWindow.xaml
    /// </summary>
    public partial class SecondWindow : Window
    {
        List<Models.User> users = new List<Models.User>();
        public SecondWindow()
        {
            InitializeComponent();        

            users.Add(new Models.User { Name = "Dave", Password = "1DavePwd" });
            users.Add(new Models.User { Name = "Steve", Password = "2StevePwd" });
            users.Add(new Models.User { Name = "Lisa", Password = "3LisaPwd" });

            uxList.ItemsSource = users;            
        }

        private void uxListColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader headerClicked = e.OriginalSource as GridViewColumnHeader;
            string header = headerClicked.Column.Header.ToString();

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(uxList.ItemsSource);
            view.SortDescriptions.Clear();

            if (header == "Name")
                view.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));
            else if (header=="Password")
                view.SortDescriptions.Add(new SortDescription("Password", ListSortDirection.Ascending));
        }

    }
}
