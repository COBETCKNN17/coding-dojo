using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;

namespace DojoSurvey.Models
{
    public class User
    {
     [Required]
     [MinLength(2, ErrorMessage = "Minimum 2 characters long!")]
     [MaxLength(15, ErrorMessage = "Maximum 15 characters long!")]
     public string name {get;set;}
     [Required]
     public string location {get;set;}
     [Required]
     public string favLanguage {get;set;}
     [MinLength(8, ErrorMessage = "Minimum 8 characters long!")]
     [MaxLength(30, ErrorMessage = "Maximum 30 characters long!")]
     public string comment {get;set;}
    }

}