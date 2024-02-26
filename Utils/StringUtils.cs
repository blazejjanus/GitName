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
    }
}
