using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace project_of_dotnet.Models
{
    public class destination
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string Image { get; set; }
        public string Location { get; set; }
        public int NumberOfCities { get; set; }
        public string AboutLocation { get; set; }

    }
}
