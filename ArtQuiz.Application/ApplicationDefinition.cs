using System.Reflection;

namespace ArtQuiz.Application
{
    public static class ApplicationDefinition
    {
        public static Assembly Assembly => Assembly.GetAssembly(typeof(ApplicationDefinition));
    }
}