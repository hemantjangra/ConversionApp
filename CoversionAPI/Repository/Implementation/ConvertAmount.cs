namespace CoversionAPI.Repository.Implementation
{
    using System;
    using CoversionAPI.Models.Implementation;
    using CoversionAPI.Repository.Interface;

    public class ConvertAmount : IConvertAmount
    {
        public PersonDetail ConvertAmountToAplha(PersonDetail input)
        {
            PersonDetail details = new PersonDetail();
            try
            {
                string amount = input?.Amount;
                string wholeNumber, decimalNumber = string.Empty;
                if (string.IsNullOrEmpty(amount))
                {
                    return details;
                }
                int decimalPlace = 0;
                if (input.Amount.Contains("."))
                {
                    decimalPlace = input.Amount.IndexOf(".");
                    wholeNumber = decimalPlace > 0 ?
                                        amount.Substring(0, decimalPlace) : amount;
                    decimalNumber = amount.Substring(decimalPlace + 1);
                }
                else
                {
                    wholeNumber = amount;
                }
                long wholeLongNumber = 0;
                long decimalLongNumber = 0;

                long.TryParse(wholeNumber, out wholeLongNumber);

                string dollarOutPut = string.Empty;
                dollarOutPut = ConvertToWords(wholeLongNumber);
                dollarOutPut = !string.IsNullOrEmpty(dollarOutPut) ? dollarOutPut + " dollar" : string.Empty;

                string centOutPut = string.Empty;

                if (!string.IsNullOrEmpty(decimalNumber))
                {
                    long.TryParse(decimalNumber, out decimalLongNumber);
                    centOutPut = ConvertToWords(decimalLongNumber);
                    centOutPut = !string.IsNullOrEmpty(centOutPut)? " and " + centOutPut + " Cents": string.Empty;
                }
                string outPut = string.Concat(dollarOutPut, centOutPut);
                details.Name = input.Name;
                details.Amount = outPut;
                return details;
            }
            catch (Exception ex)
            {
                //log exception and return value
                return details;
            }
        }

        private string ConvertToWords(long number)
        {
            string alphabeticVal = string.Empty;

            // handles digits at ten millions and hundred
            // millions places (if any)
            alphabeticVal += NumberToWords((number / 1000000), "Million ");

            // handles digits at hundred thousands and one
            // millions places (if any)
            //alphabeticVal += NumberToWords(((number / 100000) % 100), " ");

            // handles digits at thousands and tens thousands
            // places (if any)
            alphabeticVal += NumberToWords(((number / 1000) % 100), "thousand ");

            // handles digit at hundreds places (if any)
            alphabeticVal += NumberToWords(((number / 100) % 10), "hundred ");



            if (number > 100 && number % 100 > 0)
                alphabeticVal += "and ";

            // handles digits at ones and tens places (if any)
            alphabeticVal += NumberToWords((number % 100), "");

            return alphabeticVal;
        }

        private string NumberToWords(long number, string inputString)
        {

            // strings at index 0 is not used, it is to make array
            // indexing simple
            var one = new[]
            {
                "",
                "one ",
                "two ",
                "three ",
                "four ",
                "five ",
                "six ",
                "seven ",
                "eight ",
                "nine ",
                "ten ",
                "eleven ",
                "twelve ",
                "thirteen ",
                "fourteen ",
                "fifteen ",
                "sixteen ",
                "seventeen ",
                "eighteen ",
                "nineteen "
            };

            // strings at index 0 and 1 are not used, they is to
            // make array indexing simple
            var ten = new[]
            {
                "",
                "",
                "twenty ",
                "thirty ",
                "forty ",
                "fifty ",
                "sixty ",
                "seventy ",
                "eighty ",
                "ninety "
               };


            string outputString = string.Empty;
            // if n is more than 19, divide it
            if (number > 19)
                outputString += ten[number / 10] + one[number % 10];
            else
                outputString += one[number];

            // if n is non-zero
            if (number != 0)
                outputString += inputString;

            return outputString;
        }
    }
}