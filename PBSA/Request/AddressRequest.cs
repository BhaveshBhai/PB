using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PBSA.Request
{
    public class AddressRequest
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        //[RegularExpression("/^(?:(?:[2-8]\\d|9[0-7]|0?[28]|0?9(?=09))(?:\\d{2}))$/", ErrorMessage = "Invalid Post Code")]
        public string PostCode { get; set; }
    }
}
