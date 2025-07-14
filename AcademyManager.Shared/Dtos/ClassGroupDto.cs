namespace AcademyManager.Shared.Dtos
{
    public class ClassGroupDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int? NumberOfStudents { get; set; }
    }
}
