using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OurFirstApi.Filters;
using OurFirstApi.Linq;

namespace OurFirstApi.Controllers;

[Route("api/[controller]")]

public class ExceptionTestController :ControllerBase
{

    private readonly IConfiguration _configuration;
    public ExceptionTestController(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    [HttpGet]
    public string FirstEndpoint()
    {
        return "OK";
    }
    [HttpGet]
    [Route("config-test")]
    public string ConfigTest()  // PROGRAMDA OKUDUÐUMU GÝBÝ BURADA DA OKUAYBÝLÝRÝZ
    {
        var secretKey = _configuration.GetValue<string>("Secrets:SecretKey");
        var accessKey = _configuration.GetValue<int>("Secrets:AccessKey");
        var count = _configuration.GetValue<int>("Secrets:Props:Count");

        var copyrightOwner = _configuration.GetValue<string>("Copyright:Owner");
        return "OK";
    }
    [HttpGet]
    [Route("linq-test")]
    public string LinqTest()
    {
        Database db = new Database();
        //var studentCount = db.Students.Count;
        var numbers = new List<int> { 1, 1, 2, 3, 4, 5, 6, 6, 8, 0, 16, 7, 7 };
        //WHERE
        var students = db.Students.Where(s => s.Surname == "Kaya").ToList();
        //SELECT
        var names = db.Students.Where(s => s.Surname == "Kaya").Select(s => new { s.Name,s.Color}).ToList();
        //FIRST OR DEFAULT
        var firstStudent = db.Students.FirstOrDefault(s => s.Surname == "Kaya" && s.Color == "Blue");
       
        var firstStudent2 = db.Students.FirstOrDefault(s => s.Surname == "Kaya");
        var firstStudent3 = db.Students.First(s => s.Surname == "Kaya");
        var lastStudent = db.Students.LastOrDefault(s => s.Surname == "Kaya");
        var lastStudent2 = db.Students.Last(s => s.Surname == "Kaya");
        var ranksCount = db.Students.Count(t => t.Rank > 80);

        var orderedStudentList = db.Students.OrderBy(g => g.Height).ToList();
        var orderedStudentListDesc = db.Students.OrderByDescending(g => g.Height).ToList();
        var sumOfHeights = db.Students.Where(t=>t.Color=="Red").Sum(s => s.Height);
        //ANY
        var hasRedColor = db.Students.Any();
        
        //ALL
        var isOK = db.Students.All(c => c.Number>0);

         numbers.Reverse();
         numbers = numbers.Distinct().ToList();
         numbers = numbers.Except(new List<int> { 1 }).ToList();
         var max = db.Students.MaxBy(m=>m.Height);
         numbers.Add(66);
         numbers.Remove(5);
         numbers.RemoveAll(f => f.Equals(4));
         numbers.Clear();
         numbers.Exists(f => f == 5);
         numbers.Any(f => f == 5);
         numbers.AddRange(new List<int>{1,3});
         //GROUP BY
         var groupedByColor = db.Students.GroupBy(g => g.Color);
         var response = new List<GroupedStudent>();
         
         foreach (var group in groupedByColor)
         {
             var groupName = group.Key;
             var sameGroupedStudents = group.ToList();
             response.Add(new GroupedStudent
             {
                 GroupName = groupName,
                 Students = sameGroupedStudents
             });
         }

         var groupedByTwoProps = db.Students.GroupBy(g => new { g.Color, g.Surname });
         foreach (var groupedBy in groupedByTwoProps)
         {
             var colorName = groupedBy.Key.Color;
             var surname = groupedBy.Key.Surname;
             var students2 = groupedBy.ToList();
         }
         
        return "OK";
    }
    
    
    [HttpGet]
    [Route("filter-test")]
    
    [TestActionFilter]
    public IActionResult FilterTest()
    {
        try
        {
            var response = new Response
            {
                Message = "ÇITAK"
            };
            return new ContentResult
            {
                Content = JsonConvert.SerializeObject(response)
            }; 
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }
    
}