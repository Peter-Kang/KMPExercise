
def preProcessingPattern(pattern, patternLength, longestPrefixSuffix ):
    previousLength = 0
    currentPatternIndex = 1
    longestPrefixSuffix[0] = 0
    print (pattern)
    while ( currentPatternIndex < patternLength ):#iterate over entire pattern
        if pattern[currentPatternIndex] == pattern[previousLength]: 
            #pattern's current index matches the value of the previousLength character (build out the suffix)
            previousLength += 1 
            longestPrefixSuffix[currentPatternIndex] = previousLength
            currentPatternIndex += 1
            #update the lengths and increment the indexs
            #set Longest prefix suffix to the previous length
        else :
            #pattern doesn't match
            if previousLength != 0:
                #iterative step: set the previous length to the last value
                previousLength = longestPrefixSuffix[previousLength - 1] #within the index reset the value back to the previous length
            else:
                #previousLength is 0, doesnt match the prefix
                #inital/reset step: zero out the current value and move down the iteration
                longestPrefixSuffix[currentPatternIndex] = 0 #index cannot be -1, we set the LPS to 0
                currentPatternIndex += 1 #index increment

        #we only increment the index if we are setting a 0 or recording the length
        #if the patterns do not match, we compare it to the previous pattern index until we cannot
        #print("3P: ",longestPrefixSuffix, currentPatternIndex, previousLength)

def KMPSearch( pattern, text ):
    mPatternLength = len( pattern )
    nTextLength = len( text )

    longestPrefixSuffix = [0] * mPatternLength #creates a array to see how much the pattern over laps itself
    preProcessingPattern(pattern, mPatternLength, longestPrefixSuffix) #create a array with overlap mapping
    print(longestPrefixSuffix)
    indexForText = 0
    indexForPattern = 0
    while ( indexForText < nTextLength ) :
        print(indexForText, indexForPattern, text[indexForText], pattern[indexForPattern])
        if pattern[indexForPattern] == text[indexForText]:#continue the pattern search, there has been a match
            indexForPattern += 1 
            indexForText += 1
        #check if we are done
        if indexForPattern == mPatternLength: #pattern has been fully found
            print ("Found Pattern at index", str(indexForText-indexForPattern)) #print starting index
            indexForPattern = longestPrefixSuffix[indexForPattern-1]; #set the index for the pattern to the last index of the prefix mapping
        #we are not done and there is a mismatch between the pattern and the text
        elif indexForText < nTextLength and pattern[indexForPattern] != text[indexForText]:
            #characters do not match
            if indexForPattern != 0: #if we are not at the start of the pattern
                indexForPattern = longestPrefixSuffix[indexForPattern-1]; #reset the pattern to one before the current pattern index
            else:
                #move to the next index, but carry the existing indexForPattern
                indexForText += 1 

def main():
    #inputText = "this is a test testest"
    #pattern = "test"
    pattern = "dsgwadsgz"
    inputText = "adsgwadsxdsgwadsgz"
    KMPSearch(pattern, inputText)

main()