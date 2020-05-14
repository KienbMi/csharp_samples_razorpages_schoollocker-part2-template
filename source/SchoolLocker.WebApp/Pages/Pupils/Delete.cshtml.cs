using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolLocker.Core.Contracts;
using SchoolLocker.Core.Entities;
using System.Threading.Tasks;

namespace SchoolLocker.Web.Pages.Pupils
{
    public class DeleteModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public Pupil Pupil { get; set; }

        public async Task<IActionResult> OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Pupil = await _unitOfWork.PupilRepository.GetByIdAsync(id.Value);

            if (Pupil == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Pupil =await _unitOfWork.PupilRepository.GetByIdAsync(id.Value);

            if (Pupil != null)
            {
                _unitOfWork.PupilRepository.Delete(Pupil);
                await _unitOfWork.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
