using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoCoCo_Facturatie
{
    class KostenSchemaComparer : IComparer<KostenSchema>
    {
        string memberName = string.Empty;

        SortOrder sortOrder = SortOrder.None;
        
        public KostenSchemaComparer(string strMemberName, SortOrder sortingOrder)
        {
            memberName = strMemberName;
            sortOrder = sortingOrder;
        }

        public int Compare(KostenSchema kostenSchema1, KostenSchema kostenSchema2)
        {
            int returnValue = 1;
            switch(memberName)
            {
                case "Naam":
                    if (sortOrder == SortOrder.Ascending)
                        returnValue = kostenSchema1.Naam.CompareTo(kostenSchema2.Naam);
                    else
                        returnValue = kostenSchema2.Naam.CompareTo(kostenSchema1.Naam);
                    break;
                case "Archive":
                    if (sortOrder == SortOrder.Ascending)
                        returnValue = kostenSchema1.Archive.CompareTo(kostenSchema2.Archive);
                    else
                        returnValue = kostenSchema2.Archive.CompareTo(kostenSchema1.Archive);
                    break;
                case "BTW":
                    if (sortOrder == SortOrder.Ascending)
                        returnValue = kostenSchema1.BTW.CompareTo(kostenSchema2.BTW);
                    else
                        returnValue = kostenSchema2.BTW.CompareTo(kostenSchema1.BTW);
                    break;
                case "Dactylo":
                    if (sortOrder == SortOrder.Ascending)
                        returnValue = kostenSchema1.Dactylo.CompareTo(kostenSchema2.Dactylo);
                    else
                        returnValue = kostenSchema2.Dactylo.CompareTo(kostenSchema1.Dactylo);
                    break;
                case "Fotokopie":
                    if (sortOrder == SortOrder.Ascending)
                        returnValue = kostenSchema1.Fotokopie.CompareTo(kostenSchema2.Fotokopie);
                    else
                        returnValue = kostenSchema2.Fotokopie.CompareTo(kostenSchema1.Fotokopie);
                    break;
                case "Mail":
                    if (sortOrder == SortOrder.Ascending)
                        returnValue = kostenSchema1.Mail.CompareTo(kostenSchema2.Mail);
                    else
                        returnValue = kostenSchema2.Mail.CompareTo(kostenSchema1.Mail);
                    break;
                case "Prestaties":
                    if (sortOrder == SortOrder.Ascending)
                        returnValue = kostenSchema1.Prestaties.CompareTo(kostenSchema2.Prestaties);
                    else
                        returnValue = kostenSchema2.Prestaties.CompareTo(kostenSchema1.Prestaties);
                    break;
                case "Verplaatsing":
                    if (sortOrder == SortOrder.Ascending)
                        returnValue = kostenSchema1.Verplaatsing.CompareTo(kostenSchema2.Verplaatsing);
                    else
                        returnValue = kostenSchema2.Verplaatsing.CompareTo(kostenSchema1.Verplaatsing);
                    break;
                case "Wacht":
                    if (sortOrder == SortOrder.Ascending)
                        returnValue = kostenSchema1.Wacht.CompareTo(kostenSchema2.Wacht);
                    else
                        returnValue = kostenSchema2.Wacht.CompareTo(kostenSchema1.Wacht);
                    break;
            }
            return returnValue;
        }
    }
}
