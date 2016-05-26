namespace BangaloreUniversityLearningSystem.Views.Users
{
    using System.Text;
    using BangaloreUniversityLearningSystem.Infrastructure;
    using BangaloreUniversityLearningSystem.Models;

    public class Login : View
    {
        public Login(User user)
            : base(user)
        {
        }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            var userModel = this.Model as User;

            viewResult.AppendFormat("User {0} logged in successfully.", userModel.Username);
            viewResult.AppendLine();
        }
    }
}
