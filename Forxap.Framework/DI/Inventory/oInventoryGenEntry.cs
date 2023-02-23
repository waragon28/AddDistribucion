using SAPbobsCOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forxap.Framework.DI.Inventory
{
    public class oInventoryGenEntry : Base
    {

        public void Add()
        {

            SAPbobsCOM.Documents oInventoryEntry;

            oInventoryEntry =  (SAPbobsCOM.Documents)oCompany.GetBusinessObject(BoObjectTypes.oInventoryGenEntry);

            oInventoryEntry.Series = 18;
            oInventoryEntry.Reference2 = "Ref2";
            oInventoryEntry.JournalMemo = "comentario de asiento";
            

            


        }

    }
}
