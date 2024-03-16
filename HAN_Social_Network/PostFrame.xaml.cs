using Database;
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

namespace HAN_Social_Network
{
   
    public partial class PostFrame : UserControl
    {
        private Database.Post post { get; set; }
        public PostFrame(Post post)
        {
            InitializeComponent();
            tbTitle.Text = post.title;
            tbDescription.Text = post.description;
            this.post = post;
        }

        private void OnClickEditPost(object sender, RoutedEventArgs e)
        {
            PageController.EditPostPage.SetPost(this.post);
            MainWindow.pageContainer.Navigate(PageController.EditPostPage);

        }

        private void OnClickDeletePost(object sender, RoutedEventArgs e)
        {
            MainWindow.connection.Posts.Remove(this.post);
            MainWindow.connection.SaveChanges();
            PageController.ProfilePage.UpdatePage();
        }
    }
}
