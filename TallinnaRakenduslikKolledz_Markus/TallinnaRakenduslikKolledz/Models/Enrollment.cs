namespace TallinnaRakenduslikKolledz.Models
{
    public enum Grade
    {
        A = 1,
        B = 2,
        C = 3,
        D = 4,
        F = 5,
        X = 6,
        MA = 7,

    }
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        public Grade? CurrentGrade { get; set; }

        public Course Course { get; set; }
        public Student Student { get; set; }
    }
}
