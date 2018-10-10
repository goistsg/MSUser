using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSUser.Models
{
    public class User
    {
        public int Id { get; private set; }
        public String Nome { get; set; }
        public String Email { get; set; }
        public String Login { get; set; }
        public String Senha { get; set; }
        public DateTime DataCriacao { get; private set; }

        protected User ()
        {
        }

        public User(String nome, String email, String login)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                throw new Exception("Campo 'nome' não pode ser vazio.");
            }
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new Exception("Campo 'email' não pode ser vazio.");
            }
            if (string.IsNullOrWhiteSpace(login))
            {
                throw new Exception("Campo 'login' não pode ser vazio.");
            }
            Nome = nome;
            Email = email;
            Login = login;
        }
    }
}
