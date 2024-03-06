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
    /// <summary>
    /// Логика взаимодействия для GeneralPostFrame.xaml
    /// </summary>
    public partial class GeneralPostFrame : UserControl
    {
        private Database.Post post { get; set; }
        public GeneralPostFrame(Database.Post post)
        {
            InitializeComponent();
            tbTitle.Text = post.title;
            tbDescription.Text = post.description;
            this.post = post;
        }

        private void OnClickEditPost(object sender, RoutedEventArgs e)
        {

        }
    }
}
