using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dominio.Contracts;
using Dominio.Domain;

namespace TestApplication.Fake
{
    class EmailSenderFake : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            Console.WriteLine($"Se ha enviado el correo Fake satisfactoriamente. a {email}");
            return Task.CompletedTask;
        }
    }
    
    public class ProductServiceStub
    {
        public List<Product> Get(string tipo)
        {
            if(tipo=="Simple") return new List<Product>() { new Simple()  {  Name="Gaseosa", CostProduct= 2000, PriceProduct  = 5000}      };
            return new List<Product>() { new Compound() { Name="Gaseosa", CostProduct= 2000, PriceProduct  = 5000} };
        }
    }
}