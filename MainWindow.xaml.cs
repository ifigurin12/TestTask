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

namespace TestTask
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const char v = '|';
        const char s = '-';
        private Button[,] gameField;
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
                bool isWin = false; 
                gameField = GenerateGrid(gameFieldGrid, int.Parse(sizeInit.Text));
            }
            else
            {
                MessageBox.Show("Введите корректный размер игрового поля.");
            }

        }


        private Button[,] GenerateGrid(UniformGrid Grid, int size)
        {
            fieldSize = size;
            Button[,] result = new Button[size, size];

            Grid.Rows = size;
            Grid.Columns = size;
            Grid.Children.Clear();

            int tempValue; 

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    result[i, j] = new Button();
                    tempValue = randomValues(); 
                    if(tempValue == 0)
                    {
                        result[i, j].Content = "|";
                    }
                    else { result[i, j].Content = "-"; }
                    result[i, j].Click += btnFieldClick; 
                    Grid.Children.Add(result[i, j]);
                }
            }
            return result;
        }

        private void btnFieldClick(object sender, RoutedEventArgs e)
        {
            Button ourButton = sender as Button;
            string equalsSymbol = (string)ourButton.Content; 
            if (equalsSymbol == "|")
            {
                ourButton.Content = "-"; 
            }
            else
            {
                ourButton.Content = "|";
            }
        }

        private void btnCheckWin(object sender, RoutedEventArgs e)
        {

            bool isWin;
            string equalsSymbhol;
            isWin = true;
            foreach (Button item in gameField)
            {
                equalsSymbhol = (string)item.Content;
                if (equalsSymbhol == "|")
                {
                    isWin = false;
                    break;
                }
            }
            if (isWin)
            {
                MessageBox.Show("вы выйграли!");
            }
            else
            {
                isWin = true;
                foreach (Button item in gameField)
                {
                    equalsSymbhol = (string)item.Content;
                    if (equalsSymbhol == "-")
                    {
                        isWin = false;
                        break;
                    }
                }
                if (isWin)
                {
                    MessageBox.Show("вы выйграли!");
                }
                else
                {
                    MessageBox.Show("Проебали!");
                }
            }
            
           

        }

        private int randomValues()
        {
            Random rand = new Random(DateTime.Now.Second + DateTime.Now.Millisecond);
            return rand.Next(0, 2);
        }
    }
    
}
