using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.Office.Interop.Word;

namespace CoCoCo_Facturatie
{
    [Table("Facturen")]
    public abstract class Factuur
    {
        #region Fields
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None), Column(Order = 1)]
        public int FactuurJaar { get; set; }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column(Order = 2), Index(IsUnique = true)]
        public int FactuurID { get; set; }
        [Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime Tijd { get; set; }
        [Required, StringLength(2)]
        public String Wie { get; set; }
        [Required]
        public String DossierNummer { get; set; }
        [Required]
        public String DossierNaam { get; set; }
        [Required]
        public Partij Partij { get; set; }
        [Required]
        public Decimal Totaal { get; set; }
        #endregion

        public Factuur(string wie, string dossierNummer, string dossierNaam, Partij partij, Decimal totaal)
        {
            Wie = wie;
            DossierNummer = dossierNummer;
            DossierNaam = dossierNaam;
            Partij = partij;
            Totaal = totaal;
        }

        public int GetFactuurNummer()
        {
            return int.Parse(FactuurJaar.ToString() + FactuurID.ToString());
        }

        internal abstract void PrintText(Selection selection);
    }

    /// <summary>
    /// 
    /// </summary>
    [Table("Facturen")]
    public class EreloonNotaFactuur : Factuur
    {
        #region Fields
        public Int16 Dactylo { get; set; }
        public Int16 Fotokopie { get; set; }
        public Int16 Fax { get; set; }
        public Int16 Verplaatsing { get; set; }
        public Decimal BijkomendeKosten { get; set; }
        public Decimal Forfait { get; set; }
        public TimeSpan EreloonUren { get; set; }
        public TimeSpan WachtUren { get; set; }
        public Decimal BTW { get; set; }
        public Decimal Rolzetting { get; set; }
        public Decimal Dagvaarding { get; set; }
        public Decimal Betekening { get; set; }
        public Decimal Uitvoering { get; set; }
        public Decimal Anderen { get; set; }
        public Decimal Derden { get; set; }
        #endregion

        #region ForeignKeys
        [Required]
        public virtual KostenSchema KostenSchema { get; set; }
        #endregion

        public EreloonNotaFactuur(IQueryable<EreloonNota> _ereloonNotas, decimal _totaal) :
            base(_ereloonNotas.First().Wie, _ereloonNotas.First().DossierNummer, _ereloonNotas.First().DossierNaam,
                _ereloonNotas.First().Partij, 0)
        {
            foreach (var ereloonNota in _ereloonNotas)
            {
                Dactylo += (short)(ereloonNota.Dactylo - ereloonNota.Facturen.Sum(f => f.Dactylo));
                Fotokopie += (short)(ereloonNota.Fotokopie - ereloonNota.Facturen.Sum(f => f.Fotokopie));
                Fax += (short)(ereloonNota.Fax - ereloonNota.Facturen.Sum(f => f.Fax));
                Verplaatsing += (short)(ereloonNota.Verplaatsing - ereloonNota.Facturen.Sum(f => f.Verplaatsing));
                BijkomendeKosten += ereloonNota.BijkomendeKosten - ereloonNota.Facturen.Sum(f => f.BijkomendeKosten);
                EreloonUren += ereloonNota.EreloonUren - TimeSpan.FromHours(ereloonNota.Facturen.Sum(f => f.EreloonUren.TotalHours));
                WachtUren += ereloonNota.WachtUren - TimeSpan.FromHours(ereloonNota.Facturen.Sum(f => f.WachtUren.TotalHours));
                BTW = ereloonNota.BTW - ereloonNota.Facturen.Sum(f => f.BTW);
                Rolzetting += ereloonNota.Rolzetting - ereloonNota.Facturen.Sum(f => f.Rolzetting);
                Dagvaarding += ereloonNota.Dagvaarding - ereloonNota.Facturen.Sum(f => f.Dagvaarding);
                Betekening += ereloonNota.Betekening - ereloonNota.Facturen.Sum(f => f.Betekening);
                Uitvoering += ereloonNota.Uitvoering - ereloonNota.Facturen.Sum(f => f.Uitvoering);
                Anderen += ereloonNota.Anderen - ereloonNota.Facturen.Sum(f => f.Anderen);
                Derden += ereloonNota.Derden - ereloonNota.Facturen.Sum(f => f.Derden);
                Totaal += ereloonNota.Totaal - ereloonNota.Facturen.Sum(f => f.Totaal);

                if (KostenSchema is null)
                    KostenSchema = ereloonNota.KostenSchema;
                else if (KostenSchema != ereloonNota.KostenSchema)
                    throw new NotImplementedException("Factuur voor ereloonNotas met verschillende kostenschemas");
            }

            if (Totaal != _totaal)
                throw new Exception("Totaal komt niet overeen, factuur niet gemaakt");
        }

        internal override void PrintText(Selection selection)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ProvisieFactuur : Factuur
    {
        #region Fields
        [Required]
        public Decimal ProvisieErelonen { get; set; }
        [Required]
        public Decimal ProvisieBTW { get; set; }
        [Required]
        public Decimal ProvisiegerechtsKosten { get; set; }
        #endregion

        public ProvisieFactuur(IQueryable<Provisie> _provisies, decimal _totaal) :
            base(_provisies.First().Wie, _provisies.First().DossierNummer, _provisies.First().DossierNaam,
                _provisies.First().Partij, 0)
        {
            foreach (var provisie in _provisies)
            {
                ProvisieErelonen += provisie.Ereloon - provisie.Facturen.Sum(f => f.ProvisieErelonen);
                ProvisieBTW += provisie.BTW - provisie.Facturen.Sum(f => f.ProvisieBTW);
                ProvisiegerechtsKosten += provisie.Gerechtskosten - provisie.Facturen.Sum(f => f.ProvisiegerechtsKosten);
                Totaal += provisie.Totaal - provisie.Facturen.Sum(f => f.Totaal);
            }

            if (Totaal != _totaal)
                throw new Exception("Totaal komt niet overeen, factuur niet gemaakt");
        }

        internal override void PrintText(Selection selection)
        {
            throw new NotImplementedException();
        }
    }
}
