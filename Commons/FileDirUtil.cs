using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commons
{
    /// <summary>
    /// ファイル、フォルダ作成のユーティリティ。
    /// </summary>
    /// 例外を吸収し、true,falseのみを戻す。
    /// ログを出力する。
    public class FileDirUtil
    {

        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// フォルダを作成する
        /// </summary>
        /// <param name="baseDir">フォルダを作成する場所。存在しない場合はfalseを返す</param>
        /// <param name="name">作成するフォルダ名</param>
        /// <returns>true:フォルダが存在する、フォルダの作成が完了。false:フォルダの作成に失敗</returns>
        public static bool CreateDir(string baseDir,string name)
        {
            logger.Debug($"baseDir:{baseDir},name:{name}");

            if (String.IsNullOrEmpty(baseDir) || String.IsNullOrEmpty(name))
            {
                logger.Debug($"パラメータ不正");
                return false;
            }
            if (!BaseDirCheck(baseDir))
            {
                logger.Debug($"ベースフォルダが存在しない");
                return false;
            }
            if (CreateDirInternal(baseDir + "\\" + name))
            {
                logger.Debug($"フォルダを作成");
                return true;
            }
            else
            {
                logger.Debug($"フォルダ作成に失敗");
                return false;
            }
        }

        /// <summary>
        /// ファイルを作成する
        /// </summary>
        /// <param name="baseDir">ファイルを作成する場所。存在しない場合はfalseを返す</param>
        /// <param name="name">作成するファイル名</param>
        /// <param name="size">作成するファイルのサイズ</param>
        /// <returns>true:ファイルが存在する、ファイルの作成が完了。false:ファイルの作成に失敗</returns>
        public static bool CreateFile(string baseDir, string name, long size)
        {
            logger.Debug($"baseDir:{baseDir},name:{name}");

            if (String.IsNullOrEmpty(baseDir) || String.IsNullOrEmpty(name))
            {
                logger.Debug($"パラメータ不正");
                return false;
            }
            if (!BaseDirCheck(baseDir))
            {
                logger.Debug($"ベースフォルダが存在しない");
                return false;
            }
            if (CreateFileInternal(baseDir + "\\" + name, size))
            {
                logger.Debug($"ファイルを作成");
                return true;
            }
            else
            {
                logger.Debug($"ファイル作成に失敗");
                return true;
            }
        }

        /// <summary>
        /// フォルダを作成する場所が存在するかを確認
        /// </summary>
        /// <param name="baseDir"></param>
        /// <returns>true:存在する、false:存在しない、またはファイルが存在する</returns>
        internal static bool BaseDirCheck(string baseDir)
        {
            logger.Debug($"baseDir:{baseDir}");
            if (String.IsNullOrEmpty(baseDir))
            {
                logger.Debug($"パラメータ不正");
                return false;
            }
            if (Directory.Exists(baseDir))
            {
                logger.Debug($"フォルダが存在する");
                return true;
            }
            else
            {
                logger.Debug($"フォルダが存在しない");
                return false;
            }
        }

        /// <summary>
        /// フォルダ作成
        /// </summary>
        /// <param name="dirPath">作成するフォルダパス</param>
        /// <returns>true:作成に成功、false:作成に失敗</returns>
        internal static bool CreateDirInternal(string dirPath)
        {
            logger.Debug($"dirPath:{dirPath}");
            try
            {
                Directory.CreateDirectory(dirPath);
                 return true;
            }catch(Exception e)
            {
                logger.Error(e.ToString());
                return false;
            }
            
        }

        /// <summary>
        /// ファイル作成
        /// </summary>
        /// <param name="filePath">作成するファイルパス</param>
        /// <returns>true:作成に成功、false:作成に失敗</returns>
        internal static bool CreateFileInternal(string filePath, long size)
        {
            logger.Debug($"filePath:{filePath},size:{size}");
            try
            {
                using(var stream = File.Create(filePath))
                {
                    stream.SetLength(size);
                }
                logger.Debug("ファイルを作成");
                return true;
            }
            catch (Exception e)
            {
                logger.Error(e.ToString());
                return false;
            }

        }
    }
}
