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
        #endregion

        internal FactuurModel()
        {
            throw new NotImplementedException();
        }

        public FactuurModel(decimal _Bedrag, IQueryable<EreloonNota> _EreloonNotas, IQueryable<Provisie> _Provisies)
        {
            Bedrag = _Bedrag;
            EreloonNotas = _EreloonNotas;
            Provisies = _Provisies;
        }

        internal Factuur Genereer()
        {
            Factuur Factuur;
            Decimal EreloonBedrag = EreloonNotas.Sum(p => p.Totaal) - EreloonNotas.Sum(p => p.Facturen.Sum(f => f.Totaal));
            Decimal ProvisieBedrag = Provisies.Sum(p => p.Totaal) - Provisies.Sum(p => p.Facturen.Sum(f => f.Totaal));

            if (Bedrag == EreloonBedrag)
            {
                // Bedrag = som van openstaande bedragen voor ereloonnota's
                Factuur = new EreloonNotaFactuur(EreloonNotas, Bedrag);
                // Sluit Ereloonnotas af
                foreach (var EreloonNota in EreloonNotas)
                {
                    EreloonNota.Close(Factuur);
                } 
            }
            else if (Bedrag == ProvisieBedrag)
            {
                // Bedrag = som van openstaande bedragen voor provisies's
                Factuur = new ProvisieFactuur(Provisies, Bedrag);
                // Sluit provisies af
                foreach (var Provisie in Provisies)
                {
                    Provisie.Close(Factuur);
                }
            }
            // TODO: Schrijf factuur generatie code hieronder. 
            throw new NotImplementedException();
        }
    }
}
