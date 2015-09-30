namespace SharpSix
{
    using System;
    using System.Threading.Tasks;

    public class Logger
    {
        public static Task LogAsync(string message)
        {
            var task = new Task(() => Console.WriteLine(message));
            task.Start();

            return task;
        }
    }
}