using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

namespace LinqSnippets
{
    public class Snippets
    {
        static public void BasicLinQ()
        {
            string[] cars =
            {
                "VW Golf",
                "VW California",
                "Audi A3",
                "Audi A5"
            };

            // 1. SELECT * of cars
            var carList = from car in cars select car;
            foreach (var car in carList)
            {
                Console.WriteLine(car);
            }

            // 2. SELECT WHERE car is Audi
            var audiList = from car in cars where car.Contains("Audi") select car;

            foreach (var audi in audiList)
            {
                Console.WriteLine(audi);
            }
        }
        public static void LinqNumbers()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            //Each Number multiplied by 3
            //take all numbers, but 9
            //order numbers by ascending value

            var processedNumberList =
                numbers
                .Select(num => num * 3)
                .Where(num => num != 9)
                .OrderBy(num => num);

        }

        static public void SearchExamples()
        {
            List<string> textList = new List<string>
            {
                "a",
                "bx",
                "c",
                "d",
                "e",
                "cj",
                "f",
                "c"
            };

            //1. First of all elements
            var first = textList.First();

            // 2. First element that is "c"
            var cText = textList.First(text => text.Equals("c"));

            //3. first element that contains "j"
            var jText = textList.First(text => text.Contains("j"));

            //4. First element that contains "z" or default 
            var firstOrDefaultText = textList.FirstOrDefault(text => text.Contains("z")); // "" or first element that contains "z"

            //5. Last element that contains "z" or default 
            var lastOrDefaultText = textList.LastOrDefault(text => text.Contains("z")); // "" or last element that contains "z"

            //6. single Values
            var uniqueTexts = textList.Single();
            var uniqueOrDefaultTexts = textList.SingleOrDefault();

            int[] evenNumbers = { 0, 2, 4, 6, 8 };
            int[] otherEvenNumbers = { 0, 2, 6 };

            //obtain {4, 8}
            var myEvenNumbers = evenNumbers.Except(otherEvenNumbers); // {4, 8}
        }

        static public void MultipleSelects()
        {
            //SELECT MANY
            string[] myOpinions =
            {
                "opinión 1, text 1",
                "opinión 2, text 2",
                "opinión 3, text 3",
            };
            var myOpinonSelection = myOpinions.SelectMany(opinion => opinion.Split(','));

            var enterprises = new[] {
                new Enterprise()
                {
                    Id = 1,
                    Name = "Enterprise 1",
                    Employees = new[]
                    {
                        new Employee
                        {
                            Id = 1,
                            Name = "Prueba",
                            Email = "example01@email.com",
                            Salary = 30000
                        },
                        new Employee
                        {
                            Id = 2,
                            Name = "Prueba2",
                            Email = "example02@email.com",
                            Salary = 300
                        },
                        new Employee
                        {
                            Id = 3,
                            Name = "Prueba3",
                            Email = "example03@email.com",
                            Salary = 3000
                        },
                    }
                },
                new Enterprise()
                {
                    Id = 2,
                    Name = "Enterprise 2",
                    Employees = new[]
                    {
                        new Employee
                        {
                            Id = 4,
                            Name = "Prueba4",
                            Email = "example04@email.com",
                            Salary = 1000
                        },
                        new Employee
                        {
                            Id = 5,
                            Name = "Prueba5",
                            Email = "example05@email.com",
                            Salary = 2000
                        },
                        new Employee
                        {
                            Id = 6,
                            Name = "Prueba6",
                            Email = "example06@email.com",
                            Salary = 3000
                        },
                    }
                }
            };

            //Obtin all Employees of all Enterprises
            var employeeList = enterprises.SelectMany(enterprise => enterprise.Employees);

            //Know if prueba5 list is empty
            bool hasEnterprises = enterprises.Any();

            bool hasEmployees = enterprises.Any(enterprise => enterprise.Employees.Any());

            // All enterprises at least has an employees with at least 1000$ of Salary

            bool hasEmployeeWithSalaryMoreThanOrEqual1000 = enterprises.Any(enterprise =>
            enterprise.Employees.Any(employee => employee.Salary > 1000));
        } 

