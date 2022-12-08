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
                             select new { Element = element , SecondElement = secondElement};

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
}