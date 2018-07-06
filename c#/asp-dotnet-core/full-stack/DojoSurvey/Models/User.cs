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
     public string name {get;set;}
     public string location {get;set;}
     public string favLanguage {get;set;}
     public string comment {get;set;}
    }

}