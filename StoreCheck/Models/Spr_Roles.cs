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
        [DisplayName("Название роли")]
        public string Name { get; set; }
    }

}