using MealMate.Droid;
using MealMate.Model;
using SQLite;
using System;
using System.IO;
using Xamarin.Forms;

[assembly:Dependency(typeof(MealMate.Droid.SQLite_Android))]
namespace MealMate.Droid
{
    public class SQLite_Android : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            var sqliteFileName = "MyDatabase.db3";
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, sqliteFileName);
            var cn = new SQLiteConnection(path);
            return cn;
        }
    }
}