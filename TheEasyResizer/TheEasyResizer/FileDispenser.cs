using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheEasyResizer
{
   class FileDispenser
   {
      private HashSet<string> mImagePaths;
      
      public FileDispenser(string[] files)
      {
         mImagePaths = new HashSet<string>();
         foreach (var file in files)
         {
            mImagePaths.Add(file);
         }
      }

      public int GetNumRemainigFiles()
      {
         return mImagePaths.Count;
      }

      public string GetNextFile()
      {
         string filePathToRet = "";
         lock(mImagePaths)
         {
            if(mImagePaths.Count > 0)
            {
               filePathToRet = mImagePaths.First();
               mImagePaths.Remove(filePathToRet);
            }
         }
         return filePathToRet;
      }

      public void AddNewFile(string path)
      {
         lock (mImagePaths)
         {
            if (mImagePaths.Contains(path) == false)
               mImagePaths.Add(path);
         }
      }
   }
}
