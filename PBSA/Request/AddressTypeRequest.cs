using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PBSA.Request
{
    public class AddressTypeRequest
    {
        [Required]
        public string Type { get; set; }
        [Required]
        public AddressRequest AddressRequest { get; set; }
    }
}
