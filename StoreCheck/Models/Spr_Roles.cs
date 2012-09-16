using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace StoreCheck.Models
{
    [MetadataType(typeof(Spr_RolesMetadata))]
    public partial class Spr_Roles
    {

    }
    
    public class Spr_RolesMetadata
    {
        [Required]
        //[DisplayName("Название роли")]
        [Display(Name = "RoleCaption", ResourceType = typeof(MyStrings))]
       // [UIHint("Roles")]
        public string Name { get; set; }
        //[UIHint("Roles")]
        [Display(Name = "ID", ResourceType = typeof(MyStrings))]
        public string ID { get; set; }
    }

}