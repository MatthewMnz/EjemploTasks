using System.Threading.Tasks;

namespace EjemploTasks
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Ejemplo con Tareas");

            Task<List<int>> parTask = Task.Run(() => ReadAndProcessData("Pares.txt", 0, 20, 2));
            Task<List<int>> imparTask = Task.Run(() => ReadAndProcessData("Impares.txt", 1, 19, 2));

            var results = await Task.WhenAll(parTask, imparTask);

            Console.WriteLine("Procesamiento finalizado");
            Console.WriteLine($"Numeros pares procesados: {string.Join(",", results[0])}");
            Console.WriteLine($"Numeros impares procesados: {string.Join(",", results[1])}");
        }

        static List<int> ReadAndProcessData(string Name, int start, int end, int step)
        {
            Console.WriteLine($"Leyendo datos de {Name}");
            List<int> data = new List<int>();

            for (int i = start; i < end; i += step)
            {
                Console.WriteLine($"{Name} procesando dato: {i}");
                data.Add(i);
                Thread.Sleep(400);
            }

            return data;
        }
    }
}
