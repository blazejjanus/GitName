﻿using GitName.Enums;
using GitName.Enums.Helpers;
using GitName.Utils;
using System.Text;

namespace GitName {
    internal class CommitName {
        public CommitType Type { get; set; }
        public string? Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public List<string>? Tasks { get; set; }
        public string? BreakingChange { get; set; }
        public List<string>? Changes { get; set; }

        internal static CommitName FromBranchName(BranchName branch) {
            var result = new CommitName {
                Type = CommitTypeHelper.FromBranchType(branch.Type),
                Description = branch.Name,
                Tasks = [branch.Task]
            };
            return result;
        }

        public override string ToString() {
            var sb = new StringBuilder();
            //Header
            sb.Append(Type.ToString());
            if(!string.IsNullOrEmpty(Name)) {
                sb.Append($"({Name})");
            }
            if(!string.IsNullOrEmpty(BreakingChange)) {
                sb.Append("!");
            }
            sb.Append(": " + StringUtils.FormatEntry(Description));
            //Body
            if(Changes != null && Changes.Count > 0) {
                sb.Append("\n");
                sb.Append("\nChanges:\n");
                foreach(var change in Changes) {
                    sb.Append("- " + StringUtils.FormatEntry(change));
                    sb.Append("\n");
                }
            }
            if(Tasks != null && Tasks.Count > 0) {
                if(sb[sb.Length - 1] != '\n') {
                    sb.Append('\n');
                }
                sb.Append("\n");
                string tasks = string.Empty;
                for(int i = 0; i < Tasks.Count; i++) {
                    tasks += Tasks[i];
                    if(i < Tasks.Count - 1) {
                        tasks += ", ";
                    }
                }
                sb.Append("Refers to: " + tasks);
                sb.Append("\n");
            }
            //Footer
            if(!string.IsNullOrEmpty(BreakingChange)) {
                sb.Append($"\nBREAKING CHANGES: {BreakingChange}\n");
            }
            return sb.ToString();
        }
    }
}
