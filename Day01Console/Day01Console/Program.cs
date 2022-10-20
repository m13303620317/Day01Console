using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day01Console
{
    internal class Program
    {
        /**
         * 动物类
         */
        public abstract class Animal 
        {
            /** 动物的名字 */
            public string Name { get; set; }
            /** 动物“吃”的行为 */
            public abstract void Eat();
        }

        /** 
         * 兔子类，实现动物类中的抽象方法
         */
        public class Rabbit : Animal
        {
            /** 兔子吃胡萝卜 */
            public override void Eat()
            {
                Console.WriteLine("Rabbits eat carrots.");
            }
        }

        /** 
         * 狮子类，实现动物类中的抽象方法
         */
        public sealed class Lion : Animal
        {
            /** 狮子吃肉 */
            public override void Eat()
            {
                Console.WriteLine("Lions eat meat.");
            }
        }

        /** 
         * 鱼类，实现动物类中的抽象方法
         */
        public class Fish : Animal
        {
            /** 鱼吃虫 */
            public sealed override void Eat()
            {
                Console.WriteLine("Fishes eat warms.");
            }
        }

        /** 图形类 */
        public class Shape 
        {
            // 只读量PI和其它变量
            protected readonly double PI = Math.PI;
            protected double _x, _y, _z;
            public Shape()
            {
            }

            public Shape(double x)
            {
                _x = x;
            }

            public Shape(double x, double y)
            {
                _x = x;
                _y = y;
            }

            public Shape(double x, double y, double z)
            {
                _x = x;
                _y = y;
                _z = z;
            }

            /**
             * 计算图形的面积
             */
            public virtual double Area()
            {
                return _x * _y;
            }
        }

        /** 正方形类 */
        public class Square : Shape
        {
            public Square(double side) : base(side) 
            {
            }

            /**
             * 计算正方形面积
             */
            public override double Area()
            {
                return _x * _x;
            }
        }

        /** 矩形类 */
        public class Rectangle : Shape
        {
            public Rectangle(double length, double width) : base(length, width)
            {
            }

            /**
             * 计算矩形的面积
             */
            public override double Area()
            {
                return _x * _y;
            }
        }

        /** 圆类 */
        public class Circle : Shape
        {
            public Circle(double radius) : base(radius)
            {
            }

            /**
             * 计算圆的面积
             */
            public override double Area()
            {
                return PI * _x * _x;
            }
        }

        /** 枚举季节 */
        enum Season
        {
            None,
            Spring,
            Summer,
            Autumn,
            Winter
        }

        /** 枚举星期 */
        [Flags]
        public enum Days
        {
            None = 0b_0000_0000,  // 0
            Monday = 0b_0000_0001,  // 1
            Tuesday = 0b_0000_0010,  // 2
            Wednesday = 0b_0000_0100,  // 4
            Thursday = 0b_0000_1000,  // 8
            Friday = 0b_0001_0000,  // 16
            Saturday = 0b_0010_0000,  // 32
            Sunday = 0b_0100_0000,  // 64
            Weekend = Saturday | Sunday
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");

            // 抽象类
            Animal rabbit = new Rabbit();
            rabbit.Name = "Write";
            rabbit.Eat();
            Console.WriteLine("Rabbit's name: {0}", rabbit.Name);

            // 密封类
            Animal lion = new Lion();
            lion.Name = "Simba";
            lion.Eat();
            Console.WriteLine("Lion's name: {0}", lion.Name);

            // 取消成员的虚效果
            Animal fish = new Fish();
            fish.Name = "Frisk";
            fish.Eat();
            Console.WriteLine("Fish's name: {0}", fish.Name);

            // virtual关键字的使用
            // 正方形面积
            double side = 5;
            Shape square = new Square(side);
            Console.WriteLine("Area of Square = {0:F2}", square.Area());

            // 矩形面积
            double length = 7;
            double width = 4;
            Shape rectangle = new Rectangle(length, width);
            Console.WriteLine("Area of Rectangle = {0:F2}", rectangle.Area());

            // 圆形面积
            double radius = 5;
            Shape circle = new Circle(radius);
            Console.WriteLine("Area of Circle = {0:F2}", circle.Area());

            // Declare a single-dimensional array of 5 integers.
            int[] array1 = new int[5];
            foreach (int i in array1) {
                Console.Write("{0} ", i);
            }
            Console.WriteLine();

            // Declare and set array element values.
            int[] array2 = new int[] { 1, 3, 5, 7, 9 };
            foreach (int i in array2)
            {
                Console.Write("{0} ", i);
            }
            Console.WriteLine();

            // Alternative syntax.
            int[] array3 = { 1, 2, 3, 4, 5, 6 };
            foreach (int i in array3)
            {
                Console.Write("{0} ", i);
            }
            Console.WriteLine();

            // Declare a two dimensional array.
            int[,] multiDimensionalArray1 = new int[2, 3];
            int count = 0;
            foreach (int i in multiDimensionalArray1)
            {
                Console.Write("{0} ", i);
                count++;
                if (count % multiDimensionalArray1.GetLength(1) == 0)
                {
                    Console.WriteLine();
                }
            }

            // Declare and set array element values.
            int[,] multiDimensionalArray2 = { { 1, 2, 3 }, { 4, 5, 6 } };
            foreach (int i in multiDimensionalArray2)
            {
                Console.Write("{0} ", i);
                count++;
                if (count % multiDimensionalArray2.GetLength(1) == 0)
                {
                    Console.WriteLine();
                }
            }

            // Declare a jagged array.
            int[][] jaggedArray = new int[6][];

            // Set the values of the first array in the jagged array structure.
            // 异常的使用
            jaggedArray[0] = new int[4] { 1, 2, 3, 4 };
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                try
                {
                    for (int j = 0; j < jaggedArray[i].Length; j++)
                    {
                        Console.Write("{0} ", jaggedArray[i][j]);
                    }
                } 
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }
                Console.WriteLine();
            }

            // 枚举季节
            Season a = Season.Autumn;
            Console.WriteLine($"Integral value of {a} is {(int)a}");  // output: Integral value of Autumn is 3

            var b = (Season)1;
            Console.WriteLine(b);  // output: Spring

            var c = (Season)5;
            Console.WriteLine(c);  // output: 5

            // 枚举星期
            Days meetingDays = Days.Monday | Days.Wednesday | Days.Friday;
            Console.WriteLine(meetingDays);
            // Output:
            // Monday, Wednesday, Friday

            Days workingFromHomeDays = Days.Thursday | Days.Friday;
            Console.WriteLine($"Join a meeting by phone on {meetingDays & workingFromHomeDays}");
            // Output:
            // Join a meeting by phone on Friday

            bool isMeetingOnTuesday = (meetingDays & Days.Tuesday) == Days.Tuesday;
            Console.WriteLine($"Is there a meeting on Tuesday: {isMeetingOnTuesday}");
            // Output:
            // Is there a meeting on Tuesday: False

            var f = (Days)37;
            Console.WriteLine(f);
            // Output:
            // Monday, Wednesday, Saturday

            // Wait for the user to respond before closing.
            Console.Write("Press any key to close the Console app...");
            Console.ReadKey();
        }
    }
}
