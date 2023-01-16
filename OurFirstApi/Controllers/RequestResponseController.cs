using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OurFirstApi.Linq;
using OurFirstApi.Models;

namespace OurFirstApi.Controllers;

[Route("api/[controller]")]
public class RequestResponseController : ControllerBase
{
    [HttpGet]
    [Route("student/{number}")]
    public JsonResult GetStudent(int number)
    {
        Database db = new Database();
        var student = db.Students.FirstOrDefault(f => f.Number == number);
        var response = new ResponseModel
        {
            StatusCode = 200,
            Message = "Success",
            Data = student
        };
        return new JsonResult(response);
    }

    [HttpGet]
    [Route("students")]
    public JsonResult GetStudents()
    {
        Database db = new Database();
        var response = new ResponseModel
        {
            StatusCode = 200,
            Message = "Success",
            Data = db.Students
        };
        return new JsonResult(response);
    }
    [HttpPost] // K��EL� PARANTEZ ���NE YAZILANLAR ATTRIBUTE OLUR, ATTRIBUTE DE B�R CLASS DIR.
               // NE YAPACA�INI S�YLUYOR BURADA
    [Route("student")]
    public JsonResult CreateStudent([FromBody]CreateStudentRequest request)
    //FROM BODY KOYMAZSAK E�ER API FORM OLARAK ALGILAR!!!
    {
        Database db = new Database();
        
        var maxNumber = db.Students.MaxBy(m => m.Number)!.Number; 
        //MAXBY KULLANIRKEN HANG� �ZELL��E G�RE SIRALAYACA�IMIZI VERMEL�Y�Z
        var newNumber = maxNumber + 1; // YEN� KAYDED�LEN MAX NUMBERDEN B�R FAZLA OLACAK YAN� OTO. ARTTIRMAK G�B�
        
        var newStudent = new Student  //B�REB�R DB MODEL�N�N AYNISI OLSA B�LE MAN�PULE EDEB�LME �H�TMALI
                                      //DOLAYISIYLA YEN� MODEL OLU�TURUP, ENT�TY BU KATMANDA SAKLANMALIDIR.
        {
            Number = newNumber,
            Name = request.Name,
            Surname = request.Surname,
            Height = request.Height,
            Color = request.Color,
            Rank = request.Rank
        };
        db.Students.Add(newStudent);
        
        var response = new ResponseModel
        {
            StatusCode = 200,
            Message = "Success",
            Data = newStudent
        };
        return new JsonResult(response);
    }
    
    [HttpPut] //UPDATE ���N KULLANILIR
    [Route("student")]
    public JsonResult UpdateStudent([FromBody]UpdateStudentRequest request)
    {
        Database db = new Database();

        var student = db.Students.FirstOrDefault(f => f.Number == request.Number);
        if (student == null)
        {
            var errorResponse = new ResponseModel
            {
                StatusCode = 404,
                Message = "Not Found",
                Data = null
            };
            return new JsonResult(errorResponse);
        }

        student.Color = request.Color;
        student.Rank = request.Rank;
        
        
        var response = new ResponseModel
        {
            StatusCode = 200,
            Message = "Success",
            Data = student
        };
        return new JsonResult(response);
    }
    
    [HttpDelete]  //DELETE ���N REQUEST MODEL OLU�TURMAYA GEREK YOK
    [Route("student/{number}")]
    public JsonResult DeleteStudent(int number)
    {
        Database db = new Database();
        var student = db.Students.FirstOrDefault(f => f.Number == number);
        if (student == null)
        {
            var errorResponse = new ResponseModel
            {
                StatusCode = 404,
                Message = "Not Found",
                Data = null
            };
            return new JsonResult(errorResponse);
        }

        db.Students.Remove(student);
        
        var response = new ResponseModel
        {
            StatusCode = 200,
            Message = "Success",
            Data = db.Students
        };
        return new JsonResult(response);
    }

}