using System;
using System.Collections.Generic;
using System.IO;

namespace CourseworkWinForms
{
    public partial class Form1
    {
        public static List<Applications> GetApplications()
        {
            List<Applications> result = new List<Applications>();
            String userName = Environment.UserName;
            string pathProgramData = "C:\\ProgramData\\Microsoft\\Windows\\Start Menu\\Programs";
            string pathUser = "C:\\Users\\" + userName + "\\AppData\\Roaming\\Microsoft\\Windows\\Start Menu\\Programs";

            DirectoryInfo directoryProgramDataInfo = new DirectoryInfo(pathProgramData);
            foreach (var file in directoryProgramDataInfo.GetFiles()) //проходим по файлам
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
            string[] programDataDirectories = Directory.GetDirectories(pathProgramData);
            for (int i = 0; i < programDataDirectories.Length; i++)
            {
                DirectoryInfo newDirectoryInfo = new DirectoryInfo(programDataDirectories[i]);
                foreach (var file in newDirectoryInfo.GetFiles()) //проходим по файлам
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
            DirectoryInfo directoryUserInfo = new DirectoryInfo(pathUser);
            foreach (var file in directoryUserInfo.GetFiles()) //проходим по файлам
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
            string[] userDirectories = Directory.GetDirectories(pathUser);
            for (int i = 0; i < userDirectories.Length; i++)
            {
                DirectoryInfo newDirectoryInfo = new DirectoryInfo(userDirectories[i]);
                foreach (var file in newDirectoryInfo.GetFiles()) //проходим по файлам
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

            return result;
        }
    }
}
