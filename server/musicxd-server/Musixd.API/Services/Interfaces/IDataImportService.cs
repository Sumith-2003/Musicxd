using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Musicxd.API.Services.Interfaces
{
    public interface IDataImportService
    {
        Task<IActionResult> MapDatatoEntity();
    }
}
