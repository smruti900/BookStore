﻿using BookStore.Data;
using BookStore.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Repository
{
    public class LanguageRepository
    {
        private readonly BookStoreContext _context = null;
        public LanguageRepository(BookStoreContext context)
        {
            _context = context;
        }
        public async Task<List<LanguageModel>> GetLanguage()
        {
            return await _context.Language.Select(x => new LanguageModel()
            {
                Id=x.Id,
                Description=x.Description,
                Name=x.Name
            }).ToListAsync();
        }
    }
}
