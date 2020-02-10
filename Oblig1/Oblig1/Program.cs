using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oblig1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Velkommen til det kongelige slektstre!");
            var ListPeople = PersonList();

            while (true)
            {
                Console.Write("Skriv hva du ønsker å gjøre eller hjelp for hjelp: ");

                var input = Console.ReadLine();
                if (input == "hjelp")
                {
                    ShowHelpText();
                    continue;
                }
                if (input == "liste")
                {
                    ShowAllPeople(ListPeople);
                    continue;
                }
                var splitArray = input.Split(' ');
                int id = Convert.ToInt32(splitArray[1]);
                if (splitArray[0] == "vis")
                {
                    if (id > ListPeople.Count)
                    {
                        Console.WriteLine($"Det er ingen med så høy id, den høyeste id'en er: {ListPeople.Count}");
                        continue;
                    }
                    if (id == 0)
                    {
                        Console.WriteLine("Det er ingen med id'en 0.");
                        continue;
                    }
                    if (splitArray.Length > 1)
                    {
                        var PersonId = id - 1;
                        ListPeople[PersonId].Show();
                        foreach (var item in ListPeople)
                        {
                            if (item.Mother != null)
                            {
                                if (ListPeople[PersonId].FirstName == item.Mother.FirstName)
                                {
                                    item.Show();
                                }
                            }
                            if (item.Father != null)
                            {
                                if (ListPeople[PersonId].FirstName == item.Father.FirstName)
                                {
                                    item.Show();
                                }
                            }

                        }
                    }
                    if (input != "hjelp" && input != "liste" && splitArray[0] != "vis")
                    {
                        Console.WriteLine("Du skrev noe feil. Skriv hjelp for kommandoer eller prøv på nytt");
                    }
                }
            }
        }

        private static void ShowAllPeople(List<Person> listPeople)
        {
            for (var i = 0; i < listPeople.Count; i++)
            {
                listPeople[i].Show();
            }
        }

        private static void ShowHelpText()
        {
            Console.WriteLine("Skriv liste for å få opp en liste av alle personer.");
            Console.WriteLine("Skriv f.eks vis 3 (altså vis (id)) for å få opp vedkommende med mor og far.");
            Console.WriteLine("ctrl+c for å avslutte ");
        }
        public static List<Person> PersonList()
        {
            var sverreMagnus = new Person { Id = 1, FirstName = "Sverre Magnus", BirthYear = 2005 };
            var ingridAlexandra = new Person { Id = 2, FirstName = "Ingrid Alexandra", BirthYear = 2004 };
            var haakon = new Person { Id = 3, FirstName = "Haakon Magnus", BirthYear = 1973 };
            var metteMarit = new Person { Id = 4, FirstName = "Mette-Marit", BirthYear = 1973 };
            var marius = new Person { Id = 5, FirstName = "Marius", LastName = "Borg Høiby", BirthYear = 1997 };
            var harald = new Person { Id = 6, FirstName = "Harald", BirthYear = 1937 };
            var sonja = new Person { Id = 7, FirstName = "Sonja", BirthYear = 1937 };
            var olav = new Person { Id = 8, FirstName = "Olav", BirthYear = 1903 };

            sverreMagnus.Father = haakon;
            sverreMagnus.Mother = metteMarit;
            ingridAlexandra.Father = haakon;
            ingridAlexandra.Mother = metteMarit;
            marius.Mother = metteMarit;
            haakon.Father = harald;
            haakon.Mother = sonja;
            harald.Father = olav;

            var list = new List<Person>
            {
            sverreMagnus, ingridAlexandra, haakon, metteMarit, marius, harald, sonja, olav
            };
            return list;
        }
    }
}
