using GitName.Enums;

namespace GitName {
    internal class Program {
        static void Main(string[] args) {
            var opts = args.ToList();
            if(args.Length == 0) {
                DisplayHelp();
                opts.Add(Console.ReadLine() ?? "");
            }
            if(opts.Contains("-b") || opts.Contains("--branch") || opts.Contains("b")) {
                GenBranch(); return;
            }
            if(opts.Contains("-c") || opts.Contains("--commit") || opts.Contains("c")) {
                GenCommit(); return;
            }
            if(opts.Contains("-cb") || opts.Contains("--cfb") || opts.Contains("--commit-from-branch") || opts.Contains("cb")) {
                GenCommitFromBranch(); return;
            }
            Console.WriteLine("ERROR: No option provided!");
            DisplayHelp();
        }

        private static void GenBranch() {
            var name = new BranchName();
            Console.WriteLine("Generating branch name, please provide required info.");
            name.Type = Input.Enum<BranchType>("Branch type");
            name.Task = Input.Task("Task id");
            name.Name = Input.String("Task name");
            Console.WriteLine("\nGenerated branch name:\n");
            Console.WriteLine(name.ToString());
        }

        private static void GenCommit() {
            var name = new CommitName();
            Console.WriteLine("Generating commit name, please provide required info.");
            name.Type = Input.Enum<CommitType>("Commit type");
            name.Name = Input.OptionalString("Changes area / Name (optional)");
            name.Description = Input.String("Commit description");
            name.BreakingChange = Input.OptionalString("Describe breaking change if present (optional)");
            name.Changes = ReadList("Do you want to provide changes list?");
            name.Tasks = ReadList("Do you want to provide tasks?", true);
            Console.WriteLine("\nGenerated commit name:\n");
            Console.WriteLine(name.ToString());
        }

        private static void GenCommitFromBranch() {
            Console.WriteLine("Generating commit name, please provide required info.");
            string branchName = Input.String("Branch name");
            var branch = BranchName.ParseString(branchName);
            var name = CommitName.FromBranchName(branch);
            Console.WriteLine("\nGenerated commit name:\n");
            Console.WriteLine(name.ToString());
        }

        private static List<string>? ReadList(string message, bool task = false) {
            var result = new List<string>();
            var b = Input.Bool(message, false);
            int counter = 1;
            while(b) {
                var temp = string.Empty;
                if(task) {
                    temp = Input.Task(counter.ToString());
                } else {
                    temp = Input.OptionalString(counter.ToString());
                }
                if(string.IsNullOrEmpty(temp) || string.IsNullOrWhiteSpace(temp)) {
                    break;
                }
                result.Add(temp);
                counter++;
            }
            if(result.Count == 0) {
                return null;
            }
            return result;
        }

        private static void DisplayHelp() {
            Console.WriteLine("Please provide an option:\n\t-b - branch\n\t-c --commit\n\t-cb - commit from generated branch name");
        }
    }
}
