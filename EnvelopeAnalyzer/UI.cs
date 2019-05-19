using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvelopeAnalyzer
{
    public static class UI
    {
        public static void DoUI()
        {
            bool isEndSession = true;
            Console.WriteLine(string.Format("===========TASK 2==========="));
            do
            {
                AnalyzeEnvelopes();
                Console.WriteLine(string.Format("Do you want continue?"));
                string response = Console.ReadLine();
                response = response.ToUpperInvariant();
                if (response == "YES" || response == "Y")
                {
                    isEndSession = false;
                }
                else
                {
                    isEndSession = true;
                }
            }
            while (!isEndSession);

      
        }
        private static double ReadFromConsoleParametrForEnvelope(string numberEnvelope,string numberSide)
        {
            bool isReaded = false;
            double readedParametr = 0;

            do
            {
                Console.WriteLine(string.Format("Input the size {0}  parametr for {1} envelop", numberSide,numberEnvelope));
                if(double.TryParse(Console.ReadLine(),out readedParametr) && readedParametr > 0)
                {
                    isReaded = true;
                }
                else
                {
                    Console.WriteLine(string.Format("Wrong input!"));
                }


            } while (!isReaded);

            return readedParametr;
        }
        private static void AnalyzeEnvelopes()
        {
            Envelope firstEnvelope = new Envelope(ReadFromConsoleParametrForEnvelope("first", "first"), ReadFromConsoleParametrForEnvelope("first", "second"));
            Envelope secondEnvelope = new Envelope(ReadFromConsoleParametrForEnvelope("second", "first"), ReadFromConsoleParametrForEnvelope("second", "second"));
            if (firstEnvelope.IsCanPutInEnvelope(secondEnvelope))
            {
                Console.WriteLine(string.Format("We can put one of the envelopes in another"));
            }
            else
            {
                Console.WriteLine(string.Format("We cann`t put one of the envelopes in another"));
            }
            
        }
    }
}
