using System;
using System.IO;

namespace oppguidedpw
{
    public class DecimalToBinary : Conversion
    {
        public DecimalToBinary(string name, string definition) : base(name,definition, new DecimalInputValidator(),true)
        {
        }
        public override string Change(string input)
        {
            int number = Int32.Parse(input);

            if (number == 0) return "0";
            
            if (number < 0)
                throw new ArgumentException("Negative numbers are not allowed. Use DecimalToTwoComplement for signed values.");

            string binaryString = "";

            while (number > 0)
            {
                int remainder = number % 2;
                binaryString = remainder + binaryString;
                number /= 2;
            }

            return binaryString;
        }
    }
}