namespace BangaloreUniversityLearningSystem.Controllers
{
    using System;
    using System.Linq;
    using BangaloreUniversityLearningSystem.Infrastructure;
    using BangaloreUniversityLearningSystem.Interfaces;
    using BangaloreUniversityLearningSystem.Models;
    using BangaloreUniversityLearningSystem.Utilities;

    public class CoursesController : Controller
    {
        public CoursesController(IBangaloreUniversityData data, User user)
        {
            this.Data = data;
            this.CurrentUser = user;
        }

        public IView All()
        {
            return this.View(this.Data.Courses.GetAll().OrderBy(c => c.Name).ThenByDescending(c => c.Students.Count));
        }

        public IView Details(int courseId)
        {
            this.EnsureAuthorization(Role.Student, Role.Lecturer);
            var course = this.GetCourseById(courseId);
            var isInCourse = course.Students.Any(s => s == this.CurrentUser);
            if (!isInCourse)
            {
                throw new ArgumentException("You are not enrolled in this course.");
            }

            return this.View(course);
        }

        // BUG: rename input parameter id to courseId
        public IView Enroll(int courseId)
        {
            this.EnsureAuthorization(Role.Student, Role.Lecturer);
            var course = this.GetCourseById(courseId);
            //var course = this.Data.Courses.Get(courseId);
            //this validation is already made in method GetCourseById()
            //if (course == null)
            //{
            //    throw new ArgumentException(string.Format("There is no course with ID {0}.", courseId));
            //}

            if (this.CurrentUser.Courses.Contains(course))
            {
                throw new ArgumentException("You are already enrolled in this course.");
            }

            course.AddStudent(this.CurrentUser);
            this.CurrentUser.EnrollInCourse(course);

            return this.View(course);
        }

        private Course GetCourseById(int courseId)
        {
            var course = this.Data.Courses.Get(courseId);
            if (course == null)
            {
                throw new ArgumentException(string.Format("There is no course with ID {0}.", courseId));
            }

            return course;
        }

        public IView Create(string name)
        {
            if (!this.HasCurrentUser)
            {
                throw new ArgumentException("There is no currently logged in user.");
            }

            if (!this.CurrentUser.IsInRole(Role.Lecturer))
            {
                throw new AuthorizationFailedException("The current user is not authorized to perform this operation.");
            }

            var course = new Course(name);
            this.Data.Courses.Add(course);

            return this.View(course);
        }

        public IView AddLecture(int courseId, string lectureName)
        {
            if (!this.HasCurrentUser)
            {
                throw new ArgumentException("There is no currently logged in user.");
            }

            if (!this.CurrentUser.IsInRole(Role.Lecturer))
            {
                throw new AuthorizationFailedException("The current user is not authorized to perform this operation.");
            }

            Course course = this.GetCourseById(courseId);
            course.AddLecture(new Lecture(lectureName));

            return this.View(course);
        }
    }
}
