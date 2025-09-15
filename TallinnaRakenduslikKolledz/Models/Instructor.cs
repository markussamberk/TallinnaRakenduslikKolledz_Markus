using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Connections;

namespace TallinnaRakenduslikKolledz.Models
{
    public class Instructor
    {
        [Key]
        public int ID { get; set; }
        /**/
        [Required]
        [StringLength(50)]
        [Display(Name = "Perekonnanimi")]
        public string LastName { get; set; }
        /**/

        [Required]
        [StringLength(50)]
        [Display(Name = "Eesnimi")]
        public string FirstName { get; set; }
        /**/
        [Display(Name = "Õpetaja nimi")]
        public string FullName
        {
            get { return LastName + ", "  + FirstName; }
        }
        /**/
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Tööleasumiskuupäev")]
        public DateTime HireDate { get; set; }

        public ICollection<CourseAssignment>? CourseAssignments { get; set; }
        public OfficeAssignment? OfficeAssignment { get; set; }

        [Display(Name = "Hindeid Antud")]
        public int? GradesGiven { get; set; }
        [Display(Name = "Pikkus")]
        public int? Height { get; set; }
        [Display(Name = "Tunde õpetatud")]
        public int? LessonsTaught { get; set; }


    }
}
