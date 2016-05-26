namespace BangaloreUniversityLearningSystem.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
    using BangaloreUniversityLearningSystem.Data;
    using BangaloreUniversityLearningSystem.Infrastructure;
    using BangaloreUniversityLearningSystem.Interfaces;
    using BangaloreUniversityLearningSystem.Models;
    
    public class BangaloreUniversityEngine : IBangaloreUniversityEngine
    {
        public void Run()
        {
            var database = new BangaloreUniversityData();
            User currentUser = null;

            while (true)
            {
                string routeUrl = Console.ReadLine();
                if (routeUrl == null)
                {
                    break;
                }

                var route = new Route(routeUrl);

                // gets the controller type through reflection
                var controllerType = Assembly
                    .GetExecutingAssembly()
                    .GetTypes()
                    .FirstOrDefault(type => type.Name == route.ControllerName);

                // create an instance of the specified type using constructor that best match specified parameters
                var controller = Activator
                    .CreateInstance(controllerType, database, currentUser)
                    as Controller; //as == cast (only for referent types)

                // search for the public method with the specified name
                var action = controllerType.GetMethod(route.ActionName);
                object[] argumentsToPass = MapParameters(route, action);
                try 
                {
                    //invoke the method represented by the current instance, using the specified parameters (through reflection)
                    // it is the same:
                    // var controller = new UsersController();
                    // controller.Register(argumentsToPass);
                    var view = action.Invoke(controller, argumentsToPass) as IView;
                    var output = view.Display();
                    Console.WriteLine(output);
                    currentUser = controller.CurrentUser;
                }
                catch (Exception ex) 
                {
                    if (ex.InnerException is ArgumentException || ex.InnerException is AuthorizationFailedException)
                    {
                        Console.WriteLine(ex.InnerException.Message);
                    }
                    else
                    {
                        throw;
                    }
                }
            }
        }

        private static object[] MapParameters(Route route, MethodInfo action)
        {
            return action
                .GetParameters()
                .Select<ParameterInfo, object>(
                    p =>
                        {
                            if (p.ParameterType == typeof(int))
                            {
                                return int.Parse(route.Parameters[p.Name]);
                            }
                            else
                            {
                                return route.Parameters[p.Name];
                            }
                        })
                 .ToArray();
        }
    }
}
