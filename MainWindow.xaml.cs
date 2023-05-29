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
        public MainWindow()
        {
            InitializeComponent();
            select();
        }

        void select()
        {
            ingredients = EfModels.init().IngredientsHasCones.Include(p=>p.IngredientsIdingredientsNavigation).
                Include(p=>p.WorkerNavigation).Include(p=>p.ConesIdConesNavigation).ToList();

            dgMain.ItemsSource = ingredients;

        }

        private void clOpenAddWindowIngragient(object sender, RoutedEventArgs e)
        {
            new wdAddIngradient().ShowDialog();
            select();
        }

        private void tcSerch(object sender, TextChangedEventArgs e)
        {
            ingredients.Where(p => p.Date.ToString().Contains(tbSerch.Text));
            dgMain.ItemsSource = ingredients;
        }
    }
}
