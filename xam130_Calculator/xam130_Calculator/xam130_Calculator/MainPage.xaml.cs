using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace xam130_Calculator
{
    public partial class MainPage : ContentPage
    {
        private int currentState = 1;
        private string mathOperator, NumberDecimalSeparator;
        private double firstNumber, secondNumber;

        public MainPage()
        {
            InitializeComponent();
            NumberDecimalSeparator = System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            decimalPointButton.Text = NumberDecimalSeparator;
        }

        void OnSelectNumber(object sender, EventArgs e)
        {
            var keyText = (sender as Button).Text;
            if (keyText == NumberDecimalSeparator && resultText.Text.Contains(NumberDecimalSeparator)) return;
            if (resultText.Text == "0" || currentState == 2) resultText.Text = "";
            resultText.Text += keyText;
            currentState = 1;
        }

        void OnSelectOperator(object sender, EventArgs e)
        {
            firstNumber = Double.Parse(resultText.Text);
            mathOperator = (sender as Button).Text;
            currentState = 2;
            //resultText.Text = "0";
        }

        void OnClear(object sender, EventArgs e)
        {
            if ((sender as Button).Text == "CE")
            {
                resultText.Text = "0";
                currentState = 1;
            }
            else
            {
                if (resultText.Text.Length == 1) resultText.Text = "0";
                else resultText.Text = resultText.Text.Remove(resultText.Text.Length - 1);

            }
        }

        void OnCalculate(object sender, EventArgs e)
        {
            secondNumber = Double.Parse(resultText.Text);
            double result = 0;
            switch (mathOperator)
            {
                case "+":
                    result = firstNumber + secondNumber;
                    break;
                case "-":
                    result = firstNumber - secondNumber;
                    break;
                case "x":
                    result = firstNumber * secondNumber;
                    break;
                case "/":
                    result = firstNumber / secondNumber;
                    break;
                default:
                    break;
            }

            resultText.Text = result.ToString();
            currentState = 1;
        }
    }
}
