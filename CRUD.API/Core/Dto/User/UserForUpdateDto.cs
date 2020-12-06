using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.API.Core.Dto
{
    public class UserForUpdateDto
    {
        [Required]
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required(AllowEmptyStrings = false)]
        [MaxLength(50)]
        public string LastName { get; set; }
    }
}
