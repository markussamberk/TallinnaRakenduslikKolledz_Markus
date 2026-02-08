using System.ComponentModel.DataAnnotations;

namespace TallinnaRakenduslikKolledz.Models
{
    public class Delinquent
    {
        [Key]
        public int DelinquentID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        [EnumDataType(typeof(Violation))]
        public Violation Violation { get; set; }
        [EnumDataType(typeof(DelinquentType))]
        public DelinquentType DelinquentType { get; set; }
        public string? Description { get; set; }

    }
    public enum Violation
    {
        Theft,
        Vandalism,
        Assault,
        Fraud,
        DrugOffense,
        Other
    }
    public enum DelinquentType
    {
        Student,
        Instructor
    }
}
