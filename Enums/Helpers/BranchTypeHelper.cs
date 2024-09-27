namespace GitName.Enums.Helpers {
    internal static class BranchTypeHelper {
        public static BranchType Parse(string branchType) {
            branchType = branchType.Trim();
            branchType = branchType.ToLower();
            var branchTypes = Enum.GetValues<BranchType>();
            foreach(var type in branchTypes) {
                if(type.ToString() == branchType) return type;
            }
            throw new Exception($"Provided value {branchType} does not match any supported branch type.");
        }
    }
}
