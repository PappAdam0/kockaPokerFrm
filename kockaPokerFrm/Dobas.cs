using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kockaPokerFrm
{
    class Dobas
    {
        int[] kockak = new int[5];

        public int[] Kockak
        {
            get
            {
                return kockak;
            }
        }
        public string Eredmeny
        {
            get
            {
                return eredmeny;
            }
        }
        private string eredmeny;

        private int pont;
        public int Pont
        {
            get
            {
                return pont;
            }
        }
        public int Nyert { get; set; }
        public Dobas()
        {
            Nyert = 0;
        }
        public Dobas(int k1, int k2, int k3, int k4, int k5)
        {
            kockak[0] = k1;
            kockak[1] = k2;
            kockak[2] = k3;
            kockak[3] = k4;
            kockak[4] = k5;

            eredmeny = Erteke();
        }

        public void EgyDobas()
        {
            Random vel = new Random(Guid.NewGuid().GetHashCode());

            for (int i = 0; i < kockak.Length; i++)
            {
                kockak[i] = vel.Next(1, 7);
            }
            eredmeny = Erteke();

        }

        public void Kiiras()
        {
            foreach (var i in kockak)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine($"-> {eredmeny}");


        }

        public string Erteke()
        {
            Dictionary<int, int> eredmenyek = new Dictionary<int, int>();
            for (int i = 0; i <= 6; i++)
            {
                eredmenyek.Add(i, 0);
            }
            foreach (var i in kockak)
            {
                eredmenyek[i]++;
            }

            /*Dictionarybol lekérdezzük az 1 Valuenal nagyobb elemeket
             * Első esetnél ha egy elem marad (valuet nézzük),
             *  5 -> nagypóker
             *  4 -> Póker
             *  3 -> Drill
             *  2 -> Pár
             * Key érték mondja meg hogy hányas pl: 4-es Póker
             * 2. Eset 2 elem marad
             *  Value 3 és 2 -> Full
             *  Value 2 és 2 -> 2 Pár
             * 3. Eset nem marad egy sem
             *  Ha key 6 == 0 kis sor vagy key 1 == 0 nagy sor
             * Minden más esetben moslék
            */

            var result = (from e in eredmenyek
                          where e.Value > 1
                          orderby e.Value descending
                          select new { Szam = e.Key, Db = e.Value }).ToList();
            Console.WriteLine();

            int darab = result.Count;
            if (darab == 1)
            {
                string[] egyes = new string[] { "", "", "Pár", "Drill", "Póker", "Nagypóker" };

                int[] pontok = new int[] { 0, 0, 10, 300, 600, 900 };
                pont = pontok[result[0].Db] + result[0].Szam;

                return $"{result[0].Szam} {egyes[result[0].Db]}";


                //switch (result[0].Db)
                //{
                //    case 5:

                //        return $"{result[0].Szam} Nagypóker";
                //    case 4: return $"{result[0].Szam} Póker";
                //    case 3: return $"{result[0].Szam} Drill";
                //    case 2: return $"{result[0].Szam} Pár";

                //}
            }
            else if (darab == 2)
            {
                if (result[0].Db == 3 && result[1].Db == 2)
                {
                    pont = 500 + (result[0].Szam * 10 + result[1].Szam);
                    return $"{result[0].Szam}-{result[1].Szam} Full";
                }
                else
                {
                    pont = 100 + (result[0].Szam * 10 + result[1].Szam);
                    return $"{result[1].Szam}-{result[0].Szam} Pár";
                }
            }
            else
            {
                if (eredmenyek[6] == 0)
                {
                    pont = 700;
                    return "Kissor";
                }
                else if (eredmenyek[1] == 0)
                {
                    pont = 800;
                    return "Nagysor";
                }

            }

            pont = 1;
            return "Szemét";
        }
    }
}
