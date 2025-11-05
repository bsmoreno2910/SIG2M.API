using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SIG2M.Servicos.Criptografia
{
    public static class ServicoDeCriptografia
    {
        private static IConfiguration _configuracao;
        private static readonly string _chave = "4>o7do;QvJ,,@|?_ZC2_Ju1a<{V?ZRJ3jLp6@]5#&lZ,R56g~y";

        public static void IniciarServico(IConfiguration configuracao)
        {
            _configuracao = configuracao;
        }

        public static string Criptografar(this string alvo)
        {
            var bytesAlvo = Encoding.UTF8.GetBytes(alvo);
            using var encriptador = ConfigurarAlgoritimoTDES(TripleDES.Create(), _chave).CreateEncryptor();
            return Convert.ToBase64String(encriptador.TransformFinalBlock(bytesAlvo, 0, bytesAlvo.Length));
        }
        public static string Criptografar(this string alvo, string chave)
        {
            var bytesAlvo = Encoding.UTF8.GetBytes(alvo);
            using var encriptador = ConfigurarAlgoritimoTDES(TripleDES.Create(), chave).CreateEncryptor();
            return Convert.ToBase64String(encriptador.TransformFinalBlock(bytesAlvo, 0, bytesAlvo.Length));
        }

        public static string Descriptografar(this string alvo)
        {
            var bytesAlvo = Convert.FromBase64String(alvo);
            using var descriptografador = ConfigurarAlgoritimoTDES(TripleDES.Create(), _chave).CreateDecryptor();
            return Encoding.UTF8.GetString(descriptografador.TransformFinalBlock(bytesAlvo, 0, bytesAlvo.Length));
        }
        public static string Descriptografar(this string alvo, string chave)
        {
            var bytesAlvo = Convert.FromBase64String(alvo);
            using var descriptografador = ConfigurarAlgoritimoTDES(TripleDES.Create(), chave).CreateDecryptor();
            return Encoding.UTF8.GetString(descriptografador.TransformFinalBlock(bytesAlvo, 0, bytesAlvo.Length));
        }

        public static bool Criptografado(this string alvo)
        {
            try
            {
                var bytesAlvo = Convert.FromBase64String(alvo);
                using var descriptografador = ConfigurarAlgoritimoTDES(TripleDES.Create(), _chave).CreateDecryptor();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private static TripleDES ConfigurarAlgoritimoTDES(TripleDES algoritimo, string chave)
        {
            using var md5 = MD5.Create();
            algoritimo.Key = md5.ComputeHash(Encoding.UTF8.GetBytes(chave));
            algoritimo.Mode = CipherMode.ECB;
            algoritimo.Padding = PaddingMode.PKCS7;

            return algoritimo;
        }
    }
}
