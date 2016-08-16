using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RebuyFormsRating
{
    public interface IActionSheet
    {
        Task<String> UseActionSheet(Page page, String title, String cancel, params String[] buttons);
    }
}
