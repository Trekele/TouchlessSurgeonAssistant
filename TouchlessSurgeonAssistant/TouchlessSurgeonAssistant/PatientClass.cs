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

        public PatientClass(int id, string firstName, string middleName, string lastName, DateTime dob)
        {
            this.ID = id;
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.dob = dob;
        }

        public PatientClass(SqlCeDataReader rdr)
        {
            this.ID = rdr.GetInt32(0);
            this.FirstName = rdr.GetString(1);
            this.MiddleName = rdr.GetString(2);
            this.LastName = rdr.GetString(3);
            this.dob = rdr.GetDateTime(4);
        }
    }
}
