using MediatR;
using OurFirstApi.Linq;

namespace OurFirstApi.StudentMediator.CreateStudent;

public class CreateStudentCommand : IRequest<Student>
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Color { get; set; }
    public int Height { get; set; }
    public int Rank { get; set; }
}