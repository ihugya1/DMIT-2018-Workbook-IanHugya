using System;
using System.Collections.Generic;
//using a class with a static member makes the code a little short to read and write
// we can just say AppSettings[] instead of ConfigurationManager.AppSettings[]
using static System.Configuration.ConfigurationManager;
using System.Linq;
using System.Web;


namespace WebApp.Admin.Security
{
    /// <summary>
    /// A collection of application-wide settomgs that provide values
    /// for security roles which have been set up in the web.configs 
    /// <appSettings> section.
    /// 
    /// </summary>
    internal static class Settings //there is no need to instantiate this (create a new instance)
    {
        #region Security Roles
        //using static System.Configuration.ConfigurationManager;
        // public static string AdminRole => ConfigurationManager.AppSettings["adminRole"];
        public static string AdminRole => AppSettings["adminRole"];
        /*The above is the same as typing:
         * 
         * public static string AdminRole
         * {
         *      get{ return ConfigurationManager.AppSettings["adminRole"];
         * }
         */
        //using static System.Configuration.ConfigurationManager; no need for ConfigurationManager
        //public static string UserRole => ConfigurationManager.AppSettings["userRole"];
        public static string UserRole => AppSettings["userRole"];
        public static IEnumerable<string> DefaultSecurityRoles =>
            new List<string>{ AdminRole, UserRole };
        #endregion
        #region Startup Users
        public static string AdminUserName => AppSettings["adminUserName"];
        public static string AdminPassword => AppSettings["adminPassword"];
        public static string AdminEmail => AppSettings["adminEmail"];
        public static string TempPassword => AppSettings["temporaryUserPassword"];
        #endregion
    }
}