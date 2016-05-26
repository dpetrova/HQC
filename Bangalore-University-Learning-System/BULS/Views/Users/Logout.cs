namespace BangaloreUniversityLearningSystem.Views.Users
{
    using System.Text;
    using BangaloreUniversityLearningSystem.Infrastructure;
    using BangaloreUniversityLearningSystem.Models;

    public class Logout : View
    {
        public Logout(User user)
            : base(user)
        {
        }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            var userModel = this.Model as User;

            viewResult.AppendFormat("User {0} logged out successfully", userModel.Username);
            viewResult.AppendLine();
        }
    }
}
