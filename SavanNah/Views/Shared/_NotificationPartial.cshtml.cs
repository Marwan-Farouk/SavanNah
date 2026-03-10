using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace SavanNah.Views.Shared
{
    public class _NotificationPartial : PageModel
    {
        private readonly ILogger<_NotificationPartial> _logger;

        public _NotificationPartial(ILogger<_NotificationPartial> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}