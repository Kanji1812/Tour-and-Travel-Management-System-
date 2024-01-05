using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace project_of_dotnet.Models
{
    public class Guide
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Photo { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        public string TwitterLink { get; set; }

        [StringLength(255)]
        public string FacebookLink { get; set; }

        [StringLength(255)]
        public string InstagramLink { get; set; }

        [StringLength(255)]
        public string LinkedinLink { get; set; }

        [StringLength(255)]
        public string Designation { get; set; }

        [StringLength(1000)]
        public string About { get; set; }

    }
}
