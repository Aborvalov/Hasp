using System;

namespace DalDB
{
    public class LogEventArgs : EventArgs
    {
        public string TableName { get; }
        public string Action { get; }
        public int Id { get; }

        public LogEventArgs(string tableName, string action, int id)
        {
            TableName = tableName;
            Action = action;
            Id = id;
        }
    }
}
