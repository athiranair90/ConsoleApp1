using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Formatting;

namespace ConsoleApp1
{

    
    class Program
    {
        static void Main(string[] args)
        {

            #region Matching Paranthesis
            string pattern = "))(#(@%^()^#";

            bool isCorrect = AccoliteProgram.IsMatchingParanthesis(pattern);

            #endregion

            #region Pattern matching Test
            string str = "++*{5} jtggggg";
            string str1 = "++* jtggg";
            string str2 = "++* jtggggg";
            string str3 = "++*{5} jtggggg";
            Console.WriteLine(AccoliteProgram.PatternMatching(str));

            #endregion

            #region WebAPI Test
            string URL = "https://coderbyte.com/api/challenges/json/age-counting";
            AccoliteProgram.GetAgeBove50(URL);

            #endregion


            #region  generic Test


            int a = 10;
            double b = 10;
            float c = 11;
            long d = 10;

            var x = (a + d) * (c + b);
            Console.WriteLine(x.GetType());
            var y = (c + d);
            Console.WriteLine(y.GetType());

            #endregion

            #region  Check Amstring Number

            Program p = new Program();
            int number = 153;
            p.CheckAmstringNumber(number);

            #endregion

            #region  Check factorial
            int factorialNumber = 5;
            int factorial = p.FindFactorial(factorialNumber);
            Console.WriteLine(factorial);


            #endregion

            #region  Check Paliandrome
            //palindrome
            int checkPal = 121;
            p.CheckPaliandrome(checkPal);

            #endregion

            #region  Check string Paliandrome
            //Check string Paliandrome
            string palString = "abcdef";
            p.CheckStringPaliandrome(palString);
            #endregion

            #region  Check factorial
            //Fibanacci Series
            number = 15;
            p.PrintFibonacciSeries(number);
            #endregion

            #region  Check factorial
            //Check Prime Number 

            for (int i = 1; i < 10; i++)
            {
                p.checkPrimeNumber(i);
            }

            #endregion

            #region  Check Binary
            int n = 30;
            string value = Convert.ToString(n,2);

            if (!value.Contains("1"))
            {
                Console.WriteLine("0");
            }

            var binaryArray =  value.ToCharArray();
            List<int> binaryCount = new List<int>();
            for (int i = 0; i < binaryArray.Length; i++)
            {
                if (binaryArray[i] == '1')
                {
                    i++;
                    var count = 0;
                    while (binaryArray[i] != '0')
                    {
                        count++;
                        i++;
                        
                    }
                    binaryCount.Add(count);
                }
                
            }


            #endregion
        }

       

        /// <summary>
        ///  Check for Prime Number
        /// </summary>
        /// <param name="number"></param>
        public void checkPrimeNumber(int number)
        {
            int n = 0;
            bool flag = false;

            if (number == 1)
            {
                Console.WriteLine(number + " is not a prime number");
            }

            for (int i = 2; i < number / 2; i++)
            {
                if (number % i == 0)
                {
                    Console.WriteLine(number+" is not a prime number");
                    flag = true;
                    break;
                }
            }

            if (!flag)
            {
                Console.WriteLine(number + " is a prime number");
            }

        }


        /// <summary>
        /// Reversed a string / Paliandrome
        /// </summary>
        /// <param name="str"></param>
        public void CheckStringPaliandrome(string str)
        {

            string reverse = String.Empty;
            Console.WriteLine("Correct String " + str);
            for (int i = str.Length-1; i >= 0; i--)
            {
                reverse = reverse + str[i];
            }
            Console.WriteLine("Reversed String "+ reverse);

            if(str == reverse)
            {
                Console.WriteLine("String is a palindrome.\n");
            }
            else
            {
                Console.WriteLine("String is not a palindrome.\n");
            }
        }



        /// <summary>
        /// Check is number Paliandrome
        /// </summary>
        /// <param name="number"></param>
        public void CheckPaliandrome(int number)
        {

            int reverse =0;
            int temp = number;
            while (temp != 0)
            {
                reverse = reverse * 10;
                reverse = reverse + temp % 10;
                temp = temp / 10;
            }

            if (number == reverse)
            {
                Console.WriteLine("number is a palindrome number.\n");
            }
            else
            {
                Console.WriteLine("number is not a palindrome number.\n");
            }
        }


        /// <summary>
        /// Print Fibonacci Series
        /// </summary>
        /// <param name="number"></param>
        public void PrintFibonacciSeries(int number)
        {
            int n1=0, n2=1, n3;

            StringBuilder str = new StringBuilder();
            str.Append(n1+" "+n2 +" ");

            for (int i = 2; i < number; i++)
            {
                n3 = n1 + n2;
                str.Append(n3 + " ");
                n1 = n2;
                n2 = n3;
            }
            Console.WriteLine(str.ToString());
        }


        /// <summary>
        ///   Factorial
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public int FindFactorial(int number)
        {
            if (number==0)
            {
                return 1;
            }

            if (number == 1)
            {
                return 1;
            }

            return number * FindFactorial(number - 1);
        }


        /// <summary>
        /// Amstrong Number
        /// </summary>
        /// <param name="number"></param>
        public void CheckAmstringNumber(int number)
        {
            int rem;
            int sum = 0;
            for (int i = number; i > 0; i = i / 10)
            {
                rem = i % 10;
                sum += rem * rem * rem;
            }

            if (number == sum)
            {
                Console.WriteLine("The number is Amstrong Number");
            }
            else
            {
                Console.WriteLine("The number not an Amstrong Number");
            }
        }
    }
}
