using System;
using System.Net.Mail;
using System.IO;
namespace forNik
{
   class Mailbox
    {
        private string name,password,path;
        public Mailbox(string path, string name,string password) {
            if (!Directory.Exists(path))
            {
                this.name = name;
                this.path = path;
                this.password = password;
                string space = EnCrypt(" ", 1);
                string text = "0"+space+ name +space+ password;
                text = Crypt(text, 1);
                Directory.CreateDirectory(path);
                Directory.CreateDirectory(path + "/inbox");
                Directory.CreateDirectory(path + "/outbox");
                File.WriteAllText(path+"/login.txt", text);
            }
            else {
                if (check_acces(path+"/login.txt", name, password))
                { 
                    this.name = name;
                    this.path = path;
                    this.password = password;
                }
                else {
                    Console.WriteLine(name + password);
                    throw new AccessViolationException("Acess dined");
                }


            }
            
        }

        public void send_email(string path, string name,string them, string text) {

            string full_text = "From: " + this.name + "\n To: " + name + "\n them: " + them +"\n"+text;

            File.WriteAllText(path+"/"+DateTime.Now.ToString("h:mm:ss tt"), full_text);

        }


        private bool check_acces(string path,string name,string password)
        {
            string text;
            string help="";
            text = File.ReadAllText(path);
            int i;
            for (i = 0; i < text.Length; ++i) {
                if(text[i]!=' ')
                {
                    help += text[i];
                }
                else
                {
                    break;
                }
            }
            int crypto_key = int.Parse(help);
            help = "";
            ++i;
            
            for (i =i; i < text.Length; ++i)
            {
                if (text[i] != ' ')
                {
                    help += text[i];
                }
                else
                {
                    break;
                }
            }
            
            string crypt_name = help;
            help = "";
            ++i;
            for (i = i; i < text.Length; ++i)
            {
                if (text[i] != ' ')
                {
                    help += text[i];
                }
                else
                {
                    break;
                }
            }
            string crypt_password = help;
            string enrypt_login =EnCrypt(crypt_name,crypto_key);
            string encrypt_password = EnCrypt(crypt_name,crypto_key);
            if ((encrypt_password == password) && (enrypt_login == name)) return true;
            return false;
        }
        static public string Crypt(string text,int key)
        {
            string ctext="";
            for(int i = 0; i < text.Length; ++i)
            {
                ctext += (char)(text[i] + key);
            }
            return ctext;
        }
        static public string EnCrypt(string text, int key)
        {
            string ctext = "";
            for (int i = 0; i < text.Length; ++i)
            {
                ctext += (char)(text[i] - key);
            }
            return ctext;
        }

    };
}