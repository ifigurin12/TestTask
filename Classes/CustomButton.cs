using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TestTask.Classes
{
    public class CustomButton : System.Windows.Controls.Button
    {
        public int xCoords, yCoords;

        public CustomButton(int xCoords, int yCoords)
        {
            this.xCoords = xCoords;
            this.yCoords = yCoords;
        }
        public void changesValuesButton(CustomButton[,] buttonArrays)
        {
            string charOfButton;
            for (int i = 0; i < buttonArrays.GetLength(0); i++)
            {
                charOfButton = (string)buttonArrays[i, yCoords].Content;
                if (charOfButton == "|")
                {
                    buttonArrays[i, yCoords].Content = "-";
                    buttonArrays[i, yCoords].Background = Brushes.Green;
                }
                else
                {
                    buttonArrays[i, yCoords].Content = "|";
                    buttonArrays[i, yCoords].Background = Brushes.Blue;
                }
                charOfButton = (string)buttonArrays[xCoords, i].Content;
                if (charOfButton == "|")
                {
                    buttonArrays[xCoords, i].Content = "-";
                    buttonArrays[xCoords, i].Background = Brushes.Green;
                }
                else
                {
                    buttonArrays[xCoords, i].Content = "|";
                    buttonArrays[xCoords, i].Background = Brushes.Blue;
                }
            }
            charOfButton = (string)buttonArrays[xCoords, yCoords].Content;
            if (charOfButton == "|")
            {
                buttonArrays[xCoords, yCoords].Content = "-";
                buttonArrays[xCoords, yCoords].Background = Brushes.Green;
            }
            else { 
                buttonArrays[xCoords, yCoords].Content = "|";
                buttonArrays[xCoords, yCoords].Background = Brushes.Blue;
            }
        }
        
    } 
}
