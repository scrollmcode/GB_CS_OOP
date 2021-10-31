using System;
using System.Collections.Generic;
using System.Linq;

namespace GB_CS_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Account a1 = new Account(AccountType.debit);
            Account a2 = new Account(AccountType.credit);

            Console.WriteLine(a1);
            Console.WriteLine(a2);

            a1.transaction(a2, 1000);

            Console.WriteLine(a1);
            Console.WriteLine(a2);

            a2.transaction(a1, 500);

            Console.WriteLine(a1);
            Console.WriteLine(a2);

            // Задание 2
            Console.WriteLine();
            string obrazec = "Какаято строка";
            Console.WriteLine(obrazec);
            Console.WriteLine(returnString(obrazec));

            // Задание 3
            List<string> namesAndEmails = new List<string>(){
                "Кучма Андрей Витальевич & Kuchma@mail.ru",
                "Мизинцев Павел Николаевич & Pasha@mail.ru"
                };

            foreach (string n in namesAndEmails) { Console.WriteLine(n); }

            for (int i = 0; i < namesAndEmails.Count; i++)
            {
                string s = namesAndEmails[i];
                findemail(ref s);
                namesAndEmails[i] = s;
            }

            foreach (string n in namesAndEmails) { Console.WriteLine(n); }
        }

        public static string returnString(string s)
        {
            var strComponent = s.ToCharArray();
            char[] tmp = new char[strComponent.Length];

            for (int i = strComponent.Length; i > 0; i--)
            {
                tmp[i - 1] = strComponent[strComponent.Length - i];
            }

            return new string(tmp);
        }

        public static void findemail(ref string s)
        {
            s = s.Split('&')[1];
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

            public void transaction(Account account, decimal sum)
            {
                if (sum <= 0) return;

                this.ChangeBalansPlus(sum);
                account.ChangeBalansMinus(sum);
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
