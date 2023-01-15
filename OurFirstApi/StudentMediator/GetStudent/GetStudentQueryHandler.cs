using MediatR;
using OurFirstApi.Linq;

namespace OurFirstApi.StudentMediator.GetStudent;

public class GetStudentQueryHandler :IRequestHandler<GetStudentQuery,Student>
{
    public  Task<Student> Handle(GetStudentQuery query, CancellationToken cancellationToken)
    {
        Database db = new Database();
        var student = db.Students.FirstOrDefault(f => f.Number == query.Number);
        return Task.FromResult(student);
    }
}