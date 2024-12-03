using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_9.Core.University
{
    internal class University
    {
        private string? _name;

        private string? _description;

        public string? Name
        {
            get { return _name; }

            set { _name = value; }
        }

        public string? Description
        {
            get { return _description; }

            set { _description = value; }
        }

        public University(string name, string description)
        {
            _name = name;
            _description = description;
        }

        public University()
        {

        }
    }
}
