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

namespace Hom_5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            Out.Text = "";
        }
        class Aeroflot
        {
            string punkt;
            int number;
            int values;
            int pass;

            public Aeroflot(string naz, int reis, int tickets, int ost)
            {
                punkt = naz;
                number = reis;
                values = tickets;
                pass = ost;
            }
            public override string ToString()
            {
                    return $"Пункт назначения: {punkt}, Номер рейса: {number}, Кол-во пассажиров: {values}, Кол-во оставшихся мест: {pass}.\r\n";
            }
            public string naz { get => punkt; }
            public int reis { get => number; }
            public int tickets { get => values; }
            public int ost { get => pass; }
        }


        Aeroflot[] Air = new Aeroflot[10];
        int start = 5;

        private void Button(object sender, RoutedEventArgs e)
        {
            Out.Text = "";
            Air[0] = new Aeroflot("Москва", 65350, 400, 400);
            Air[1] = new Aeroflot("Владивосток", 79876, 300, 200);
            Air[2] = new Aeroflot("Казань", 46598, 500, 242);
            Air[3] = new Aeroflot("Ростов", 13255, 250, 146);
            Air[4] = new Aeroflot("Ставрополь", 94915, 100, 2);

            for (int i = 0; i < start; i++)
            {
                Out.Text = Out.Text + Air[i].ToString();
            }
        }
        private void Button_1(object sender, RoutedEventArgs e)
        {
            int number_for_check = 1;

            if (tb_1.Text == "" || tb_2.Text == "" || tb_3.Text == "" || tb_4.Text == "")
            {
                MessageBox.Show("Введите все данные!");
            }
            else if (int.TryParse(tb_2.Text, out number_for_check) == false || int.TryParse(tb_3.Text, out number_for_check) == false || int.TryParse(tb_4.Text, out number_for_check) == false)
            {
                MessageBox.Show("Введите численные значения или данные значения будут равны нулю!");
                tb_2.Text = "0";
                tb_3.Text = "0";
                tb_4.Text = "0";
            }
            else
            {
                Air[start] = new Aeroflot(tb_1.Text, int.Parse(tb_2.Text), int.Parse(tb_3.Text), int.Parse(tb_4.Text));
                start++;
                Out.Text = "";

                for (int i = 0; i < start; i++)
                {
                    Out.Text = Out.Text + Air[i].ToString();
                }
            }
        }
        public void Button_2(object sender, RoutedEventArgs e)
        {
            int check = 0;

            for (int i = 0; i < start; i++)
            {
                if ((Air[i].naz != tb_tick_1.Text || Air[i].reis != int.Parse(tb_tick_2.Text)))
                {
                    check ++;
                }
                if (check != start)
                {
                    if (Air[i].ost != 0 )
                    {
                        if (Air[i].naz == tb_tick_1.Text && Air[i].reis == int.Parse(tb_tick_2.Text))
                        {
                            Out.Text = "";
                            Air[i] = new Aeroflot(Air[i].naz, Air[i].reis, Air[i].tickets, Air[i].ost - 1);
                            for (int j = 0; j < start; j++)
                            { Out.Text = Out.Text + Air[j].ToString(); }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Мест нет!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                    }
                }
                else
                {
                    MessageBox.Show("Такого рейса нет!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }     
        }
    }
}
