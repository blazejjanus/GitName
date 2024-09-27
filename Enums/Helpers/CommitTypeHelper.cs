namespace GitName.Enums.Helpers {
    internal static class CommitTypeHelper {
        public static CommitType FromBranchType(BranchType branchType) {
            return branchType switch {
                BranchType.feature => CommitType.feat,
                BranchType.bugfix => CommitType.fix,
                BranchType.hotfix => CommitType.fix,
                BranchType.test => CommitType.test,
                _ => throw new Exception($"Branch type {branchType} conversion is not implemented!"),
            };
        }
    }
}
