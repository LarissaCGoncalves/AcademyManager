using AcademyManager.Shared.Entities;

namespace AcademyManager.Domain.Entities
{
    public class Enrollment : Entity
    {
        public Enrollment(int studentId, int classGroupId)
        {
            StudentId = studentId;
            ClassGroupId = classGroupId;
        }

        public int StudentId { get; }
        public int ClassGroupId { get; }

        public Student Student { get; set; }
        public ClassGroup ClassGroup { get; set; }
    }
}
