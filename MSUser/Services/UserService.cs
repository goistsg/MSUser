using Microsoft.ApplicationInsights.Extensibility.Implementation;
using MSUser.Data;
using MSUser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSUser.Services
{
    public class UserService
    {
        private AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public User find(int id)
        {
            if (id > 0)
            {
                return _context.Users.Where(u => u.Id == id).FirstOrDefault();
            }
            else {
                return null;
            }
        }

        public IEnumerable<User> findAll()
        {
            return _context.Users.OrderBy(u => u.Nome).ToList();
        }

        public String create(User dadosUsuario)
        {
            if (_context.Users.Where(
                u => u.Login == dadosUsuario.Login).Count() > 0)
            {
                return "O login já está cadastrado";
            }
            
            _context.Users.Add(dadosUsuario);
            _context.SaveChanges();

            return "Cadastro realizado com sucesso!";
        }

        public String edit(User dadosUsuario)
        {
            User user = find(dadosUsuario.Id);

            if (user == null)
            {
                return "Usuário não foi encontrado";
            }
            else
            {
                user.Nome = dadosUsuario.Nome;
                user.Email = dadosUsuario.Email;
                user.Login = dadosUsuario.Login;
                _context.SaveChanges();
            }

            return "Alterações realizadas com sucesso!";
        }

        public String delete(int id)
        {
            User user = find(id);
            if (user == null)
            {
                return "Usuário não foi encontrado";
            }
            else
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }

            return "Usuário removido com sucesso!";
        }
    }
}
