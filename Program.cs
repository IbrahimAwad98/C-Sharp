using System;
using System.Collections.Generic; //för att skapa en lista.
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Bloggen
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string[]> minBlogg = new List<string[]>(); //att skapa en string lista för att spara vektor i listan.
            string[] inlägg = new string[3]; //skapa list och deklara det för att underlätta case 1.


            DateTime currentdatum = DateTime.Now;
            Console.WriteLine(currentdatum.ToString());//datum när programmet starts.
            Console.WriteLine("## Ibrahim Awad ##"); //copyright hehe.

            bool menyVal = true; //starta loop.

            while (menyVal)
            {
                Console.WriteLine("\n\t ¤¤¤¤¤¤ Hej och välkommen till Bloggen!¤¤¤¤¤¤ "); //hälsa användaren
                Console.WriteLine("\n\t[1] - Skriv nytt inlägg i Bloggen: "); //menyval 1 
                Console.WriteLine("\n\t[2] - Skriv ut alla inlägg i Bloggen: "); //menyval 2
                Console.WriteLine("\n\t[3] - Sök inlägg i Bloggen: "); //menyval 3
                Console.WriteLine("\n\t[4] - Rensa allt i Bloggen: "); //menyval 4
                Console.WriteLine("\n\t[5] - Avsluta Programmet.\n\t"); //menyval 5
                Console.Write("Välja gärna ett val: ");


                int menuSelection;
                int.TryParse(Console.ReadLine(), out menuSelection); //att hanteras körtidsfel och fel inmatning

                switch (menuSelection)
                {
                    case 1:
                        Console.Clear();
                        //korta variabels livslängd som skrivs i case 1.
                        inlägg = new string[3]; //vektorerna innehåller tre element. 

                        Console.Write("Skriv in titel: \n"); //användaren skriver in title.
                        inlägg[0] = Console.ReadLine(); //element för title.

                        Console.Clear(); //att rensa konsolen med methoden clear.
                        Console.Write("Skriv in ditt nytt inlägg: \n"); //användaren skriver in nytt inlägg.
                        inlägg[1] = Console.ReadLine(); //element för inlägg (text).
                        minBlogg.Add(inlägg); //att spara de i listan.

                        inlägg[2] = DateTime.Now.ToString(); //trejade element (datum och tid).
                        MenyAvslut();
                        Console.Clear();

                        break;

                    case 2:
                        if (minBlogg.Count != 0) //villkor.
                        {
                            foreach (string[] item in minBlogg) //foreach metod för att urskrift.
                            {
                                Console.WriteLine("Här är dina inlägg! \t" + item[2]); //skriva ut datum av element. 
                                Console.WriteLine("Titel: " + item[0] + "\nInlägg: " + item[1]); //repsentera resultat.
                            }

                        }
                        else
                        {
                            Console.WriteLine("Det Finns inget att skriva ut"); //fel meddelande.         
                        }
                        MenyAvslut();
                        break;

                    case 3:                                                                 //(Binär Sökning).
                         Console.Write("Sök ditt inlägg här: "); //ge använadaren att söka.
                            string sökord = Console.ReadLine(); //keyword för sökning.
                            bool wordFound= false; //vi starta en bool för att rätta om ordet finns eller inte.
                            // jag har tagit bort for-loop då har jag använad bool för både villkoret. 
                            // MEN användaren har lagt samma element många gånger då sökning visar ett resultat, d.v.s en element.
                            // denna är en positiv lösning av användning bool som hjälper mig vid deklaration av samma element. 
                            foreach (string[] item in minBlogg) //en loop för att söka genom. 
                            {
                                    if (item.Contains(sökord)) //om sökning inträffas då presenserta samma och alla såsom case2 (contains istället =).
                                    {
                                        Console.WriteLine("Här är dina inlägg! \t" + item[2]);
                                        Console.WriteLine("Titel: " + item[0] + "\nInlägg: " + item[1]); //repsentera resultat.
                                        wordFound = true; //bool avslutas vid hittades ordet.
                                        break;
                                    }    
                            }  
                            if (!wordFound) //andra villkor. 
                             {
                                 Console.WriteLine("Sökning Misslyckades! Finns ej listan."); //fel meddelande!.
                             }
                        MenyAvslut();
                        break;

                    case 4:
                        minBlogg = new List<string[]>(); //att rensa allt såsom starta ny.
                        Console.WriteLine("Bloggen rensades!");
                        break;

                    case 5:
                        menyVal = false; //här kan användaren avsluta programmet så att loop avslutas.
                        Console.WriteLine("Tack för den här gången!");
                        Console.WriteLine("Hejdå!");
                        break;
                }
            }
        }
        static void MenyAvslut() //en metod för att minska repetaring av kod.
        {
            Console.ForegroundColor = ConsoleColor.Yellow; //färg för texten.
            Console.WriteLine("\n\tTryck ENTER för att återvända till menyn.");
            Console.ReadLine();
            Console.ResetColor(); //återställa färgen.
        }
    }
}








