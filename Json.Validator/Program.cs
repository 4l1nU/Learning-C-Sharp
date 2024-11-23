using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json
{
    public class Program
    {
        static void Main(string[] args)
        {
            foreach (var element in args)
            {
                var value = new Value();
                try
                {
                    using var sr = new StreamReader(element);
                    IMatch match = value.Match(new StringView(0, sr.ReadToEnd()));
                    Console.WriteLine(
                        "{0}", match.Success() && match.RemainingText().IsEmpty() ? "Json valid!" : "Json nevalid!");
                }
                catch (IOException e)
                {
                    Console.WriteLine("The file could not be read:");
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}