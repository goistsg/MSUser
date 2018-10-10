using MSUser.Data;
using MSUser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSUser.Services
{
    public class TokenService
    {
        private AppDbContext _context;

        public TokenService(AppDbContext context)
        {
            _context = context;
        }

        public Token find(string id)
        {
            return _context.Tokens.Where(t => t.Id == id).FirstOrDefault();
        }

        public void createAccess(Token token)
        {
            _context.Tokens.Add(token);
            _context.SaveChanges();
        }
    }
}
