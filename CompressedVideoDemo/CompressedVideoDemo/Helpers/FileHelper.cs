using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CompressedVideoDemo.Helpers
{
    static class FileHelper
    {
        public static string directoryPath = "";
        public static string PictureDirectoryPath = "";
#if _ANDROID_
        directoryPath = System.IO.Path.Combine(Android.OS.Environment.ExternalStorageDirectory.Path, "CompressedVideo");

        PictureDirectoryPath = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryPictures) + "/CompressedVideo";
#endif
#if _IOS_
                PictureDirectoryPath = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "/CompressedVideo";

               directoryPath = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos) + "/CompressedVideo";
#endif

        static FileHelper()
        {
            CheckAndCreateAppDirectory();
        }

        public static string CreateVideoDirectory()
        {
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            return directoryPath;
        }

        public static string GetUniqueVideoName(string ext)
        {
            string nomeArquivo = "";

#if _IOS_
			nomeArquivo =  System.Guid.NewGuid().ToString().Replace("-", "") + ext;
			
#endif

#if _ANDROID_

            nomeArquivo =  "VID_" + System.DateTime.Now.ToString("yyyyMMddHHmmssfff") + (ext ?? "");
#endif
            return nomeArquivo;
        }

        public static string CreateNewVideoPath()
        {
            return Path.Combine(CreateVideoDirectory(), GetUniqueVideoName(".mp4"));
        }

        public static void CheckAndCreateAppDirectory()
        {
            if (!Directory.Exists(PictureDirectoryPath))
                Directory.CreateDirectory(PictureDirectoryPath);
        }

        public static string MapPicturePath(string fileName)
        {
            return Path.Combine(PictureDirectoryPath, fileName);
        }

        public static void CopyImageToPath(string sourceFilePath, string targetFilePath)
        {
            File.Copy(sourceFilePath, targetFilePath);
        }

        public static string GenerateUniqueFileName(string ext)
        {
            if (!ext.StartsWith("."))
                ext = "." + ext;
            return string.Format("{0}{1}", DateTime.Now.ToString("yyyyMMddhhmmssfff"), ext);
        }

        public static string GenerateUniqueFilePath(string ext)
        {
            if (!ext.StartsWith("."))
                ext = "." + ext;
            return MapPicturePath(string.Format("{0}{1}", DateTime.Now.ToString("yyyyMMddhhmmssfff"), ext));
        }


        public static string GetExtension(string filename, string defaultExt)
        {
            return filename == null ? defaultExt : filename.Split('.').LastOrDefault() ?? defaultExt;
        }

    }
}