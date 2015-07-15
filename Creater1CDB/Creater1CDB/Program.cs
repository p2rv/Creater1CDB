using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            string DBUID;
            string DBPwd;
            string CrSQLDB="Y";
            string SchJobDn="Y";

            Console.Write("Ведите Имя пользователя SQL-сервера: ");
            DBUID= Console.ReadLine();
            Console.Write("Ведите пароль пользователя SQL-сервера. Если пароль для пользователя сервера баз данных не задан, то данный параметр можно не указывать: ");
            DBPwd= Console.ReadLine();
            Console.Write("Ведите через запятую список информационных баз, которые необходимо создать: ");
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
            string pathToLog=@"C:\Users\Администратор\Desktop\1c";
            string pathToDT=@"\\102.1.14.224\distr\Базы\2015\Июль\18\13.07.2015\13_07_2015_ФРП_5.dt";
           foreach(string name in DBName)
           {
               pathToLog+=name+".log";
               const string quote = "\"";
               Console.WriteLine("Запускаю создание ИБ " + name);
               string exe = @"C:\Program Files (x86)\1cv82\common\1cestart.exe";
               string param = "CREATEINFOBASE Srvr=" + quote + Srvr + quote + ";Ref=" + quote + name + quote + ";DB=" + quote + name + quote + ";DBMS=" + quote + DBMS + quote + ";DBSrvr=" + quote + DBSrvr + quote + ";DBUID=" + quote + DBUID + quote + ";DBPwd=" + quote + DBPwd + quote + ";CrSQLDB=Y;SchJobDn=Y /OUT " + quote + pathToLog + quote + " /AddInList " + quote + name + quote + " /UseTemplate " + quote + pathToDT + quote;
              System.Diagnostics.Process.Start(exe,param);
           }
        }
    }
}
