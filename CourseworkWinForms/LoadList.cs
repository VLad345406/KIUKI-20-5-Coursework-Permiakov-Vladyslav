using System;
using System.Collections.Generic;
using System.IO;

namespace CourseworkWinForms
{
    public partial class Form1
    {
        public static void checkLnk(List<Applications> result, DirectoryInfo directoryDataInfo)
        {
            foreach (FileInfo file in directoryDataInfo.GetFiles()) //проходим по файлам
            {
                //получаем расширение файла и проверяем подходит ли оно нам 
                if (Path.GetExtension(file.Name) == ".lnk")
                {
                    Applications testApp = new Applications();
                    testApp.name = file.Name;
                    testApp.path = file.DirectoryName;
                    result.Add(testApp);
                }
            }
        }

        public static List<Applications> GetApplications()
        {
            List<Applications> result = new List<Applications>();
            String userName = Environment.UserName;
            string pathProgramData = "C:\\ProgramData\\Microsoft\\Windows\\Start Menu\\Programs";
            string pathUser = "C:\\Users\\" + userName + "\\AppData\\Roaming\\Microsoft\\Windows\\Start Menu\\Programs";

            DirectoryInfo directoryProgramDataInfo = new DirectoryInfo(pathProgramData);
            checkLnk(result, directoryProgramDataInfo);
            string[] programDataDirectories = Directory.GetDirectories(pathProgramData);
            for (int i = 0; i < programDataDirectories.Length; i++)
            {
                DirectoryInfo newDirectoryInfo = new DirectoryInfo(programDataDirectories[i]);
                checkLnk(result, newDirectoryInfo);
            }
            DirectoryInfo directoryUserInfo = new DirectoryInfo(pathUser);
            checkLnk(result, directoryUserInfo);
            string[] userDirectories = Directory.GetDirectories(pathUser);
            for (int i = 0; i < userDirectories.Length; i++)
            {
                DirectoryInfo newDirectoryInfo = new DirectoryInfo(userDirectories[i]);
                checkLnk(result, newDirectoryInfo);
            }

            return result;
        }
    }
}
