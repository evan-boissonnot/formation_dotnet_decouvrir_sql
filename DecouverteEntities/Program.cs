using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecouverteEntities
{
    class Program
    {
        static void Main(string[] args)
        {
            using (KartinaEntities context = new KartinaEntities())
            {
                var listVendeurRequete = from vend in context.Vendeur
                                         select vend;

                var maListeDeVendeurs = listVendeurRequete.ToList();

                foreach (var vendeur in maListeDeVendeurs)
                {
                    Console.WriteLine(vendeur.FirstName + ", " + vendeur.LastName);
                }
            }
        }
    }
}
