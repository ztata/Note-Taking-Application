using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace NoteTakingApp.Models
{
    public class Notes
    {

        [Key]
        public int Id { get; set; }

        [StringLength(200)]
        [Required]
        public string NoteTitle { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string NoteBody { get; set; }
    }
}
