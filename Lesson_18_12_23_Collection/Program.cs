/*
string path = "myFile.txt";
List<int> ints = new List<int>(100);
Random r = new Random();
int xVal = 4;

Console.WriteLine("Введите диапазон Random :");
int x1 = 0, y1 = 0;


x1 = int.Parse(Console.ReadLine());
y1 = int.Parse(Console.ReadLine());



for (int i = 0; i < 100; i++)
{
    ints.Add(r.Next(x1, y1));
}

foreach (var item in ints)
{
    Console.Write($"{item}.");
}


Console.WriteLine("\nВведите диапазон :");
int x = 0, y = 0;
x = int.Parse(Console.ReadLine());
y = int.Parse(Console.ReadLine());

if (x == y || x < 0 || x > 100 || y < 0 || y > 100)
    Console.WriteLine("Некорректный диапазон");
else
{
    for (int i = x; i < y + 1; i++)
    {
        Console.Write($"{ints[i]}.");
        File.AppendAllText(path, (ints[i].ToString() + "," + "\n")); // запись в файл
    }
}


Console.WriteLine("\nВведите имя файла");
string name = Console.ReadLine();
Console.WriteLine("Введите расширение файла");
string txt = Console.ReadLine();
string[] strs = new string[10];

if (txt  == "txt" && name == "myFile")
    for (int i = 0; i < strs.Length; i++)
        strs = File.ReadAllLines(path);

string[] s;
for (int i = 0; i < strs.Length; i++)
{
    s = strs[i].Split(new char[] { ',' });
    Console.WriteLine(s[0]);
}
*/





//  5) Создать класс Точка (2Д)
// Реализовать рандом по позициям (диапазон для Х и У от 0.000001 до 4.000001)
// ИЛИ принять у пользователя путь где лежит файл с данными уже и вывести данные в консоль

//  6) Дополнить 5 задание отсортировав точки по убыванию от абсолютного центра

//  7) Дополнить 6 задание найдя две ближайшие и 2 самые удаленные точки



using System.Drawing;
using Lesson_18_12_23_Collection;


string path = "myFile.txt";

List<Point2D> ints = new List<Point2D>(10);  // List with 10 elem

//  Добавление Рандомных Точек в LIST и запись в файл

/*
Point2D p1 = new Point2D();
ints.Add(p1);
Point2D p2 = new Point2D();
ints.Add(p2);
Point2D p3 = new Point2D();
ints.Add(p3);
Point2D p4 = new Point2D();
ints.Add(p4);
Point2D p5 = new Point2D();
ints.Add(p5);
Point2D p6 = new Point2D();
ints.Add(p6);
Point2D p7 = new Point2D();
ints.Add(p7);
Point2D p8 = new Point2D();
ints.Add(p8);
Point2D p9 = new Point2D();
ints.Add(p9);
Point2D p10= new Point2D();
ints.Add(p10);


foreach (Point2D item in ints)
{
    Console.WriteLine($"X: {item.X},\t  Y: {item.Y}");                              // вывод точек в консоль
    File.AppendAllText(path, (item.X.ToString() + ":" + item.Y.ToString() + "\n")); // запись точек в файл
}
*/




