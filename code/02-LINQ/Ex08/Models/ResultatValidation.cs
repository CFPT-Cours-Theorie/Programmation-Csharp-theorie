using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex08_VerificationsAnyAllContains.Models
{
    internal class ResultatValidation
    {
        public bool EstValide { get; set; }
        public List<string> Messages { get; set; } = new();
    }
}
