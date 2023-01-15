namespace ApiBackend.Models.DataModels
{
    public class Student: BaseEntity
    {
        public string FirstName { get; set; } = string.Empty;
 
        public string LastName { get; set; } = string.Empty;

        public int Grade { get; set; } = 0;

        public bool Certified { get; set; } 
    }
}
