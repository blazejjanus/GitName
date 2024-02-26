using GitName.Utils;

namespace GitName {

    public static class Input {
        public static string String(string message) {
            string? input;
            do {
                Console.Write(message + ": ");
                input = Console.ReadLine()?.Trim();
                if(string.IsNullOrEmpty(input)) {
                    Console.WriteLine("Please enter a non-empty string.");
                }
            } while(string.IsNullOrEmpty(input));

            return input;
        }

        public static string? OptionalString(string message) {
            Console.Write(message + ": ");
            return Console.ReadLine()?.Trim();
        }

        public static bool Bool(string message, bool? defaultValue = null) {
            string[] trueValues = { "y", "yes", "t", "true", "tak", "1" };
            string[] falseValues = { "n", "no", "nie", "f", "false", "0" };
            string tooltip = string.Empty;
            if(defaultValue == null)
                tooltip = "(y/n)";
            if(defaultValue == true)
                tooltip = "(Y/n)";
            if(defaultValue == false)
                tooltip = "(y/N)";
            string? input;
            do {
                Console.Write(message + $" {tooltip}: ");
                input = Console.ReadLine()?.Trim().ToLower();
                if(string.IsNullOrEmpty(input)) {
                    if(defaultValue.HasValue)
                        return defaultValue.Value;
                    Console.WriteLine("Please enter a valid input.");
                    continue;
                }
                if(Array.Exists(trueValues, element => element.Equals(input)))
                    return true;

                if(Array.Exists(falseValues, element => element.Equals(input)))
                    return false;
                Console.WriteLine("Please enter a valid input.");
            } while(true);
        }

        public static string Task(string message, bool required = false) {
            string? input;
            do {
                Console.Write(message + ": ");
                input = Console.ReadLine()?.Trim();
                if(string.IsNullOrEmpty(input) && !required) {
                    return string.Empty;
                }
                if(string.IsNullOrEmpty(input) || !input.Contains("-")) {
                    Console.WriteLine("Please enter a valid input containing '-' character.");
                    continue;
                }
                string[] parts = input.Split('-');
                if(parts.Length != 2 || string.IsNullOrEmpty(parts[0]) || string.IsNullOrEmpty(parts[1]) || !char.IsLetter(parts[0][0])) {
                    Console.WriteLine("Invalid format. Please follow the pattern: <letters/numbers>-<numbers>");
                    continue;
                }
                input = parts[0].ToUpper() + "-" + parts[1];
                break;
            } while(true);
            return input;
        }

        public static T Enum<T>(string message) where T : Enum {
            Console.WriteLine(message + ": ");
            foreach(T enumValue in System.Enum.GetValues(typeof(T))) {
                Console.WriteLine($"\t{Convert.ToInt32(enumValue)} - {enumValue.GetName()}");
            }
            T result;
            do {
                Console.Write("Enter the number corresponding to your choice: ");
                string? input = Console.ReadLine();
                if(int.TryParse(input, out int intValue) && System.Enum.IsDefined(typeof(T), intValue)) {
                    result = (T)System.Enum.ToObject(typeof(T), intValue);
                    return result;
                }
                Console.WriteLine("Invalid input. Please enter the number corresponding to your choice.");
            } while(true);
        }
    }
}
