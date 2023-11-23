using System.Linq.Expressions;


ParameterExpression param1 = Expression.Parameter(typeof(int), "x");
ParameterExpression param2 = Expression.Parameter(typeof(int), "y");
ParameterExpression param3 = Expression.Parameter(typeof(int), "z");

ConstantExpression constant = Expression.Constant(3);

Expression sum1 = Expression.Add(param1, param2);
Expression sum2 = Expression.Add(param3, param1);
Expression mult = Expression.Multiply(sum1, constant);  
Expression subtract = Expression.Subtract(mult, sum2);

LambdaExpression lambdaExpression = Expression.Lambda(subtract, param1, param2, param3);
var newLambda = (Func<int, int, int, int>)lambdaExpression.Compile();

Console.WriteLine(newLambda(1, 2, 100));