using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary1;
using SQLite;

namespace ZnamkyConsole {
    class Program {
        static List<Marks> loadedMarks = new List<Marks>();

        static bool exit = false;
        static string SubjectNew;

        static void Main(string[] args) {
            Console.WriteLine("Žákovská:");
            do {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("1]Zobrazit známky");
                Console.WriteLine("2]Zapsat známku");
                Console.WriteLine("3]Exit" + "\n");
                Console.ResetColor();
                char r = Console.ReadKey().KeyChar;
                int menu = (int)Char.GetNumericValue(r);
                if (menu == 1) {
                    Console.Clear();
                    Console.WriteLine("Vyber předmět:");
                    writesubjects();
                    
                    int SubjectRead = Int32.Parse(Console.ReadLine());
                    if (SubjectRead == 1) {
                        SubjectNew = "Anglický jazyk";
                    } else if (SubjectRead == 2) {
                        SubjectNew = "Animační a vizualizační systémy";
                    } else if (SubjectRead == 3) {
                        SubjectNew = "Český jazyk a literatura";
                    } else if (SubjectRead == 4) {
                        SubjectNew = "Ekonomika";
                    } else if (SubjectRead == 5) {
                        SubjectNew = "Matematika";
                    } else if (SubjectRead == 6) {
                        SubjectNew = "Německý jazyk";
                    } else if (SubjectRead == 7) {
                        SubjectNew = "Operační systémy";
                    } else if (SubjectRead == 8) {
                        SubjectNew = "Počítačové sítě";
                    } else if (SubjectRead == 9) {
                        SubjectNew = "Praktická cvičení";
                    } else if (SubjectRead == 10) {
                        SubjectNew = "Tělesná výchova";
                    } else if (SubjectRead == 11) {
                        SubjectNew = "Vývoj aplikací a her";
                    } else if (SubjectRead == 12) {
                        SubjectNew = "Základy společenských věd";
                    }
                    Console.Clear();
                    loadMarks(SubjectNew);
                }
                if (menu == 2) {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Předmět:");
                    writesubjects();
                    Console.ForegroundColor = ConsoleColor.Green;

                    int SubjectRead = Int32.Parse(Console.ReadLine());
                    if (SubjectRead == 1) {
                        SubjectNew = "Anglický jazyk";
                    } else if (SubjectRead == 2) {
                        SubjectNew = "Animační a vizualizační systémy";
                    } else if (SubjectRead == 3) {
                        SubjectNew = "Český jazyk a literatura";
                    } else if (SubjectRead == 4) {
                        SubjectNew = "Ekonomika";
                    } else if (SubjectRead == 5) {
                        SubjectNew = "Matematika";
                    } else if (SubjectRead == 6) {
                        SubjectNew = "Německý jazyk";
                    } else if (SubjectRead == 7) {
                        SubjectNew = "Operační systémy";
                    } else if (SubjectRead == 8) {
                        SubjectNew = "Počítačové sítě";
                    } else if (SubjectRead == 9) {
                        SubjectNew = "Praktická cvičení";
                    } else if (SubjectRead == 10) {
                        SubjectNew = "Tělesná výchova";
                    } else if (SubjectRead == 11) {
                        SubjectNew = "Vývoj aplikací a her";
                    } else if (SubjectRead == 12) {
                        SubjectNew = "Základy společenských věd";
                    }

                    Console.WriteLine("\nZnámka:");
                    char ValueChar = Console.ReadKey().KeyChar;
                    int ValueNew = (int)Char.GetNumericValue(ValueChar);
                    Console.WriteLine();
                    Console.WriteLine("Váha:");
                    int WeightNew = Int32.Parse(Console.ReadLine());
                    Console.ResetColor();
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Kniha byla přidána!");
                    Console.ResetColor();
                    saveMarks(SubjectNew, ValueNew, WeightNew);
                }
                if (menu == 3) {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ukončuji...");
                    exit = true;
                }
            } while (exit == false);
        }

        static async void saveMarks(string subject, int value, int weight) {
            await MySQL.Database.SaveItemAsync(new Marks { Subject = subject, Value = value, Weight = weight });
        }
        static async void loadMarks(string subject) {
            loadedMarks = await MySQL.Database.GetItemsAsync();
                        Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Známky z " + subject);
            Console.ResetColor();
            var loadedMarksCopy = loadedMarks.Where(s => s.Subject == subject);
            if (loadedMarksCopy.Count() > 0) {
                foreach (Marks mark in loadedMarksCopy) {
                    Console.WriteLine("ID: {0} - Předmět: {1} - Známka: {2} - Váha: {3}", mark.Id, mark.Subject, mark.Value, mark.Weight);
                }
            } else {
                Console.WriteLine("Z předmětu nemáte žádnou známku!");
            }
        }

        static void writesubjects() {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("1] Anglický jazyk");
            Console.WriteLine("2] Animační a vizualizační systémy");
            Console.WriteLine("3] Český jazyk a literatura");
            Console.WriteLine("4] Ekonomika");
            Console.WriteLine("5] Matematika");
            Console.WriteLine("6] Německý jazyk");
            Console.WriteLine("7] Operační systémy");
            Console.WriteLine("8] Počítačové síťe");
            Console.WriteLine("9] Praktická cvičení");
            Console.WriteLine("10] Tělesná výchova");
            Console.WriteLine("11] Vývoj aplikací a her");
            Console.WriteLine("12] Základy společenských věd");
            Console.ResetColor();
        }
    }
}