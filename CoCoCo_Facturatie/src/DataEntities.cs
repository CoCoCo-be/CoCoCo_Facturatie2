using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace CoCoCo_Facturatie
{
    static class Variabelen
    {
        public static Partij Partij { get; set; }
        public static String DossierNummer { get; set; }
        public static String DossierNaam { get; set; }
        public static String Wie { get; internal set; }

        public static CultureInfo Cultuur = new CultureInfo("nl-BE");
        public static NumberStyles NummerStijl = NumberStyles.Currency ;
        
        public static Boolean LeesCSV()
        {
            Boolean result = false;

            Wie = Properties.Settings.Default.GebruikerInitialen;
            try
            {
                using (var reader = new StreamReader(Properties.Settings.Default.PartijFile))
                {
                    // Only read first line
                    if (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(';');
                        DossierNummer = values[0];
                        DossierNaam = values[1];
                        Partij = new Partij(values[2], values[3], values[4], values[5]);
                        result = true;
                    }
                }
            }
            catch (IOException ex)
            {
                if (ex is FileNotFoundException || ex is DirectoryNotFoundException)
                {
                    result = false;
                }
                else
                {
                    throw;
                }
            }

            return result;
        }
    }

    [ComplexType] 
    public class Partij
    {
        [Required]
        public String AanspreekTitel { get; set; }
        [Required]
        public String Naam { get; set; }
        [Required]
        public String Adres { get; set; }
        [Required]
        public String Adres2 { get; set; }

        public Partij(String _AanspreekTitel, string _Naam, string _Adres, string _Adres2)
        {
            AanspreekTitel = _AanspreekTitel;
            Naam = _Naam;
            Adres = _Adres;
            Adres2 = _Adres2;
        }
    }
    
 
}
