using System;
using System.Windows.Forms;


namespace Windows7Calculator
{
    public partial class Form1 : Form
    {
        private double memory;
        double firstNumber = 0;
        double secondNumber = 0;
        string operation = "";
        bool operationPressed = false;
        private const int MaxLength = 12;

        private ErrorProvider errorProvider;
        public Form1()
        {
            InitializeComponent();

            errorProvider = new ErrorProvider();
        }


        private void InitializeCalculatorLayout()
        {

            errorProvider.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
            errorProvider.BlinkRate = 1000;
        }

        private void CalculatorUI_Load(object sender, EventArgs e)
        {


            // Убрать обводку поля
            calculatorScreen.BorderStyle = BorderStyle.None;

            InitializeCalculatorLayout();

            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 1;
            comboBox3.SelectedIndex = 0;



        }

        private void eraseButton_Click(object sender, EventArgs e)
        {
            string t = calculatorScreen.Text;
            string res = "";
            for (int i = 0; i < t.Length - 1; i++)
            {
                res = res + t[i];
            }

            calculatorScreen.Text = res;
        }

        private void calculatorScreen_TextChanged(object sender, EventArgs e)
        {
            if (calculatorScreen.Text.Length > MaxLength)
            {
                calculatorScreen.Text = calculatorScreen.Text.Substring(0, MaxLength);
                calculatorScreen.SelectionStart = calculatorScreen.Text.Length;
                calculatorScreen.SelectionLength = 0;
            }
        }

        private void cButton_Click(object sender, EventArgs e)
        {
            calculatorScreen.Text = "0";
            firstNumber = 0;
            secondNumber = 0;
        }

        private void ceButton_Click(object sender, EventArgs e)
        {
            calculatorScreen.Text = "0";
        }

        private void equalsButton_Click(object sender, EventArgs e)
        {
            string[] parts = calculatorScreen.Text.Split(' ');
            secondNumber = double.Parse(parts[parts.Length - 1]);

            switch (operation)
            {
                case "+":
                    calculatorScreen.Text = (firstNumber + secondNumber).ToString();
                    break;
                case "-":
                    calculatorScreen.Text = (firstNumber - secondNumber).ToString();
                    break;
                case "*":
                    calculatorScreen.Text = (firstNumber * secondNumber).ToString();
                    break;
                case "/":
                    calculatorScreen.Text = (firstNumber / secondNumber).ToString();
                    if (secondNumber != 0)
                        calculatorScreen.Text = (firstNumber / secondNumber).ToString();
                    else
                        ShowError("Деление на ноль!");
                    calculatorScreen.Text = "ERROR!";
                    break;
                default:
                    break;
            }

            operationPressed = false;
        }

        private void numberButton_Click(object sender, EventArgs e)
        {
            if (calculatorScreen.Text == "0")
                calculatorScreen.Text = "";
            Button b = (Button)sender;
            calculatorScreen.Text = calculatorScreen.Text + b.Text;
        }

        private void operationButton_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;

            if (operationPressed == false)
                firstNumber = double.Parse(calculatorScreen.Text);

            calculatorScreen.Text = "";
            operationPressed = true;
            operation = b.Text;
        }



        private void PlusMinusButton_Click(object sender, EventArgs e)
        {
            string currentText = calculatorScreen.Text;
            double currentValue = double.Parse(currentText);

            if (currentValue > 0)
            {
                calculatorScreen.Text = "-" + currentText;
            }
            else if (currentValue < 0)
            {
                calculatorScreen.Text = currentText.Substring(1); // remove the negative sign
            }
        }

        private void fracButton_Click(object sender, EventArgs e)
        {
            double number = double.Parse(calculatorScreen.Text);
            number = 1 / number;
            calculatorScreen.Text = number.ToString();
        }

        private void sqrtButton_Click(object sender, EventArgs e)
        {
            double number = double.Parse(calculatorScreen.Text);
            if (number >= 0)
                calculatorScreen.Text = Math.Sqrt(number).ToString();
            else
                ShowError("Нельзя вычислить квадратный корень отрицательного числа!");
        }

        private void powerButton_Click(object sender, EventArgs e)
        {
            memory = 0;
            // Clear the memory 
        }

        private void percentButton_Click(object sender, EventArgs e)
        {
            double number = double.Parse(calculatorScreen.Text);
            number /= 100;
            calculatorScreen.Text = number.ToString();
        }

        private void MRButton_Click(object sender, EventArgs e)
        {
            calculatorScreen.Text = memory.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (calculatorScreen.Text != "")
            {
                memory += double.Parse(calculatorScreen.Text);

            }
        }

        private void MMinusButton_Click(object sender, EventArgs e)
        {
            if (calculatorScreen.Text != "")
            {
                memory -= double.Parse(calculatorScreen.Text);
            }
        }

        private void MSButton_Click_1(object sender, EventArgs e)
        {
            memory = double.Parse(calculatorScreen.Text);
        }



        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {

                this.Size = new System.Drawing.Size(700, 450);



            }
            if (!checkBox1.Checked)
            {
                this.Size = new System.Drawing.Size(300, 450);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void ShowError(string message)
        {
            errorProvider.SetError(calculatorScreen, message);
        }







        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e) {}

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e) {}

        private void ComboBox3_SelectedIndexChanged(object sender, EventArgs e) {}

        private double PerformConversion(double inputValue, string inputUnit, string outputUnit)
        {
            double result = 0;

            switch (inputUnit)
            {
                case "centimeters":
                    switch (outputUnit)
                    {
                        case "inches":
                            result = ConvertCmToInches(inputValue);
                            break;
                        case "centimeters":
                            result = inputValue;
                            break;
                    }
                    break;
                case "inches":
                    switch (outputUnit)
                    {
                        case "centimeters":
                            result = ConvertInchesToCm(inputValue);
                            break;
                        case "inches":
                            result = inputValue;
                            break;
                    }
                    break;
            }

            return result;
        }

        private double ConvertCmToInches(double cm)
        {
            return cm * 0.393701;
        }

        private double ConvertInchesToCm(double inches)
        {
            return inches * 2.54;
        }

        private void button1_Click_1(object sender, EventArgs e) //выполнение конвертизации
        {
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                System.Console.Write(textBox2.Text);
                ShowError("Пожалуйста, введите значение для конвертации.");
                return;
            }

            double inputValue = double.Parse(textBox2.Text);
            string inputUnit = comboBox2.SelectedItem.ToString();
            string outputUnit = comboBox3.SelectedItem.ToString();

            double result = PerformConversion(inputValue, inputUnit, outputUnit);

            if (result != 0)
            {
                textBox1.Text = result.ToString("F5");
            }
            else
            {
                ShowError("Ошибка при выполнении операции.");
            }
        }
    }

}