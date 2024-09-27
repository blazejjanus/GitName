using GitName.Enums;
using GitName.Enums.Helpers;
using GitName.Utils;
using System.Text;

namespace GitName {
    internal class BranchName {
        public BranchType Type { get; set; }
        public string Task { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;

        public static BranchName ParseString(string branchName) {
            var result = new BranchName();
            branchName = branchName.Trim();
            var parts = branchName.Split('/');
            if(parts.Length == 3) {
                result.Type = BranchTypeHelper.Parse(parts[0]);
                result.Task = parts[1];
                result.Name = NormalizeBranchName(parts[2]);
            } else if(parts.Length == 2) {
                result.Type = BranchTypeHelper.Parse(parts[0]);
                result.Name = NormalizeBranchName(parts[1]);
            } else {
                throw new Exception("Provided branch name is not in valid format!");
            }
            return result;
        }

        public override string ToString() {
            var sb = new StringBuilder();
            sb.Append(Type.ToString());
            sb.Append("/");
            sb.Append(Task.Trim());
            sb.Append("/");
            var name = Name.Trim();
            name = name.Replace(" ", "-");
            name = name.Replace('\n', '-');
            name = name.Replace('\r', '-');
            name = name.Replace("---", "-");
            name = name.Replace("--", "-");
            sb.Append(StringUtils.FormatEntry(name));
            return sb.ToString();
        }

        private static string NormalizeBranchName(string name) {
            name = name.Trim();
            name = StringUtils.UppercaseFirstLetter(name);
            name = StringUtils.ReplaceSpaceReplacementWithSpaces(name);
            name = StringUtils.AddDotIfNotSentenceEndingCharPresent(name);
            return name;
        }
    }
}
