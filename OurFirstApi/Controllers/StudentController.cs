using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OurFirstApi.Linq;
using OurFirstApi.StudentMediator.CreateStudent;
using OurFirstApi.StudentMediator.GetStudent;

namespace OurFirstApi.Controllers;

[Route("api/[controller]")]
public class StudentController : ControllerBase
{
    private readonly IMediator _mediator;

    //CONTROLLER TARAFINDA BUSSN ��� OLMAMALI, SO BUNU KULLANARAK SA�LAYAB�L�YORUZ BU KO�ULU
    public StudentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("{number}")]
    public async Task<JsonResult> GetStudent(int number)
    {
        var query = new GetStudentQuery
        {
            Number = number
        };
        var student = await _mediator.Send(query);
        var newResult = JsonConvert.SerializeObject(student);
        var newResult2 = JsonConvert.DeserializeObject<Student>(newResult);

        // DESERIALIZE = JSON FORMATINI OBJ �EV�R�R
        // OBJEY� JSON FORMATINA �EV�R�R = SERIALIZE
        // �EV�R�P OKURKEN SURNAME -> lASTNAME OLUR
        // OBJEDE DE����KL�K OLMAZ 


        return new JsonResult(student);
        
    }

    [HttpPost]
    public async Task<JsonResult> CreateStudent(CreateStudentCommand command)
    {
        var result = await _mediator.Send(command);
        // AWAIT KALDIRILINCA D�NEN NESENE TASK T�R�NDEN OLUYOR. FARK BURADA.

        
        return new JsonResult(result);
    }
}