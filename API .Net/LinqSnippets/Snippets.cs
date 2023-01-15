

namespace LinqSnippets;

public class Snippets
{
    static public void BasicLinq()
    {
        string[] cars =
        {
            "VW Golf",
            "VW CAlifornia",
            "Audi A3",
            "Audi A5",
            "Fiat Punto",
            "Seat Ibiza",
            "Seat León"
        };

        // 1. SELECT * of cars
        var carList = from car in cars select car;

        foreach (var car in carList)
            Console.WriteLine(car);

        // 2. SELECT WHERE car is Audi
        var audiList = from car in cars where cars.Contains("Audi") select cars;

        foreach (var car in audiList)
            Console.WriteLine(car);
    }

    // Number Examples
    static public void LinqNumbers()
    {
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        // Each Number multiplied by 3
        // take all numbers, but 9
        // Order numbers by ascending value

        var processedNumberList =
            numbers
            .Select(n => n * 3) //{ 3, 6, 9, etc }
            .Where(n => n != 9) // {all but the 9 }
            .OrderBy(n => n);
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
            "c",
        };

        // 1. First of all elemet
        var first = textList.First();

        // 2. First element that has "c"
        var cText = textList.First(text => text.Equals("c"));

        // 3. First element that contains "j"
        var jText = textList.First(text => text.Contains("j"));

        // 4. First element that contains "z" or default
        var firstOrDefaultText = textList.FirstOrDefault(text => text.Contains("z")); // "" or first element whit "z"

        // 5. Last element that contains "z" or default
        var lastOrDefaultText = textList.LastOrDefault(text => text.Contains("z")); // "" or last element whit "z"

        // 6. Single values
        var uniqueTexts = textList.Single();
        var uniqueDefaultTexts = textList.SingleOrDefault();

        int[] evenNumber = { 2, 4, 6, 8 };
        int[] otherEvenNumber = { 0, 2, 6 };

