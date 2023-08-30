using Panda.Core.Common.Enums;
using Panda.Core.Modules.Categories.Domain;
using Panda.Core.Modules.Sages.Domain;

namespace Panda.Core.Calculation;
public sealed class SageActualsCalculator
{
    private readonly List<SageActual> _sageActuals;
    private readonly List<Category> _categories;

    public SageActualsCalculator(List<SageActual> sageActuals, List<Category> categories)
    {
        _sageActuals = sageActuals;
        _categories = categories;
    }

    public void CalculateForCategoryField(CategoryField categoryField)
    {
        var filteredCategories = _categories.Where(category => category.CategoryField == categoryField);
    }

}