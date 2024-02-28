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
    public partial class EditPostPage : Page
    {
        public EditPostPage()
        {
            InitializeComponent();
        }

        public void SetPost(Database.Post post)
        {
            DataContext = post;
        }



        private void GoBack(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void OnSave(object sender, RoutedEventArgs e)
        {
            MainWindow.connection.SaveChanges();
            PageController.ProfilePage.UpdatePage();
            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
        }
        private void description_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            double contendHeight = textBox.DesiredSize.Height;
            double maxHeight = textBox.MaxHeight;
            if (contendHeight >= maxHeight)
            {
                textBox.Height = maxHeight;
            }
            else
            {
                textBox.Height = double.NaN;
            }
        }
    }
}
