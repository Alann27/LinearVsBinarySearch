using System;
using System.IO;

namespace DiscreteMathematicsII_Project.Utils
{
    public static class Constants
    {
        public static string projectPath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\..\"));
        public static string FirstNamesFiles = Path.Combine(projectPath, @"Files\Nombres.txt");
        public static string LastNamesFiles = Path.Combine(projectPath, @"Files\Apellidos.txt");
        public const int idLimit = 9999999;
    }
}
