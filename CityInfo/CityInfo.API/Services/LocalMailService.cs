namespace CityInfo.API.Services
{
    public class LocalMailService
    {
        
        private string mailFrom = "noreply@mycompany.com";
        private string mailTo = "admin@mycompany.com";
        private object _mailFrom;
        private object _mailTo;

        public void Send(string subject, string message)
        {
            //send mail-to output window

            Console.WriteLine($"Mail from {_mailFrom}to{_mailTo}," +
                $"with{nameof(LocalMailService)}.");
            Console.WriteLine($"Subject:{subject}");
            Console.WriteLine($"Subject:{message}");

        }
            
            
            
    }
}
