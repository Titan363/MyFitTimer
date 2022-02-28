/*
 * CEN 4031 Advanced Programming Development Framework
 * Class: 3222  Instructor: Tillman  Team: Honey Badger
 * Final Project: MyFitTimer
 * Members: Jacob Leffew, William Kategianes, Sean Meinsen
*/
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFitTimer.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
        
    }
}
