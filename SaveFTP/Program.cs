using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace Examples.System.Net
{
    public class WebRequestGetExample
    {
        public static async Task Main()
        {
            string nombreFichero = "Prueba.txt";
            GuardarFTP("C:\\Users\\USUARIO HP\\Documents\\" + nombreFichero, nombreFichero);
            static void GuardarFTP(string origen, string nombreArchivo)
            {
                try
                {
                    string FTP = "ftp://waws-prod-dm1-255.ftp.azurewebsites.windows.net/site/wwwroot/PDF";
                    string user = "Web-SAG\\TMedrano";
                    string pass = "TMedrano21$";
                    FtpWebRequest dirFtp = ((FtpWebRequest)FtpWebRequest.Create(FTP + "/" + nombreArchivo));
                    dirFtp.Credentials = new NetworkCredential(user, pass); ;
                    dirFtp.UsePassive = true;
                    dirFtp.UseBinary = true;
                    dirFtp.KeepAlive = true;
                    dirFtp.Method = WebRequestMethods.Ftp.UploadFile;
                    FileStream stream = File.OpenRead(origen);
                    byte[] buffer = new byte[stream.Length];
                    stream.Read(buffer, 0, buffer.Length);
                    stream.Close();
                    Stream reqStream = dirFtp.GetRequestStream();
                    reqStream.Write(buffer, 0, buffer.Length);
                    reqStream.Flush();
                    reqStream.Close();
                    Console.WriteLine("Archivo Guardado");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }
    }
}