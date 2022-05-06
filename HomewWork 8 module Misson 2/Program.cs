using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HomewWork_8_module_Misson_2
{
    internal class Program
    {
        const string Path = @"F:\";
        
       
        static void Main(string[] args)
        {


            DriveInfo[] dv = DriveInfo.GetDrives();
            string[] myArray = new string[dv.Length];
            foreach (DriveInfo d in dv)
            {
                
               
                for (int i = 0; i < dv.Length; i++)
                {
                    myArray[i] = d.Name;
                }
                
            }

            foreach (var item in myArray)
            {
                Console.WriteLine(item);
            }


            DirectoryInfo DI = new DirectoryInfo(Path);
            long size = 0;
            Size(DI,ref size);
            Console.WriteLine(size);

        }
    
    
        static long Size (DirectoryInfo DI,ref long size)
        {

            try
            {

                FileInfo[] FI = DI.GetFiles();

                foreach (var f in FI)
                {
                    size += f.Length;
                }
            }
            catch (Exception )
            {
                Console.WriteLine("Есть файлы без доступа, честно не знаю как на Windows это сделать,что бы в каждую скрутыю папку вошел");
            }


            try
            {
                DirectoryInfo[] dir = DI.GetDirectories();
                foreach (var item in dir)
                {
                    size += Size(item, ref size);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Есть папки без доступа,честно не знаю как на Windows это сделать,что бы в каждую скрутыю папку вошел");
            }
            return size;



        }
    
    
    }
}
