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
    /// Логика взаимодействия для PostFrame.xaml
    /// </summary>
    public partial class PostFrame : UserControl
    {
        public PostFrame(string title, string descripton)
        {
            InitializeComponent();
            tbTitle.Text = title;
            tbDescription.Text = descripton;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
