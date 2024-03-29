﻿using Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Principal;
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

namespace HAN_Social_Network
{
    public partial class ProfilePage : Page
    {
        public static ObservableCollection<Database.Account> Accounts { get; set; }
        public static ObservableCollection<Database.Post> Post { get; set; }
        private Database.Account Account { get; set; }
        private int idAccount;
        public ProfilePage(int id)
        {
            InitializeComponent();
            idAccount = id;
            UpdatePage();
        }

        public Database.Account GetSelectedAccount()
        {
            return MainWindow.connection.Accounts.FirstOrDefault(x => x.username == tbUsername.Text);
        }

        //public Database.Post GetSelectedPost()
        //{
        //    return lvAccounts. as Database.Post;
        //}

        private void OnClickEdit(object sender, RoutedEventArgs e)
        {
            var selectedAccount = GetSelectedAccount();
            PageController.UserEdit.SetAccount(selectedAccount);
            MainWindow.pageContainer.Navigate(PageController.UserEdit);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.pageContainer.Navigate(PageController.CreatePostPage);
        }

        public void UpdatePage()
        {
            Account = new Database.Account();
            Accounts = new ObservableCollection<Database.Account>();
            Post = new ObservableCollection<Database.Post>();

            Binding test = new Binding();
            Binding binding = new Binding();
            test.Source = Accounts;
            tbUsername.SetBinding(TextBox.TextProperty, test);
            tbFullName.SetBinding(TextBox.TextProperty, test);
            tbBirthday.SetBinding(TextBox.TextProperty, test);

            var account = MainWindow.connection.Accounts.FirstOrDefault(x => x.id == idAccount);
            tbUsername.Text = account.username;
            tbFullName.Text = account.fullname;
            tbBirthday.Text = account.birthday.ToShortDateString();

            var posts = MainWindow.connection.Posts.Where(x => x.accountID == idAccount);
            lvAccounts.Items.Clear();
            foreach (var post in posts)
            {
                PostFrame postFrame = new PostFrame(post);
                lvAccounts.Items.Add(postFrame);
            }
        }
       
        private void NavigateToNewsFeed(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(PageController.NewsFeed);
        }

        private void lvAccounts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
