using Panda.Core.Common.Enums;
using Panda.Core.Modules.Categories.Domain;

namespace Panda.Core.Unit.Tests;
public class CategoryTest
{
    [Fact]
    public void Test_Category_Status()
    {
        var category = new Category("Test Category", Guid.NewGuid(), CategoryType.CorporateCosts, CategoryField.CC);
        category.SetNotStarted();
        Assert.Equal(Status.NotStarted, category.Status);
        category.SetInProgress();
        Assert.Equal(Status.InProgress, category.Status);
        category.SetReviewed();
        Assert.Equal(Status.Reviewed, category.Status);
        category.SetApproved();
        Assert.Equal(Status.Approved, category.Status);
    }
}