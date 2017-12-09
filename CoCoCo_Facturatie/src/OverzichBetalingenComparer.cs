using System.Collections.Generic;
using System.Windows.Forms;

namespace CoCoCo_Facturatie
{
    internal class OverzichBetalingenComparer : IComparer<OverzichtBetalingen>
    {
        private string strColumnName;
        private SortOrder strSortOrder = SortOrder.None;

        public OverzichBetalingenComparer(string strColumnName, SortOrder strSortOrder)
        {
            this.strColumnName = strColumnName;
            this.strSortOrder = strSortOrder;
        }

        public int Compare(OverzichtBetalingen overzichtBetalingen1, OverzichtBetalingen overzichtBetalingen2)
        {
            int returnValue = 1;
            switch(strColumnName)
            {
                case "Tijd":
                    if (strSortOrder == SortOrder.Ascending)
                        returnValue = overzichtBetalingen1.Tijd.CompareTo(overzichtBetalingen2.Tijd);
                    else
                        returnValue = overzichtBetalingen2.Tijd.CompareTo(overzichtBetalingen1.Tijd);
                    break;
                case "Wie":
                    if (strSortOrder == SortOrder.Ascending)
                        returnValue = overzichtBetalingen1.Wie.CompareTo(overzichtBetalingen2.Wie);
                    else
                        returnValue = overzichtBetalingen2.Wie.CompareTo(overzichtBetalingen1.Wie);
                    break;
                case "DossierNummer":
                    if (strSortOrder == SortOrder.Ascending)
                        returnValue = overzichtBetalingen1.DossierNummer.CompareTo(overzichtBetalingen2.DossierNummer);
                    else
                        returnValue = overzichtBetalingen2.DossierNummer.CompareTo(overzichtBetalingen1.DossierNummer);
                    break;
                case "DossierNaam":
                    if (strSortOrder == SortOrder.Ascending)
                        returnValue = overzichtBetalingen1.DossierNaam.CompareTo(overzichtBetalingen2.DossierNaam);
                    else
                        returnValue = overzichtBetalingen2.DossierNaam.CompareTo(overzichtBetalingen1.DossierNaam);
                    break;
                case "Totaal":
                    if (strSortOrder == SortOrder.Ascending)
                        returnValue = overzichtBetalingen1.Totaal.CompareTo(overzichtBetalingen2.Totaal);
                    else
                        returnValue = overzichtBetalingen2.Totaal.CompareTo(overzichtBetalingen1.Totaal);
                    break;
                case "BTW":
                    if (strSortOrder == SortOrder.Ascending)
                        returnValue = overzichtBetalingen1.BTW.CompareTo(overzichtBetalingen2.BTW);
                    else
                        returnValue = overzichtBetalingen2.BTW.CompareTo(overzichtBetalingen1.BTW);
                    break;
                case "Betaald":
                    if (strSortOrder == SortOrder.Ascending)
                        returnValue = overzichtBetalingen1.Betaald.CompareTo(overzichtBetalingen2.Betaald);
                    else
                        returnValue = overzichtBetalingen2.Betaald.CompareTo(overzichtBetalingen1.Betaald);
                    break;
            }
            return returnValue;

        }
    }
}