using StrategyShipping.Models;
using System.Net;
using System.Net.Mail;


namespace StrategyShipping.Strategies.Invoice
{
    public class EmailInvoiceStrategy : InvoiceStrategy
    {
        public override void Generate(Order order)
        {
            using (SmtpClient client = new("smtp.sendgrid.net", 587))
            {
                NetworkCredential credentials = new("USERNAME", "PASSWORD");
                client.Credentials = credentials;

                MailMessage message = new("FROM", "TO")
                {
                    Subject = "Invoice for order",
                    Body = GenerateTextInvoice(order)
                };

                client.Send(message);
            }
        }
    }
}
