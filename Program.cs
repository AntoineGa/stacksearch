using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stacksearch
{
    public class Program
    {
        public static int Main(string[] args)
        {
            var currentColor = Console.ForegroundColor;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("                  ++++++                ");
            Console.WriteLine("                ++++++++++++             ");
            Console.WriteLine("              ++++++++++++++++           ");
            Console.WriteLine("              ++++++++++++++++           ");
            Console.WriteLine("             ++++++       :+++++++++     ");
            Console.WriteLine("          ++ ++++. +++++++  +++++++++    ");
            Console.WriteLine("        ++++++++~ ++++++++++ ++++++++    ");
            Console.WriteLine("       +++++++++ +++++++++++  +++++++    ");
            Console.WriteLine("    ++++++++++++ ++++++++++++ +++++++    ");
            Console.WriteLine("  ++++++++++++++ +++++++++++  +++++++++  ");
            Console.WriteLine(" ++++++++++++++++ ++++++++++ +++++++++++ ");
            Console.WriteLine(" +++++++++++++++   .++++++  ++++++++++++ ");
            Console.WriteLine(" +++++++++++++   ++~      +++++++++++++++");
            Console.WriteLine(" ++++++++++++  ~+++++++++++++++++++++++++");
            Console.WriteLine(" ++++++++++   ++++++++++++++++++++++++++ ");
            Console.WriteLine("  +++++++++++++++++++++++++++++++++++++  ");
            Console.WriteLine("   +++++++++++++++++++++++++++++++++++   ");
            Console.WriteLine("     +++++++++++++++++++++++++++++++     ");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("StackExchange CommandLine - Azure Search");
            Console.WriteLine("----------------------------------------");
            
           Console.ForegroundColor = currentColor;
            while(true){
                Console.Write("Ingrese un texto a buscar y presione ENTER o EXIT para terminar:");
                var text = Console.ReadLine().Trim();
                if("exit".Equals(text.ToLowerInvariant()))break;
                Console.Clear();
                WriteColorAndReturn(currentColor, ConsoleColor.Cyan, string.Format("Buscando [{0}]...", text),true);
                var results = SearchService.SearchDocuments(text,string.Empty, string.Empty);
                if(!results.Any()){
                    Console.WriteLine("No se han encontrado resultados :(");
                    Console.WriteLine("----------------------------------");
                }
                else{
                    foreach(var entry in results){
                        WriteColorAndReturn(currentColor, ConsoleColor.DarkCyan, "Titulo: ");
                        Console.WriteLine(entry.Title);
                        WriteColorAndReturn(currentColor, ConsoleColor.DarkCyan, "Respuestas: ");
                        Console.WriteLine(entry.AnswerCount);
                        WriteColorAndReturn(currentColor, ConsoleColor.DarkCyan, "Comentarios: ");
                        Console.WriteLine(entry.CommentCount);
                        WriteColorAndReturn(currentColor, ConsoleColor.DarkCyan, "Creada: ");
                        Console.WriteLine(entry.CreationDate.ToString("dd/MM/yyyy HH:mm"));
                        WriteColorAndReturn(currentColor, ConsoleColor.DarkCyan, "Ultima actividad: ");
                        Console.WriteLine("Ultima actividad: {0}", entry.LastActivityDate.ToString("dd/MM/yyyy HH:mm"));
                        WriteColorAndReturn(currentColor, ConsoleColor.DarkCyan, "Pregunta: ");
                        Console.WriteLine(entry.Body);
                        Console.WriteLine("----------------------------------");
                        WriteColorAndReturn(currentColor, ConsoleColor.Cyan, "<Presione una tecla para más resultados>",true);
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
            }
            return 0;
        }
        
        private static void WriteColorAndReturn(ConsoleColor currentColor, ConsoleColor colorToUse, string text, bool returnLine = false){
            
            Console.ForegroundColor = colorToUse;
            if(returnLine){
                Console.WriteLine(text);    
            }else{
                Console.Write(text);
            }
            Console.ForegroundColor = currentColor;
        }
    }
    
    
}
