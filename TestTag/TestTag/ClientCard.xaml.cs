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
    /// Логика взаимодействия для ClientCard.xaml
    /// </summary>
    public partial class ClientCard : UserControl
    {
        public string IdString { get; set; }

        public ClientCard(string IdString, Tag[] tags)
        {
            this.IdString = IdString;
            
            InitializeComponent();
            this.DataContext = this;

            foreach (Tag tag in tags)
            {
                TagCard tagCard = new TagCard(tag.name, tag.color);
                TagsStack.Children.Add(tagCard);
            }
        }
    }
}
