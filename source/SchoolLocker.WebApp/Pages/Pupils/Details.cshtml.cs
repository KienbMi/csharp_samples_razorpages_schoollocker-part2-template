using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolLocker.Core.Contracts;
using SchoolLocker.Core.Entities;
using System.Threading.Tasks;

namespace SchoolLocker.Web.Pages.Pupils
{
  public class DetailsModel : PageModel
  {
    private readonly IUnitOfWork _unitOfWork;

    public DetailsModel(IUnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
    }

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
  }
}
