

namespace CSNullBasics
{
    internal class Program
    {
        static void Main()
        {
            Message message = new Message()
            {
                Text = "Hello There",
                From = null
            };

            MessagePopulator.Populate(message);

            Console.WriteLine(message.Text);
            Console.WriteLine(message.From ?? "no from");
            Console.WriteLine(message.From!.Length);
            Console.WriteLine(message.ToUpperFrom());

            Console.WriteLine("Press enter to end");
            Console.ReadLine();
        }
    }
}