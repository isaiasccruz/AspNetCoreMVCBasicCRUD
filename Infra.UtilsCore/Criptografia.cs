using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infra.Utils
{
    using System;
    using System.Security.Cryptography;
    using System.Text;

    namespace Infra.Utils
    {
        public class Criptografia
        {
            /// <summary>
            /// Criptografa uma objeto String. IMPORTANTE: a chave e o vetor deverão conter exatamente 16 bytes.
            /// </summary>
            /// <param name="valor">Objeto String a ser criptografado.</param>
            /// <returns>Retorna um objecto String criptografado.</returns>
            public static string Criptografar(string valor)
            {
                const string vetorInicializacao = "1yoU4/N5+52J1aB5";
                const string chave = "Z7A9bmlqULFD1El#";

                byte[] plainTextBytes;
                byte[] cipherTextBytes;
                RijndaelManaged symemetricKey;
                ICryptoTransform encryptor;
                System.IO.MemoryStream memoryStream;
                CryptoStream cryptoStream;

                try
                {
                    //cria os objetos
                    memoryStream = new System.IO.MemoryStream();
                    symemetricKey = new RijndaelManaged();

                    //preenche o vetor de bytes com o conteudo da string valor
                    plainTextBytes = Encoding.UTF8.GetBytes(valor);

                    //seta o metodo de criptográfia
                    symemetricKey.Mode = CipherMode.CBC;

                    //Gera o encryptor
                    encryptor = symemetricKey.CreateEncryptor(Encoding.ASCII.GetBytes(chave), Encoding.ASCII.GetBytes(vetorInicializacao));

                    //define uma stream de criptografia
                    cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);

                    //inicia a criptografia
                    cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);

                    //termina a criptografia
                    cryptoStream.FlushFinalBlock();

                    //obtém o resultado da criptografia
                    cipherTextBytes = memoryStream.ToArray();

                    //fecha os streams
                    cryptoStream.Close();
                    memoryStream.Close();

                    //retorna a string encriptografada.
                    return Convert.ToBase64String(cipherTextBytes);

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            /// <summary>
            /// Decriptografa uma objeto String. IMPORTANTE: a chave e o vetor deverão conter exatamente 16 bytes.
            /// </summary>
            /// <param name="valor">Objeto String a ser decriptografado.</param>
            /// <returns>Retorna um objecto String decriptografado.</returns>
            public static string Decriptografar(string valor)
            {
                const string vetorInicializacao = "1yoU4/N5+52J1aB5";
                const string chave = "Z7A9bmlqULFD1El#";

                byte[] cipherTextBytes;
                byte[] plainTextBytes;
                RijndaelManaged symemetricKey;
                ICryptoTransform decryptor;
                System.IO.MemoryStream memoryStream;
                CryptoStream cryptoStream;
                int decryptedByteCount;

                try
                {
                    //cria o objeto
                    symemetricKey = new RijndaelManaged();

                    //preenche o vetor de bytes com o conteudo da string valor
                    cipherTextBytes = Convert.FromBase64String(valor);

                    //seta o método de criptografia
                    symemetricKey.Mode = CipherMode.CBC;

                    //Gera o decryptor 
                    decryptor = symemetricKey.CreateDecryptor(Encoding.ASCII.GetBytes(chave), Encoding.ASCII.GetBytes(vetorInicializacao));

                    //define stream memory
                    memoryStream = new System.IO.MemoryStream(cipherTextBytes);

                    //define cryptostream
                    cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);

                    //onde ira guarda a senha decriptrografada
                    plainTextBytes = new byte[cipherTextBytes.Length];

                    //inicia a descriptografia
                    decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);

                    //fecha as streams
                    cryptoStream.Close();
                    memoryStream.Close();
                    cryptoStream.Close();

                    //retorna a senha descriptografada
                    return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);


                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            /// <summary>
            /// Criptografa uma objeto String. [NÃO HAVIA AVISO IMPORTANTE NESTE AQUI]
            /// </summary>
            /// <param name="valor">Objeto String a ser criptografado.</param>
            /// <param name="chave">Objeto String contendo a chave de criptografia.</param>
            /// <returns>Retorna um objecto String criptografado.</returns>
            public static string Criptografar(string valor, string chave)
            {
                const string vetorInicializacao = "1yoU4/N5+52J1aB5";

                if (chave.Length != 16)
                    throw new Exception("Erro: chave deve ser de 16 bytes");

                byte[] plainTextBytes;
                byte[] cipherTextBytes;
                RijndaelManaged symemetricKey;
                ICryptoTransform encryptor;
                System.IO.MemoryStream memoryStream;
                CryptoStream cryptoStream;

                try
                {
                    //cria os objetos
                    memoryStream = new System.IO.MemoryStream();
                    symemetricKey = new RijndaelManaged();

                    //preenche o vetor de bytes com o conteudo da string valor
                    plainTextBytes = Encoding.UTF8.GetBytes(valor);

                    //seta o metodo de criptográfia
                    symemetricKey.Mode = CipherMode.CBC;

                    //Gera o encryptor
                    encryptor = symemetricKey.CreateEncryptor(Encoding.ASCII.GetBytes(chave), Encoding.ASCII.GetBytes(vetorInicializacao));

                    //define uma stream de criptografia
                    cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);

                    //inicia a criptografia
                    cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);

                    //termina a criptografia
                    cryptoStream.FlushFinalBlock();

                    //obtém o resultado da criptografia
                    cipherTextBytes = memoryStream.ToArray();

                    //fecha os streams
                    cryptoStream.Close();
                    memoryStream.Close();

                    //retorna a string encriptografada.
                    return Convert.ToBase64String(cipherTextBytes);

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            /// <summary>
            /// Decriptografa uma objeto String. IMPORTANTE: a chave e o vetor deverão conter exatamente 16 bytes.
            /// </summary>
            /// <param name="valor">Objeto String a ser decriptografado.</param>
            /// <param name="chave">Objeto String contendo a chave de criptografia.</param>
            /// <returns>Retorna um objecto String decriptografado.</returns>
            public static string Decriptografar(string valor, string chave)
            {
                const string vetorInicializacao = "1yoU4/N5+52J1aB5";
                if (chave.Length != 16)
                    throw new Exception("Erro: chave deve ser de 16 bytes");

                byte[] cipherTextBytes;
                byte[] plainTextBytes;
                RijndaelManaged symemetricKey;
                ICryptoTransform decryptor;
                System.IO.MemoryStream memoryStream;
                CryptoStream cryptoStream;
                int decryptedByteCount;

                try
                {
                    //cria o objeto
                    symemetricKey = new RijndaelManaged();

                    //preenche o vetor de bytes com o conteudo da string valor
                    cipherTextBytes = Convert.FromBase64String(valor);

                    //seta o método de criptografia
                    symemetricKey.Mode = CipherMode.CBC;

                    //Gera o decryptor 
                    decryptor = symemetricKey.CreateDecryptor(Encoding.ASCII.GetBytes(chave), Encoding.ASCII.GetBytes(vetorInicializacao));

                    //define stream memory
                    memoryStream = new System.IO.MemoryStream(cipherTextBytes);

                    //define cryptostream
                    cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);

                    //onde ira guarda a senha decriptrografada
                    plainTextBytes = new byte[cipherTextBytes.Length];

                    //inicia a descriptografia
                    decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);

                    //fecha as streams
                    cryptoStream.Close();
                    memoryStream.Close();
                    cryptoStream.Close();

                    //retorna a senha descriptografada
                    return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);


                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
