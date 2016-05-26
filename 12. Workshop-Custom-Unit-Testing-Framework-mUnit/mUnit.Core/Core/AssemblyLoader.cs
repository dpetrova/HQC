namespace mUnit.Core.Core
{
    using System.Reflection;

    public class AssemblyLoader
    {
        private Assembly assembly;

        public AssemblyLoader(string assemblyPath)
        {
            this.AssemblyPath = assemblyPath;
        }

        public string AssemblyPath { get; private set; }

        public Assembly Assembly
        {
            get
            {
                //lazy loading
                if (this.assembly == null)
                {
                    this.assembly = Assembly.LoadFrom(this.AssemblyPath); //if assebly == null, load assembly from path
                }

                return this.assembly; //else return the assembly
            }
        }
    }
}
