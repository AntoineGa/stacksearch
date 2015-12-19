using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stacksearch
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("StackExchange CommandLine - Azure Search");
            Console.WriteLine("----------------------------------------");
            
           
            while(true){
                Console.Write("Ingrese un texto a buscar y presione ENTER o EXIT para terminar:");
                var text = Console.ReadLine();
                if("exit".Equals(text.ToLowerInvariant()))break;
                Console.WriteLine("Buscando [{0}]...", text);
                var results = SearchService.SearchDocuments(text,string.Empty, string.Empty);
                if(!results.Any()){
                    Console.WriteLine("No se han encontrado resultados :(");
                    Console.WriteLine("----------------------------------");
                }
                else{
                    foreach(var entry in results){
                        Console.WriteLine("Titulo: {0}", entry.Title);
                        Console.WriteLine("Respuestas: {0}", entry.AnswerCount);
                        Console.WriteLine("Comentarios: {0}", entry.CommentCount);
                        Console.WriteLine("Creada: {0}", entry.CreationDate.ToString("dd/MM/yyyy HH:mm"));
                        Console.WriteLine("Ultima actividad: {0}", entry.LastActivityDate.ToString("dd/MM/yyyy HH:mm"));
                        Console.WriteLine("Pregunta: {0}", entry.Body);
                        Console.WriteLine("----------------------------------");
                        Console.WriteLine("<Más resultados>");
                        Console.ReadKey();
                    }
                }
            }
        }
    }
}
