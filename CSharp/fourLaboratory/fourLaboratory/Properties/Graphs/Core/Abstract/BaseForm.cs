using DoAnPaint.Graphs.Core.Interfaces;
using DoAnPaint.Graphs.Presenters;
using LiveCharts;
using LiveCharts.WinForms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DoAnPaint.Graphs.Core.Abstract
{
    public partial class BaseForm : Form, IView
    {
        public IPresenter _presenter;
        public List<IModel> _models;

        public double Step { get; set; }
        private const int PointsCount = 1000;

        private readonly double[] XValues = new double[PointsCount];
        private readonly double[] YValues = new double[PointsCount];
        public double Start { get; set; }
        public double End { get; set; }
        public bool IsAnimationEnabled => animationCheckBox.Checked;
        public CartesianChart CartesianChart => cartesianChart;
        public SeriesCollection ChartData
        {
            get => cartesianChart.Series;
            set
            {
                cartesianChart.Series.Clear();
                foreach (var series in value)
                {
                    cartesianChart.Series.Add(series);
                }
            }
        }

        /// <summary>
        /// В Visual Studio под капотом для отображения Form используется рефлексия, поэтому этот пустой конструктор нужен
        /// !!!НЕ ИСПОЛЬЗОВАТЬ ЕГО!!!!
        /// </summary>
        public BaseForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Пытался изначально написать BaseForm конструктор с List<IModel>, чтобы потом у дочерних классов вызывать родительский конструктор, передавая список. 
        /// Но проблема была в том, что не отображался экран. Было вот решено запихнуть в такой отдельный метод. 
        /// Каждый дочерний класс должен вызвать этот метод, передавая ему список моделей, в ином случае все поломается.
        /// К сожалению, его нельзя сделать абстрактным, так как класс должен иметь модификатор abstract, который в свою очередь не может быть вместе с partitial
        /// </summary>
        /// <param name="models"></param>
        public void InitializeModels(List<IModel> models)
        {
            _models = models;
            _presenter = new BasePresenter(this, _models);
            firstChartCheckBox.Text = _models[0].Name;
            secondChartCheckBox.Text = _models[1].Name;
            thirdChartCheckBox.Text = _models[2].Name;

        }

        /// <summary>
        /// Обработчик событий на вписывание значений в textBox, где написано "(ось Ox) А (от) ="
        /// </summary>
        protected void GraphStartTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidateGraphInput(graphStartTextBox, value => Start = value, "Введите корректное значение для начала графика.");
        }

        /// <summary>
        /// Обработчик событий на вписывание значений в textBox, где написано "(ось Ox) B (до) ="
        /// </summary>
        protected void GraphEndTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidateGraphInput(graphEndTextBox, value => End = value, "Введите корректное значение для конца графика.");
        }

        /// <summary>
        /// Обработчик событий на вписывание значений в textBox, где написано "h (шаг) = "
        /// </summary>
        protected void GraphStepTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidateGraphInput(graphStepTextBox, value => Step = value, "Введите корректное значение для шага графика.");
        }

        /// <summary>
        /// Обработчик событий на выбор у 1 comboBox
        /// </summary>
        protected void FirstChartCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ChartCheckBox_CheckedChanged(firstChartCheckBox, 0);
        }

        /// <summary>
        /// Обработчик событий на выбор у 2 comboBox
        /// </summary>
        protected void SecondChartCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ChartCheckBox_CheckedChanged(secondChartCheckBox, 1);
        }

        /// <summary>
        /// Обработчик событий на выбор у 3 comboBox
        /// Честно говоря, понимаю, что тут можно было пойти через рефлексию и вписывание функции в тегах, но у меня времени нет, чтобы это писать. 
        /// Изляшняя масштабируемость - тоже плохо, когда мало времени. 
        /// </summary>
        protected void ThirdChartCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ChartCheckBox_CheckedChanged(thirdChartCheckBox, 2);
        }

        /// <summary>
        /// Вспомогательный метод, который фиксиурет изменения в ComboBox и добавляет в Presenter необходимые функции для отображения и построения
        /// </summary>
        /// <param name="checkBox">checkBox, где пользователь выбрал галочку</param>
        /// <param name="modelIndex">Индекс, под которым находится нужный график</param>
        private void ChartCheckBox_CheckedChanged(CheckBox checkBox, int modelIndex)
        {
            if (
                    string.IsNullOrWhiteSpace(graphStartTextBox.Text) ||
                    string.IsNullOrWhiteSpace(graphEndTextBox.Text) ||
                    string.IsNullOrWhiteSpace(graphStepTextBox.Text)
                )
            {
                MessageBox.Show("Заполните поля перед тем, как выбирать функцию");
                checkBox.Checked = false;
            }

            else
            {
                if (checkBox.Checked)
                {
                    _presenter.SelectModel(_models[modelIndex]);
                }
                else
                {
                    _presenter.DeselectModel(_models[modelIndex]);
                }

                _presenter.Draw();
            }

        }

        /// <summary>
        /// Валидация ввода от пользователя
        /// </summary>
        /// <param name="textBox">textBox, в котором пользователь ввел значение</param>
        /// <param name="setValueAction">что происходит, когда пользователь ввел значение, здесь я сделал лямба выражение такое</param>
        /// <param name="errorMessage">ошибка, которая выводится в MessageBox</param>
        private void ValidateGraphInput(TextBox textBox, Action<double> setValueAction, string errorMessage)
        {
            if (double.TryParse(textBox.Text, out double value))
            {
                setValueAction(value);

                if (
                    !string.IsNullOrWhiteSpace(graphStartTextBox.Text) &&
                    !string.IsNullOrWhiteSpace(graphEndTextBox.Text) &&
                    !string.IsNullOrWhiteSpace(graphStepTextBox.Text)
                )

                {
                    _presenter.Draw();
                }
            }
            else
            {
                MessageBox.Show(errorMessage);
                textBox.Clear();
            }
        }

        private void graphStartTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void animationCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            GenerateData();
            PrintGraph();

        }

        private void GenerateData()
        {
            double dx = 2 * (10 - (-10)) / (PointsCount - 1);
            for (int i = 0; i < PointsCount; i++)
            {
                XValues[i] = -10 + i * dx;
                YValues[i] = Calculate(XValues[i]);
            }
        }

        public static double Calculate(double x)
        {
            return 1 / (2 * Math.Sqrt(2 * Math.PI)) * Math.Exp(-0.35 * Math.Pow(x, 2));
        }

        public void PrintGraph()
        {
            Console.WriteLine("График функции:");

            // Выводим оси координат
            Console.WriteLine("     |");
            Console.Write("   ---+");
            for (int i = 0; i < 20; i++) Console.Write("---");
            Console.WriteLine();

            // Выводим точки на графике
            for (int y = 0; y <= 10; y++)
            {
                Console.Write(y.ToString().PadLeft(3) + "| ");
                for (int x = 0; x < 20; x++)
                {
                    int index = (x * 200) / 19;
                    if (index >= PointsCount || YValues[index] > y) Console.Write("* ");
                    else Console.Write("  ");
                }
                Console.WriteLine();
            }

            // Выводим метки оси X
            Console.WriteLine("   ---+---+---+---+---+---+---+---+---+---+---");
            Console.WriteLine("    -0 -- -5 -- -10");
        }

        public void PrintGraphWithLines()
        {
            Console.WriteLine("График функции с линиями:");
            for (int i = 0; i < PointsCount; i++)
            {
                Console.Write($"|{XValues[i]:F2} | {YValues[i]:F6}|");
                if ((i + 1) % 50 == 0) Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
