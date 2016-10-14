using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jojo.Common.Extensions.System.Data.SqlClient
{
    /// <summary>
    /// Extensions de la classe <see cref="SqlConnection"/>.
    /// </summary>
    public static class SqlConnectionExtensions
    {
        public static int ExecuteNonQuery(this SqlConnection connection, Action<SqlCommand> prepareCommand)
        {
            using (var command = connection.CreateCommand())
            {
                try
                {
                    prepareCommand(command);
                    connection.Open();
                    return command.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    // TODO : Gestion de l'exception
                    throw;
                }
                finally
                {
                    connection.Dispose();
                }
            }
        }

        public static object ExecuteScalar(this SqlConnection connection, Action<SqlCommand> prepareCommand)
        {
            using (var command = connection.CreateCommand())
            {
                try
                {
                    prepareCommand(command);
                    connection.Open();
                    return command.ExecuteScalar();
                }
                catch (Exception)
                {
                    // TODO : Gestion de l'exception
                    throw;
                }
                finally
                {
                    connection.Dispose();
                }
            }
        }

        public static T ExecuteScalar<T>(this SqlConnection connection, Action<SqlCommand> prepareCommand)
        {
            using (var command = connection.CreateCommand())
            {
                try
                {
                    prepareCommand(command);
                    connection.Open();
                    return (T)command.ExecuteScalar();
                }
                catch (Exception)
                {
                    // TODO : Gestion de l'exception
                    throw;
                }
                finally
                {
                    connection.Dispose();
                }
            }
        }

        public static IEnumerable<T> ExecuteReader<T>(this SqlConnection connection, Action<SqlCommand> prepareCommand, Func<SqlDataReader, T> parseResult)
        {
            using (var command = connection.CreateCommand())
            {
                prepareCommand(command);
                connection.Open();
                using (var reader = command.ExecuteReader(CommandBehavior.CloseConnection | CommandBehavior.SingleResult))
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            yield return parseResult(reader);
                        }
                    }
                }
            }
            connection.Dispose();
        }

        public static DataSet ExecuteDataSet(this SqlConnection connection, Action<SqlCommand> prepareCommand)
        {
            using (var command = connection.CreateCommand())
            {
                try
                {
                    prepareCommand(command);
                    var dataAdapter = new SqlDataAdapter(command);
                    connection.Open();
                    var result = new DataSet();
                    dataAdapter.Fill(result);
                    return result;
                }
                catch (Exception)
                {
                    // TODO : Gestion de l'exception
                    throw;
                }
                finally
                {
                    connection.Dispose();
                }
            }
        }

        public static void ExecuteDataSet(this SqlConnection connection, Action<SqlCommand> prepareCommand, DataTable table)
        {
            using (var command = connection.CreateCommand())
            {
                try
                {
                    prepareCommand(command);
                    var dataAdapter = new SqlDataAdapter(command);
                    connection.Open();
                    dataAdapter.Fill(table);
                }
                catch (Exception)
                {
                    // TODO : Gestion de l'exception
                    throw;
                }
                finally
                {
                    connection.Dispose();
                }
            }
        }
    }
}