        // Show except { 4 , 8 }
        var myEventNumbers = evenNumber.Except(otherEvenNumber); // { 4 , 8 }

    }

    public static void MultipleSelects()
    {
        // Select Many
        string[] myOpinions =
        {
            "Opinion 1, text1",
            "Opinion 2, text2",
            "Opinion 3, text3"
        };

        var myOpinionSelection = myOpinions.SelectMany(opinion => opinion.Split(","));

        var enterprises = new[]
        {
            new Enterprise()
            {
                Id = 1,
                Name = "Enterprise 1",
                Employees = new[]
                {
                    new Employee
                    {
                        Id = 1,
                        Name = "Martín",
                        Email = "Martin@enterprise1.com",
                        Salary = 3000
                    },
                    new Employee
                    {
                        Id = 2,
                        Name = "Pepe",
                        Email = "Pepe@enterprise1.com",
                        Salary = 1000
                    },
                    new Employee
                    {
                        Id = 3,
                        Name = "Juanjo",
                        Email = "Juanjo@enterprise1.com",
                        Salary = 2000
                    }

                }
            },
            new Enterprise()
            {
                Id = 2,
                Name = "Enterprise 1",
                Employees = new[]
                {
                    new Employee
                    {
                        Id = 4,
                        Name = "Ana",
                        Email = "Ana@enterprise1.com",
                        Salary = 3000
                    },
                    new Employee
                    {
                        Id = 5,
                        Name = "Maria",
                        Email = "Maria@enterprise1.com",
                        Salary = 1300
                    },
                    new Employee
                    {
                        Id = 6,
                        Name = "Marta",
                        Email = "Marta@enterprise1.com",
                        Salary = 4000
                    }

                }
            }
        };

        // Obtain all Employees of all Enterprises
        var employeeList = enterprises.SelectMany(enterprise => enterprise.Employees);

        // Know if a list is empty
        bool hasEnterprises = enterprises.Any();
        bool hasEmployees = enterprises.Any(enterprise => enterprise.Employees.Any());

        // All enterprises at least employee with more that 1000€ of salary
        bool hasEmployeeWithSalaryMoreThatOrEqual100 =
            enterprises.Any(enterprise => enterprise.Employees.Any(Employee => Employee.Salary >= 1000));
    }

    static public void LinqCollections()
    {
        var firstList = new List<string>() { "a", "b", "c" };
        var secondList = new List<string>() { "a", "c", "d" };

        // INNER JOIN
        //var commonResult = from element in firstList
        //                   join secondElement in secondList
        //                   on element equals secondList
        //                   select new { element, secondList };

        var commonResult2 = firstList.Join(
            secondList,
            element => element,
            secondElement => secondElement,
            (element, secondElement) => new { element, secondElement }
            );

        // OUTER JOIN - LEFT
        var leftOuterJoin = from element in firstList
                            join secondElement in secondList
                            on element equals secondElement
                            into temporalList
                            from temporalElement in temporalList.DefaultIfEmpty()
                            where element != temporalElement
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

        // UNION
        var unionList = leftOuterJoin.Union(rightOuterJoin);

    }

    static public void SkipTakeLinq()
    {
        var myList = new[]
        {
            1,2,3,4,5,6,7,8,9,10
        };

        // SKIP

        var skipTowFirstValues = myList.Skip(2); // {3,4,5,6,7,8,9,10}

        var skipTowLastValues = myList.Skip(2); // {1,2,3,4,5,6,7,8}

        var skipWhileSmallThan4 = myList.SkipWhile(num => num < 4); // {4,5,6,7,8}

        // TAKE
        var takeFistTowValues = myList.Take(2); // {1,2}

        var takeLastTowValues = myList.TakeLast(2); // {9,10}

        var takeWhileSmallerThat4 = myList.TakeWhile(num => num < 4); // {1,2,3}
    }

    // PAGING with Skip & Take
    static public IEnumerable<T> GetPage<T>(IEnumerable<T> collection, int pageNumber, int resultPerPage)
    {
        int startIndex = (pageNumber - 1) * resultPerPage;
        return collection.Skip(startIndex).Take(resultPerPage);
    }

    // VARIABLES
    static public void LinqVariables()
    {
        int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        var aboverAverage = from number in numbers
                            let average = numbers.Average()
                            let nSquared = Math.Pow(number, 2)
                            where nSquared > average
                            select number;

        Console.WriteLine($"Average: {numbers.Average()}");
        foreach (int number in aboverAverage)
            Console.WriteLine($"Number: {number} Square: {Math.Pow(number, 2)}");
    }

    // ZIP
    static public void ZipLinq()
    {
        int[] numbers = { 1, 2, 3, 4, 5 };
        string[] stringNumbers = { "one", "two", "three", "four", "five" };

        IEnumerable<string> zipNumbers = numbers.Zip(stringNumbers, (number, word) => $"{number}+{word}");
        // {"1=one", "2=two", ...}
    }

    // REPEAT & RANGE
    static public void RepeatRangeLinq()
    {
        // Generate collection from 1 - 1000 --> RANGE
        IEnumerable<int> first1000 = Enumerable.Range(1, 1000);

        // Repeat a value N times
        IEnumerable<string> fiveXs = Enumerable.Repeat("X", 5); // {"X","X","X","X","X"}
    }

    static public void StudentsLinq()
    {
        var classRoom = new[]
        {
            new Student
            {
                Id = 1,
                FirstName = "Martin",
                Grade = 90,
                Certified = true,
            },
            new Student
            {
                Id = 2,
                FirstName = "Juan",
                Grade = 50,
                Certified = false,
            },
            new Student
            {
                Id = 3,
                FirstName = "ana",
                Grade = 96,
                Certified = true,
            },
            new Student
            {
                Id = 4,
                FirstName = "Alvaro",
                Grade = 10,
                Certified = false,
            },
            new Student
            {
                Id = 5,
                FirstName = "Angel",
                Grade = 50,
                Certified = true,
            }
        };

        var certifiedStudents = from student in classRoom
                                where student.Certified
                                select student;

        var noCertifiedStudents = from student in classRoom
                                  where student.Certified == false
                                  select student;

        var appovedStudentsNames = from student in classRoom
                                   where student.Grade >= 50 && student.Certified == true
                                   select student.FirstName;

    }

    // ALL
    static public void AllLinq()
    {
        var numbers = new List<int>() { 1, 2, 3, 4, 5 };

        bool allAreSmallerThat10 = numbers.All(x => x < 10); // true
        bool allAreBiggerOrEqualThat2 = numbers.All(x => x >= 2); // false

        var emptyList = new List<int>();
        bool allNumbersAreGreaterThat0 = numbers.All(x => x >= 0); // true 
    }

    // AGREGATE
    static public void AggregateQueries()
    {
        int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        // Sum all number
        int sum = numbers.Aggregate((prevSum, current) => prevSum + current);

        // 0,1 => 1
        // 1,2 => 3
        // 3,4 => 7
        // etc.

        string[] words = { "hello,", "my", "name", "is", "Bob" };
        string greeting = words.Aggregate((prevGreeting, current) => prevGreeting + " " + current);

        // "", "hello," => hello,
        // "hello,", "my" => hello, my
        // "hello, my", "name" => hello, my name
        // etc..
    }

    //DISTINCT
    static public void DistictValues()
    {
        int[] numberss = { 1, 2, 3, 4, 5, 4, 3, 2, 1 };

        IEnumerable<int> distinctValues = numberss.Distinct();
    }

    //GROUPBY
    static public void GroupByExamples()
    {
        List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        // Obtain only even numbers and generate two groups
        var grouped = numbers.GroupBy(x => x % 2 == 0);

        // We will have two groups:
        // 1. The group that doesnt fit the condition (odd numbers)
        // 2. The group that fits the condition (even numbers)
        foreach (var group in grouped)
            foreach (var value in group)
                Console.WriteLine(value); // 1,3,5,7,9 .... 2,4,,6,8 (frist the odds and then the even)


        // Another Example
        var classRoom = new[]
        {
            new Student
            {
                Id = 1,
                FirstName = "Martin",
                Grade = 90,
                Certified = true,
            },
            new Student
            {
                Id = 2,
                FirstName = "Juan",
                Grade = 50,
                Certified = false,
            },
            new Student
            {
                Id = 3,
                FirstName = "ana",
                Grade = 96,
                Certified = true,
            },
            new Student
            {
                Id = 4,
                FirstName = "Alvaro",
                Grade = 10,
                Certified = false,
            },
            new Student
            {
                Id = 5,
                FirstName = "Angel",
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
            Console.WriteLine($"------- {group.Key} -------");
            foreach (var student in group)
                Console.WriteLine(student.FirstName);
        }

    }
    static public void RelationsLinq()
    {
        List<Post> posts = new List<Post>()
        {
            new Post()
            {
                Id= 1,
                Title = "My First Post",
                Content = "My first Content",
                Created = DateTime.Now,
                Comments = new List<Comment>()
                {
                    new Comment()
                    {
                        Id = 1,
                        Created = DateTime.Now,
                        Title = "My First Comment",
                        Content = "My content"
                    },
                     new Comment()
                    {
                        Id = 2,
                        Created = DateTime.Now,
                        Title = "My second Comment",
                        Content = "My other content"
                    }
                }
            },
             new Post()
            {
                Id= 2,
                Title = "My second Post",
                Content = "My second Content",
                Created = DateTime.Now,
                Comments = new List<Comment>()
                {
                    new Comment()
                    {
                        Id = 3,
                        Created = DateTime.Now,
                        Title = "My First Comment",
                        Content = "My content"
                    },
                     new Comment()
                    {
                        Id = 4,
                        Created = DateTime.Now,
                        Title = "My second Comment",
                        Content = "My other content"
                    }
                }
            }
        };

        var commentsContent = posts.SelectMany(
            post => post.Comments, 
                (post, comment) => new { PostId = post.Id, CommentContent = comment.Content });
    }
}