using MediatR;
using OurFirstApi.Linq;

namespace OurFirstApi.StudentMediator.CreateStudent;

public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand,Student>
{
    public   Task<Student> Handle(CreateStudentCommand command, CancellationToken cancellationToken)
    // ��ER�S�NDE ASENKRON METOT TANIMLAMA �HT Y�KSEK OLDU�UNDAN BU D�REKT DEFAULT OALRAK TASK OALRAK TANIMLANMI�TIR
    {
        Database db = new Database();
        
        var maxNumber = db.Students.MaxBy(m => m.Number)!.Number;
        var newNumber = maxNumber + 1;
        
        var newStudent = new Student
        {
            Number = newNumber,
            Name = command.Name,
            Surname = command.Surname,
            Height = command.Height,
            Color = command.Color,
            Rank = command.Rank
        };
        
         
        db.Students.Add(newStudent);
        return Task.FromResult<Student>( newStudent);
    }
}