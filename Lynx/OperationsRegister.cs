using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Lynx
{
    public static class OperationsRegister
    {
        private static Dictionary<string, Operation> operationsToIdentifierMap = new Dictionary<string, Operation>();
        private static Dictionary<string, Operation> operationsToVerboseMap = new Dictionary<string, Operation>();

        static OperationsRegister()
        {
            InitOperations();
        }

        public static Operation GetOperation(string identifier)
        {
            return operationsToIdentifierMap[identifier];
        }

        public static Operation GetOperationVerbose(string verboseIdentifier)
        {
            return operationsToVerboseMap[verboseIdentifier];
        }

        public static void InitOperations()
        {
            var operationTypes = Assembly.GetExecutingAssembly().GetTypes().Where(x => x.IsSubclassOf(typeof(Operation)));

            foreach (Type type in operationTypes)
            {
                var operation = (Operation)Activator.CreateInstance(type);
                operationsToIdentifierMap.Add(operation.Identifier, operation);
                operationsToVerboseMap.Add(operation.VerboseIdentifier, operation);
            }
        }
    }
}
