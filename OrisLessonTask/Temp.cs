namespace OrisLessonTask;

public static class Temp
{
    public static string Task1(string name)
    {
        return $"Здравствуйте, {name}, вы отчислены";
    }

    public static string Task2(object obj)
    {
        
    }

    public static string Task3(object obj)
    {
        
    }

    public static string Task4(object obj)
    {
        
    }
}

public class Student
{
    public string Surname { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public int Temperature { get; set; }
    public int Balls { get; set; }
}