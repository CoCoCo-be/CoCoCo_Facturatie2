﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Office.Interop.Word;
using System.Linq;
using System.Collections.ObjectModel;

namespace CoCoCo_Facturatie
{
    public class Provisie
    {
        #region Fields
        [Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProvisieId { get; set; }
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
        public Decimal Ereloon { get; set; }
        public Decimal BTW { get; set; }
        public Decimal Gerechtskosten { get; set; }
        public Decimal Totaal { get; set; }
        public Boolean Betaald { get; set; }
        public String OGMNummer { get; set; }
        public Int16 Status { get; set; }
        public Boolean InterCompany { get; set; }
        #endregion

        #region ForeignKeys
        public virtual ICollection<ProvisieFactuur> Facturen { get; internal set; }
        public virtual ICollection<Aanmaning> Aanmaningen { get; internal set; }
        #endregion

        public Provisie(Decimal _Ereloon, Decimal _BTW, Decimal _Gerechtskosten, Decimal _Totaal, Boolean _InterCompany)
        {
            Tijd = DateTime.Now;
            Wie = Variabelen.Wie;
            DossierNummer = Variabelen.DossierNummer;
            DossierNaam = Variabelen.DossierNaam;
            Partij = Variabelen.Partij;
            Ereloon = _Ereloon;
            BTW = _BTW;
            Gerechtskosten = _Gerechtskosten;
            Totaal = _Totaal;
            Betaald = false;
            OGMNummer = new OGMNummer(DossierNummer).ToString();
            Status = 0;
            InterCompany = _InterCompany;
        }

        internal Provisie()
        {
        }

        internal void PrintText(Selection selection)
        {
            String Text = null;

            if ((Ereloon == 0) && (Gerechtskosten != 0))
            {
                Text = "Mag ik u vragen om in dit dossier een provisie van " +
                    Gerechtskosten.ToString("C", Variabelen.Cultuur) +
                    " te betalen. Dit om mij toe te laten de gerechtsdeurwaarder te betalen.";
            }

            else if (Gerechtskosten != 0)
            {
                Text = "Mag ik u vragen om in dit dossier een globale provisie te betalen van " +
                    Totaal.ToString("C", Variabelen.Cultuur) + "." +
                    Environment.NewLine + "Dit bedrag is als volgt samengesteld: Provisie erelonen en bureelkosten " +
                    Ereloon.ToString("C", Variabelen.Cultuur);
                if (!InterCompany)
                {
                    Text += "vermeerderd met 21% btw of" + BTW.ToString("C", Variabelen.Cultuur);
                }

                Text += "en een provisie voor de gerechtskosten van " +
                    Gerechtskosten.ToString("C", Variabelen.Cultuur) + ".";
            }

            else
            {
                Text = "Mag ik u vragen om in dit dossier een globale provisie te betalen van " +
                    Totaal.ToString("C", Variabelen.Cultuur) +
                    "samengesteld als volgt " + Ereloon.ToString("C", Variabelen.Cultuur) +
                    " aan erelonen en bureelkosten";
                if (!InterCompany)
                {
                    Text += " en" + BTW.ToString("C", Variabelen.Cultuur) + " aan BTW";
                }
                Text += ".";
            }

            Text += Environment.NewLine + "U kunt dit bedrag overmaken op rekeningnummer BE96 0012 4751 7505 met als mededeling: " +
                OGMNummer + ".";

            selection.TypeText(Text);
        }

        public static IQueryable<Provisie> ProvisieOGM(string OGM, FacturatieModel context)
        {
            return context.Provisies.Where(p => (p.OGMNummer == OGM) && (p.Betaald == false));
        }

        public static IQueryable<Provisie> ProvisieDossierNr(String DossierNummer, FacturatieModel context)
        {
            return context.Provisies.Where(p => (p.DossierNummer == DossierNummer) && (p.Betaald == false));
        }

        internal void Close(Factuur factuur)
        {
            Betaald = true;
            if (Facturen == null)
                Facturen = new Collection<ProvisieFactuur>();
            Facturen.Add((ProvisieFactuur)factuur);
        }

    }
}