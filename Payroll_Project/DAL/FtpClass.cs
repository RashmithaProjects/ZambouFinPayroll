using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;

namespace Payroll_Project.DAL
{
    public class FtpClass
    {
        private string host = "ftp://103.231.101.235";
        private string user = "RISFTP";
        private string pass = "ris@123";
        string directory = "ZambouLoans/CRDB/";


        bool checkfile;
        public FtpClass()
        {
        }
        public bool CheckFileExistOrNot(string FileName)
        {
            FtpWebRequest ftpRequest = null;
            FtpWebResponse ftpResponse = null;
            bool IsExists = true;
            try
            {
                ftpRequest = (FtpWebRequest)WebRequest.Create(host + "/" + directory + "/" + FileName);
                ftpRequest.Credentials = new NetworkCredential(user, pass);
                ftpRequest.Method = WebRequestMethods.Ftp.GetFileSize;
                ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                ftpResponse.Close();
                ftpRequest = null;
            }
            catch (Exception)
            {
                IsExists = false;
            }
            return IsExists;
        }

        public void DeleteFile(string FileName)
        {
            FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create(host + "/" + directory + "/" + FileName);
            ftpRequest.Credentials = new NetworkCredential(user, pass);
            ftpRequest.Method = WebRequestMethods.Ftp.DeleteFile;
            FtpWebResponse responseFileDelete = (FtpWebResponse)ftpRequest.GetResponse();
        }

        public string MyUpload(string filepath, string filename)
        {
            FileInfo fileInf = new FileInfo(filepath);
            string uri = host + "/" + directory + "/" + filename;
            string ResponseDescription = "Form Uploaded";
            checkfile = CheckFileExistOrNot(filename);
            if (checkfile == true)
            {
                DeleteFile(filename);
                Thread.Sleep(1000);
            }

            FtpWebRequest reqFTP;
            reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(host + "/" + directory + "/" + filename));
            reqFTP.Credentials = new NetworkCredential(user, pass);
            reqFTP.KeepAlive = false;
            reqFTP.Method = WebRequestMethods.Ftp.UploadFile;
            reqFTP.UseBinary = true;
            reqFTP.ContentLength = fileInf.Length;
            int buffLength = 2048;
            byte[] buff = new byte[buffLength];
            int contentLen;
            FileStream fs = fileInf.OpenRead();
            try
            {
                Stream strm = reqFTP.GetRequestStream();
                contentLen = fs.Read(buff, 0, buffLength);
                while (contentLen != 0)
                {
                    strm.Write(buff, 0, contentLen);
                    contentLen = fs.Read(buff, 0, buffLength);
                }
                strm.Close();
                fs.Close();
                return "Uploaded Success";
            }
            catch (Exception ex)
            {
                return "Upload Error";
            }
            return ResponseDescription;
        }



        public string DownLoadFiles_FTP(string FileNameToDownload, string tempDirPath)
        {
            string url = host + "/" + directory;
            string ResponseDescription = "File Not Exist";
            string PureFileName = new FileInfo(FileNameToDownload).Name;
            string DownloadedFilePath = tempDirPath + "/" + PureFileName;
            string downloadUrl = String.Format("{0}/{1}", url, FileNameToDownload);
            FtpWebRequest req = (FtpWebRequest)FtpWebRequest.Create(downloadUrl);
            req.Method = WebRequestMethods.Ftp.DownloadFile;
            req.Credentials = new NetworkCredential(user, pass);
            req.UseBinary = true;
            req.Proxy = null;
            try
            {
                FtpWebResponse response = (FtpWebResponse)req.GetResponse();
                Stream stream = response.GetResponseStream();
                byte[] buffer = new byte[2048];
                FileStream fs = new FileStream(DownloadedFilePath, FileMode.Create);
                int ReadCount = stream.Read(buffer, 0, buffer.Length);
                while (ReadCount > 0)
                {
                    fs.Write(buffer, 0, ReadCount);
                    ReadCount = stream.Read(buffer, 0, buffer.Length);
                }
                ResponseDescription = response.StatusDescription;
                fs.Close();
                stream.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return ResponseDescription;
        }



        //public  string DownloadFile(string FtpUrl, string FileNameToDownload,  string tempDirPath)
        //{
        //   // string uri = host + "/" + directory + "/" + filename;
        //    string ResponseDescription = "";
        //    string PureFileName = new FileInfo(FileNameToDownload).Name;
        //    string DownloadedFilePath = tempDirPath + "/" + PureFileName;
        //    string downloadUrl = String.Format("{0}/{1}", FtpUrl, FileNameToDownload);
        //    FtpWebRequest req = (FtpWebRequest)FtpWebRequest.Create(downloadUrl);
        //    req.Method = WebRequestMethods.Ftp.DownloadFile;
        //    req.Credentials = new NetworkCredential(user, pass);
        //    req.UseBinary = true;
        //    req.Proxy = null;
        //    try
        //    {
        //        FtpWebResponse response = (FtpWebResponse)req.GetResponse();
        //        Stream stream = response.GetResponseStream();
        //        byte[] buffer = new byte[2048];
        //        FileStream fs = new FileStream(DownloadedFilePath, FileMode.Create);
        //        int ReadCount = stream.Read(buffer, 0, buffer.Length);
        //        while (ReadCount > 0)
        //        {
        //            fs.Write(buffer, 0, ReadCount);
        //            ReadCount = stream.Read(buffer, 0, buffer.Length);
        //        }
        //        ResponseDescription = response.StatusDescription;
        //        fs.Close();
        //        stream.Close();
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //    }
        //    return ResponseDescription;
        //}
        public string MyUploads(string filepath, string filename, string directory)
        {
            FileInfo fileInf = new FileInfo(filepath);
            string uri = host + "/" + directory + "/" + filename;
            string ResponseDescription = "Form Uploaded";
            checkfile = CheckFileExistOrNot(filename);
            if (checkfile == true)
            {
                DeleteFile(filename);
                Thread.Sleep(1000);
            }

            FtpWebRequest reqFTP;
            reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(host + "/" + directory + "/" + filename));
            reqFTP.Credentials = new NetworkCredential(user, pass);
            reqFTP.KeepAlive = false;
            reqFTP.Method = WebRequestMethods.Ftp.UploadFile;
            reqFTP.UseBinary = true;
            reqFTP.ContentLength = fileInf.Length;
            int buffLength = 2048;
            byte[] buff = new byte[buffLength];
            int contentLen;
            FileStream fs = fileInf.OpenRead();
            try
            {
                Stream strm = reqFTP.GetRequestStream();
                contentLen = fs.Read(buff, 0, buffLength);
                while (contentLen != 0)
                {
                    strm.Write(buff, 0, contentLen);
                    contentLen = fs.Read(buff, 0, buffLength);
                }
                strm.Close();
                fs.Close();
                return "Uploaded Success";
            }
            catch (Exception ex)
            {
                return "Upload Error";
            }
            return ResponseDescription;
        }

        public void DeleteFiles(string FileName, string directory)
        {
            FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create(host + "/" + directory + "/" + FileName);
            ftpRequest.Credentials = new NetworkCredential(user, pass);
            ftpRequest.Method = WebRequestMethods.Ftp.DeleteFile;
            FtpWebResponse responseFileDelete = (FtpWebResponse)ftpRequest.GetResponse();
        }

    }
}