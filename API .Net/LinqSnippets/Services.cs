namespace LinqSnippets;

internal class Services
{
    static public void UsersByEmail()
    {
        var users = new[]
        {
            new User()
            {
                Id = 1,
                Name = "Martin",
                LastName = "Herrera",
                Email = "martin@herrera.com",
                Password = "1234"
            },
            new User
            {
                Id = 2,
                Name = "Ana",
                LastName = "Gomez",
                Email = "ana@gomez.com",
                Password = "2345"
            },
            new User
            {
                Id = 3,
                Name = "Marta",
                LastName = "Charcon",
                Email = "marta@charcon.com",
                Password = "4567"
            }
        };

        var userByEmail = users.OrderBy(users => users.Email);
    }

    static public void StudenAdult()
    {
        var student = new[]
        {
            new Student()
            {
                FirstName ="Martin",
                LastName = "Herrera",
                Dob = new DateTime(2010, 5, 28),

            },
            new Student()
            {
                FirstName = "Ana",
                LastName = "Gomez",
                Dob = new DateTime(2000, 2, 13),

            },
            new Student()
            {
                FirstName = "Marta",
                LastName = "Charcon",
                Dob = new DateTime(2005, 1, 30),
            }
        };


    }
}