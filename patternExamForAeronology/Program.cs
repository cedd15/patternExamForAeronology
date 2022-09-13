

using System.Text;
using System.Text.RegularExpressions;


while(true)
{
    Console.WriteLine("Enter your sample:");
    string userInput = Console.ReadLine();
    Console.WriteLine("\n");



    static bool isMatched(string sample)
    {
        var sb = new StringBuilder();

        var stringArr = sample.Split("|");
        
        //get the first half which is the pattern
        var pattern = stringArr[0];
        //the second half which is the string to be tested
        var stringToTest = stringArr[1];

        //start of string
        sb.Append("^");

        foreach (var item in pattern)
        {
            //convert @ to alphabet
            if (item == '@')
            {
                sb.Append("[a-zA-Z]");
            }
            //convert ! to numbers
            else if (item == '!')
            {
                sb.Append("[0-9]");
            }
            else if (item == '%')
            {
                sb.Append("[a-zA-Z]");
                if (!pattern.Contains("{"))
                {
                    sb.Append("{2}");
                }
            }
            else
            {
                sb.Append(item);
            }
        }

        //end of string
        sb.Append("$");

        var newPattern = sb.ToString();

        return Regex.IsMatch(stringToTest, newPattern) ? true : false;
    }


    Console.WriteLine("Result: " + isMatched(userInput).ToString());

    Console.WriteLine("\n");
    Console.WriteLine("************");

}




