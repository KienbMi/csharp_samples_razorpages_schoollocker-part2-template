using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SchoolLocker.Core.Contracts;
using SchoolLocker.Core.Entities;
using SchoolLocker.Web.DataTransferObjects;
using System.Threading.Tasks;

namespace SchoolLocker.Web.Pages.Pupils
{
    public class EditModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public EditModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public PupilDto Pupil { get; set; }

        public async Task<IActionResult> OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pupil = await _unitOfWork.PupilRepository.GetByIdAsync(id.Value);

            if (pupil == null)
            {
                return NotFound();
            }
            Pupil = new PupilDto
            {
                FirstName = pupil.FirstName,
                LastName = pupil.LastName,
                Id = pupil.Id,
                Version = pupil.Version
            };
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Pupil dbPupil = await _unitOfWork.PupilRepository.GetByIdAsync(Pupil.Id);
            dbPupil.FirstName = Pupil.FirstName;
            dbPupil.LastName = Pupil.LastName;
            dbPupil.Version = Pupil.Version;

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await PupilExists(Pupil.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private async Task<bool> PupilExists(int id)
        {
            return await _unitOfWork.PupilRepository.GetByIdAsync(id) != null;
        }
    }
}
