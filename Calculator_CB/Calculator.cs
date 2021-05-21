using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_CB
{
    public class Calculator
    {
        // make get only as doesnt need to be set, just Push
        private Stack<int> intStack { get; }

        public Calculator()
        {
            intStack = new Stack<int>();
        }

        private bool Push(int i)
        {
            try
            {
                intStack.Push(i);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private int Pop()
        {
            int val = intStack.Pop();
            return val;
        }

        public void DecodeInputString(string input)
        {
            //split at whitespace
            List<string> split = input.Split(' ').ToList();

            //interate through
            foreach (string s in split)
            {
                int tmpDigit;
                try
                {
                    //try to parse as a number
                    //this will fail for anything not a number
                    //so we can tell if its a number or operator
                    tmpDigit = int.Parse(s);

                    //stop negative numbers
                    if (tmpDigit < 0)
                    {
                        Console.WriteLine("Negative numbers are not allowed");
                        return;
                    }

                    Push(tmpDigit);
                }
                catch
                {
                    //input is not a number
                    ProcessOperator(s);
                }
            }
        }

        private void ProcessOperator(string op)
        {
            switch (op)
            {
                //get correct operator
                case "+":
                    Add();
                    break;
                case "-":
                    Subtract();
                    break;
                case "*":
                    Multiply();
                    break;
                case "/":
                    Divide();
                    break;
                case "p":
                    Print();
                    break;
                default:
                    //Refuse other operators
                    Console.WriteLine("Invalid character in input");
                    break;
            }
        }

        //Use bool so we can check if the method completed successfully later if needed
        private bool Add()
        {
            try
            {
                int secondNum = Pop();
                int firstNum = Pop();
                int sum = firstNum + secondNum;
                Push(sum);
                return true;
            }
            catch
            {
                Console.WriteLine("Stack empty");
                return false;
            }
        }

        private bool Subtract()
        {
            try
            {
                int secondNum = Pop();
                int firstNum = Pop();
                int sum = firstNum - secondNum;
                Push(sum);
                return true;
            }
            catch
            {
                Console.WriteLine("Stack empty");
                return false;
            }
        }

        private bool Multiply()
        {
            try
            {
                int secondNum = Pop();
                int firstNum = Pop();
                int sum = firstNum * secondNum;
                Push(sum);
                return true;
            }
            catch
            {
                Console.WriteLine("Stack empty");
                return false;
            }
        }

        private bool Divide()
        {
            try
            {
                int secondNum = Pop();
                int firstNum = Pop();

                if (secondNum == 0)
                {
                     Console.WriteLine("Attempting to divide by zero");
                     return false;
                }

                int sum = firstNum / secondNum; 
                Push(sum); 
                return true;
            }
            catch
            {
                Console.WriteLine("Stack empty");
                return false;
            }
        }

        private void Print()
        {
            // Make sure stack is not empty
            if (intStack.Count >= 1)
            {
                int retVal = Pop();
                Console.WriteLine(retVal + Environment.NewLine);
            }
        }
    }
}
