using System;
using System.IO;
using System.Text;
namespace forNik
{
    public class Crypto
    {
        private long secretKey;
        public long openKey;
        private long p1;
        private long p2;
        private long num;

        public Crypto(ref long openKey)
        {
            string path = "/Users/alex/Projects/forNik/forNik/1.txt";
            string help = File.ReadAllText(path);
            Console.WriteLine(help);
            this.p1 = 17;
            this.p2 = 11;
            this.num = this.p1*this.p2;
            long Phinum = phi_p(this.p1) * phi_p(this.p2);
            generate(Phinum);
            openKey = this.openKey;
        }

        public long Encrypt(long open_key,long message) {
            return (long)Math.Pow(message,open_key);
        }


        public long Decrypt(long message)
        {
            return (long)Math.Pow(message,secretKey);
        }

        private long phi_p(long p)
        {
            return p - 1;
        }

        private void generate(long Phnum)
        {
           
            
            bool flag = false;
            DateTime time = new DateTime();
            Console.WriteLine(time.Ticks);
            Random random = new Random((int)time.Ticks);
            do
            {
                
            
                long e = ((long)random.Next(0, int.MaxValue))%Phnum;
               long d = 1;
                long cnum = Phnum;
                long ce = e;
                long help;
                long v = 0;
                if (ce != 0)
                {
                    while (cnum % ce != 0)
                    {
                        long t = cnum / ce;
                        help = ce;
                        ce = cnum % ce;
                    }
                }
                if (ce == 1)
                {
                    Console.WriteLine(e);
                    this.openKey = e;
                    this.secretKey = v;
                    flag = false;
                }
                else
                {
                    
                    flag = true;
                }

            } while (flag);
        }
        
    }
  
}
