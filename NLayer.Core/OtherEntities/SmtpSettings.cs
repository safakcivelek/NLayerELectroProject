namespace NLayer.Core.OtherEntities
{
    public class SmtpSettings
    {
        public string Server { get; set; }
        public int Port { get; set; }
        public string SenderName { get; set; } // E-Posta kim tarafından gönderiliyor? Örnek:Electro tarafından.
        public string SenderEmail { get; set; } // Emaili kim gönderiyor.
        public string Username { get; set; } // Smtp Serverine hangi kullanıcı olarak bağlanuıyoruz.
        public string Password { get; set; } // Smtp Serverine hangi kullanıcı olarak bağlanuıyoruz.
    }
}
