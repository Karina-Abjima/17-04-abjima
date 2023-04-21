namespace CityInfo.API.Services
{
    public class LocalMailService : IMailService
    {
        private readonly string mailTo = String.Empty;
        private readonly string mailFrom = String.Empty;
        
        private object _mailFrom;
        private object _mailTo;

        public LocalMailService(IConfiguration configuration) 
        {
            _mailTo = configuration["mailSettings:mailToAddress"];
            _mailFrom = configuration["mailSettings:mailFromAddress"];
           
        }
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
