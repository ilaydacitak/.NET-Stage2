namespace OurFirstApi.Models;

public class CreateStudentRequest
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Color { get; set; }
    public int Height { get; set; }
    public int Rank { get; set; }
}