using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ListaClientesNet.Models
{
    public class ClienteModel
    {
        public int id { get; set; }
        public int activado { get; set; }

        [Required]
        [StringLength(50)]
        public string dni { get; set; }

        [Required]
        [StringLength(50)]
        public string nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string apellido { get; set; }

        [Required]
        [StringLength(50)]
        public string email { get; set; }

        [Required]
        [StringLength(50)]
        public string telefono { get; set; }

        [Required]
        [StringLength(50)]
        public string pais { get; set; }

        [Required]
        public DateTime nacimiento { get; set; }

        [Required]
        [StringLength(50)]
        public string empresa { get; set; }

        [Required]
        [StringLength(50)]
        public string twitter { get; set; }

        [Required]
        [StringLength(50)]
        public string intereses { get; set; }

        [Required]
        public string genero { get; set; }
    }
}