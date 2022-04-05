using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;    

namespace KlasaPath
{
    internal class Program
    {
        static void Main(string[] args)
        {


            string[] nazivi = new string[5]; 
            string prviDirektorij = @"C:\prviDir";
            string drugiDirektorij = @"C:\drugiDir";

            if (!Directory.Exists(prviDirektorij))
            {
                Directory.CreateDirectory(prviDirektorij);
            }
            if (!Directory.Exists(drugiDirektorij))
            {
                Directory.CreateDirectory(drugiDirektorij);
            }

            for(int i = 0; i < 5; i++)
            {
                nazivi[i] = "Datoteka" + i;
                if (!File.Exists(@"C:\prviDir\" + nazivi[i]))
                {
                    File.Create(@"C:\prviDir\" + nazivi[i]);
                }
            }

            try
            {
                foreach(string datoteka in Directory.GetFiles(prviDirektorij))
                {
                    string imeDatoteka = Path.GetFileName(datoteka);
                    string ciljnaDatoteka = Path.Combine(drugiDirektorij, imeDatoteka);

                    File.Copy(datoteka, ciljnaDatoteka, true);
                }

                Console.WriteLine("It is Done");


            }
            catch(Exception greska)
            {
                Console.WriteLine("Greška: {0}", greska.Message);
            }
            Console.ReadKey();
        }
    }
}
