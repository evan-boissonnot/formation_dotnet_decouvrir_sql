using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecouverteSql.Toto
{
    /// <summary>
    /// 
    /// </summary>
    class Program
    {
        /// <summary>
        /// sldskfjdskfhsdkjfhksdjhfsdkjfhsd
        /// </summary>
        /// <param name="args">c'est des arguments venant du cliebt</param>
        static void Main(string[] args)
        {
            AfficheLesVendeurs();
            InsererUneLigneDeVendeur();
            AfficheLesVendeurs();
        }


        static void InsererUneLigneDeVendeur()
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = Properties.Settings.Default.MaChaineDeConnectionPourKartina;
                connection.Open();

                using (SqlCommand command = connection.CreateCommand())
                {
                    string prenomVendeur = Console.ReadLine();


                    string sql = "INSERT INTO Vendeur" +
                        "           (FirstName)" +
                        "     VALUES" +
                        "           ('" + prenomVendeur + "')";

                    command.CommandText = sql;
                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Se connecte à la base de données et récupère tous les vendeurs
        /// et les affiche sur la console
        /// </summary>
        private static void AfficheLesVendeurs()
        {

            using (var maConnection = new SqlConnection())
            {
                maConnection.ConnectionString = Properties.Settings.Default.MaChaineDeConnectionPourKartina;
                maConnection.Open();

                using (SqlCommand maCommand = maConnection.CreateCommand())
                {
                    string maRequete = "SELECT FirstName, Titre " +
                        "FROM Vendeur " +
                        "JOIN Photo on Vendeur.Id = Photo.IDVendeur";

                    maCommand.CommandText = maRequete;

                    using (var monLecteurDeDonnees = maCommand.ExecuteReader())
                    {
                        while(monLecteurDeDonnees.Read())
                        {
                            Console.WriteLine(monLecteurDeDonnees["FirstName"] + ", " + 
                                              monLecteurDeDonnees["Titre"]);

                            Console.WriteLine(string.Format("{0}, {1}", monLecteurDeDonnees["FirstName"],
                                                                        monLecteurDeDonnees["Titre"]));
                        }
                    }
                }
            }
        }
    }
}
