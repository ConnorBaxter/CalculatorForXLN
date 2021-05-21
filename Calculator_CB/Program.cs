using System;
using System.Collections.Generic;
using System.Linq;

namespace Calculator_CB
{
    class Program
    {
        static Stack<int> intStack = new Stack<int>();
        
        static void Main(string[] args)
        {
            // loop until user exits
            Console.Write("Input: ");
            string input = Console.ReadLine();
            while(input != "q")
            {
                //Clear the stack
                //I think that the specifictaion calls for
                //clean stack each input

                //intStack = new Stack<int>();
                
                //DecodeInputString(input);

                Calculator calculator = new Calculator();

                calculator.DecodeInputString(input);


                Console.Write("Input: ");
                input = Console.ReadLine();
            }
        }

        static void DecodeInputString(string input)
        {
            //split at whitespace
            List<string> split = input.Split(' ').ToList();
            
            //interate through
            foreach(string s in split)
            {
                int tmpDigit;
                try
                {
                    //try to parse as a number
                    //this will fail for anything not a number
                    //so we can tell if its a number or operator
                    tmpDigit = int.Parse(s);

                    //stop negative numbers
                    if(tmpDigit < 0)
                    {
                        Console.WriteLine("Negative numbers are not allowed");
                        return;
                    }

                    intStack.Push(tmpDigit);
                }
                catch
                {
                    //input is not a number
                    ProcessOperator(s);
                }
            }
        }

        static void ProcessOperator(string op)
        {
            switch(op)
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

        static void Add()
        {
            try
            {
                int secondNum = intStack.Pop();
                int firstNum = intStack.Pop();
                int sum = firstNum + secondNum;
                intStack.Push(sum);
            }
            catch
            {
                Console.WriteLine("Stack empty");
                return;
            }
        }

        static void Subtract()
        {
            try
            {
                int secondNum = intStack.Pop();
                int firstNum = intStack.Pop();
                int sum = firstNum - secondNum;
                intStack.Push(sum);
            }
            catch
            {
                Console.WriteLine("Stack empty");
                return;
            }
        }

        static void Multiply()
        {
            try
            {
                int secondNum = intStack.Pop();
                int firstNum = intStack.Pop();
                int sum = firstNum * secondNum;
                intStack.Push(sum);
            }
            catch
            {
                Console.WriteLine("Stack empty");
                return;
            }
        }

        static void Divide()
        {
            try
            {
                int secondNum = intStack.Pop();
                int firstNum = intStack.Pop();

                if (secondNum == 0)
                {
                    Console.WriteLine("Attempting to divide by zero");
                    return;
                }

                int sum = firstNum / secondNum;
                intStack.Push(sum);
            }
            catch
            {
                Console.WriteLine("Stack empty");
                return;
            }
            return;
        }

        static void Print()
        {
            // Make sure stack is not empty
            if(intStack.Count >= 1)
            {
                int retVal = intStack.Pop();
                Console.WriteLine(retVal + Environment.NewLine);
            }
            else
            {
                Console.WriteLine("Nothing to print");
            }
            return;
        }
    }
}