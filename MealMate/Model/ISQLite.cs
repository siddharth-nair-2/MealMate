using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MealMate.Model
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
