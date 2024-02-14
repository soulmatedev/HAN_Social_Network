using Database;
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

        public Database.Account GetSelected()
        {
            return MainWindow.connection.Accounts.FirstOrDefault(x => x.username == tbUsername.Text);
        }
        private void OnClickEdit(object sender, RoutedEventArgs e)
        {
            var selectedAccount = GetSelected();
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
            foreach (var post in posts)
            {
                Post.Add(post);
            }
            binding.Source = Post;
            lvAccounts.SetBinding(ListView.ItemsSourceProperty, binding);
        }

        private void lvAccounts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
