using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility
{
    class Program
    {
        static void Main(string[] args)
        {

            // Lesson 3 (Time Complexity).
            // TapeEquilibrium. 
            // Equilibrium test (Codility).
            //int[] A = { -1, 3, -4, 5, 1, -6, 2, 1 };
            //Console.WriteLine(
            //    "Equilibrium found at [{0}]",
            //    Equilibrium.RunTest3(A)
            //);





            // Lesson 1 (Iterations). 
            // BinaryGap. 
            //int N = 2147483647;
            //int N = 20;
            //int N = 529;
            //int N = 1041;
            // int N = 9; 
            // int N = 1; 
            int N = 0;  
            int MaxGap = BinaryGap.RunTest(N);
            Console.WriteLine(
                "Max gap for {0} is {1}", 
                Convert.ToString( N, 2 ), 
                MaxGap
            );



            Console.ReadLine();


        }





    }









    // Lesson 3 (Time Complexity).
    // TapeEquilibrium. 
    static public class Equilibrium
    {





        // 100% (found solution). 
        static public int RunTest(int[] A)
        {


            var length = A.Length;

            if (length == 1) return A[0];
            if (length == 2) return Math.Abs(A[0] - A[1]);

            var leftSum = 0;
            var rightSum = 0;

            for (var i = 0; i < length; i++)
            {
                rightSum += A[i];
            }

            var difference = int.MaxValue;

            for (var i = 0; i < length - 1; i++)
            {
                var value = A[i];

                leftSum += value;
                rightSum -= value;

                difference = Math.Min(difference, Math.Abs(rightSum - leftSum));

                if (difference == 0) return 0;
            }

            return difference;




        }




        // https://codility.com/demo/results/demoS3XY72-4SR/#task-0
        // 0% (First attempt). 
        static public int RunTest1A(int[] A)
        {

            double SumLeft = 0.0;
            double SumRight = 0.0;

            int Index = 0;

            int EquilibriumIndex = 0;
            bool EquilibriumFound = false;

            int ArrayLength = A.Length;





            for (Index = 0; Index < ArrayLength; Index++)
            {

                SumLeft = 0.0;
                SumRight = 0.0;


                for (int IndexLeft = 0; IndexLeft <= Index; IndexLeft++)
                {

                    SumLeft += A[IndexLeft];

                }



                for (int IndexRight = Index + 2; IndexRight < ArrayLength; IndexRight++)
                {

                    SumRight += A[IndexRight];

                }


                if (SumLeft == SumRight)
                {
                    EquilibriumIndex = Index + 1;
                    EquilibriumFound = true;
                }


            }


            if (!EquilibriumFound)
                return (-1);
            else
                return (EquilibriumIndex);

        }



        // https://codility.com/demo/results/demoGY63AW-ADR/
        // 35% (Second attempt). 
        static public int RunTest1B(int[] A)
        {

            double SumLeft = 0.0;
            double SumRight = 0.0;

            int Index = 0;

            int EquilibriumIndex = 0;
            bool EquilibriumFound = false;

            int ArrayLength = A.Length;





            for (Index = 0; Index < ArrayLength; Index++)
            {

                SumLeft = 0.0;
                SumRight = 0.0;


                for (int IndexLeft = 0; IndexLeft <= Index; IndexLeft++)
                {

                    SumLeft += A[IndexLeft];

                }



                for (int IndexRight = Index + 2; IndexRight < ArrayLength; IndexRight++)
                {

                    SumRight += A[IndexRight];

                }


                if (SumLeft == SumRight)
                {
                    EquilibriumIndex = Index + 1;
                    EquilibriumFound = true;
                }


            }


            if (!EquilibriumFound)
                return (-1);
            else
                return (EquilibriumIndex);

        }




        // https://codility.com/demo/results/demoVTG4U8-BC4/
        // 58% (Third attempt). 
        static public int RunTest2(int[] A)
        {

            int Index = 0;
            int Index2 = 0;
            int Length = A.Length;



            for (Index = 0; Index < Length; Index++)
            {

                int LeftSum = 0;
                int RightSum = 0;

                // Sum left eq. 
                for (Index2 = 0; Index2 < Index; Index2++)
                    LeftSum += A[Index2];

                // Sum right eq. 
                for (Index2 = Index + 1; Index2 < Length; Index2++)
                    RightSum += A[Index2];

                // Check left and right eq are 0? 
                if (LeftSum == RightSum)
                    // Return this eq index. 
                    return (Index);

            }

            // No eq index. 
            return (-1);



        }




        // https://codility.com/demo/results/demoMNY9GJ-CZU/ 
        // 82% (Fourth attempt). 
        static public int RunTest3(int[] A)
        {

            int Index = 0;
            int Index2 = 0;
            int Length = A.Length;



            for (Index = 0; Index < Length; Index++)
            {

                long LeftSum = 0;
                long RightSum = 0;

                // Sum left eq. 
                for (Index2 = 0; Index2 < Index; Index2++)
                    LeftSum += A[Index2];

                // Sum right eq. 
                for (Index2 = Index + 1; Index2 < Length; Index2++)
                    RightSum += A[Index2];

                // Check left and right eq are 0? 
                if (LeftSum == RightSum)
                    // Return this eq index. 
                    return (Index);

            }

            // No eq index. 
            return (-1);



        }





    }




    // Lesson 1 (Iterations). 
    // BinaryGap. 
    static public class BinaryGap
    {

        // 100% (First attempt). 
        // https://codility.com/demo/results/trainingHERKDH-7D9/
        static public int RunTest(int N)
        {

            // Convert to string. 
            string Binary = Convert.ToString(N, 2);
            int Length = Binary.Length;
            // Console.WriteLine("{0} is {1} \r\n \r\n ", N, Binary); 


            int MaxGap = 0;
            int Gap = 0; 


            for( int Index = 0; Index < Length; Index++)
            {

                // Console.WriteLine("{0}", Binary[Index]);

                // Found zero. 
                if( Binary[Index] == '0')
                {


                    // Increment for this gap.
                    Gap++;

                    
                    // If last index, 
                    // Reset gap. 
                    if (Index == Length - 1)
                        Gap = 0; 

                    // Else if next index is 1, 
                    // Store new max gap. 
                    else if( Binary[Index + 1] == '1')
                    {
                        // If gap greater than max gap. 
                        // Store new max gap. 
                        if (Gap > MaxGap)
                            MaxGap = Gap;

                        // Reset gap for next check. 
                        Gap = 0;

                    }


                }

                

            }


            // No binary gap. 
            // return (0);

            // Return maximum binary gap. 
            return (MaxGap);


        }



    }
    










    
}
