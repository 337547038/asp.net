using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace GL.Utility
{
    public class GreateFiles
    {
        /// <summary>
        /// 初始化文件夹信息 检查文件夹是否存在，如果不存在则建立
        /// </summary>
        /// <param name="path">文件夹的相对路径</param>
        /// <returns>返回文件夹物理路径</returns>
        public static string InitFolderPath(string path)
        {
            string physicsPath = System.Web.HttpContext.Current.Server.MapPath(path);
            if (!Directory.Exists(physicsPath))
            {
                Directory.CreateDirectory(physicsPath);
            }
            return physicsPath;
        }

        /// <summary>
        /// 创建文件
        /// </summary>
        /// <param name="filePath">路径</param>
        /// <returns>内容</returns>
        public static void CreateFile(string filePath, string text)
        {
            try
            {
                StreamWriter sw = new StreamWriter(filePath, false, Encoding.GetEncoding("UTF-8"));
                sw.WriteLine(text);
                sw.Flush();
                sw.Close();
            }
            catch (Exception ex)
            {
                BasePage.Alertback("创建文件失败");
                //这里可以提示信息创建文件出错，文件地址：+filePath,ex
                throw ex;
            }
        }

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="filePath">路径</param>
        public static void DeleteFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                try
                {
                    File.Delete(filePath);
                }
                catch (Exception ex)
                {
                    //这里可以提示删除失败，文件地址 +filePath,ex
                    BasePage.Alertback("删除失败");
                    throw ex;
                }
            }
        }


        /// <summary>
        /// 读取外部文件
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <returns></returns>
        public static string Read_File(string path)
        {

            //读取外部文件
            StringBuilder HTM = new StringBuilder();
            try
            {
                using (StreamReader reader = new StreamReader(path, System.Text.Encoding.GetEncoding("utf-8")))
                {
                    while (reader.Peek() >= 0)
                    {
                        HTM.Append(((char)reader.Read()).ToString());
                    }
                }
            }
            catch { return null; }
            return HTM.ToString();

        }

        #region 检测指定目录是否存在
        /// <summary> 
        /// 检测指定目录是否存在 
        /// </summary> 
        /// <param name="directoryPath">目录的绝对路径</param>         
        public static bool IsExistDirectory(string directoryPath)
        {
            return Directory.Exists(directoryPath);
        }
        #endregion
    }
}
