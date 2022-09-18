using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TestTask.Classes;

namespace TestTask
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CustomButton[,] gameFieldCustom; 
        private int fieldSize;
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnClearAndGenerate(object sender, RoutedEventArgs e)
        {
            fieldSize = int.Parse(sizeInit.Text);
            if (fieldSize > 1)
            {
                gameFieldCustom = (CustomButton[,])GenerateGrid(gameFieldGrid, int.Parse(sizeInit.Text));
            }
            else
            {
                MessageBox.Show("Введите корректный размер игрового поля.");
            }

        }


        private CustomButton[,] GenerateGrid(UniformGrid Grid, int size)
        {
            fieldSize = size;
            CustomButton[,] result = new CustomButton[size, size];
            Grid.Rows = size;
            Grid.Columns = size;
            Grid.Children.Clear();
            Random rand = new Random(DateTime.Now.Second * DateTime.Now.Millisecond);

            int clickValue = rand.Next(3, 8);

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    result[i, j] = new CustomButton(i, j);
                    result[i, j].Content = "|";
                    result[i, j].Background = Brushes.Blue;
                    result[i, j].Click += btnFieldClick; 
                    Grid.Children.Add(result[i, j]);
                }
            }
            int x, y, countArr;
            int[] xCoordsArr, yCoordsArr; 
            while (clickValue > 0)
            {
                x = rand.Next(0, size);
                y = rand.Next(0, size); 
                result[x, y].changesValuesButton(result);
                clickValue--;
            }
            

            return result;
        }


        private void btnFieldClick(object sender, RoutedEventArgs e)
        {
            CustomButton ourButton = sender as CustomButton;
            ourButton.changesValuesButton(gameFieldCustom);
        }

        private void btnCheckWin(object sender, RoutedEventArgs e)
        {
            if(safeIsOpen(gameFieldCustom, "|") == true || safeIsOpen(gameFieldCustom, "-") == true)
            {
                MessageBox.Show("Вы выйграли!");
                gameFieldGrid.Children.Clear();
            }
            else
            {
                MessageBox.Show("Вы проиграли!");
            }
        }
        public bool safeIsOpen(CustomButton[,] buttonArrays, string charEquals)
        {
            bool isWin;
            string equalsSymbhol;
            isWin = true;
            foreach (Button item in buttonArrays)
            {
                equalsSymbhol = (string)item.Content;
                if (equalsSymbhol == charEquals)
                {
                    isWin = false;
                    break;
                }
            }
            return isWin;
        }

    }
    
}
