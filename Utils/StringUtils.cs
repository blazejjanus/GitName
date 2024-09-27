namespace GitName.Utils {
    internal static class StringUtils {
        public static string FormatEntry(string input) {
            string output = input.Trim();
            if(input.Length > 0) {
                output = char.ToLower(input[0]) + input.Substring(1);
            }
            output = output.TrimEnd('.');
            return output;
        }

        public static string UppercaseFirstLetter(string sentence) {
            sentence = sentence.Trim();
            var result = char.ToUpper(sentence.First()) + sentence.Substring(1);
            return result;
        }

        public static string AddDotIfNotSentenceEndingCharPresent(string sentence) {
            sentence = sentence.Trim();
            var last = sentence.Last();
            if(last == '.' || last == '?' || last == '!') return sentence;
            return sentence + ".";
        }

        public static string ReplaceSpaces(string sentence, char replacement = '_') {
            var result = sentence.Replace(' ', replacement);
            if(result.Contains($"{replacement}{replacement}")) {
                result = result.Replace($"{replacement}{replacement}", $"{replacement}");
            }
            return result;
        }

        public static string ReplaceSpaceReplacementWithSpaces(string sentence) {
            sentence = sentence.Trim();
            if(sentence.Contains('-')) {
                return sentence.Replace('-', ' ');
            }
            if(sentence.Contains('_')) {
                return sentence.Replace('_', ' ');
            }
            return sentence;
        }
    }
}