        static public void LinqCollections()
        {
            var firstList = new List<string>() { "a", "b", "c" };
            var secondList = new List<string>() { "a", "c", "d" };

            //INNER JOIN
            var commonResult = from element in firstList
                               join secondElement in secondList
                               on element equals secondElement
                               select new { element, secondElement };

            var commonResult2 = firstList.Join(secondList,
                element => element,
                secondElement => secondElement,
                (element, secondElement) => new { element, secondElement }
                );

            // JOIN - LEFT
            var leftOuterJoin = from element in firstList
            join secondElement in secondList
            on element equals secondElement
            into temporalList
            from temporalE1ement in temporalList.DefaultIfEmpty()
            where element != temporalE1ement
            select new { Element = element };

            var leftOuterJoin2 = from element in firstList
                                from secondElement in secondList.Where(s => s == element).DefaultIfEmpty()
                                select new { Element = element, SecondElement = secondElement };

            // OUTER JOIN - RIGHT
            var rightOuterJoin = from secondElement in secondList
                                 join element in firstList
                                 on secondElement equals element
                                 into temporalList
                                 from temporalElement in temporalList.DefaultIfEmpty()
                                 where secondElement != temporalElement
                                 select new { Element = secondElement };

            //UNION
            var unionList = leftOuterJoin.Union(rightOuterJoin);
        }

        static public void SkipTakeLinq()
        {
            var myList = new[]
            {
                1,2, 3, 4, 5, 6, 7, 8, 9, 10,
            };
            var skipTwoFirstValues = myList.Skip(2); //{   3, 4, 5, 6, 7, 8, 9, 10, }
            var skipLastTwoValues = myList.SkipLast(2); //{ 1,2,  3, 4, 5, 6, 7, 8,  }
            var skipWhile = myList.SkipWhile(num => num < 4); // { 4, 5, 6, 7 , 8 , 9 , 10}

            //TAKE

            var takeFirstTwoValues = myList.Take(2); // {1, 2}
            var takeLastTwoValues = myList.TakeLast(2); // {9, 10}

            var takeWhile = myList.TakeWhile(num => num < 4); // {1, 2}
        }

        // Paging with Skip & Take
        static public IEnumerable<T> GetPage<T>(IEnumerable<T> collection, int pageNumber, int resultsPerPage)
        {
            int startIndex = (pageNumber - 1) * resultsPerPage;
            return collection.Skip(startIndex).Take(resultsPerPage);
        }

        // Variables
        static public void LinqVariables()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var aboveAverage = from number in numbers
                               let average = numbers.Average()
                               let nSquared = Math.Pow(number,2)
                               where nSquared > average
                               select number;
            Console.WriteLine("Avegare:{0}", numbers.Average());

