using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using PrimeadesCL;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace PrimeadesWF
{
    public partial class FormMain : Form
    {
        static List<int> PrimeArray = new List<int>();
        public FormMain()
        {
            InitializeComponent();
            //Привязка кнопки Enter к копке "Вычислить"
            this.AcceptButton = buttonCalculate;
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            var sw = new Stopwatch();
            sw.Start();
            int N = 0;
            int segment = 10;
            //Проверка некорректного ввода
            try
            {
                N = int.Parse(textBoxInputN.Text);
                if (N < 1) throw new Exception();
            }
            catch (Exception)
            {
                MessageBox.Show("Некорректный ввод количества чисел.","Ошибка!");
                return;
            }

            if (N > 100000000)
            {
                MessageBox.Show("Введено слишком большое количество чисел.", "Ошибка!");
                return;
            }

            try
            {
                segment = int.Parse(textBoxSegmentInput.Text);
                if (segment <= 1) throw new Exception();
            }
            catch (Exception)
            {
                MessageBox.Show("Некорректный ввод отрезка чисел.", "Ошибка!");
                return;
            }

            if (N < segment)
            {
                MessageBox.Show("Некорректный ввод. Отрезок чисел не может быть больше количества чисел.","Ошибка!");
                return;
            }

            if (segment > 1000000)
            {
                MessageBox.Show("Введена слишком большая длина отрезка.", "Ошибка!");
                return;
            }


            //Создаем массив с целыми числами от 1 до N
            List<int> NewArray = ArrayHandler.ArrayFiller(N);

            //Применяем алгоритм решета Эратосфена
            //для поиска простых чисел
            NewArray = Primes.doEratosfen(NewArray);

            BuildDiagram(ArrayHandler.CountPrimesOnSegment(NewArray,segment));

            //Находим максимальные десятки
            //с минимальным и максимальным количеством простых чисел
            List<int> Answer = ArrayHandler.SplitPrimes(NewArray,segment);
            //Answer[десяток с минимумом, минимум, десяток с максимумом,максимум]

            //Заполняем текстовые поля на форме
            textBoxMinSeg.Text=MakeAnswerMinMaxSeg(Answer,NewArray,true,segment);
            textBoxMaxSeg.Text=MakeAnswerMinMaxSeg(Answer, NewArray,false,segment);

            Answer = ArrayHandler.Segment(NewArray);
            textBoxMaxSegment.Text= MakeAnswerSegment(Answer);

            sw.Stop();
            textBoxT.Text = Convert.ToString(sw.Elapsed.TotalSeconds);
        }

        private void BuildDiagram(List<int> list)
        {
            this.chartPrimes.Series.Clear();
            this.chartPrimes.Series.Add("Primes Diagram");
            this.chartPrimes.Series["Primes Diagram"].ChartType = SeriesChartType.Column;

            for (int i = 0; i < list.Count; i++)
            {
                this.chartPrimes.Series["Primes Diagram"].Points.Add(list[i]);
            }
            Axis ax = new Axis();
            ax.Title = "Номер отрезка";
            chartPrimes.ChartAreas[0].AxisX = ax;
            Axis ay = new Axis();
            ay.Title = "Количество простых чисел";
            chartPrimes.ChartAreas[0].AxisY = ay;

        }

        /// <summary>
        /// Функция формирования строки-ответа с отрезком максимальной длины без простых чисел
        /// </summary>
        /// <param name="answer">Информация об отрезке максимальной длины без простых чисел</param>
        /// <returns>Строка - отрезок чисел</returns>
        private string MakeAnswerSegment(List<int> answer)
        {
            string tmp = "Отрезок чисел:" + Environment.NewLine;
            if (answer[1] - answer[0] > 10)
                tmp += answer[0] + "..." + answer[1];
            else
                for (int i = answer[0]; i <= answer[1]; i++)
                {
                    tmp += Convert.ToString(i) + " ";
                }
            
            tmp += Environment.NewLine + "Длина отрезка:"+Convert.ToString(answer[2]);

            return tmp;
        }

        /// <summary>
        /// Функция формирования строки-ответа с сегментом чисел и списком простых чисел в нём
        /// </summary>
        /// <param name="TaskAns">Информация о максимальных десятках с минимальным и 
        /// максимальным количеством простых чисел</param>
        /// <param name="newArray">Массив целых чисел, в котором непростые числа заменены нулями</param>
        /// <param name="minmax">флаг, определяющий десяток с минимальным или максимальным количеством чисел</param>
        /// <returns>Строка - ответ с сегментом чисел и списком простых чисел в нём</returns>
        private string MakeAnswerMinMaxSeg(List<int> TaskAns, List<int> newArray, bool minmax, int segment)
        {
            string Answer = "";
            //Восстановление десятка
            Answer += RecoverSegment(minmax ? TaskAns[0] : TaskAns[2], segment)+ Environment.NewLine;
            Answer += "Простые числа:"+ Environment.NewLine;
            //восстановление списка простых чисел из необходимого десятка
            string tmpPrimes = PrintPrimes(minmax ? TaskAns[0] : TaskAns[2], newArray, segment);
            //если чисел в десятке нет, вносится сообщение об этом
            if (tmpPrimes == "") Answer += "Простых чисел нет";
            else Answer += tmpPrimes;

            return Answer;
        }

        /// <summary>
        /// Функция восстановления списка простых чисел из указанного сегмента
        /// </summary>
        /// <param name="StartDecade">Номер сегмента</param>
        /// <param name="Primes">Массив простых чисел</param>
        /// <returns>Строка - Простые числа из определённого сегмента через пробел</returns>
        private string PrintPrimes(int StartDecade, List<int> Primes, int segment)
        {
            string PrimesDecade = "";
            
            for (int i = StartDecade*segment; i < StartDecade*segment+segment; i++)
                if (Primes[i] != 0) PrimesDecade += Convert.ToString(Primes[i]) + " ";

            return PrimesDecade;
        }

        /// <summary>
        /// Функция восстановления списка целых чисел из указанного сегмента 
        /// </summary>
        /// <param name="StartSegment">Номер сегмента</param>
        /// <returns>Строка - сегмент чисел</returns>
        private string RecoverSegment(int StartSegment,int segment)
        {
            string Segment = "";
            if(segment > 10)
                Segment = Convert.ToString(StartSegment * segment + 1)+"..."+Convert.ToString(StartSegment * segment + segment);
            else
                for (int i = StartSegment* segment+1; i <= StartSegment* segment + segment; i++)
                    Segment += Convert.ToString(i) + " ";

            return Segment;
        }

        private void buttonHelp_Click(object sender, EventArgs e)
        {
                MessageBox.Show("ПРОГРАММА ПОИСКА ОТРЕЗКА С МАКСИМАЛЬНЫМ И МИНИМАЛЬНЫМ КОЛИЧЕСТВОМ ПРОСТЫХ ЧИСЕЛ\n" +
        "Программа осуществляет поиск отрезка максимальной длины с максимальным и минимальным количеством чисел в ряде целых чисел от 1 до N" +
        " с помощью алгоритма \"Решето Эратосфена\"\n" +
        "А также определяет длину максимального отрезка без простых чисел, строит гистограмму, " +
        "показывающую распределение простых чисел по числовой прямой." +
        " По горизонтали откладывается номер сегмента, а по вертикали - количество простых чисел на сегменте \n" +
        "В окне \"Введите количество чисел \" введите натуральное количество чисел.\n","Справка");
        }

        private void buttonDividers_Click(object sender, EventArgs e)
        {
            FormDividers f = new FormDividers();
            f.Show();
        }

    }
    
}
