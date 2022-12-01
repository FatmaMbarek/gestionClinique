using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Domain
{
    public class Admission

    {
        [DataType(DataType.Date)]
        public DateTime DateAdmission { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Le motif de\nl’admission")]
        public string ModifAdmission { get; set; }

        public int NbJours { get; set; }

        public virtual Patient Patients { get; set; }

        public virtual Chambre Chambres { get; set; }


        [ForeignKey("Patients")]
        public int PatientsFk { get; set; }

        [ForeignKey("Chambres")]
        public int ChambresFk { get; set; }

    }
}
