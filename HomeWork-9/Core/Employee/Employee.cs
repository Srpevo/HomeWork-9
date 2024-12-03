using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_9.Core.Employee
{
    internal class Employee
    {
        private int? _id;
        private string? _name;

        public int? Id
        {
            set { _id = value; }

            get { return _id; }
        }

        public string? Name
        {
            set { _name = value; }

            get { return _name; }
        }

        public Employee(int id, string name)
        {
            this._id = id;
            this._name = name;
        }

        public Employee()
        {

        }

    }
}
