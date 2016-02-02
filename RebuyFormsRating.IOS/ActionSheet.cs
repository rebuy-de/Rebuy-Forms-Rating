using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using RebuyFormsRating.IOS;

[assembly: Dependency(typeof(ActionSheet))]
namespace RebuyFormsRating.IOS
{
    public class ActionSheet : IActionSheet
    {
        public async Task<string> UseActionSheet(Page page, string title, string cancel, params string[] buttons)
        {
            return await page.DisplayActionSheet(title, cancel, null, buttons);
        }
    }
}
