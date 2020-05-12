using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolLocker.Core.Contracts;
using SchoolLocker.Core.Entities;
using SchoolLocker.Web.DataTransferObjects;
using System.Threading.Tasks;

namespace SchoolLocker.Web.Pages.Pupils
{
    public class CreateModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public PupilDto Pupil { get; set; }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Pupil pupil = new Pupil
            {
                FirstName = Pupil.FirstName,
                LastName = Pupil.LastName,
            };

            await _unitOfWork.PupilRepository.AddAsync(pupil);
            await _unitOfWork.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}