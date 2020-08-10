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

        public static IEnumerable<Operation> Operations => operationsToIdentifierMap.Values;

        static OperationsRegister()
        {
            InitOperations();
        }

        public static Operation GetOperation(string identifier)
        {
            if (!operationsToIdentifierMap.TryGetValue(identifier, out var operation))
            {
                throw new InvalidOperationException($"Unknown operation identifier \"{identifier}\"");
            }

            return operation;
        }

        public static Operation GetOperationVerbose(string verboseIdentifier)
        {
            if (!operationsToVerboseMap.TryGetValue(verboseIdentifier, out var operation))
            {
                throw new InvalidOperationException($"Unknown operation identifier \"{verboseIdentifier}\"");
            }

            return operation;
        }

        public static T GetOperation<T>() where T : Operation
        {
            return (T)operationsToIdentifierMap.First(o => o.Value.GetType() == typeof(T)).Value;
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
