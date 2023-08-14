using System.ComponentModel.DataAnnotations;

namespace Endpoint.MVC.Models
{
    public class ShowPlayerVM
    {
        [Display(Name= "نام")]
        public string Name { get; set; } = string.Empty;
    }
}
