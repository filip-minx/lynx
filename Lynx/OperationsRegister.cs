using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Lynx
{
    public class OperationsRegister
    {
        private Dictionary<string, Operation> operations = new Dictionary<string, Operation>();

        public OperationsRegister()
        {
            InitOperations();
        }

        public Operation GetOperation(string identifier)
        {
            return operations[identifier];
        }

        public void InitOperations()
        {
            var operationTypes = Assembly.GetExecutingAssembly().GetTypes().Where(x => x.IsSubclassOf(typeof(Operation)));

            foreach (Type type in operationTypes)
            {
                var operation = (Operation)Activator.CreateInstance(type);
                operations.Add(operation.Indentifier, operation);
            }
        }
    }
}
