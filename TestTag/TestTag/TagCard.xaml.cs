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

namespace TestTag
{
    /// <summary>
    /// Логика взаимодействия для TagCard.xaml
    /// </summary>
    public partial class TagCard : UserControl
    {
        public TagCard(string nameString, string colorString)
        {

            //SolidColorBrush brush = new SolidColorBrush();

            //Color color = (Color)ColorConverter.ConvertFromString(colorString);
            BrushConverter brushConverter = new BrushConverter();
            Brush brush = (Brush)brushConverter.ConvertFromString(colorString);
            //brush = new BrushConverter().ConvertFromString(colorString) as SolidColorBrush;

            InitializeComponent();
            this.DataContext = this;

            nameTextBox.Text = "gfh";
            nameTextBox.Background = brush;
        }
    }
}
