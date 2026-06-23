using System;

namespace MVCPatternExample
{
    public class Student
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Grade { get; set; } = string.Empty;
    }

    public class StudentView
    {
        public void DisplayStudentDetails(string studentName, string studentId, string studentGrade)
        {
            Console.WriteLine("--- Student Record ---");
            Console.WriteLine($"Name: {studentName}");
            Console.WriteLine($"Roll No: {studentId}");
            Console.WriteLine($"Grade: {studentGrade}");
            Console.WriteLine("----------------------\n");
        }
    }

    public class StudentController
    {
        private Student _model;
        private StudentView _view;

        public StudentController(Student model, StudentView view)
        {
            _model = model;
            _view = view;
        }

        public void SetStudentName(string name)
        {
            _model.Name = name;
        }

        public void SetStudentId(string id)
        {
            _model.Id = id;
        }

        public void SetStudentGrade(string grade)
        {
            _model.Grade = grade;
        }

        public void UpdateView()
        {
            _view.DisplayStudentDetails(_model.Name, _model.Id, _model.Grade);
        }
    }
}