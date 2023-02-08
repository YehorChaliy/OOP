using System;

namespace Lab1
{

    public class TFraction
    {
 
        public double numerator, denominator;

        public TFraction()
        {
            numerator = 0;
            denominator = 0;
        }

        public TFraction(double numerator, double denominator)
        {
            this.numerator = numerator;
            this.denominator = denominator;
        }

        public TFraction(TFraction newFraction)
        {
            //Console.WriteLine("Duplicated circle:");
            this.numerator = newFraction.numerator;
            this.denominator = newFraction.denominator;
        }
        public virtual void SetData()
        {
            Console.Write("Enter the numerator of a fraction: ");
            numerator = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter the denominator of a fraction: ");
            denominator = Convert.ToDouble(Console.ReadLine());
        }
        public virtual void OutputData()
        {
            Console.WriteLine("Fraction: " + numerator + "/" + denominator);
        }
        public virtual TFraction ReductionOfFractions(TFraction newFraction)
        {
            //знаходження спільного дільника
            static double Fcd(double numer, double denom)
            {
                double temp;
                numer = Math.Abs(numer);
                denom = Math.Abs(denom);
                while (denom != 0 && numer != 0)
                {
                    if (numer % denom > 0)
                    {
                        temp = numer;
                        numer = denom;
                        denom = temp % denom;
                    }
                    else break;
                }
                if (denom != 0 && numer != 0) return denom;
                else return 0;
            }

            double fcd = Fcd(newFraction.numerator, newFraction.denominator);
            if (fcd != 0)
            {
                newFraction.numerator /= fcd;
                newFraction.denominator /= fcd;
            }
            Console.WriteLine("The fraction is reduced to a number: " + fcd);
            Console.WriteLine("Fraction: " + numerator + "/" + denominator);
            return newFraction;
        } 


        public static TFraction operator +(TFraction temp, double summand) => new TFraction(temp.numerator + summand, temp.denominator + summand);

        public static TFraction operator -(TFraction temp, double subtrahend)
        {
            try
            {
                if (temp.numerator - subtrahend < 0 || temp.denominator - subtrahend < 0 || temp.numerator - subtrahend == 0 || temp.denominator - subtrahend == 0)
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Numerator and denominator cannot be negative or zero!");
                Console.WriteLine("Сhanges were not accepted.");
                subtrahend = 0;
              
            }
            finally
            {

            }
            return new TFraction(temp.numerator - subtrahend, temp.denominator - subtrahend);
        }

        public static TFraction operator *(TFraction temp, double num) => new TFraction(temp.numerator * num, temp.denominator * num);

        public static TFraction operator /(TFraction temp, double num) => new TFraction(temp.numerator / num, temp.denominator / num);

    }

    public class TMixFraction : TFraction
    {
        private int integerNum;

        public TMixFraction()
        {
            integerNum = 0;
        }
        public TMixFraction(double numerator, double denominator) : base(numerator, denominator)
        {
            integerNum = 0;
        }

        public TMixFraction(TMixFraction newTMixFraction)
        {
            this.numerator = newTMixFraction.numerator;
            this.denominator = newTMixFraction.denominator;
            this.integerNum = newTMixFraction.integerNum;
        }

        public override void SetData()
        {
            Console.Write("Enter the integer part of the fraction: ");
            integerNum = Convert.ToInt32(Console.ReadLine());
            base.SetData();
        }

        public override void OutputData()
        {
            Console.WriteLine("Fraction: " + integerNum + " " + numerator + "/" + denominator);
        }

        public override TFraction ReductionOfFractions(TFraction newTMixFraction)
        {
            //знаходження спільного дільника
            static double Fcd(double numer, double denom)
            {
                double temp;
                numer = Math.Abs(numer);
                denom = Math.Abs(denom);
                while (denom != 0 && numer != 0)
                {
                    if (numer % denom > 0)
                    {
                        temp = numer;
                        numer = denom;
                        denom = temp % denom;
                    }
                    else break;
                }
                if (denom != 0 && numer != 0) return denom;
                else return 0;
            }

            double fcd = Fcd(newTMixFraction.numerator, newTMixFraction.denominator);
            if (fcd != 0)
            {
                newTMixFraction.numerator /= fcd;
                newTMixFraction.denominator /= fcd;
            }
            Console.WriteLine("The fraction is reduced to a number: " + fcd);
            Console.WriteLine("Fraction: " + integerNum + " " + numerator + "/" + denominator);
            return newTMixFraction;
        }
    }



    public class Program
    {
        static void Main(string[] args)
        {
            //
            Console.WriteLine("**** Constructor without parameters ****");
            TFraction testFraction = new TFraction();
            Console.WriteLine(" ");
            Console.WriteLine("**** Input data ****");
            testFraction.SetData();
            Console.WriteLine(" ");
            Console.WriteLine("**** Info ****");
            testFraction.OutputData();

            //
            Console.WriteLine(" ");
            Console.WriteLine("**** Reduction of fraction ****");
            testFraction.ReductionOfFractions(testFraction);

            //
            Console.WriteLine(" ");
            Console.WriteLine("**** Constructor with parameters ****");
            TFraction testWithParam = new TFraction(42, 78);
            testWithParam.OutputData();

            //
            Console.WriteLine(" ");
            Console.WriteLine("**** Copy constructor ****");
            TFraction testCopyFraction = new TFraction(testWithParam);
            testCopyFraction.OutputData();

            //
            Console.WriteLine(" ");
            Console.WriteLine("**** Аdding a number to the numerator and denominator **** ");
            TFraction testAddOper = testFraction + 10.0;
            testAddOper.OutputData();

            //
            Console.WriteLine(" ");
            Console.WriteLine("**** Subtraction from the numerator and denominator of a number ****");
            TFraction testSubtractOper = testFraction - 8.0;
            testSubtractOper.OutputData();

            //
            Console.WriteLine(" ");
            Console.WriteLine("**** Multiplying the numerator and denominator by a number ****");
            TFraction testMultiplOper = testFraction * 7;
            testMultiplOper.OutputData();

            //
            Console.WriteLine(" ");
            Console.WriteLine("**** Dividing the numerator and denominator by a number ****");
            TFraction testDivideOper = testFraction / 9;
            testDivideOper.OutputData();

            //
            Console.WriteLine(" ");
            Console.WriteLine("**** Create an object of the TMixFraction class ****");
            Console.WriteLine(" ");
            TMixFraction testTMixFraction = new TMixFraction();
            Console.WriteLine("**** Input data ****");
            testTMixFraction.SetData();
            Console.WriteLine(" ");
            Console.WriteLine("**** Info ****");
            testTMixFraction.OutputData();

            //
            Console.WriteLine(" ");
            Console.WriteLine("**** Reduction of fraction ****");
            testTMixFraction.ReductionOfFractions(testTMixFraction);
        }
    }
}