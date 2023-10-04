namespace Opgavesæt_08___Opgave_2
{
    internal class Program
    {
        static int mainSum;
        static Random Rand;
        static object mainSumLock;
          
        static void MakeSum()
        {
            int mySum = 0;

            for (int i = 0; i < 1000; i++)
            {
                Thread.Sleep(Rand.Next(10));
                int a = Rand.Next(10);
                mySum += a;

                lock (mainSumLock)
                {
                    mainSum += a;
                }

            }

            Console.WriteLine(mySum);
        }

        static void SubtractSum()
        {
            int mySum = 0;

            for (int i = 0; i < 1000; i++)
            {
                Thread.Sleep(Rand.Next(10));
                int a = Rand.Next(10);
                mySum += a;

                lock (mainSumLock)
                { 
                    mainSum -= a; 
                }
            }

            Console.WriteLine(-mySum);
        }

        static void Main(string[] args)
        {
            mainSum = 0;
            Rand = new Random();
            mainSumLock = new object();

            var t1 = new Thread(new ThreadStart(MakeSum));
            var t2 = new Thread(new ThreadStart(MakeSum));
            var t3 = new Thread(new ThreadStart(MakeSum));
            t1.Start();
            t2.Start();
            t3.Start();

            t1.Join();
            t2.Join();
            t3.Join();
            
            Console.WriteLine(mainSum);
        
            t1 = new Thread(new ThreadStart(SubtractSum));
            t2 = new Thread(new ThreadStart(SubtractSum));
            t3 = new Thread(new ThreadStart(SubtractSum));
            
            t1.Start();
            t2.Start();
            t3.Start();

            t1.Join();
            t2.Join();
            t3.Join();
        
            Console.WriteLine(mainSum);
        }
    }
}