            foreach(int number in aboveAverage){
                Console.WriteLine("Number:{0} Square:{1}", number, Math.Pow(number,2));
            }
        }

        // ZIP
        static public void ZipLinq()
        {
            int[] numbers = { 1, 2, 3, 4, 5 };
            string[] stringNumbers = { "one", "two", "three", "four", "five" };
            IEnumerable<string> zipNumbers = numbers.Zip(stringNumbers, (number, word) => number + "=" + word);
            // {"1=one", "2=two", . . . }
        }

        // Repeat & Range
        static public void repeatRangeLinq()
        {
            // Generate collection from 1 - 1000 --> RANGE
            IEnumerable<int> first1000 = Enumerable.Range(1, 1000);

            // Repeat a value N times
            IEnumerable<string> fiveXs = Enumerable.Repeat("X", 5); // {"X","X","X","X","X"}

        }


        static public void studentsLinq()
        {

            var classRoom = new[]
            {
                new Student
                {
                    Id = 1,
                    Name = "Martín",
                    Grade = 90,
                    Certified = true,
                },
                new Student
                {
                    Id = 2,
                    Name = "Juan",
                    Grade = 50,
                    Certified = false,
                },
                new Student
                {
                    Id = 3,
                    Name = "Ana",
                    Grade = 96,
                    Certified = true,
                },
                new Student
                {
                    Id = 4,
                    Name = "Álvaro",
                    Grade = 10,
                    Certified = false,
                },
                new Student
                {
                    Id = 5,
                    Name = "Pedro",
                    Grade = 50,
                    Certified = true,
                }
            };


            var certifiedStudents = from student in classRoom
                                    where student.Certified
                                    select student;

            var notCertifiedStudents = from student in classRoom
                                       where student.Certified == false
                                       select student;

            var appovedStudentsNames = from student in classRoom
                                       where student.Grade >= 50 && student.Certified == true
                                       select student.Name;

        }

        // ALL
        static public void AllLinq()
        {
            var numbers = new List<int>() { 1, 2, 3, 4, 5 };
            bool allAreSmallerThan10 = numbers.All(x => x < 10); // true
            bool allAreBiggerOrEqualThan2 = numbers.All(x => x >= 2); // false

            var emptyList = new List<int>();
            bool allNumbersAreGreaterThan0 = numbers.All(x => x >= 0); // true

        }


        // Aggregate
        static public void aggregateQueries()
        {

            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // Sum all numbers
            int sum = numbers.Aggregate((prevSum, current) => prevSum + current);

            // 0, 1 => 1
            // 1, 2 => 3
            // 3, 4 => 7
            // etc.


            string[] words = { "hello,", "my", "name", "is", "Martín" }; // hello, my name is Martín
            string greeting = words.Aggregate((prevGreeting, current) => prevGreeting + current);

            // "", "hello," => hello,
            // "hello,", "my" => hello, my
            // "hello, my", "name" => hello, my name
            // etc.
        }


        //Disctinct
        static public void distinctValues()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 5, 4, 3, 2, 1 };
            IEnumerable<int> distinctValues = numbers.Distinct();
        }


        //GroupBy
        static public void groupByExamples()
        {

            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // Obtain only even numbers and generate two groups
            var grouped = numbers.GroupBy(x => x % 2 == 0);

            // We will have two groups:
            // 1. The group that doesnt fit the condition (odd numbers)
            // 2. The group that fits the condition (even numbers)

            foreach (var group in grouped)
            {
                foreach (var value in group)
                {
                    Console.WriteLine(value); // 1,3,5,7,9 ... 2, 4, 6, 8 (first the odds and then the even)
                }
            }

            // Another Example
            var classRoom = new[]
            {
                new Student
                {
                    Id = 1,
                    Name = "Martín",
                    Grade = 90,
                    Certified = true,
                },
                new Student
                {
                    Id = 2,
                    Name = "Juan",
                    Grade = 50,
                    Certified = false,
                },
                new Student
                {
                    Id = 3,
                    Name = "Ana",
                    Grade = 96,
                    Certified = true,
                },
                new Student
                {
                    Id = 4,
                    Name = "Álvaro",
                    Grade = 10,
                    Certified = false,
                },
                new Student
                {
                    Id = 5,
                    Name = "Pedro",
                    Grade = 50,
                    Certified = true,
                }
            };


            var certifiedQuery = classRoom.GroupBy(student => student.Certified);

            // We obtain two groups
            // 1- Not certified students
            // 2- Certified Students

            foreach (var group in certifiedQuery)
            {
                Console.WriteLine("--------- {0} --------", group.Key);
                foreach (var student in group)
                {
                    Console.WriteLine(student.Name);
                }
            }
        }

        static public void relationsLinq()
        {

            List<Post> posts = new List<Post>()
            {
                new Post()
                {
                    Id= 1,
                    Title = "My first post",
                    Content = "My first content",
                    Created = DateTime.Now,
                    Comments = new List<Comment>()
                    {
                        new Comment()
                        {
                            Id = 1,
                            Created = DateTime.Now,
                            Title = "My first comment",
                            Content = "My content"
                        },
                        new Comment()
                        {
                            Id = 2,
                            Created = DateTime.Now,
                            Title = "My second comment",
                            Content = "My other content"
                        }
                    }
                },
                new Post()
                {
                    Id= 2,
                    Title = "My second post",
                    Content = "My second content",
                    Created = DateTime.Now,
                    Comments = new List<Comment>()
                    {
                        new Comment()
                        {
                            Id = 3,
                            Created = DateTime.Now,
                            Title = "My other comment",
                            Content = "My new content"
                        },
                        new Comment()
                        {
                            Id = 4,
                            Created = DateTime.Now,
                            Title = "My other new comment",
                            Content = "My new content"
                        }
                    }
                }
            };


            var commentsContent = posts.SelectMany(
                    post => post.Comments,
                        (post, comment) => new { PostId = post.Id, CommentContent = comment.Content });

        }
    }
}