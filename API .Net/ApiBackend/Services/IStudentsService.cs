namespace ApiBackend.Services;

public interface IStudentsService
{
    IEnumerable<Student> GetStudentsWithCourses();
    IEnumerable<Student> GetStudentsWithNoCourses();
}
