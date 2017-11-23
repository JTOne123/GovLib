using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Gov.NET.Models;
using Gov.NET.ProPublica;
using ConsoleColors;

namespace TestApp
{
    class Program
    {
        static string civicKey = Environment.GetEnvironmentVariable("GOOGLE_KEY");
        static string publicaKey = Environment.GetEnvironmentVariable("PUBLICA_KEY");
        static string homeDir = Environment.GetEnvironmentVariable("HOME");
        static Congress Congress = new Congress(publicaKey);

        static void Main(string[] args)
        {
            if (args.Length == 0)
                PrintHelp();
            else
                ParseArgs(args);
        }

        static void ParseArgs(string[] args)
        {
            switch (args[0])
            {
                case "all-senators":
                    PrintAllSens();
                    break;
                case "all-reps":
                    PrintAllReps();
                    break;
                case "new-members":
                    PrintNewMembers();
                    break;
                case "get-member":
                    if (args.Length < 2)
                        Console.WriteLine("You must specify an ID");
                    else
                        PrintFromID(args[1]);
                    break;
                default:
                    PrintHelp();
                    break;
            }
        }

        static void WriteToFile(JObject json, string name)
        {
            var frmt = JsonConvert.SerializeObject(json, Formatting.Indented);
            File.WriteAllText($"{homeDir}/Desktop/all-info/{name}.json", frmt);
        }

        static void PrintAllSens()
        {
            var members = Congress.Members.GetAllSenators(115);
            SortedPrint(members);
        }

        static void PrintAllReps()
        {
            var members = Congress.Members.GetAllRepresentatives(115);
            SortedPrint(members);
        }

        static void PrintNewMembers()
        {
            var members = Congress.Members.GetNewMembers();
            SortedPrint(members);
        }

        static void PrintCruz()
        {
            var cruz = Congress.Members.GetMemberByID("C001098");
            Console.WriteLine(cruz);
        }

        static void PrintMrSpeaker()
        {
            var paulRyan = Congress.Members.GetMemberByID("R000570");
            Console.WriteLine(paulRyan);
        }

        static void PrintFromID(string id)
        {
            var mem = Congress.Members.GetMemberByID(id);
            if (mem != null)
                Console.WriteLine(mem);
            else
                Console.WriteLine($"Invalid ID: {id}");
        }
        static void PrintHelp()
        {
            Console.WriteLine("\n---------- ProPublica Test App ----------\n"
                            + "  Options:\n"
                            + "    - all-senators\n"
                            + "    - all-reps\n"
                            + "    - new-members\n"
                            + "    - get-member [ID]\n"
                            + "------------------------------------------\n"
                            );
        }

        public static void BasicPrint(IEnumerable<Politician> members)
        {
            foreach (var mem in members)
            {
                if (mem.Party == "D")
                    Printer.WriteLine($"{Clr.Blue}{mem}{Clr.Default}");
                else if (mem.Party == "R")
                    Printer.WriteLine($"{Clr.Red}{mem}{Clr.Default}");
                else
                    Console.WriteLine(mem);
            }
        }

        public static void SortedPrint(IEnumerable<Politician> members)
        {
            var dems = members.Where(s => s.Party == "D");
            var reps = members.Where(s => s.Party == "R");
            var inds = members.Where(s => s.Party != "D" && s.Party != "R");
            var dCount = dems.Count();
            var rCount = reps.Count();
            var iCount = inds.Count();

            Printer.WriteLine($"\n{Clr.Blue}{Frmt.Bold}Democrats ({dCount}):{Reset.Code}{Clr.Blue}");
            foreach (var sen in dems)
                Console.WriteLine($"{sen}");

            Printer.WriteLine($"\n{Clr.Red}{Frmt.Bold}Republicans ({rCount}):{Reset.Code}{Clr.Red}");
            foreach (var sen in reps)
                Console.WriteLine($"{sen}");

            Printer.WriteLine($"\n{Reset.Code}{Frmt.Bold}Independents ({iCount}):{Reset.Code}");
            foreach (var sen in inds)
                Console.WriteLine($"{sen}");

            Console.WriteLine();
        }
    }
}
