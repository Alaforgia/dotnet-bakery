using System.Collections.Generic;
using System;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DotnetBakery.Models
{
    public class Baker 
    {
        public int id {get; set;}

        [Required] // attribute
        // just like NOT NULL
        public string name {get; set;}


    }
}
