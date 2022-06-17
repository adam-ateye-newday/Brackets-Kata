namespace BracketsKata
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("")]
        [InlineData("{}")]
        [InlineData("[]")]
        [InlineData("()[({})]")]
        [InlineData("{}{}{[()]}")]
        public void GivenPositiveShouldResultTrue(string inputString)
        {
            //Arrange
            Boolean result = true;
            //Act
            result = BracketsChecker.checkString2(inputString);
            //Assert    
            result.Should().BeTrue();
        }

        [Theory]
        [InlineData("}{")]
        [InlineData("{{]]")]
        [InlineData("(}]()")]
        [InlineData("[[[]]")]
        [InlineData("abcd")]
        public void GivenNegativeShouldResultFalse(string inputString)
        {
            //Arrange
            Boolean result = false;
            //Act
            result = BracketsChecker.checkString2(inputString);
            //Assert
            result.Should().BeFalse();
        }
    }

    public static class BracketsChecker
    {
        public static Boolean checkString(string inputString)
        {
            Boolean HasRemovals = true;
            while (HasRemovals)
            {
                HasRemovals = false;
                if (inputString.Contains("{}"))
                {
                    inputString = inputString.Replace("{}", "");
                    HasRemovals = true;
                }
                if (inputString.Contains("[]"))
                {
                    inputString = inputString.Replace("[]", "");
                    HasRemovals = true;
                }
                if (inputString.Contains("()"))
                {
                    inputString = inputString.Replace("()", "");
                    HasRemovals = true;
                }

            }
            return inputString == String.Empty;
        }

        private static Dictionary<Char, Char> pairs = new Dictionary<char, char>()
        {
            {'{' , '}' },
            {'(' , ')' },
            {'[' , ']' },
            {'<' , '>' }
        };

        public static Boolean checkString2(string inputString)
        {
            var stack= new Stack<char>();
            foreach (Char c in inputString)
            {
                if (pairs.ContainsKey(c))
                {
                    var closingBracket = pairs[c];
                    stack.Push(closingBracket);
                } else
                {
                    if (stack.Count == 0)
                    {
                        return false;
                    }
                    var expectedBracket = stack.Pop();
                    if(expectedBracket != c)
                    {
                        return false;
                    }
                }
            }
            return stack.Count == 0;
        }
    }

}