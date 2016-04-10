using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlServerCe;

namespace TouchlessSurgeonAssistant
{
    public class PatientClass
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime dob { get; set; }
        public string Notes { get; set; }
        public string Area { get; set; }
        public ProcedureClass procedure { get; set; }

        public PatientClass(SqlCeDataReader rdr)
        {
            ID = rdr.GetInt32(0);
            FirstName = rdr.GetString(1);
            MiddleName = rdr.GetString(2);
            LastName = rdr.GetString(3);
            dob = rdr.GetDateTime(4);
            Notes = rdr.GetString(5);
            Area = rdr.GetString(6);

            int procedureID = rdr.GetInt32(7);
            string name = rdr.GetString(11);
            string notes = rdr.GetString(12);
            List<string> checkList = rdr.GetString(13).Split('|').ToList();
            procedure = new ProcedureClass(procedureID, name, checkList, notes);
        }
    }
}
