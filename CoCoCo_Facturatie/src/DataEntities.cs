using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.IO;
using System.Linq;
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

        internal Partij()
        {
        }
    }
    
 
    public class OGMNummer
    {
        #region Variables
        String Dossier;
        public int Year;
        public int DossierNr;
        public int Count;
        public int Rest;
        public bool DerdenGelden;
        #endregion  

        public OGMNummer(string DossierNummer, bool _DerdenGelden = false)
        {
            long value=0;
            int positieMinTeken = DossierNummer.IndexOf("-");
            if (positieMinTeken > 0)
                Dossier = DossierNummer.Substring(0, positieMinTeken);
            else
                Dossier = DossierNummer;
            Year = int.Parse(Dossier.Substring(0, 4));
            DossierNr = int.Parse(Dossier.Substring(6));
            DerdenGelden = _DerdenGelden;

            using (var context = new FacturatieModel())
            {
                Count = context.Provisies.Where(p => p.DossierNummer.Contains(Dossier)).Count();
                Count += context.DerdenGelden.Where(p => p.DossierNummer.Contains(Dossier)).Count();
                Count += context.EreloonNotas.Where(p => p.DossierNummer.Contains(Dossier)).Count();
            }
            if (DerdenGelden)
                Count += 3000;

            value = ((long)DossierNr * 10000 + (long)Year) * 1000 + (long)Count;
            Rest = (int)(value % 97);
        }

        public OGMNummer(string code1, string code2, string code3)
        {
            DossierNr = int.Parse(code1);
            Year = int.Parse(code2);
            Count = int.Parse(code3.Substring(0, 3));
            Rest = int.Parse(code3.Substring(3, 2));
        }

        public Boolean Geldig()
        {
            long value = ((long)DossierNr * 10000 + (long)Year) * 1000 + (long)Count;
            return (Rest == (int)(value % 97));
        }

        public override string ToString()
        {
            return string.Format("+++{0:000}/{1:0000}/{2:00000}+++", DossierNr, Year, Count*100+Rest);
        }
    }

    public static class ObjectExtensionMethods
    {
        public static IQueryable<TEntityType> ToQueryable<TEntityType>(this TEntityType instance)
        {
            return new[] { instance }.AsQueryable();
        }
    }
}
