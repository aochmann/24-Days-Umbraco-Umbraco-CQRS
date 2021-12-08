using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.MembersRegistration.Web.Views.Components.RegistrationForm
{
    public class RegistrationFormViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
            => View(new RegistrationFormViewModel());
    }
}