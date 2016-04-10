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
        public string ProcedureInfo { get; set; }
        public string Notes { get; set; }
        public string Area { get; set; }
        public string ProcedureNotes { get; set; }

        public PatientClass(SqlCeDataReader rdr)
        {
            this.ID = rdr.GetInt32(0);
            this.FirstName = rdr.GetString(1);
            this.MiddleName = rdr.GetString(2);
            this.LastName = rdr.GetString(3);
            this.dob = rdr.GetDateTime(4);
            this.ProcedureInfo = rdr.GetString(5);
            this.Notes = rdr.GetString(6);
            this.Area = rdr.GetString(7);
            this.ProcedureNotes = rdr.GetString(8);
        }
    }
}
