using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
namespace project_of_dotnet.Models
{
    public class booking
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int B_Id { get; set; }
        [Display(Name = "user_data")]
        public int Id { get; set; }
        [ForeignKey("Id")]
        public virtual user_data user_data { get; set; }


    }
}