int choice =7;
do
{
    Console.Clear();
    Console.WriteLine("МЕНЮ:");
    Console.WriteLine("Выберите действие");
    Console.WriteLine("1. Добавление точки в файл.");
    Console.WriteLine("2. Считывание точек из файла в список.");
    Console.WriteLine("3. Создание библиотеки из списка.");
    Console.WriteLine("4. Сортировка точек по длинне.");
    Console.WriteLine("5. Ввести 2 ближайшие и 2 самые удаленные точки.");
    Console.WriteLine("0. Выход");

    
    choice = int.Parse(Console.ReadLine());

    
    

    if (choice == 1)
    {
        Point2D p11 = new Point2D();
        ints.Add(p11);
        File.AppendAllText(path, (p11.X.ToString() + ":" + p11.Y.ToString() + "\n")); // запись точек в файл
        Console.WriteLine("Рандомная точка p11 добавлена в файл");
        Console.ReadLine();
    }

    else if (choice == 2)
    {
        //  Считывание Точек из файла в LIST
        List<Point2D> list1 = new List<Point2D>();
        Console.WriteLine("Считанные точки из файла");
        string[] point2D = File.ReadAllLines(path);
        foreach (string line in point2D)
        {
            string[] split = line.Split(':');
            list1.Add(new Point2D(double.Parse(split[0]), double.Parse(split[1])));
        }
        Console.WriteLine();

        //  Вывод точек из LIST  в консоль
        foreach (Point2D point in list1)
            point.PrintPoint2D();
        Console.ReadLine();
    }

    else if (choice == 3)
    {
        //  Считывание Точек из файла в LIST
        List<Point2D> list1 = new List<Point2D>();
        Console.WriteLine("Считанные точки из файла");
        string[] point2D = File.ReadAllLines(path);
        foreach (string line in point2D)
        {
            string[] split = line.Split(':');
            list1.Add(new Point2D(double.Parse(split[0]), double.Parse(split[1])));
        }

        // из LIST  сделали словарь
       
        Dictionary<double, Point2D> d1 = new Dictionary<double, Point2D>();
        foreach (Point2D point in list1)
        {
            double k = point.Z;
            d1.Add(k, point);
        }

        Console.WriteLine("СЛОВАРЬ");
        foreach (KeyValuePair<double, Point2D> item in d1)
        {
            Console.Write($"Key: {item.Key}\nValues: ");
            Console.Write($"X: {item.Value.X},  Y: {item.Value.Y}");
            Console.WriteLine();
        }
        Console.WriteLine();
        Console.ReadLine();
    }

    else if (choice == 4)
    {
        //  Считывание Точек из файла в LIST
        List<Point2D> list1 = new List<Point2D>();
        Console.WriteLine("Считанные точки из файла");
        string[] point2D = File.ReadAllLines(path);
        foreach (string line in point2D)
        {
            string[] split = line.Split(':');
            list1.Add(new Point2D(double.Parse(split[0]), double.Parse(split[1])));
        }
        Console.WriteLine("Отсортированные точки по длинне от нуля (Z)");
        list1.Sort(delegate (Point2D x, Point2D y)                          //  Сортировка с помощью ДЕЛЕГАТА
        {
            if (x.Z == null && y.Z == null) return 0;
            else if (x.Z == null) return -1;
            else if (y.Z == null) return 1;
            else return x.Z.CompareTo(y.Z);
        });

        Console.WriteLine();

        foreach (Point2D point in list1)
            point.PrintPoint2D();
        Console.ReadLine();
    }

    else if (choice == 5)
    {
        //  Считывание Точек из файла в LIST
        List<Point2D> list1 = new List<Point2D>();
        Console.WriteLine("Считанные точки из файла");
        string[] point2D = File.ReadAllLines(path);
        foreach (string line in point2D)
        {
            string[] split = line.Split(':');
            list1.Add(new Point2D(double.Parse(split[0]), double.Parse(split[1])));
        }
        Console.WriteLine("Отсортированные точки по длинне от нуля (Z)");
        list1.Sort(delegate (Point2D x, Point2D y)                          //  Сортировка с помощью ДЕЛЕГАТА
        {
            if (x.Z == null && y.Z == null) return 0;
            else if (x.Z == null) return -1;
            else if (y.Z == null) return 1;
            else return x.Z.CompareTo(y.Z);
        });

        Console.WriteLine("Две ближайшие точки:");
        list1[0].PrintPoint2D();
        list1[1].PrintPoint2D();
        Console.WriteLine("\nДве самые удаленные точки:");
        list1[list1.Count - 2].PrintPoint2D();
        list1[list1.Count - 1].PrintPoint2D();

        Console.ReadLine();
        
    }

    else if (choice == 0) { break; }


    else { Console.WriteLine("НЕверный выбор"); Thread.Sleep(2000); }

} while (choice != 0);


















