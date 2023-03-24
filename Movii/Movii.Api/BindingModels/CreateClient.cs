using System;
using System.ComponentModel.DataAnnotations;

namespace Movii.Api.BindingModels
{
    public class CreateClient
    {
        [Required]
        [Display(Name = "ClientId")]
        public int ClientId { get; set; }
        
        [Required]
        [Display(Name = "ClientName")]
        public string ClientName { get; set; }
        
        [Required]
        [Display(Name = "ClientLastName")]
        public string ClientLastName { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public string Gender { get; set; }
        
        [Required]
        [Display(Name = "BirthDate")]
        public DateTime BirthDate { get; set; }
        
        [Required]
        [Display(Name = "ClientHistory")]
        public string ClientHistory { get; set; }
        
        [Required]
        [Display(Name = "ClientAddress")]
        public string ClientAddress { get; set; }
    }
}