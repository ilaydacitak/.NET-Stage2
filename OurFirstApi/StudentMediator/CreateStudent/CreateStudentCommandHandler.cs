using MediatR;
using OurFirstApi.Linq;

namespace OurFirstApi.StudentMediator.CreateStudent;

public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand,Student>
{
    public   Task<Student> Handle(CreateStudentCommand command, CancellationToken cancellationToken)
    // ÝÇERÝSÝNDE ASENKRON METOT TANIMLAMA ÝHT YÜKSEK OLDUÐUNDAN BU DÝREKT DEFAULT OALRAK TASK OALRAK TANIMLANMIÞTIR
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