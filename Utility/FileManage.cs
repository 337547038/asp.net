using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace GL.Utility
{
    //文件操作类
    public class FileManage
    {
        #region 获取文件大小
        /// <summary>
        /// 获取文件大小 
        /// </summary>
        /// <param name="dirPath"></param>
        /// <returns></returns>
        public static long GetDirectoryLength(string dirPath)
        {
            if (!Directory.Exists(dirPath))
                return 0;
            long len = 0;
            DirectoryInfo di = new DirectoryInfo(dirPath);
            foreach (FileInfo fi in di.GetFiles())
            {
                len += fi.Length;
            }
            DirectoryInfo[] dis = di.GetDirectories();
            if (dis.Length > 0)
            {
                for (int i = 0; i < dis.Length; i++)
                {
                    len += GetDirectoryLength(dis[i].FullName);
                }
            }
            return len;
        }
        #endregion

        #region 单位转换
        /// <summary>    
        /// 单位转换   
        /// </summary>    
        /// <param name="size">文件的大小</param>    
        /// <returns></returns>
        public static string GetFileSize(int size)
        {
            string FileSize = "";
            if (size != 0)
            {
                if (size >= 1073741824)
                {
                    FileSize = System.Math.Round(Convert.ToDouble((double)size / (double)1073741824), 2).ToString() + " GB";  //GB     
                }
                else if (size >= 1048576)
                {
                    FileSize = System.Math.Round(Convert.ToDouble((double)size / (double)1048576), 2).ToString() + " MB";
                }
                else if (size >= 1024)
                {
                    FileSize = System.Math.Round(Convert.ToDouble((double)size / (double)1024), 2).ToString() + " KB";
                    int a = size / 1024 * 100;
                    int b = size / 1024;
                }
                else
                {
                    FileSize = size.ToString() + "bytes";
                }
            }
            else
            {
                FileSize = size.ToString() + "bytes";
            }
            return FileSize;
        }
        #endregion
        
    }
}
