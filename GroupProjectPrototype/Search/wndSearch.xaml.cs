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
using GroupProjectPrototype.Main;

namespace GroupProjectPrototype.Search
{
    /// <summary>
    /// Interaction logic for wndSearch.xaml
    /// </summary>
    public partial class wndSearch : Window
    {
        /// <summary>
        /// the main window which created this search window, class name wndMain is not final
        /// </summary>
        public wndMain main;

        /// <summary>
        /// the default constructor for this class
        /// </summary>
        /// <param name="m">the main window which created this window</param>
        public wndSearch(wndMain m)
        {
            main = m;
            InitializeComponent();
        }
    }
}
