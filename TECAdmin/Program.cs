using TECAdmin.enums;
using TECAdmin.Models;

namespace TECAdmin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a list of students
            var students = new List<Student>
            {
                new Student(1, "Sebastian", "Tølbøl Nielsen", new DateTime(2005, 1, 1)),
                new Student(2, "Andreas", "Lorenzen", new DateTime(2007, 2, 2)),
                new Student(3, "Casper", "Clemmensen", new DateTime(2003, 3, 3)),
                new Student(4, "Daniel", "Bjerre Jensen", new DateTime(2002, 4, 4)),
                new Student(5, "Hjalte", "Moesgaard Leth", new DateTime(2004, 11, 21)),
                new Student(6, "Johan", "Milter Jakobsen", new DateTime(2000, 6, 6)),
                new Student(7, "Louis", "Thomas Dao Pedersen", new DateTime(2005, 7, 7)),
                new Student(8, "Lukas", "Haugstad Frederiksen", new DateTime(2004, 8, 8)),
                new Student(9, "Marcus", "Wahlstrøm", new DateTime(2003, 9, 9)),
                new Student(10, "Marcus", "Slot Rohr", new DateTime(2002, 10, 10)),
                new Student(11, "Marius", "Ulslev Fogelgren", new DateTime(2006, 12, 24)),
                new Student(12, "Mathias", "Altenburg", new DateTime(2000, 12, 12)),
                new Student(13, "Patrick", "Gutierrez Fogelstrøm", new DateTime(2005, 1, 13)),
                new Student(14, "Ramtin", "Akbari", new DateTime(2004, 2, 14)),
                new Student(15, "Simon", "Heilbuth", new DateTime(2003, 3, 15)),
                new Student(16, "Thobias", "Svarter Hammarkvist", new DateTime(2002, 4, 16)),
                new Student(17, "Yosef", "Kasas", new DateTime(2007, 5, 17))
            };

            // Create a list of teachers
            var teachers = new List<Teacher>
            {
                new Teacher(1, "Henrik", "V. Paulsen"),
                new Teacher(2, "Niels", "Olesen"),
                new Teacher(3, "Michael", "Gilbert Hansen"),
                new Teacher(4, "Nikolaj", "Bo Fredsoe")
            };

            // Create a list of subjects
            var subjects = new List<SubjectDTO>
            {
                new SubjectDTO
                {
                    Name = "Grundlæggende programmering",
                    Teacher = teachers[0],
                    Students = students
                },
                new SubjectDTO
                {
                    Name = "OOP",
                    Teacher = teachers[1],
                    Students = students
                },
                new SubjectDTO
                {
                    Name = "Computerteknologi",
                    Teacher = teachers[2],
                    Students = students
                },
                new SubjectDTO
                {
                    Name = "Serversikkerhed",
                    Teacher = teachers[3],
                    Students = students
                },
                new SubjectDTO
                {
                    Name = "Databaseprogram",
                    Teacher = teachers[2],
                    Students = students
                },
                new SubjectDTO
                {
                    Name = "Databaseserver",
                    Teacher = teachers[2],
                    Students = students
                },
                new SubjectDTO
                {
                    Name = "Clientsideprogrammering",
                    Teacher = teachers[2],
                    Students = students
                }
            };


            string errorMessage = string.Empty;

            while (true)
            {
                Console.Clear();
                // Display any previous error message
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(errorMessage + "\n");
                    Console.ResetColor();
                    errorMessage = string.Empty;
                }

                // Display the menu
                foreach (SearchCriteria searchCriteria in Enum.GetValues(typeof(SearchCriteria)))
                {
                    Console.WriteLine($"{(int)searchCriteria}) {Utils.GetEnumDescription(searchCriteria)}");
                }

                Console.Write("\nVælg 1, 2 eller 3");
                var keyPressed = Console.ReadKey(intercept: true).KeyChar;  // Read key without showing it in console
                Console.WriteLine();  // Move to the next line after the key press

                // Check if the input is valid
                if (int.TryParse(keyPressed.ToString(), out int choice) &&
                    Enum.IsDefined(typeof(SearchCriteria), choice))
                {
                    SearchCriteria selectedCriteria = (SearchCriteria)choice;
                    switch (selectedCriteria)
                    {
                        case SearchCriteria.Teacher:
                            Console.Clear();
                            var teachersFromSubjects = subjects.Select(s => s.Teacher).Distinct().ToList();
                            teachersFromSubjects.Sort();
                            foreach (var teacher in teachersFromSubjects)
                            {
                                Console.WriteLine($"{teacher.Id}) {teacher.FirstName} {teacher.LastName}");
                            }
                            Console.Write("\nVælg en lærer id fra listen: ");
                            if (int.TryParse(Console.ReadLine(), out int selectedTeacherId))
                            {
                                var selectedTeacher = teachersFromSubjects.FirstOrDefault(t => t.Id == selectedTeacherId);
                                if (selectedTeacher != null)
                                {
                                    var teacherSubjects = subjects.Where(s => s.Teacher.Id == selectedTeacherId).ToList();
                                    if (teacherSubjects.Any())
                                    {
                                        foreach (var subject in teacherSubjects)
                                        {
                                            Console.WriteLine($"\n\tFag: {subject.Name}");
                                            Console.WriteLine($"\tAntal elever: {subject.Students.Count}");
                                            Console.WriteLine("\tElever:");
                                            //Sort students
                                            var studentsFromSubject = subject.Students;
                                            studentsFromSubject.Sort();
                                            foreach (var student in studentsFromSubject)
                                            {
                                                int age = AgeCalculator.CalculateAge(student.BirthDay);
                                                if(age < 18)
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                }
                                                Console.WriteLine($"\t\t- {student.FirstName} {student.LastName} {age} år ({student.BirthDay:dd-MM-yyyy})");

                                                Console.ResetColor();
                                            }
                                        }
                                    }
                                    else
                                    {
                                        errorMessage = ("Ingen fag fundet for denne lærer.");
                                        break;
                                    }
                                }
                                else
                                {
                                    errorMessage = "Ingen match fundet for det valgte lærer id.";
                                    break;
                                }
                            }
                            else
                            {
                                errorMessage = "Ugyldigt id. Prøv igen.";
                                break;
                            }
                            Console.Write("\nTryk på en vilkårlig tast, for at komme tilbage");
                            Console.ReadKey();
                            break;
                        case SearchCriteria.Student:
                            Console.Clear();
                            Console.Write("Angiv elevens navn: ");
                            string? search = Console.ReadLine();
                            if (!string.IsNullOrEmpty(search))
                            {
                                var matchingStudents = subjects
                                    .SelectMany(s => s.Students)
                                    .Where(st => st.FirstName.Contains(search, StringComparison.OrdinalIgnoreCase) || st.LastName.Contains(search, StringComparison.OrdinalIgnoreCase))
                                    .Distinct()
                                    .ToList();

                                if (matchingStudents.Any())
                                {
                                    Console.WriteLine($"Elever fundet: {matchingStudents.Count}");
                                    foreach (var student in matchingStudents)
                                    {
                                        Console.WriteLine($"\nElev: {student.FirstName} {student.LastName}");
                                        var studentSubjects = subjects.Where(s => s.Students.Contains(student)).ToList();
                                        foreach (var subject in studentSubjects)
                                        {
                                            Console.WriteLine($"\tFag: {subject.Name}");
                                            Console.WriteLine($"\tLærer: {subject.Teacher.FirstName} {subject.Teacher.LastName}");
                                            Console.WriteLine("");
                                        }
                                    }
                                }
                                else
                                {
                                    errorMessage = "Ingen match fundet.";
                                    break;
                                }
                            }
                            else
                            {
                                errorMessage = "Ingen match fundet.";
                                break;
                            }
                            Console.Write("\nTryk på en vilkårlig tast, for at komme tilbage");
                            Console.ReadKey();
                            break;
                        case SearchCriteria.Subject:
                            Console.Clear();
                            int index = 1;
                            foreach (var subject in subjects)
                            {
                                Console.WriteLine($"{index}) {subject.Name}");
                                index++;
                            }
                            Console.Write("\nVælg et fag id fra listen: ");
                            if (int.TryParse(Console.ReadLine(), out int selectedSubjectId) && selectedSubjectId > 0 && selectedSubjectId <= subjects.Count)
                            {
                                var selectedSubject = subjects[selectedSubjectId - 1];
                                Console.WriteLine($"\tFag: {selectedSubject.Name}");
                                Console.WriteLine($"\tLærer: {selectedSubject.Teacher.FirstName} {selectedSubject.Teacher.LastName}");
                                Console.WriteLine($"\tAntal elever: {selectedSubject.Students.Count}");
                                Console.WriteLine("\tElever:");
                                var studentsFromSubject = selectedSubject.Students;
                                studentsFromSubject.Sort();
                                foreach (var student in studentsFromSubject)
                                {
                                    int age = AgeCalculator.CalculateAge(student.BirthDay);
                                    if (age < 18)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                    }
                                    Console.WriteLine($"\t\t- {student.FirstName} {student.LastName} {age} år ({student.BirthDay:dd-MM-yyyy})");
                                    Console.ResetColor();
                                }
                            }
                            else
                            {
                                errorMessage = "Ingen match fundet for det valgte fag id.";
                                break;
                            }
                            Console.Write("\nTryk på en vilkårlig tast, for at komme tilbage");
                            Console.ReadKey();
                            break;
                        default:
                            errorMessage = "Invalid choice. Please try again!";
                            break;
                    }
                }
                else
                {
                    errorMessage = "Invalid choice. Please try again!";
                }
            }
        }
    }
}
