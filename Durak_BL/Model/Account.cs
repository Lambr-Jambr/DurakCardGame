using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Durak_BL.Model
{
    public class Account
    {
        public string Name { get; }
        public int Balance { get; }

        public Account(string name, int balance)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("", nameof(name));
            }
            if (balance < 0)
            {
                throw new ArgumentException("", nameof(balance));
            }
            Name = name;
            Balance = balance;
        }
    }
}
