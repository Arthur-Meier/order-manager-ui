using System;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using OrderManager.Data;
using OrderManager.Models;

namespace OrderManagerUi.Controllers
{
    public partial class ClientController(ApplicationDbContext context) : Controller
    {
        private readonly ApplicationDbContext _context = context;

        public IActionResult Index()
        {
            var clientes = _context.Clients.ToList();
            return View(clientes);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Client cliente)
        {
            cliente.Birthday = cliente.Birthday.ToUniversalTime();
            // Verifica se o modelo passado no formulário é válido
            if (!ModelState.IsValid)
            {
                return View(cliente);
            }

            // Validação manual do CPF
            if (!IsValidCpf(cliente.Cpf))
            {
                ModelState.AddModelError("Cpf", "CPF inválido.");
                return View(cliente);
            }

            if (_context.Clients.Any(c => c.Cpf == cliente.Cpf))
            {
                ModelState.AddModelError("Cpf", "CPF já cadastrado.");
                return View(cliente);
            }

            // Validação manual da data de nascimento
            if (CalculateAge(cliente.Birthday) < 18)
            {
                ModelState.AddModelError("DataNascimento", "O cliente deve ter 18 anos ou mais.");
                return View(cliente);
            }

            // Se chegou até aqui, salva no banco
            _context.Clients.Add(cliente);
            var registrosSalvos = _context.SaveChanges();
            if (registrosSalvos == 0)
            {
                ModelState.AddModelError("", "Erro ao salvar no banco de dados.");
                return View(cliente);
            }
            return RedirectToAction("Index");
        }

        // Valida CPF (somente um exemplo simples de regex, para validação completa use uma biblioteca)
        public static bool IsValidCpf(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf))
                return false;

            cpf = cpf.Replace(".", "").Replace("-", "").Trim();

            if (cpf.Length != 11 || cpf.Distinct().Count() == 1)
                return false;

            int[] multiplicador1 = [10, 9, 8, 7, 6, 5, 4, 3, 2];
            int[] multiplicador2 = [11, 10, 9, 8, 7, 6, 5, 4, 3, 2];
            string tempCpf = cpf[..9];
            int soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            int resto = soma % 11;
            int digito1 = resto < 2 ? 0 : 11 - resto;

            tempCpf += digito1;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            int digito2 = resto < 2 ? 0 : 11 - resto;

            return cpf.EndsWith(digito1.ToString() + digito2.ToString());
        }


        // Valida e-mail
        public static bool IsValidEmail(string email)
        {
            var regex = EmailRegex();
            return regex.IsMatch(email);
        }

        // Calcula a idade com base na data de nascimento
       public static int CalculateAge(DateTime birthDate)
       {
            var today = DateTime.Today;
            int age = today.Year - birthDate.Year;

            if (birthDate.Date > today.AddYears(-age)) 
                age--;

            return age;
       }

        [GeneratedRegex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")]
        private static partial Regex EmailRegex();
    }
}
