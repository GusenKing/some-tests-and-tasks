namespace MyTemplates;

public static class Mapper
{
    public static string Task1(string name)
    {
        return "Здравствуйте, @{name}, вы отчислены".Replace("@{name}", name);
    }

    public static string Task2(object obj)
    {
        string s = "Здравствуйте, @{name}. Вы прописаны по адресу @{address}";
        var type = obj.GetType();
        
    }
    
}