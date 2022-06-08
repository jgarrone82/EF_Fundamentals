using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EF_Fundamentals.Models
{
    public class Task
    {   
        [Key]     
        public Guid TaskId { get; set; }
        [ForeignKey("CategoryId")]
        public Guid CategoryId { get; set;}

        [Required]
        [MaxLength(150)]
        public string Title { get; set; }
        public string Description { get; set; }
        public Priority PriorityTask { get; set; }
        public DateTime CreationDate { get; set; }
        public virtual Category Category { get; set; }

        [NotMapped]
        public string Resume { get; set; }

    }
}