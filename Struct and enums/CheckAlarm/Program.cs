using System;
using static System.Formats.Asn1.AsnWriter;

namespace Alarm
{
/*    Problema de rezolvat:

Descarcă proiectul atașat problemei și continuă rezolvarea.Trebuie implementate funcțiile AddDayToAlert și CheckAlarmDay și apoi se trimite – ca de obicei – fișierul Program.cs pentru validare.

Problema:

O alarmă poate fi configurată să se declanșeze la o anumită oră în una sau mai multe zile din săptămână. De exemplu, să se declanșeze la ora 8:00 de luni până vineri și de la ora 10:00 sâmbăta și duminica.

Să se scrie o aplicație consolă ce verifică dacă alarma se declanșează la o oră și zi date.

Datele de intrare se dau astfel:

pe prima linie numărul de alerte configurate
pentru fiecare alertă urmează două linii:
ora alertei în format hh:mm
zilele în care se declanșează (una sau mai multe din următoarele, despărțite între ele printr-un spațiu: Su Mo Tu We Th Fr Sa)
la sfârșit pe ultimile două linii se dau ora și ziua pentru care se face verificarea.
Exemplu:

Pentru datele de intrare:

2
12:00
Mo Tu We
13:30
Th Fr Sa Su
13:30
We
La consolă se va afișa:

False
Validarea Soluției
Rezolvarea trimisă este corectă.

 4/22/2023, 1:50:30 PM - rezolvarea corectă - ascunde detaliie...

Fișier: Program.cs

Rezultate:

Compilare executată cu succes.
Testul 1: Verifică corect o alertă simplă (1, 14:00 Mo, 14:00 Mo) - succes
Testul 2: Verifică corect o alertă simplă ce nu se declanșează la ora dată(1, 14:00 Mo, 15:00 Mo) - succes
Testul 3: Verifică corect o alertă simplă ce nu se declanșează în ziua dată(1, 14:00 Mo, 14:00 Tu) - succes
Testul 4: Verifică corect o alertă mai complexă(1, 14:00 Mo Tu We, 14:00 Tu) - succes
Testul 5: Verifică corect o alertă mai complexă ce nu se declanșează în ziua de dată(1, 14:00 Mo Tu We, 14:00 Th) - succes
Testul 6: Verifică corect mai multe alerte(2, 14:00 Mo Tu We, 17:20 We Th Fr, 17:20 Fr) - succes
Testul 7: Verifică corect mai multe alerte ce nu se declanșează în ziua dată(2, 14:00 Mo Tu We, 17:20 We Th Fr, 14:00 Fr) - succes
Testul 8: Rezolvarea merge cu date de intrare aleatoare - succes
*/
    [Flags]
    public enum Days
    {
        None = 0,
        Su = 1,
        Mo = 1 << 1,
        Tu = 1 << 2,
        We = 1 << 3,
        Th = 1 << 4,
        Fr = 1 << 5,
        Sa = 1 << 6
    }

    public struct Time
    {
        public int Hour;
        public int Minutes;

        public Time(int hour, int minutes)
        {
            this.Hour = hour;
            this.Minutes = minutes;
        }
    }

    public struct Alert
    {
        public Time Time;
        public Days Days;

        public Alert(Time time, Days days = Days.None)
        {
            this.Time = time;
            this.Days = days;
        }
    }

    public class Program
    {
        public static void Main()
        {
            int countOfAlerts = Convert.ToInt32(Console.ReadLine());
            Alert[] alerts = new Alert[countOfAlerts];

            for (int i = 0; i < alerts.Length; i++)
            {
                alerts[i] = ReadAlert();
            }

            Time timeToCheck = ReadTime();
            Days dayToCheck = GetDay(Console.ReadLine());

            Console.WriteLine(CheckAlarm(alerts, timeToCheck, dayToCheck));
            Console.Read();
        }

        public static bool CheckAlarm(Alert[] alerts, Time timeToCheck, Days dayToCheck)
        {
            for (int i = 0; i < alerts.Length; i++)
            {
                if (!CheckAlarmTime(alerts[i].Time, timeToCheck))
                {
                    continue;
                }

                if (CheckAlarmDay(alerts[i].Days, dayToCheck))
                {
                    return true;
                }
            }

            return false;
        }

        public static void AddDayToAlert(ref Alert result, Days day)
        {
            result.Days |= day;
        }

        static bool CheckAlarmDay(Days days, Days dayToCheck)
        {
            return (days & dayToCheck) != 0;
        }

        static bool CheckAlarmTime(Time time, Time timeToCheck)
        {
            return time.Hour == timeToCheck.Hour && time.Minutes == timeToCheck.Minutes;
        }

        static Alert ReadAlert()
        {
            Alert result = new Alert(ReadTime());

            string[] days = Console.ReadLine().Split(' ');
            for (int i = 0; i < days.Length; i++)
            {
                AddDayToAlert(ref result, GetDay(days[i]));
            }

            return result;
        }

        static Time ReadTime()
        {
            string[] time = Console.ReadLine().Split(':');
            return new Time(Convert.ToInt32(time[0]), Convert.ToInt32(time[1]));
        }

        static Days GetDay(string day)
        {
            return day switch
            {
                "Mo" => Days.Mo,
                "Tu" => Days.Tu,
                "We" => Days.We,
                "Th" => Days.Th,
                "Fr" => Days.Fr,
                "Sa" => Days.Sa,
                _ => Days.Su,
            };
        }
    }
}