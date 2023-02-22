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

        public List<int> SeachIndexLocations( string pattern )
        {
            List<int> result = new List<int>();
            int[] longestPrefixSuffix = generatePreprocessPattern(pattern);
            Console.WriteLine("Longest prefix suffix: {0}", string.Join(',',longestPrefixSuffix));
            //Get lengths
            int mPatternLength = pattern.Length;
            int nTextLength = this.textToSearch.Length;
            //Get the index for the text and the pattern
            int indexForText = 0;
            int indexForPattern = 0;

            while( indexForText < nTextLength )
            {
                if(pattern[indexForPattern] == textToSearch[indexForText])
                {
                    indexForPattern++;
                    indexForText++;
                }

                if( indexForPattern == mPatternLength )
                {
                    result.Add(indexForText-indexForPattern);
                    indexForPattern = longestPrefixSuffix[indexForPattern-1]; 
                }
                else if ( indexForText < nTextLength && 
                    pattern[indexForPattern] != textToSearch[indexForText] ) 
                {
                    if( indexForPattern !=0  )
                    {
                        indexForPattern =longestPrefixSuffix[indexForPattern-1];
                    }
                    else
                    {
                        indexForText++;
                    }
                }


            }    
            
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
            List<int> result = kmp.SeachIndexLocations(pattern);
            Console.WriteLine("Substring found : {0}",string.Join(",", result));
        }
    }
}