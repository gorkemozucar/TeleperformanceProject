
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HangfireService.Services
{
    public class EmailService : IEmailService
    {
        private readonly AppDbContext _context;
        public EmailService(AppDbContext context)
        {
            _context = context;
        }
        public void SendEmail()
        {
            var lists = _context.ShoppingLists.ToList();
            foreach (var list in lists)
            {
                File.AppendAllText(@"C:\Users\sg_oz\Desktop\patikabootcamp\hangfire.txt", $"Tamamlanmış Liste Id'si: {list.Id}\n");
            }
            Console.WriteLine("Email gönderildi.");
        }
    }
}
