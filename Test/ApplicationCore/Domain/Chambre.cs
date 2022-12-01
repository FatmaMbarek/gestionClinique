using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Domain
{
    public enum TypeChamber { Simple, Double }


    public class Chambre
    {
        [Key]
        public int NumeroChambre { get; set; }

        public double Prix { get; set; }

        public TypeChamber typeChamber { get; set; }

        public virtual ICollection<Clinique> Cliniques { get; set; }



    }
}
