namespace TECAdmin.Interfaces
{
    public interface ISubjectDTO
    {
        string Name { get; set; }
        Teacher Teacher { get; set; }
        List<Student> Students { get; set; }
    }
}
