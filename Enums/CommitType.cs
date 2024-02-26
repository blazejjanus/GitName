using System.ComponentModel.DataAnnotations;

namespace GitName.Enums {
    internal enum CommitType {
        [Display(Name = "Feature")]
        feat = 1,
        [Display(Name = "Fix")]
        fix = 2,
        [Display(Name = "Refactor")]
        refactor = 3,
        [Display(Name = "Refactor/Performance")]
        perf = 4,
        [Display(Name = "Code style (cleanup)")]
        style = 5,
        [Display(Name = "Test")]
        test = 6,
        [Display(Name = "Documentation")]
        docs = 7,
        [Display(Name = "Build (dependencies built)")]
        build = 8,
        [Display(Name = "Operations (infrastructure)")]
        ops = 9,
        [Display(Name = "Chore (production code changes)")]
        chore = 10,
    }
}
