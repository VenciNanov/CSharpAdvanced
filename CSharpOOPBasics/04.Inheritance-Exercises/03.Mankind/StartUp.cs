using System;


public class StartUp
{
    static void Main(string[] args)
    {
        GetHumans();
    }

    private static void GetHumans()
    {
        var studentData = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        var workerData = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        try
        {
            var student = new Student(studentData[0], studentData[1], studentData[2]);
            var worker = new Worker(workerData[0], workerData[1], decimal.Parse(workerData[2]), decimal.Parse(workerData[3]));

            Console.WriteLine(student);
            Console.WriteLine(worker);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}

