using System.Security.Cryptography;
using System.Text;
using UrbanFarming.Domain.Classes;
using UrbanFarming.Domain.Exceptions;
using UrbanFarming.Domain.Interfaces.Repositories;
using UrbanFarming.Domain.Interfaces.Services;

namespace UrbanFarming.Service.AppService
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;

        public LoginService(ILoginRepository clienteRepository)
        {
            _loginRepository = clienteRepository;
        }

        public async Task<Login> GetByEmail(string email)
        {
            var usuario = await _loginRepository.GetByEmail(email);

            return usuario;
        }

        public async Task<bool> PostUsuario(Login usuario)
        {
            var sucesso = await _loginRepository.PostUsuario(usuario);

            if (!sucesso)
                throw new NotFoundException("Não foi possível cadastrar o usuário.");

            return sucesso;
        }

        public async Task<bool> CadastrarUsuario(Login usuario)
        {
            var cadastroExiste = await GetByEmail(usuario.Email);

            if (cadastroExiste != null)
                throw new BadRequestException("Usuário já cadastrado.");

            usuario.Senha = HashPassword(usuario.Senha);

            return await PostUsuario(usuario);
        }

        public async Task<(Login usuario, bool sucesso)> Login(string email, string senha)
        {
            var usuario = await _loginRepository.GetByEmail(email);

            if (usuario == null)
                return (null, false);

            if (!VerificaSenha(senha, usuario.Senha))
                return (null, false);

            return (usuario, true);
        }

        private string HashPassword(string senha)
        {
            using var hmac = new HMACSHA256();
            var salt = hmac.Key;

            var hashedPassword = hmac.ComputeHash(Encoding.UTF8.GetBytes(senha));
            var saltString = Convert.ToBase64String(salt);
            var hashString = Convert.ToBase64String(hashedPassword);

            return $"{saltString}:{hashString}";
        }

        private bool VerificaSenha(string senha, string hashedSenha)
        {
            var parts = hashedSenha.Split(':');
            var salt = Convert.FromBase64String(parts[0]);
            var storedHash = Convert.FromBase64String(parts[1]);

            using var hmac = new HMACSHA256(salt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(senha));

            return computedHash.SequenceEqual(storedHash);
        }
    }
}
