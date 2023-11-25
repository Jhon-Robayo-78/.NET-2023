/* CONVERSION DE VARIBLES 
int edad = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Edad: " + edad);
*/
/*
int x, y;
x = 13;
y = 2;

Console.WriteLine(x % y);
*/
/*
for(int i = 2;i <= 10; i += 3)
{
    Console.WriteLine(i);
}
*/
/*
int x = 0;
for (int i = 0; i < 3; i++)
{
    Console.WriteLine("Iteracion: " + i);
    x += i;
    Console.WriteLine($"valor de x: {x}");
}

Console.WriteLine(x);*/
/*int num = Convert.ToInt32(Console.ReadLine());
int fact = 1;
if (num == 0)
{
    Console.WriteLine(1);
}
else
{
    for (int i = 1; i <= num; i++)
    {
        fact *= i; 
        Console.WriteLine(fact);
    }
}*/
/*
int num = Convert.ToInt32(Console.ReadLine());
int total = 0;
for (int i = 0; i <= num; i++)
{
    total += i;
}
Console.WriteLine(total+"-------------");

int sum = 0;
for (int i = 1; i <= 3; i++)
{
    if (i == 2)
    {
        continue;
    }
    sum += 1;
}
Console.WriteLine(sum);*/
/*
int[,] num = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };

Console.WriteLine(num.Length);
//your code goes here
for (int i = 0; i < 3; i++)
{
    for (int j = 0; j < 3; j++)
    {
        Console.Write(num[i, j]);
    }
    Console.Write("\n");
}*/
/*
int day1Winner = Convert.ToInt32(Console.ReadLine());
int day2Winner = Convert.ToInt32(Console.ReadLine());
int day3Winner = Convert.ToInt32(Console.ReadLine());


string[][] olympiad = new string[][]
{
                //day 1 - 5 participants
                new string[] { "Jill Yan", "Bridgette Ramona", "Sree Sanda", "Jareth Charlene", "Carl Soner" },
                //day 2 - 7 participants
                new string[] { "Anna Hel", "Mariette Vedrana", "Fran Mayur", "Drake Hilmar", "Nikolay Brooks", "Eliana Vlatko", "Villem Mario" },
                //day 3 - 4 participants
                new string[] { "Hieremias Zavia", "Ziya Ollie", "Christoffel Casper", "Kristian Dana", }

};
//your code goes here
//Console.WriteLine(olympiad[1].Length);
for(int i = 0; i < olympiad.Length; i++)
{
    for (int j = 0; j < olympiad[i].Length; j++)
    {
        if (day1Winner == j + 1)
        {
            Console.WriteLine(olympiad[i][j]);
        }
        if (day2Winner == j + 1)
        {
            Console.WriteLine(olympiad[i][j]);
        }
        if (day3Winner == j + 1)
        {
            Console.WriteLine(olympiad[i][j]);
        }
    }
             
}*/
/*
int[,,] a = new int[2, 3, 4];

Console.Write(a.Rank);*/

int i = 0;
int[] arr = new int[5];
while (i < arr.Length)
{
    arr[i] = Convert.ToInt32(Console.ReadLine());
    i++;
            }
int max, min;
max = 0;
min = 0;
max = arr.Max();
min = arr.Min();
Console.WriteLine(max + min);