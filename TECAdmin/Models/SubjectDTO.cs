namespace TECAdmin.Models
{
    public class SubjectDTO : ISubjectDTO
    {
        public string Name { get; set; }
        public Teacher Teacher { get; set; }
        public List<Student> Students { get; set; } = new();
    }
}
