using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlayerManager.Data;
using PlayerManager.Models;
using PlayerManager.Models.Entities;

namespace PlayerManager.Controllers
{
    public class PlayerController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public PlayerController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddPlayerViewModel viewModel)
        {
            var player = new Player
            {
                playerName = viewModel.playerName,
                Email = viewModel.Email,
                PhoneNumber = viewModel.PhoneNumber,
                Contact = viewModel.Contact
            };
            await dbContext.players.AddAsync(player);
            await dbContext.SaveChangesAsync();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var player = await dbContext.players.ToListAsync();
            return View(player);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid Id)
        {
            var player = await dbContext.players.FindAsync(Id);

            return View(player);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Player viewModel)
        {
            var player = await dbContext.players.FindAsync(viewModel.Id);
            if (player is not null)
            {
                player.playerName = viewModel.playerName;
                player.Email = viewModel.Email;
                player.PhoneNumber = viewModel.PhoneNumber;
                player.Contact = viewModel.Contact;
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Player");
        }


        [HttpPost]
        public async Task<IActionResult> Delete(Player viewModel)
        {
            var player = await dbContext.players.AsNoTracking().FirstOrDefaultAsync(x => x.Id == viewModel.Id);

            if (player is not null)
            {
                dbContext.players.Remove(player);
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Player");
        }
    }
}
