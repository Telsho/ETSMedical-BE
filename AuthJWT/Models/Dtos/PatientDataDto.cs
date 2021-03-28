using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthJWT.Models.Dtos
{
    public class PatientDataDto
    {
        public string DoctorName { get; set; }
        public float Temperature{ get; set; }
        public float Heartbeat{ get; set; }
    }
}
