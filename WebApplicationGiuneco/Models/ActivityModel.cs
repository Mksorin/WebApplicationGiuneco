using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationGiuneco.Models
{    public enum Status
    {
        Backlog = 1,
        In_Progress = 2,
        Completata = 3,
    }
    public class ActivityModel
    {
        [DisplayName("Numero Tiket") ]
        public int Id { get; set; }
        [Required]
        [DisplayName("Titolo")]
        public string Title { get; set; }
        [Required]
        [DisplayName("Descrizione")]
        public string Description { get; set; }
        [DisplayName("Ore Lavorate")]
        public int HoursWorked { get; set; }
        [Required]
        [DisplayName("Stato (1 = Backlog, 2 = In corso, 3 = Completato)")]
        public Status Status { get; set; }
    }
}
