namespace AcademyManager.Shared.Dtos
{
    public class EnrollmentDto
    {
        public int StudentId { get; set; }
        public int ClassId { get; set; }

        public StudentDto? Student { get; set; }
        public ClassGroupDto? ClassGroup { get; set; }
    }
}
