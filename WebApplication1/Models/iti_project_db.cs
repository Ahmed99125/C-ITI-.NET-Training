using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Department
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? ManagerName { get; set; }

        public ICollection<Course> Courses { get; set; } = new List<Course>();
        public ICollection<Student> Students { get; set; } = new List<Student>();
        public ICollection<Instructor> Instructors { get; set; } = new List<Instructor>();
    }

    public class Course
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Course name is required")]
        public string Name { get; set; } = string.Empty;

        [Range(50, 100, ErrorMessage = "Degree must be between 50 and 100")]
        public int? Degree { get; set; }

        [Range(20, 50, ErrorMessage = "Minimum degree must be between 20 and 50")]
        public int? MinimumDegree { get; set; }

        [CustomValidation(typeof(Course), nameof(ValidateDegree))]
        public string? Validation { get; set; }

        public int? Hours { get; set; }

        [Display(Name = "Department")]
        [Required(ErrorMessage = "Department is required")]
        public int DeptId { get; set; }
        public Department? Department { get; set; }

        public ICollection<CourseStudent> CourseStudents { get; set; } = new List<CourseStudent>();
        public ICollection<Instructor> Instructors { get; set; } = new List<Instructor>();
        public static ValidationResult? ValidateDegree(Course course, ValidationContext context)
        {
            if (course.MinimumDegree.HasValue && course.Degree.HasValue)
            {
                if (course.MinimumDegree >= course.Degree)
                {
                    return new ValidationResult("Minimum degree must be less than Degree");
                }
            }
            return ValidationResult.Success;
        }
    }

    public class Student
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Image { get; set; }
        public string? Address { get; set; }
        public int? Grade { get; set; }

        public int DeptId { get; set; }
        public required Department Department { get; set; }

        public ICollection<CourseStudent> CourseStudents { get; set; } = [];
    }

    public class Instructor
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public decimal? Salary { get; set; }
        public string? Address { get; set; }
        public string? Image { get; set; }

        public int DeptId { get; set; }
        public required Department Department { get; set; }

        public int CrsId { get; set; }
        public required Course Course { get; set; }
    }

    public class CourseStudent
    {
        public int Id { get; set; }
        public int? Degree { get; set; }

        public int CrsId { get; set; }
        public required Course Course { get; set; }

        public int StdId { get; set; }
        public required Student Student { get; set; }
    }
}
