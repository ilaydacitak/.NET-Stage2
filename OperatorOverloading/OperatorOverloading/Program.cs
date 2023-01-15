using OperatorOverloading;

Student student1 = new Student("İlayda", "ÇITAK", 24, 1999, 100);
Student student2 = new Student("Erol", "ÇITAK", 30, 1992, 100);

var IsEqual = student1 == student2;

var result = student1 + student2;

var result2 = student1 + 5;

student1 += student2;

Console.WriteLine(IsEqual);
Console.WriteLine(result);
Console.WriteLine(result2);
Console.WriteLine($"{student1.age}");