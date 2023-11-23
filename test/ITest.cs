namespace test;

public interface ITest
{
    public void SomeMethod(int a);
}


public class TestClass : ITest
{
    public void SomeMethod(int a)
    {
        Console.WriteLine(a);
    }
}

public class TestClass2 : ITest
{
    public void SomeMethod(int a)
    {
        Console.WriteLine(a * 2);
    }
}

public class ProgrammTest
{
    public void Method(ITest input)
    {
        var a = (object)input;
        input.SomeMethod(1);
    }
}