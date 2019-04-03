using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheque
{
    public class Consulta
    {
        [Display(Name = "CPF")]
        public string CPFCNPJ { get; set; }
        [Display(Name = "D1")]
        public string CM7D1 { get; set; }
        [Display(Name = "D2")]
        public string CM7D2 { get; set; }
        [Display(Name = "D3")]
        public string CM7D3 { get; set; }
        [Display(Name = "CPF INTERESSADO")]
        public string CPFINTERESSADO { get; set; }
        [Display(Name = "STATUS")]
        public string STATUS { get; set; }
        public string RESULTADO { get; set; }


        public string ToTxtLinha
        {
            get
            {
                return string.Format("{0};{1};{2};{3};{4};{5};{6}", CPFCNPJ, CM7D1, CM7D2, CM7D3, CPFINTERESSADO, STATUS, RESULTADO);

            }
        }

    }
}
