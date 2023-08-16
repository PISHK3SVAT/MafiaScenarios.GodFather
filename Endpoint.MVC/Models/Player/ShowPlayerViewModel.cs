using System.ComponentModel.DataAnnotations;

using Domain;

namespace Endpoint.MVC.Models.Player
{
    public class ShowPlayerViewModel
    {
        [Display(Name= "نام")]
        public string Name { get; set; }=string.Empty;
        public ShowPlayerRoleViewModel Role { get; set; }
    }
    public class ShowPlayerRoleViewModel
    {
        public string Title { get; set; }=string.Empty;
        public string PicPath { get; set; }=string.Empty;
        public string Describtion { get; set; }= string.Empty;
        public virtual Side Side { get; set; }
        public virtual SideRoles SideRole { get; set; }
    }
}
