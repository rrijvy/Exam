using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exam.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Exam.Controllers
{
    public class GetDataController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GetDataController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Questions(int id)
        {
            var question = await _context.Question.SingleOrDefaultAsync(x => x.Id == id);

            if(question == null)
            {
                return NotFound();
            }

            return Json(question);
        }
    }
}