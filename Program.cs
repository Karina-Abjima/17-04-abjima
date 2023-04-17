using System;
namespace Test
{

    class Program
    {
        public static void Main(string[] args)
        {   
            //using (var printcsv = new PrintCSV())
            var printcsv = new PrintCSV(5,4);
            try
            {
                printcsv.PrintCSv();
            }
            finally
            {
                ((IDisposable)printcsv).Dispose();
            }
           
            GC.SuppressFinalize(printcsv); 
            printcsv.add();

        }

      public  class Print : IDisposable
        {
            public void Dispose()
            {
                Console.WriteLine("Here to dispose unused resources");
            }
        }

      public  class PrintCSV : Print
        {
            public int a, b;
            public PrintCSV(int A,int B)
            {
                a=A;

                b = B;
            }
            public new void Dispose()
            {
                Console.WriteLine("Disposing PrintCSV");
            }
            public void PrintCSv()
            {
                Console.WriteLine("just to print");
            }

           public void add()
            {
                Console.WriteLine(a+b);
            }
        }
    }
}