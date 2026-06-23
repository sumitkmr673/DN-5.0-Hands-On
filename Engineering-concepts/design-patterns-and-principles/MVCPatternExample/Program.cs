using System;

namespace MVCPatternExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Student model = new Student
            {
                Id = "CS2023-045",
                Name = "Aarav Sharma",
                Grade = "A"
            };

            StudentView view = new StudentView();
            StudentController controller = new StudentController(model, view);

            controller.UpdateView();

            controller.SetStudentName("Aarav S.");
            controller.SetStudentGrade("A+");

            controller.UpdateView();
        }
    }
}