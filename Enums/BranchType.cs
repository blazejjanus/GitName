using System.ComponentModel.DataAnnotations;

namespace GitName.Enums {
    internal enum BranchType {
        [Display(Name = "Feature")]
        feature = 1,
        [Display(Name = "BugFix")]
        bugfix = 2,
        [Display(Name = "HotFix")]
        hotfix = 3,
        [Display(Name = "Test")]
        test = 4,
    }
}
