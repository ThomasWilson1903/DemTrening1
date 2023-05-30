
using DemTrening1.DataBase;
using DemTrening1.DataBase.Entity;
using DemTrening1.Windows;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
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

namespace DemTrening1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IEnumerable<IngredientsHasCone> ingredients;
        List<Cone> cones = new List<Cone>();
        public MainWindow()
        {
            InitializeComponent();
            cones = EfModels.init().Cones.ToList();
            cbColab.ItemsSource = cones;
            cbColab.SelectedIndex = 0;
            select();
        }//Server=cfif31.ru;Port=3306;User ID=ISPr22-33_BirukovAA;Password=ISPr22-33_BirukovAA;Database=ISPr22-33_BirukovAA_DemTrening1;Character Set=utf8s

        void select()
        {
            ingredients = EfModels.init().IngredientsHasCones.Include(p => p.IngredientsIdingredientsNavigation).
                Include(p => p.WorkerNavigation).Include(p => p.ConesIdConesNavigation).ToList();
            
            
                ingredients = ingredients.Where(p => p.ConesIdCones == (cbColab.SelectedIndex + 1));
            

            dgMain.ItemsSource = ingredients;

        }

        private void clOpenAddWindowIngragient(object sender, RoutedEventArgs e)
        {
            new wdAddIngradient().ShowDialog();
            select();
        }

        private void tcSerch(object sender, TextChangedEventArgs e)
        {
            ingredients = ingredients.Where(p => p.IngredientsIdingredientsNavigation.Name.ToString().Contains(tbSerch.Text));
            dgMain.ItemsSource = ingredients;
        }

        private void scFilter(object sender, SelectionChangedEventArgs e)
        {
            select();
        }
    }
}
