using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCoCo_Facturatie
{
    class FactuurModel
    {
        #region Variables
        IQueryable<Provisie> Provisies;
        IQueryable<EreloonNota> EreloonNotas;
        decimal Bedrag;
        FacturatieModel context;
        #endregion

        internal FactuurModel()
        {
            throw new NotImplementedException();
        }

        public FactuurModel(decimal _Bedrag, IQueryable<EreloonNota> _EreloonNotas, IQueryable<Provisie> _Provisies, FacturatieModel _context)
        {
            Bedrag = _Bedrag;
            EreloonNotas = _EreloonNotas;
            Provisies = _Provisies;
            context = _context;
        }

        internal Factuur Genereer()
        {
            Boolean found = false;
            Factuur Factuur = null;
            Decimal EreloonBedrag = 0;
            Decimal ProvisieBedrag = 0;

            if (0 != EreloonNotas.Count())
            {
                EreloonBedrag = EreloonNotas.Sum(p => p.Totaal);
                if (EreloonNotas.Any(p => p.Facturen.Any()))
                    EreloonBedrag -= EreloonNotas.Sum(p => p.Facturen.Sum(f => f.Totaal));;
            }
            if (0 != Provisies.Count())
            {
                ProvisieBedrag = Provisies.Sum(p => p.Totaal);
                if (Provisies.Any(p => p.Facturen.Any()))
                    ProvisieBedrag -= Provisies.Sum(p => p.Facturen.Sum(f => f.Totaal)); 
            }

            if (Bedrag == EreloonBedrag)
            {
                // Bedrag = som van openstaande bedragen voor ereloonnota's
                Factuur = new EreloonNotaFactuur(EreloonNotas, Bedrag);
                // Sluit Ereloonnotas af
                foreach (var EreloonNota in EreloonNotas)
                {
                    EreloonNota.Close(Factuur);
                }
                found = true;
            }
            else if (Bedrag < EreloonBedrag)
            {
                // Kijk of Bedrag het bedrag van 1 ereloonnota is.
                foreach (var EreloonNota in EreloonNotas)
                {
                    if (Bedrag == EreloonNota.Totaal)
                    {
                        // EreloonNota gevonden
                        Factuur = new EreloonNotaFactuur( EreloonNota.ToQueryable(), Bedrag);
                        EreloonNota.Close(Factuur);
                        found = true;
                        // Spring uit lus
                        break;
                    }
                }
            }

            if (Bedrag == ProvisieBedrag && !found)
            {
                // Bedrag = som van openstaande bedragen voor provisies's
                Factuur = new ProvisieFactuur(Provisies, Bedrag);
                // Sluit provisies af
                foreach (var Provisie in Provisies)
                {
                    Provisie.Close(Factuur);
                }
                found = true;
            }
            else if (Bedrag < ProvisieBedrag && !found)
            {
                // Kijk of Bedrag het bedrag van 1 provisie is
                foreach (var Provisie in Provisies)
                {
                    if (Bedrag == Provisie.Totaal)
                    {
                        // Provisie gevonden
                        Factuur = new ProvisieFactuur(Provisie.ToQueryable(), Bedrag);
                        Provisie.Close(Factuur);
                        found = true;
                        //spring uit lus
                        break;
                    }
                }
            }

            // TODO: Schrijf factuur generatie code hieronder. 
            if (found && Factuur != null) 
                Factuur.PrintText(Globals.CoCoCo_Facturatie_Plugin.Application.Selection);
            else
                throw new NotImplementedException();

            return Factuur;
        }
    }
}
