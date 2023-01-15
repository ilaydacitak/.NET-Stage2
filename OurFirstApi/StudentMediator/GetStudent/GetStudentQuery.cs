using MediatR;
using OurFirstApi.Linq;

namespace OurFirstApi.StudentMediator.GetStudent;

public class GetStudentQuery :IRequest<Student>
{
    public int Number { get; set; }
}