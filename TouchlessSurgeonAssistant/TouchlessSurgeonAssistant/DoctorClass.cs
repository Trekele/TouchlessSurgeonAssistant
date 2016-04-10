using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouchlessSurgeonAssistant
{
    public class DoctorClass
    {
        public int ID { get; set; }
        public List<PatientClass> patientIDs { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public DoctorClass(SqlCeDataReader doctorReader)
        {
            ID = doctorReader.GetInt32(0);
            FirstName = doctorReader.GetString(1);
            LastName = doctorReader.GetString(2);
            UserName = doctorReader.GetString(3);
            Password = doctorReader.GetString(4);
            patientIDs = new List<PatientClass>();
        }
    }
}
