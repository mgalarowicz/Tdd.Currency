using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace tdd1
{
    public class Money : IExpression
    {
        public Money(int amount, string currency)
        {
            this.amount = amount;
            this.currency = currency;
        }

        public int amount;

        protected string currency;

        public IExpression Times(int multiplier)
        {
            return new Money(amount * multiplier, currency);
        }

        public string Currency() => currency;

        public override bool Equals(object obj)
        {
            Money money = (Money)obj;
            return amount == money.amount && Currency().Equals(money.Currency());
        }

        public static Money Dollar(int amount)
        {
            return new Money(amount, "USD");
        }

        public static Money Franc(int amount)
        {
            return new Money(amount, "CHF");
        }

        public IExpression Plus(IExpression addend)
        {
            return new Sum(this, addend);
        }

        public Money Reduce(Bank bank, string to)
        {
            int rate = bank.Rate(currency, to);
            return new Money(amount / rate, to);
        }
    }
}
