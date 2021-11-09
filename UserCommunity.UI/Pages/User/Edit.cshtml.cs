using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserCommunity.Access;
using UserCommunity.DTO;

namespace UserCommunity.UI.Pages.User
{
    public class EditModel : PageModel
    {
        private readonly IDataAccess<UserDTO> _dataAccess;
        [BindProperty]
        public UserDTO CurrentUser { get; set; }
        public EditModel(IDataAccess<UserDTO> DataAccess)
        {
            _dataAccess = DataAccess;
        }
        public void OnGet(int id)
        {
            CurrentUser = _dataAccess.LoadById(id);
        }

        public ActionResult OnPostEdit()
        {
            if (ModelState.IsValid)
            {
                _dataAccess.Update(CurrentUser);
                return RedirectToPage("/User/List");
            }
            return Page();
        }

        public ActionResult OnPostDelete()
        {
            if (ModelState.IsValid)
            {
                _dataAccess.Delete(CurrentUser);
                return RedirectToPage("/User/List");
            }
            return Page();
        }

    }
}
