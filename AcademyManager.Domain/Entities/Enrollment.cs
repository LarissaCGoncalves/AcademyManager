using AcademyManager.Shared.Entities;

namespace AcademyManager.Domain.Entities
{
    public class Enrollment : Entity
    {
        private Enrollment() { }
        public Enrollment(int studentId, int classId)
        {
            StudentId = studentId;
            ClassId = classId;
        }

        public int StudentId { get; }
        public int ClassId { get; }

        public Student Student { get; set; }
        public ClassGroup ClassGroup { get; set; }
    }
}
