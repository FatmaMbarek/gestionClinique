using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Domain
{
    public class Patient
    {
        [DataType(DataType.EmailAddress)]
        public string AdresseEmail { get; set; }

        public string CIN { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateNaissance { get; set; }

        [Key]
        public int NumDossier { get; set; }

        public int ? NumTel { get; set; }

        public NomComplet nomComplet { get; set; }

        public virtual ICollection<Admission> Admissions { get; set; }

    }
}
