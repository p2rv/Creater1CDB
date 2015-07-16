using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Creater1CDB
{
    class Program
    {
        static void Main(string[] args)
        {
            string Srvr="server1c";
            List<string> DBName=new List<string>();
            string DBMS="MSSQLServer";
            string DBSrvr="server1c";
            string DBUID="";
            string DBPwd="";
            string CrSQLDB="";
            string SchJobDn="";
            string SQLYOffs="";

            

            Console.Write("Ведите Имя пользователя SQL-сервера \n DBUID=");
            DBUID= Console.ReadLine();
            if (DBUID != "")
            {
                Console.Write("Ведите пароль пользователя SQL-сервера \n DBPwd=");
                DBPwd = Console.ReadLine();
            }
            while (CrSQLDB != "Y" && CrSQLDB != "N") 
            {
                Console.Write("Cоздать базу данных SQL в случае ее отсутствия (Y/N) Значение по умолчанию - Y. \n CrSQLDB=");
                CrSQLDB = Console.ReadLine().ToUpper();
                if (CrSQLDB == "")
                    CrSQLDB = "Y";
            }
            while (SchJobDn != "Y" && SchJobDn != "N") 
            {
                Console.Write("Запретить выполнение регламентных созданий (Y/N). Значение по умолчанию - Y. \n SchJobDn=");
                SchJobDn = Console.ReadLine().ToUpper();
                if (SchJobDn == "")
                    SchJobDn = "Y";
            }

            while (SQLYOffs != "2000" && SQLYOffs != "0") 
            {
                Console.Write("Смещение дат, используемое для хранения дат в SQL-сервере. Допустимые значения - 0 или 2000. По умолчанию - 2000 \n SQLYOffs=");
                SQLYOffs = Console.ReadLine();
                if (SQLYOffs == "")
                    SQLYOffs = "2000";
            } 
            
                        
            Console.Write("Ведите через точку запятую список информационных баз, которые необходимо создать: ");
            string line=Console.ReadLine();
            DBName=new List<string>(line.Split(';'));
            List<string> incorectName=new List<string>();
            foreach(string name in DBName)
            {
                if (name == "")
                    incorectName.Add(name);
            }
            foreach(string name in incorectName)
            {
                DBName.Remove(name);
            }

            string pathToLog;
            string pathToDT;

            Console.Write("Укажите к файлу шаблона. В качестве шаблонов могут быть файлы конфигурации (.cf) или файлы выгрузки информационной базы (.dt)");
            pathToDT = Console.ReadLine().ToUpper();
            if(!File.Exists(pathToDT))
                pathToDT = @"D:\13.07.2015\1.dt";

           foreach(string name in DBName)
           {
               pathToLog = @"C:\Users\Администратор\Desktop\create1C_";
               pathToLog+=name+".log";
               const string quote = "\"";
               Console.WriteLine("Запускаю создание ИБ " + name);
               string exe = @"C:\Program Files (x86)\1cv82\common\1cestart.exe";
               string param = "CREATEINFOBASE Srvr=" + quote + Srvr + quote + ";Ref=" + quote + name + quote + ";DB=" + quote + name + quote + ";DBMS=" + quote + DBMS + quote + ";DBSrvr=" + quote + DBSrvr + quote + ";DBUID=" + quote + DBUID + quote + ";DBPwd=" + quote + DBPwd + quote + ";CrSQLDB="+CrSQLDB+";SchJobDn="+SchJobDn+";SQLYOffs="+SQLYOffs+" /OUT " + quote + pathToLog + quote + " /AddInList " + quote + name + quote + " /UseTemplate " + quote + pathToDT + quote;
              System.Diagnostics.Process.Start(exe,param);
           }
        }
    }
}
