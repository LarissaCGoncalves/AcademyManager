namespace AcademyManager.Shared.Dtos
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateOnly BirthDate { get; set; }
        public string Cpf { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public IReadOnlyCollection<EnrollmentDto> Enrollments { get; set; } = [];
    }
}
