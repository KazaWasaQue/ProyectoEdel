﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Net;

namespace UTTT.Ejemplo.Persona.Control.Ctrl
{
    public class ctrlEmail
    {
        public void sendEmail(String message)
        {
            try
            {
                MailMessage mailMessage = new MailMessage();
                SmtpClient smtpClient = new SmtpClient();
                mailMessage.From = new MailAddress("alejandro.iran.alvarez.vazquez@gmail.com");
                mailMessage.To.Add(new MailAddress("18300312@uttt.edu.mx"));
                mailMessage.Subject = "Error / Exception Handling";
                mailMessage.IsBodyHtml = false;
                mailMessage.Body = message;
                smtpClient.Port = 587;
                smtpClient.Host = "smtp.gmail.com";
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential("alejandro.iran.alvarez.vazquez@gmail.com", "Alfalfa90");
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.Send(mailMessage);
            }
            catch (Exception _e)
            {
                Console.WriteLine(_e.Message);
            }
        }
    }
}