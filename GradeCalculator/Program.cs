using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("How many sections? (quizzes, final, midterm... etc)");
            int sections = (int)Int64.Parse(Console.ReadLine());
            Console.WriteLine("Ok so " + sections + " sections");
            Console.WriteLine();

            //loop though and collect the name of each section
            string[] names = new string[sections];
            for (int i = 0; i < sections; i++)
            {
                Console.Write("Section " + i + " name: ");
                names[i] = Console.ReadLine();
            }
            
            Console.WriteLine();

            //loop though and collect the percentages of each section
            double[] percentages = new double[sections];
            for (int i = 0; i < sections; i++)
            {
                Console.Write(names[i] + " percentage: ");
                percentages[i] = double.Parse(Console.ReadLine());
            }

            Console.WriteLine();

            //holds the grades for each section
            Dictionary<int, double[]> grades = new Dictionary<int, double[]>();
            for (int i = 0; i < sections; i++)
            {
                Console.Write("How many " + names[i] + ": ");
                int number = int.Parse(Console.ReadLine());
                double[] temp = new double[number];

                grades.Add(i, temp);
            }

            Console.WriteLine();

            //now finally get the grades
            for (int i = 0; i < sections; i++)
            {
                for (int j = 0; j < grades[i].Count(); j++)
                {
                    Console.Write(names[i] + " " + j + " grade: ");
                    grades[i][j] = double.Parse(Console.ReadLine());
                }
                Console.WriteLine();
            }

            //add all the grades for each section up
            double[] totals = new double[sections];
            for (int i = 0; i < sections; i++)
            {
                for (int j = 0; j < grades[i].Count(); j++)
                {
                    double temp = 0.0;
                    temp = temp + grades[i][j];
                    
                    //got the last grade for this section
                    if (j == grades[i].Count() - 1)
                    {
                        temp = (temp / grades[i].Count()) * percentages[i];
                        totals[i] = temp;
                    }
                }
            }

            //now add them all together.
            double final = 0;
            foreach (double i in totals)
            {
                final = final + i;
            }

            Console.WriteLine("Your final percentage is: " + final);




            Console.ReadLine();
        }
    }
}
