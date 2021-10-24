using System;

namespace GB_CS_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Account a1 = new Account(AccountType.debit);
            Account a2 = new Account(AccountType.credit);

            Console.WriteLine("+1000");
            a1.ChangeBalansPlus(1000);
            Console.WriteLine(a1);
            Console.WriteLine("-500");
            a1.ChangeBalansMinus(500);
            Console.WriteLine(a1);
            Console.WriteLine("-530");
            a1.ChangeBalansMinus(530);
            Console.WriteLine(a1);
            Console.WriteLine("+530");
            a1.ChangeBalansPlus(530);
            Console.WriteLine(a1);

            Console.WriteLine();

            Console.WriteLine("+1000");
            a2.ChangeBalansPlus(1000);
            Console.WriteLine(a2);
            Console.WriteLine("-500");
            a2.ChangeBalansMinus(500);
            Console.WriteLine(a2);
            Console.WriteLine("-530");
            a2.ChangeBalansMinus(530);
            Console.WriteLine(a2);
            Console.WriteLine("+530");
            a2.ChangeBalansPlus(530);
            Console.WriteLine(a2);
        }

        public class Account
        {
            private static int lastAccountNumber;
            private string _accountNumber;
            private decimal _balans;

            public Account(AccountType accountType)
            {
                lastAccountNumber += 1;
                this._accountNumber = lastAccountNumber.ToString();
                this.AccountType = accountType;
                this._balans = 0M;
            }

            public string AccountNumber 
            { 
                get { return _accountNumber; } 
            }

            public decimal Balans 
            {
                get 
                { 
                    return _balans; 
                }
            }

            public AccountType AccountType { get; set; }

            public void ChangeBalansPlus(decimal value)
            {
                if (value < 0)
                {
                    Console.WriteLine("Ошибка");
                    return;
                }

                _balans = _balans + value;
            }

            public void ChangeBalansMinus(decimal value)
            {
                if (value < 0)
                {
                    Console.WriteLine("Ошибка");
                    return;
                }

                if (this.AccountType == AccountType.debit && (_balans - value < 0))
                {
                    Console.WriteLine("Баланс по дебетовому счёту не может быть ниже 0");
                }
                else
                {
                    _balans = _balans - value;
                }
            }

            public override string ToString()
            {
                return string.Format(
                    @"account number: {0}, account tupe: {1}, balans: {2}",
                    this.AccountNumber, this.AccountType, this.Balans);
            }

        }

        public enum AccountType
        {
            debit,
            credit
        }
    }
}
