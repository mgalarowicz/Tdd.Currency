using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tdd1
{
    public class Bank
    {
        public Money Reduce(IExpression source, string to)
        {
            return source.Reduce(this, to);
        }

        public int Rate(string from, string to)
        {
            if (from.Equals(to)) return 1;

            return (int)rates[new Pair(from, to)];
        }

        private Hashtable rates = new Hashtable();

        public void AddRate(string from, string to, int rate)
        {
            rates.Add(new Pair(from, to), rate);
        }


    }
}
