//Bao Tran
//Homework 4

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

namespace ZipCodeBox
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
        string aStr; 
        private void uxZipCode_TextChanged(object sender, TextChangedEventArgs e)
        {
            aStr = uxZipCode.Text;
            bool result = false;

            switch (aStr.Length)
            {
                case 5: //Check if a string an integer.
                    if (int.TryParse(aStr, out int aNumber))
                        result = true;
                    break;

                case 6:
                    result = true;
                    //Check every other even character is NOT a letter
                    for (int i = 0; i < aStr.Length; i = i + 2)
                    {
                        if (!(char.IsLetter(aStr[i])))
                        {
                            result = false;
                            break;
                        }                       
                    }
                    //Check every other even character is NOT a digit
                    for (int i = 1; i < aStr.Length; i = i + 2)
                    {
                        if (!(char.IsDigit(aStr[i])))
                        {
                            result = false;
                            break;
                        }
                    }                    
                    break;

                case 10:
                    string[] subStr = aStr.Split('-');
                    if (subStr[0].Length==5 && int.TryParse(subStr[0], out int aNumber2) && int.TryParse(subStr[0], out int aNumber3))
                        result = true;
                    break;

                default:
                    result = false;
                    break;            
            }

            uxSubmit.IsEnabled = result;
        }

        private void uxSubmit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Zip Code:  " + uxZipCode.Text);
        }
    }
}
