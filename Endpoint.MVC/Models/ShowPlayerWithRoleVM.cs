using System.ComponentModel.DataAnnotations;

namespace Endpoint.MVC.Models
{
    public class ShowPlayerWithRoleVM
    {
        [Display(Name ="نام")]
        public string PlayerName { get; set; } = default!;
        [Display(Name ="نقش")]
        public string RoleTitle { get; set; } = default!;
    }
}
