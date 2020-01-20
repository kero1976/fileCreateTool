using Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace テスト用ファイル大量作成ツール
{
    public class Logic
    {
        public static bool createFileVarI(string dir, string fileName, int number, bool isFix, long fileSize)
        {
            List<string> filesName = CreateName.createFileListVarI(fileName, number, isFix);
            foreach(string name in filesName){
                if (!FileDirUtil.CreateFile(dir, name, fileSize))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool createDirVarJ(string dir, string dirName, int number, bool isFix)
        {
            List<string> filesName = CreateName.createDirListVarJ(dirName, number, isFix);
            foreach (string name in filesName)
            {
                if (!FileDirUtil.CreateDir(dir, name))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
