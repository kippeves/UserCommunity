using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserCommunity.Access;
using UserCommunity.DTO;

namespace UserCommunity.UI.Pages.User
{
    public class CreateModel : PageModel
    {
        private readonly IDataAccess<UserDTO> _dataAccess;
        [BindProperty]
        public UserDTO CurrentUser { get; set; }
        public CreateModel(IDataAccess<UserDTO> DataAccess)
        {
            _dataAccess = DataAccess;
        }
        public void OnGet(int id)
        {
            CurrentUser = _dataAccess.LoadById(id);
        }
        public ActionResult OnPostSave()
        {
            if (ModelState.IsValid)
            {
                _dataAccess.Save(CurrentUser);
                return RedirectToPage("/user/List");
            }
            return Page();
        }
    }
}
