namespace ClassWork5_Polimorfizm_operators
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*int a = 2, b = 4;
            A ad = new A(3, 2.0f);
            Console.WriteLine(ad + 2.4f);*/
            Point a = new Point();
            Point b = new Point();
            a.X = 10;
            a.Y = 10;
            b.X = 10;
            b.Y = 10;
            if (a && b) // Раз два операнда, то на каждый операнд по одному амперсанту, поэтому мы прегружаем operator &
            {

            }
            Rectangle rectangle = new Rectangle(5, 10);
            Square square = new Square { Length = 7 };
            Rectangle rectSquare = square;
            Shop laptops = new Shop(3);
            laptops[0] = new Laptop
            {
                Vendor = "Samsung",
                Price = 5200
            };
            laptops[1] = new Laptop
            {
                Vendor = "Asus",
                Price = 6100
            };
            laptops[2] = new Laptop
            {
                Vendor = "LG",
                Price = 4300
            };
            //Console.WriteLine(laptops[1].ToString());
            Employee employee1 = new Employee("Иванов Иван Иванович", new DateTime(1990, 5, 15), "+7124564456", "ivan@mail.ru",
                "Программист", "Разработка ПО", 50000);
            Employee employee2 = new Employee("Петров Петр Петрович", new DateTime(1985, 10, 20), "+712465456", "petrov@mail.ru",
                "Дизайнер", "Графический дизайн", 45000);
            Console.WriteLine(employee1.ToString());
            Console.WriteLine(employee1.ToString());
            employee2.Salary = employee2 + 5000.0m;
            Console.WriteLine(employee1.Equals(employee2));
        }
    }
    public class A
    {
        public int Abc { get; set; }
        public float Bbc { get; set; }
        public A(int Abc, float Bbc) 
        {
            this.Abc = Abc;
            this.Bbc = Bbc;
        }
        // Перегруженные ооператоры всегда static
        public static float operator +(A a, float b) { return a.Abc + b; }
        public static float operator +(A a, A b) { return a.Abc + b.Abc; }
        public static bool operator >(A a, A b) 
        { 
            if (a.Abc > b.Abc) return true; 
            else return false;
        }
        public static bool operator <(A a, A b)
        {
            if (a.Abc < b.Abc) return true;
            else return false;
        }
        public static A operator ++(A a) 
        { 
            a.Abc++;
            return a; 
        }
        public static A operator --(A a)
        {
            a.Abc--;
            return a;
        }
        public static A operator -(A a) 
        { 
            a.Abc = -a.Abc;
            return a;
        }
        public static bool operator true(A a) { return a.Abc > 0; }
        public static bool operator false(A a) { return a.Abc == 0; }
        public static A operator &(A a, A b) { return a; }
        //public static implicit operator Point (A a) { } // неявное
        //public static explicit operator Point (A a) { } // явное
    }
    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }
        public Point() { }
        public static Point operator &(Point a, Point b)
        {
            if ((a.X != 0 && a.Y != 0) && (b.X != 0 && b.Y != 0)) return b;
            return new Point();
        }
        public static bool operator true(Point p)
        {
            return p.X != 0 || p.Y != 0 ? true : false;
        }
        public static bool operator false(Point p)
        {
            return p.X == 0 || p.Y == 0 ? true : false;
        }
    }
       
    class Rectangle
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Rectangle(int Width, int Height) 
        { 
            this.Width = Width;
            this.Height = Height;
        }
        public static implicit operator Rectangle(Square s)
        {
            return new Rectangle (s.Length * 2, s.Length);
        }
    }
    class Square
    {
        public int Length { get; set; }
        // тип данных this[тип аргумента] { get; set;}
    }
    public class Laptop // Класс "Ноутбук"
    {
        public string Vendor { get; set; } // производитель
        public double Price { get; set; } // цена
        public override string ToString()
        {
            return $"{Vendor} {Price}";
        }
    }
    public class Shop // Класс "Магазин"
    {
        Laptop[] laptopArr;
        public Shop(int size)
        {
            laptopArr = new Laptop[size];
        }
        public Laptop this[int index]
        {
            get
            {
                if (index >= 0 && index < laptopArr.Length) { return laptopArr[index]; }
                throw new IndexOutOfRangeException();
            }
            set
            {
                laptopArr[index] = value;
            }
        }
    }    
}
