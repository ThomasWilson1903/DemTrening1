using DemTrening1.DataBase;
using DemTrening1.DataBase.Entity;
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
using System.Windows.Shapes;

namespace DemTrening1.Windows
{
    /// <summary>
    /// Interaction logic for wdAddIngradient.xaml
    /// </summary>
    public partial class wdAddIngradient : Window
    {
        List<Cone> cone;//создаем лист для дальнейшего использования 
        List<Worker> worker;//создаем лист для дальнейшего использования 

        public wdAddIngradient()
        {
            InitializeComponent();
            cone = EfModels.init().Cones.ToList();


            worker = EfModels.init().Workers.ToList();//заполняем лист данными из бд


            cbWorker.ItemsSource = worker;
        }

        private void clAddSave(object sender, RoutedEventArgs e)
        {



            /*EfModels.init().Add(new IngredientsHasCone
            {
                Date = DateOnly.FromDateTime(DateTime.Now),
                Time = TimeOnly.FromDateTime(DateTime.Now),
                Worker =
            });*/
        }
    }
}
