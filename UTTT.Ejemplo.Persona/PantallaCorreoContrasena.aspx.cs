using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UTTT.Ejemplo.Linq.Data.Entity;

namespace UTTT.Ejemplo.Persona
{
    public partial class PantallaCorreoContrasena : System.Web.UI.Page
    {
        private DataContext dcGlobal = new DcGeneralDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnBuscar_Click(object sender,EventArgs e)
        {
            List<UTTT.Ejemplo.Linq.Data.Entity.Persona> listape = dcGlobal.GetTable<UTTT.Ejemplo.Linq.Data.Entity.Persona>().ToList();
            List<UTTT.Ejemplo.Linq.Data.Entity.Usuario> listaus = dcGlobal.GetTable<UTTT.Ejemplo.Linq.Data.Entity.Usuario>().ToList();
            //bool resiltstatus = listape.Any(p => p.carroElectronico == this.email.Text);

            var resultado = (from u in listaus
                                join p in listape
                                on u.personaId equals p.id
                                where p.carroElectronico == this.email.Text
                                select new
                                {
                                    Id = p.id,
                                    Correos = p.carroElectronico,
                                    User = u.usuario1
                                }).FirstOrDefault();
                            ;

            if (resultado == null)
            {
                this.msgWarningCampos.Visible = true;
                this.msgWarningCampos.InnerText = "El correo no Existe";
            }
            else
            {

                //send email
                try
                {
                    String ToEmailAddress = this.email.Text.ToString();
                    String Username = Encriptar(resultado.User.ToString());
                    String EmailBody = "<br/><br/> Link para la recuperacion de la contraseña <br/><br/> http://localhost:36683/PantallaRecuperarContrasena.aspx?Uid=" + Username;
                    MailMessage PassRecMail = new MailMessage("kazawasaque@gmail.com", ToEmailAddress);
                    PassRecMail.Body = EmailBody;
                    PassRecMail.IsBodyHtml = true;
                    PassRecMail.Subject = "Recuperar Contraseña";
                    PassRecMail.Priority = MailPriority.High;
                    SmtpClient SMTP = new SmtpClient("smtp.gmail.com", 587);
                    SMTP.DeliveryMethod = SmtpDeliveryMethod.Network;
                    SMTP.UseDefaultCredentials = false;
                    SMTP.Credentials = new NetworkCredential()
                    {
                        UserName = "kazawasaque@gmail.com",
                        Password = "Alfalfa90!@!#!@#ASDASDewee}{}"
                    };
                    SMTP.EnableSsl = true;
                    SMTP.Send(PassRecMail);
                    this.msgWarningCampos.Visible = true;
                    this.msgWarningCampos.InnerText = "Correo Enviado Cheque su correo";

                }
                catch (Exception _e)
                {
                    Response.Write("<script>alert('"+_e.Message.ToString()+"');</script>");
                }
             

            }


            /*
            if (resiltstatus)
            {
                this.msgWarningCampos.Visible = true;
                this.msgWarningCampos.InnerText = "El correo Existe";
            }
            else
            {
                this.msgWarningCampos.Visible = true;
                this.msgWarningCampos.InnerText = "El correo no Existe";
            }   
            */
        }
        protected static string Encriptar(string _cadenaAencriptar)
        {
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(_cadenaAencriptar);
            result = Convert.ToBase64String(encryted);
            return result;
        }
    }
}