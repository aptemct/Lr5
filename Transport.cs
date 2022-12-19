using System;
using System.Collections;
using System.IO;
using System.Threading.Tasks;

namespace ConsoleApp19
{
    public class Sides
    {
        public int[] sides;
        public Sides()
        {
            sides = new int[] { 0, 0, 0, 0 };
        }
        public int this[int index]
        {

            get { return sides[index]; }
            set
            {
                if (value <= 0) throw new ArgumentException();
                sides[index] = value;
                if ((sides[0] > 0) && (sides[1] > 0) && (sides[2] > 0) && (sides[3] > 0))
                {
                    if (sides[0] + sides[2] != sides[1] + sides[3])
                    {
                        throw new ArgumentException();
                    }

                }
            }
        }

    }
    public class Tetragon : IComparable<Tetragon>
    {
        public Sides Sides { get; set; }
        public int P { get; set; }

        public void Input()
        {
            var sides = new Sides();
            Console.WriteLine("Введите стороны 4-угольника");
            for (int i = 0; i < sides.sides.Length; i++)
            {
                sides[i] = int.Parse(Console.ReadLine());
                P += sides[i];
            }
            Sides = sides;
        }
        public int this[int index]
        {

            get { return Sides[index]; }
            set
            {
                if (value <= 0) throw new ArgumentException();
                Sides[index] = value;
                if (Sides[0] != 0 && Sides[1] != 0 && Sides[2] != 0)
                {
                    if ((Sides[0] > Sides[2] + Sides[1]) || (Sides[1] > Sides[2] + Sides[0]) || (Sides[2] > Sides[0] + Sides[1]))
                    {
                        throw new ArgumentException();
                    }
                }

            }
        }
        public int CompareTo(Tetragon? tetragon)
        {
            if (tetragon == null) throw new ArgumentNullException("Четырехугольник задан некорректно");

            return P.CompareTo(tetragon.P);
        }
        public void PrintTetragon(Tetragon tetragon)
        {
            Console.WriteLine("{0}", tetragon.P);
            Console.WriteLine();
        }
    }

    class TetragonArray
    {
        public int TetragonCount { get; set; }
        public Tetragon[] tetragons { get; set; }
        public TetragonArray(int tetragonCount)
        {
            TetragonCount = tetragonCount;
            tetragons = new Tetragon[TetragonCount];
        }
        public void TetragonInput()
        {
            for (int i = 0; i < TetragonCount; i++)
            {
                tetragons[i] = new Tetragon();
                tetragons[i].Input();
            }
        }
    }
    class Comparator : IComparer
    {
        public int Compare(object x, object y)
        {
            var tetragon1 = (Tetragon)x;
            var tetragon2 = (Tetragon)y;
            if ((x == null) || (y == null))
                throw new ArgumentException("Стороны заданы некорректно");
            return
                tetragon1.P.CompareTo(tetragon2.P);
        }
    }
    static class ArrayExtensions
    {
        public static void Swap(this Array array, int i, int j)
        {
            object obj = array.GetValue(i);
            array.SetValue(array.GetValue(j), i);
            array.SetValue(obj, j);
        }

        //public static void SortIComparable(this Array tetragons)
        //{
        //    for (int i = tetragons.Length - 1; i >= 0; i--)
        //    {
        //        for (int j = 1; j <= i; j++)
        //        {
        //            var element1 = (IComparable)tetragons.GetValue(i);
        //            var element0 = tetragons.GetValue(j - 1);
        //            if (element1.CompareTo(element0) < 0)
        //            {
        //                tetragons.Swap(j - 1, j);

        //            }
        //        }

        //    }
        //}
    }
    class Program
    {
        public static void SortIComparer(Tetragon[] tetragons, IComparer comparer)
        {
            for (int i = tetragons.Length - 1; i > 0; i--)
                for (int j = 1; j <= i; j++)
                {
                    object element1 = tetragons.GetValue(j - 1);
                    object element2 = tetragons.GetValue(j);
                    if (comparer.Compare(element1, element2) > 0)
                    {
                        object temporary = tetragons.GetValue(j);
                        tetragons.SetValue(tetragons.GetValue(j - 1), j);
                        tetragons.SetValue(temporary, j - 1);
                    }
                }
        }
        static void Main()
        {
            Tetragon tetragon = new Tetragon();
            Console.WriteLine("Введите кол-во четырехугольников: ");
            TetragonArray x = new TetragonArray(int.Parse(Console.ReadLine()));
            Console.WriteLine("Ввод сторон");
            x.TetragonInput();
            x.tetragons[1].Sides[3] = 150;
            Console.Write("4 сторона 2-го четырехугольника: ");
            Console.WriteLine(x.tetragons[1].Sides[3]);
            //Console.WriteLine(tetragons[]);
            //x.tetragons.SortIComparable();
            //Console.WriteLine("Отсортированные SortIComparable периметры:");
            //foreach (var tetr in x.tetragons)
            //{
            //    tetr.PrintTetragon(tetr);
            //}

            SortIComparer(x.tetragons, new Comparator());
            Console.WriteLine("Отсортированные SortIComparer периметры:");
            foreach (var tetr in x.tetragons)
            {
                tetr.PrintTetragon(tetr);
            }

        }
    }
}