using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KingdomController : ControllerBase
    {
        public KingdomContext Context { get; set; }

        public KingdomController(KingdomContext context)
        {
            Context = context;
        }

        [Route("GetKingdoms")]
        [HttpGet]
        public async Task<List<Kingdom>> GetKingdoms()
        {
            return await Context.Kingdoms.Include(k => k.Groups).ThenInclude(gr => gr.Heroes).ToListAsync();
        }

        [Route("MakeKingdom")]
        [HttpPost]
        public async Task<IActionResult> MakeKingdom([FromBody] Kingdom kingdom)
        {
            Context.Kingdoms.Add(kingdom);
            await Context.SaveChangesAsync();
            return Ok(kingdom.ID);
        }

        [Route("ChangeKingdom")]
        [HttpPut]
        public async Task ChangeKingdom([FromBody] Kingdom kingdom)
        {
            Context.Update<Kingdom>(kingdom);
            await Context.SaveChangesAsync();
        }

        [Route("DeleteKingdom/{id}")]
        [HttpDelete]
        public async Task DeleteKingdom(int id)
        {
            var kingdom = await Context.Kingdoms.FindAsync(id);
            Context.Remove(kingdom);
            await Context.SaveChangesAsync();
        }

        [Route("AddGroup/{kingdomID}")]
        [HttpPost]
        public async Task<IActionResult> AddGroup(int kingdomID, [FromBody] Group group)
        {
            var kingdom = await Context.Kingdoms.FindAsync(kingdomID);
            group.Kingdom = kingdom;
            Context.Groups.Add(group);
            await Context.SaveChangesAsync();
            return Ok(group.ID);
        }
    }
}