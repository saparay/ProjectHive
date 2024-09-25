using Microsoft.AspNetCore.Mvc;
using ProjectHive.API.Models.DTO;
using ProjectHive.API.Services;

namespace ProjectHive.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountListController : Controller
    {
        private readonly IAccountListService _accountListService;

        public AccountListController(IAccountListService accountListService)
        {
            _accountListService = accountListService;
        }
        [HttpGet]
        public Task<List<AccountListDto>> GetAllAccountList()
        {
            return _accountListService.GetAllAccountsAsync();
        }
    }
}
