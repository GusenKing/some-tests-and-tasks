var result = ClassFactory(1, 123);
var propertyOfInstance = result.GetType().GetProperty("Property");
Console.WriteLine($"result is {result.GetType()} and " +
                  $"Property = {propertyOfInstance.GetValue(result)} of type {propertyOfInstance.PropertyType}");

object ClassFactory(int classType, object arg)
{
    switch (classType)
    {
        case 1:
            if (arg is int)
            {
                var currentType = Type.GetType("Class1");
                var typeConstructor = currentType.GetConstructor(Array.Empty<Type>());
                var instance = typeConstructor.Invoke(Array.Empty<object>());
                instance.GetType().GetProperty("Property").SetValue(instance, arg);
                return instance;
            }
            else
            {
                throw new ArgumentException();
            }
        case 2:
            if (arg is string)
            {
                var currentType = Type.GetType("Class2");
                var typeConstructor = currentType.GetConstructor(Array.Empty<Type>());
                var instance = typeConstructor.Invoke(Array.Empty<object>());
                instance.GetType().GetProperty("Property").SetValue(instance, arg);
                return instance;
            }
            else
            {
                throw new ArgumentException();
            }
        default:
            throw new ArgumentException();
    }
    return null;
}

class Class1
{
    public int Property { get; set; }
}

class Class2
{
    public string Property { get; set; }
}