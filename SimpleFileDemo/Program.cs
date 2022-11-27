namespace SimpleFileDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string file = @"D:\new.txt";

            FileInfo f1 = new FileInfo(file);

           using (StreamReader reader = new StreamReader(file))
            {
                /////
            }

        }
    }
}