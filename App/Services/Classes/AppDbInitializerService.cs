using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Services.Interfaces;
using DataAccessLayer;
using DataAccessLayer.Entities;

namespace App.Services.Classes
{
    internal class AppDbInitializerService:IDbInitializerService
    {
        private readonly DefaultContext _context;

        public AppDbInitializerService(DefaultContext context)
        {
            _context = context;
        }

        public void Seed()
        {
        }

    }
}
