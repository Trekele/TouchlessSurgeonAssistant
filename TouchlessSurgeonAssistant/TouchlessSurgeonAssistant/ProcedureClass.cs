using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouchlessSurgeonAssistant
{
    public class ProcedureClass
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<string> CheckList { get; set; }
        public string Notes { get; set; }

        public ProcedureClass(int ID, string Name, List<string> CheckList, string Notes)
        {
            this.ID = ID;
            this.Name = Name;
            this.Notes = Notes;
            this.CheckList = CheckList;
        }

    }
}
