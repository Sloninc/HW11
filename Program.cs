namespace HW11
{
    internal class Program
    {
        static void Main()
        {
            try
            {
                var s = new Stack("a", "b", "c");
                Console.WriteLine($"size = {s.Size}, Top = '{s.Top}'");
                var deleted = s.Pop();
                Console.WriteLine($"Извлек верхний элемент '{deleted}' Size = {s.Size}");
                s.Add("d");
                Console.WriteLine($"size = {s.Size}, Top = '{s.Top}'");
                s.Pop();
                s.Pop();
                s.Pop();
                Console.WriteLine($"size = {s.Size}, Top = {(s.Top == null ? "null" : s.Top)}");
                //s.Pop();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            Console.ReadLine();
        }
    }
}