using System;
using System.IO;

namespace oppguidedpw
{
    public class DecimalInputValidator : InputValidator
    {
        public override void validate(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '-' && i > 0)
                {
                    throw new FormatException("Bad form: input is not a valid integer");
                }
            }
        }   
    }
}