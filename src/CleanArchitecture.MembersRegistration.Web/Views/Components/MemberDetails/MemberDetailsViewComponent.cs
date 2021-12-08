using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.MembersRegistration.Web.Views.Components.MemberDetails
{
    public class MemberDetailsViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
            => View(new MemberDetailsViewModel());
    }
}