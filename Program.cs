using System;
using System.Collections.Generic;
using System.Text;

namespace PI
{
    public class gruz
    {
        public readonly string type;
        public readonly string track;
        public readonly int cost;
        public readonly DateTime data_otgr;
        public readonly DateTime data_vozvr;
        public readonly int koef_skidki;
        public readonly int koef_pov;
        public gruz(string type, string track, int cost, DateTime data_otgr, DateTime data_vozvr, int koef_skidki, int koef_pov)
        {
            this.type = type;
            this.track = track;
            this.cost = cost;
            this.data_otgr = data_otgr;
            this.data_vozvr = data_vozvr;
            this.koef_skidki = koef_skidki;
            this.koef_pov = koef_pov;
        }
    }
    class gruz_list
    {
        private gruz[] mas;
        public gruz_list(int n)
        {
            Console.Write("кол-во заказов: ");
            n=Convert.ToInt32(Console.ReadLine());
            mas = new gruz[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write("Вид груза: ");
                string type = Convert.ToString(Console.ReadLine());
                Console.Write("Тип перевозки: ");
                string track = Convert.ToString(Console.ReadLine());
                Console.Write("Базовая стоимость перевозки: ");
                int cost = Convert.ToInt32(Console.ReadLine());
                Console.Write("Дата отгрузки: ");
                DateTime data_otgr = Convert.ToDateTime(Console.ReadLine());
                Console.Write("Дата доставки заказа: ");
                DateTime data_vozvr = Convert.ToDateTime(Console.ReadLine());
                Console.Write("Коэфициент зимней скидки: ");
                int koef_skidki = Convert.ToInt32(Console.ReadLine());
                Console.Write("Коэффициент повышения стоимости перевозки летом: ");
                int koef_pov = Convert.ToInt32(Console.ReadLine());
                mas[i] = new gruz(type, track, cost, data_otgr, data_vozvr, koef_skidki, koef_pov);
            }
        }
        public void output()
        {
            Console.WriteLine("Вид груза Тип перевозки  Cтоим п-и Дата отгр. Дата дост. Коэф.з.с. Коэф.п.с.");
            for (int i = 0; i < 1; i++)
            {
                Console.WriteLine(mas[i].type + "           " + mas[i].track + "         " + mas[i].cost + "      " + mas[i].data_otgr.ToString("dd.MM.yyyy") + "  " + mas[i].data_vozvr.ToString("dd.MM.yyyy") + "  " + mas[i].koef_skidki + "        " + mas[i].koef_pov);
            }
        }
        public void task1()
        {
            int k = 0;
            for (int i = 0; i < 1; i++)
                if (mas[i].data_otgr.Year == DateTime.Now.Year - 1 && mas[i].data_otgr.Month < 7)
                {
                    Console.WriteLine("Тип перевозки, который использовался в первом полугодии прошлого года: " + mas[i].type);
                    k++;
                }
            if (k == 0) { Console.WriteLine("Ни один из типов перевозки не использовался в первом полугодии прошлого года"); }
        }
        public double task3()
        {
            double sum = 0;
            for (int i = 0; i < 1; i++)
            {
                int s = mas[i].cost;
                if ((mas[i].data_otgr.Month == 1) || (mas[i].data_otgr.Month == 2) || (mas[i].data_otgr.Month == 12))
                {
                    s = s - (mas[i].koef_skidki);
                }
                if ((mas[i].data_otgr.Month == 6) || (mas[i].data_otgr.Month == 7) || (mas[i].data_otgr.Month == 8))
                {
                    s = s + (mas[i].koef_pov);
                }
                sum += s;
            }
            return sum;
        }
        public double task2()
        {
            Console.WriteLine("Введите вид груза: ");
            string str = Convert.ToString(Console.ReadLine());
            int sum = 0;
            int k = 0;
            double sr_sum = 0;
            for (int i = 0; i < 1; i++)
            {
                if (mas[i].type == str)
                {
                    int s = mas[i].cost;
                    if ((mas[i].data_otgr.Month == 1) || (mas[i].data_otgr.Month == 2) || (mas[i].data_otgr.Month == 12))
                    {
                        s = s - mas[i].koef_skidki;
                    }
                    if ((mas[i].data_otgr.Month == 6) || (mas[i].data_otgr.Month == 7) || (mas[i].data_otgr.Month == 8))
                    {
                        s = s + mas[i].koef_pov;
                    }
                    sum += s;
                    k++;
                }
            }
            if (k == 0) { Console.WriteLine("Груз такого вида не найден"); }
            else
            {
                sr_sum = sum / k;
            }
            return sr_sum;
        }
        class Program
        {
            static void Main(string[] args)
            {
                gruz_list gl = new gruz_list(5);
                gl.output();
                gl.task1();
                Console.WriteLine("Cредняя стоимости перевозки груза данного вида: ");
                Console.WriteLine(gl.task2().ToString());
                Console.WriteLine("Общяя стоимость перевозок: ");
                Console.WriteLine(gl.task3().ToString());
                Console.ReadKey();
            }
        }
    }
}