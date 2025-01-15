using System.Collections.Generic;
using System.Data.Common;

namespace UpgradeHelpers.DB.ADO
{
    /// <summary>
    /// This class is used to provide functionality similar to a VB6 DataEnvironment.
    /// </summary>
    public class DataEnvironmentHelper<TConnection, TCommand, TRecordSet>
    {
        /// <summary>
        /// Internal list of connections.
        /// </summary>
        protected Dictionary<string, TConnection> m_Connections = new Dictionary<string, TConnection>();
        /// <summary>
        /// Internal list of commands.
        /// </summary>
        protected Dictionary<string, TCommand> m_Commands = new Dictionary<string, TCommand>();
        /// <summary>
        /// Internal list of non-Recordset-returning commands.
        /// </summary>
        protected Dictionary<string, TCommand> m_NonRSReturningCommands = new Dictionary<string, TCommand>();
        /// <summary>
        /// Internal list of record sets.
        /// </summary>
        protected Dictionary<string, TRecordSet> m_Recordsets = new Dictionary<string, TRecordSet>();

        /// <summary>
        /// The list of ADORecordSetHelpers in the environment.
        /// </summary>
        public Dictionary<string, TRecordSet> Recordsets
        {
            get
            {
                return m_Recordsets;
            }
        }

        /// <summary>
        /// The list of DbCommands in the environment.
        /// </summary>
        public Dictionary<string, TCommand> Commands
        {
            get
            {
                return m_Commands;
            }
        }
    }

    /// <summary>
    /// Extension methods for the DataEnvironmentHelper.
    /// </summary>
    public static class Extensions
    {
        static Dictionary<string, DbCommand> commandNames = new Dictionary<string, DbCommand>();

        /// <summary>
        /// Sets the name for a DbCommand in a DataEnvironment.
        /// </summary>
        /// <param name="command"></param>
        /// <param name="name"></param>
        public static void setName(this DbCommand command, string name)
        {
            if (commandNames.ContainsKey(name))
            {
                commandNames[name] = command;
            }
            else
            {
                commandNames.Add(name, command);
            }
        }
    }
}