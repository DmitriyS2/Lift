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

namespace Lift
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private static Random rand = new();

        int etazh, diff, number, index;
        int[] lift = new int[4];
        List<TextBox> Lifty = new List<TextBox>();

        private void RandomEtazh(object sender, RoutedEventArgs e)
        {
            etazh = rand.Next(1, 41);
            tbEtazh.Text = etazh.ToString();
        }

        private void ChangeText(object sender, DependencyPropertyChangedEventArgs e)
        {
          
        }

        private void Vkl(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < lift.Length; i++)
            {
                lift[i] = rand.Next(1, 41);
            }
            tbLift1.Text = lift[0].ToString();
            Lifty.Add(tbLift1);
            tbLift2.Text = lift[1].ToString();
            Lifty.Add(tbLift2);
            tbLift3.Text = lift[2].ToString();
            Lifty.Add(tbLift3);
            tbLift4.Text = lift[3].ToString();
            Lifty.Add(tbLift4);
        }

        private void SwitchCase(int index)
        {
            switch (index)
            {
                case 0:
                    tbLift1.Clear();
                    tbLift1.Text = lift[index].ToString();
                    break;
                case 1:
                    tbLift2.Clear();
                    tbLift2.Text = lift[index].ToString();
                    break;
                case 2:
                    tbLift3.Clear();
                    tbLift3.Text = lift[index].ToString();
                    break;
                case 3:
                    tbLift4.Clear();
                    tbLift4.Text = lift[index].ToString();
                    break;
            }
        }
        private void Go(object sender, RoutedEventArgs e)
        {
            diff = 40;
            index = 0;
            if (tbEtazh.Text == "")
            {
                MessageBox.Show("Введите этаж!");
                return;
            }
            if (Convert.ToInt32(tbEtazh.Text) < 1 || Convert.ToInt32(tbEtazh.Text) > 40)
            {
                MessageBox.Show("Неверный этаж!");
                return;
            }
            number = Convert.ToInt32(tbEtazh.Text);
            for (int i = 0; i < lift.Length; i++)
            {
                if (Math.Abs(lift[i] - number) < diff)
                {
                    diff = Math.Abs(lift[i] - number);
                    index = i;
                }
            }
            MessageBox.Show("К Вам едет лифт №"+(index+1).ToString());
            if (number > lift[index])
            {
                for (int i = lift[index]; i < number + 1; i++)
                {
                    lift[index] = i;
                    Lifty[index].Text = lift[index].ToString();                    
                    //System.Threading.Thread.Sleep(100);
                    //MessageBox.Show(Lifty[index].Text);
                    SwitchCase(index);
                }
            }
            if (number < lift[index])
            {
                for (int i = lift[index]; i > number - 1; i--)
                {
                    lift[index] = i;
                    Lifty[index].Text = lift[index].ToString();                    
                    //System.Threading.Thread.Sleep(100);
                    //MessageBox.Show(Lifty[index].Text);
                    SwitchCase(index);
                }

            }
        }
    }
}
