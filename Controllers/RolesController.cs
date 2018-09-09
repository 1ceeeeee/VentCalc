using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VentCalc.Models;

namespace VentCalc.Controllers {
    [Route("api/[controller]")]
    public class RolesController : Controller {
        private readonly UserManager<AppUser> _userManager;

        private readonly RoleManager<IdentityRole> _roleManager;

        public RolesController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager) {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        public async Task<IEnumerable<IdentityRole>> GetAll() {
            return _roleManager.Roles.ToList();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] string name) {

            if (string.IsNullOrEmpty(name))
                return BadRequest(("create_role_failure", "Не удалось создать роль, имя роли не было передано"));                

            var role = await _roleManager.CreateAsync(new IdentityRole(name));

            return Ok(name);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id) {
            if (string.IsNullOrEmpty(id))
                return BadRequest(("delete_role_failure", "Не удалось удалить роль, ид роли не был передан"));

            var role = await _roleManager.FindByIdAsync(id);

            if(role != null){
                await _roleManager.DeleteAsync(role);
            }

            return Ok(id);
        }
    }
}