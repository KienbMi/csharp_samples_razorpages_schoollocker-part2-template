using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolLocker.Core.Contracts;
using SchoolLocker.Core.DataTransferObjects;
using System.Threading.Tasks;

namespace SchoolLocker.Web.Pages
{
  public class IndexModel : PageModel
  {
    private readonly IUnitOfWork _unitOfWork;

    public IndexModel(IUnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
    }

    public SchoolLockerOverviewDto[] SchoolLockerOverviewDtos { get; set; }

    public async Task OnGet()
    {
      SchoolLockerOverviewDtos = await _unitOfWork.LockerRepository.GetLockersOverviewAsync();
    }
  }


}
