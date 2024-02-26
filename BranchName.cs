using GitName.Enums;
using GitName.Utils;
using System.Text;

namespace GitName {
    internal class BranchName {
        public BranchType Type { get; set; }
        public string Task { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;

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
    }
}
