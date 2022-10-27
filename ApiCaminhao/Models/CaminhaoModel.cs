using AngleSharp.Css;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Desafio.Models
{
    public class CaminhaoModel
    {
        public int Id { get; set; }
        [Required]
        public string anoFabricacao { get; set; }
        [Required]
        public string anoModelo { get; set; }
        [Required]
        public EnumModel modelo { get; set; }



    }
}