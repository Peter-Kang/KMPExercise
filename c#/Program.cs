namespace KMP
{

    public class KMPalgo
    {
        public String textToSearch {get; set;}

        public KMPalgo(string argsText)
        {
            textToSearch = (argsText);
        }

        private int[] generatePreprocessPattern( string pattern )
        {
            int patternLength = pattern.Length;
            int[] longestPrefixSuffix = new int[patternLength];
            Console.WriteLine(pattern);
            int previousLength = 0;
            int currentPatternIndex = 1;

            while( currentPatternIndex < patternLength )
            {
                if( pattern[currentPatternIndex] == pattern[previousLength] )
                {
                    previousLength++;
                    longestPrefixSuffix[currentPatternIndex] = previousLength;
                    currentPatternIndex++;
                }
                else if( previousLength != 0 )
                {
                    previousLength = longestPrefixSuffix[previousLength-1];
                }
                else
                {
                    longestPrefixSuffix[currentPatternIndex] = 0;
                    currentPatternIndex++;
                }
            }
            return longestPrefixSuffix;
        }

        public List<int> SeachIndexLocations( string substring )
        {
            List<int> result = new List<int>();
            int[] longestPrefixSuffix = generatePreprocessPattern(substring);
            Console.WriteLine("Longest prefix suffix: {0}", string.Join(',',longestPrefixSuffix));

            return result;
        }
    };

    class Program
    {
        static void Main(string[] args)
        {
            string pattern = "dsgwadsgz";
            string inputText = "adsgwadsxdsgwadsgz";
            KMPalgo kmp = new KMPalgo(inputText);
            kmp.SeachIndexLocations(pattern);
        }
    }
}