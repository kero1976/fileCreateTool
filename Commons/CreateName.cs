using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commons
{
    public class CreateName
    {

        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// ファイルリスト(連番i)作成
        /// </summary>
        /// <param name="fileName">ファイル名。連番iを含む</param>
        /// <param name="number">ファイルの個数</param>
        /// <param name="isFix">連番の長さを固定にするか(先頭ゼロ埋め)</param>
        /// <returns>ファイル名のリスト</returns>
        public static List<string> createFileListVarI(string fileName,int number, bool isFix)
        {
            logger.Debug($"fileName:{fileName},number:{number},isFix:{isFix}");

            if (!fileName.Contains("<連番i>"))
            {
                logger.Debug("ファイル名の値が不正です");
                return null;
            }
            List<string> result = new List<string>();

            if (isFix)
            {
                string format = fixFormat(number);
                for (int i = 1; i <= number; i++)
                {
                    result.Add(fileName.Replace("<連番i>", String.Format(format, i)));
                }
            }
            else
            {
                for (int i = 1; i <= number; i++)
                {
                    result.Add(fileName.Replace("<連番i>", i.ToString()));
                }
            }

            return result;
        }

        public static List<string> createDirFileListVarK(string dirName, int number, bool isFix, int j)
        {
            logger.Debug($"dirName:{dirName},number:{number},isFix:{isFix},i{j}");

            if (!dirName.Contains("<連番k>"))
            {
                logger.Debug("フォルダ名の値が不正です");
                return null;
            }
            List<string> result = new List<string>();

            if (isFix)
            {
                string format = fixFormat(number);
                for (int i = 1; i <= number; i++)
                {
                    result.Add(dirName.Replace("<連番k>", String.Format(format, i).Replace("<連番j>",j.ToString())));
                }
            }
            else
            {
                for (int i = 1; i <= number; i++)
                {
                    result.Add(dirName.Replace("<連番k>", i.ToString()).Replace("<連番j>",j.ToString()));
                }
            }
            return result;
        }

        /// <summary>
        /// フォルダリスト(連番j)作成
        /// </summary>
        /// <param name="fileName">フォルダ名。連番jを含む</param>
        /// <param name="number">フォルダの個数</param>
        /// <param name="isFix">連番の長さを固定にするか(先頭ゼロ埋め)</param>
        /// <returns>フォルダ名のリスト</returns>
        public static List<string> createDirListVarJ(string dirName, int number, bool isFix)
        {
            logger.Debug($"dirName:{dirName},number:{number},isFix:{isFix}");

            if (!dirName.Contains("<連番j>"))
            {
                logger.Debug("フォルダ名の値が不正です");
                return null;
            }
            List<string> result = new List<string>();

            if (isFix)
            {
                string format = fixFormat(number);
                for (int i = 1; i <= number; i++)
                {
                    result.Add(dirName.Replace("<連番j>", String.Format(format, i)));
                }
            }
            else
            {
                for (int i = 1; i <= number; i++)
                {
                    result.Add(dirName.Replace("<連番j>", i.ToString()));
                }
            }

            return result;
        }

        public static int fixCal(int number)
        {
            return (int)System.Math.Floor(System.Math.Log10(number) + 1);
        }

        private static string fixFormat(int number)
        {
            return "{0:D" + fixCal(number) + "}";
        }
    }
}
