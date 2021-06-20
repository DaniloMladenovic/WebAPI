using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GroupController : ControllerBase
    {
        public KingdomContext Context { get; set; }

        public GroupController(KingdomContext context)
        {
            Context = context;
        }

        [Route("GetGroups")]
        [HttpGet]
        public async Task<List<Group>> GetGroups()
        {
            return await Context.Groups.Include(p => p.Heroes).ToListAsync();
        }

        [Route("MakeGroup")]
        [HttpPost]
        public async Task MakeGroup([FromBody] Group group)
        {
            Context.Groups.Add(group);
            await Context.SaveChangesAsync();
        }

        [Route("ChangeGroup")]
        [HttpPut]
        public async Task ChangeGroup([FromBody] Group group)
        {
            Context.Update<Group>(group);
            await Context.SaveChangesAsync();
        }

        [Route("DeleteGroup/{id}")]
        [HttpDelete]
        public async Task DeleteGroup(int id)
        {
            var group = await Context.Groups.FindAsync(id);
            Context.Remove(group);
            await Context.SaveChangesAsync();
        }

        [Route("AddHero/{groupID}")]
        [HttpPost]
        public async Task<ActionResult> AddHero(int groupID, [FromBody] Hero hero)
        {
            var group = await Context.Groups.FindAsync(groupID);
            hero.Group = group;
            Context.Heroes.Add(hero);
            await Context.SaveChangesAsync();
            return Ok(hero.ID);
        }
    }
}