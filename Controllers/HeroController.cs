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
    public class HeroController : ControllerBase
    {
        public KingdomContext Context { get; set; }

        public HeroController(KingdomContext context)
        {
            Context = context;
        }

        [Route("GetHeroes")]
        [HttpGet]
        public async Task<List<Hero>> GetHeroes()
        {
            return await Context.Heroes.ToListAsync();
        }

        [Route("MakeHero")]
        [HttpPost]
        public async Task MakeHero([FromBody] Hero hero)
        {
            Context.Heroes.Add(hero);
            await Context.SaveChangesAsync();
        }

        [Route("ChangeHero")]
        [HttpPut]
        public async Task ChangeHero([FromBody] Hero hero)
        {
            Context.Update<Hero>(hero);
            await Context.SaveChangesAsync();
        }

        [Route("DeleteHero/{id}")]
        [HttpDelete]
        public async Task DeleteHero(int id)
        {
            var hero = await Context.Heroes.FindAsync(id);
            Context.Remove(hero);
            await Context.SaveChangesAsync();
        }
    }
}