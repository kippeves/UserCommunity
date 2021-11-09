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
    public class ListModel : PageModel
    {
        readonly IDataAccess<UserDTO> _dataAccess;

        [BindProperty]
        public List<UserDTO> Users { get; set; }
        [BindProperty]
        public int ID { get; set; }
        public ListModel(IDataAccess<UserDTO> DataAccess)
        {
            _dataAccess = DataAccess;
        }

        public void OnGet() {
            Users = _dataAccess.LoadAll().ToList();
        }
        public IActionResult OnPostEdit()
        {
            if (ModelState.IsValid)
            {
                return RedirectToPage("/User/Edit","Edit", new  {id = ID});
            }
            return Page();
        }
    }
}
