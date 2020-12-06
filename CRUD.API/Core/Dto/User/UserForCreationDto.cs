using System.ComponentModel.DataAnnotations;

namespace CRUD.API.Core.Dto
{
    public class UserForCreationDto
    {

        [Required(AllowEmptyStrings = false)]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required(AllowEmptyStrings = false)]
        [MaxLength(50)]
        public string LastName { get; set; }
    }
}
