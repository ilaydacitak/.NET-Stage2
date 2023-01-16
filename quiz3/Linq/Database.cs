namespace quiz3.Linq
{
    public class Database
    {
        public Database()
        {
            emails = new List<Email>
            {
                new()
                {
                    email = "ilaydaa.citakk@gmail.com"
                },
                new()
                {
                    email = "mrs.citak@gmail.com"
                }
            };
        }

        public List<Email> emails { get; set; }




    }
    public class Email
    {
        public string email { get; set; }

    }




}
