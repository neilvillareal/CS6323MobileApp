using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MyFirstMobileApp
{
    public enum Operations
    {
        Add,
        Subtract,
        Multiply,
        Division,
        Percentage
    }

    public partial class CalculatorPage : ContentPage
    {
        private double leftValue, rightValue;

        Operations? Operand;

        public CalculatorPage()
        {
            InitializeComponent();

            Operand = null;

            txtDisplay.Text = string.Empty;

        }

        void Button_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (txtDisplay.Text.Contains(".") && button.Text.Equals("."))
                return;

            txtDisplay.Text += button.Text;
        }

        void BtnDel_Clicked(object sender, EventArgs e)
        {
            if (txtDisplay.Text.Length > 0)
                txtDisplay.Text = txtDisplay.Text.Substring(0, txtDisplay.Text.Length - 1);
        }

        void BtnOperation_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (txtDisplay.Text.Length < 1)
                return;

            if (button.Text.Equals("X"))
            {
                leftValue = double.Parse(txtDisplay.Text);
                Operand = Operations.Multiply;
                txtDisplay.Text = string.Empty;
            }
            else if (button.Text.Equals("/"))
            {
                leftValue = double.Parse(txtDisplay.Text);
                Operand = Operations.Division;
                txtDisplay.Text = string.Empty;
            }
            else if (button.Text.Equals("+"))
            {
                leftValue = double.Parse(txtDisplay.Text);
                Operand = Operations.Add;
                txtDisplay.Text = string.Empty;
            }
            else if (button.Text.Equals("-"))
            {
                leftValue = double.Parse(txtDisplay.Text);
                Operand = Operations.Subtract;
                txtDisplay.Text = string.Empty;
            }
            else if (button.Text.Equals("%"))
            {
                txtDisplay.Text = (double.Parse(txtDisplay.Text) * 0.01).ToString();
            }
            else if (button.Text.Equals("="))
            {

                rightValue = double.Parse(txtDisplay.Text);
                switch (Operand)
                {
                    case Operations.Add:
                        txtDisplay.Text = (leftValue + rightValue).ToString();
                        break;
                    case Operations.Subtract:
                        txtDisplay.Text = (leftValue - rightValue).ToString();
                        break;
                    case Operations.Multiply:
                        txtDisplay.Text = (leftValue * rightValue).ToString();
                        break;
                    case Operations.Division:
                        txtDisplay.Text = (leftValue / rightValue).ToString();
                        break;
                    default:
                        txtDisplay.Text = "Error";
                        break;
                }
            }
        }

        private void BtnAC_Clicked(object sender, EventArgs e)
        {
            leftValue = 0;
            rightValue = 0;
            Operand = null;
            txtDisplay.Text = string.Empty;
        }


        //    78 * ((234 / 21) - 15)
    }
}
