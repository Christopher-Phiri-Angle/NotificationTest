using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotificationTest.Data
{
    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}
