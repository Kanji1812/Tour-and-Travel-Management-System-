using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace project_of_dotnet.Models
{
    public class trip_data
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string image { get; set; }
        public string Location { get; set; }
        public int PersonNumber { get; set; }
        public int StarNumber { get; set; }
        public int TotalPerson { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string GuideName { get; set; }
        public string Guide_Photo { get; set; }
        public string GuideDescription { get; set; }

    }
}
