using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using DirectorioSjf2017.Dto;
using PadronApi.Dto;
using ScjnUtilities;

namespace DirectorioSjf2017.Model
{
    public class EncargadosModel
    {

        private readonly string connectionString = ConfigurationManager.ConnectionStrings["Base"].ConnectionString;


        public ObservableCollection<Encargado> GetEncargados()
        {
            ObservableCollection<Encargado> catalogoEncargados = new ObservableCollection<Encargado>();

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = null;
            SqlDataReader reader = null;

            try
            {
                connection.Open();

                cmd = new SqlCommand("SELECT * FROM C_Encargado ORDER BY Apellidos", connection);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Encargado titular = new Encargado()
                        {
                            IdTitular = Convert.ToInt32(reader["IdEncargado"]),
                            Nombre = reader["Nombre"].ToString(),
                            Apellidos = reader["Apellidos"].ToString(),
                            NombreStr = reader["NombMay"].ToString(),
                            IdTitulo = Convert.ToInt32(reader["IdTitulo"]),
                            Observaciones = reader["Obs"].ToString(),
                            Estado = Convert.ToInt32(reader["IdEstatus"]),
                            Genero = Convert.ToInt16(reader["Genero"]),
                            IdOrganismo = Convert.ToInt32(reader["IdOrganismo"]),
                            IdFuncion = Convert.ToInt32(reader["IdFuncion"]),
                            IdTpoOrg = Convert.ToInt32(reader["IdTpoOrg"])
                        };


                        catalogoEncargados.Add(titular);
                    }
                }
                cmd.Dispose();
                reader.Close();

            }
            catch (SqlException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,EncargadosModel", "DirectorioSjf2017");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,EncargadosModel", "DirectorioSjf2017");
            }
            finally
            {
                connection.Close();
            }

            return catalogoEncargados;
        }


        /// <summary>
        /// Verifica si el titular que se esta intentando agregar existe o no en la base de datos
        /// </summary>
        /// <param name="nombre">Nombre del titular normalizado</param>
        /// <returns></returns>
        public bool DoEncargadoExist(string nombre)
        {
            const string SqlQuery = "SELECT * FROM C_Titular WHERE NombMay = @Nombre ORDER BY Apellidos";

            int cuantos = 0;
            bool existe = false;

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = null;
            SqlDataReader reader = null;

            try
            {
                connection.Open();

                cmd = new SqlCommand(SqlQuery, connection);
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        cuantos++;
                    }
                }
                cmd.Dispose();
                reader.Close();

                if (cuantos > 0)
                    existe = true;
            }
            catch (SqlException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,EncargadosModel", "DirectorioSjf2017");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,EncargadosModel", "DirectorioSjf2017");
            }
            finally
            {
                connection.Close();
            }

            return existe;
        }


        public bool InsertaEncargado(Encargado encargado)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            bool insertCompleted = false;

            encargado.IdTitular = DataBaseUtilities.GetNextIdForUse("C_Encargado", "IdEncargado", connection);

            if (encargado.IdTitular == 0)
                encargado.IdTitular = 1;

            try
            {
                connection.Open();

                string sqlQuery = "INSERT INTO C_Encargado(IdEncargado, Nombre,Apellidos,IdTitulo,NombMay,IdOrganismo,IdUsr,Fecha,Obs,Genero,IdTpoOrg,IdFuncion)" +
                                  "VALUES (@IdEncargado,@Nombre,@Apellidos,@IdTitulo,@NombMay,@IdOrganismo,@IdUsr,@Fecha,@Obs,@Genero,@IdTpoOrg,@IdFuncion)";

                SqlCommand cmd = new SqlCommand(sqlQuery, connection);
                cmd.Parameters.AddWithValue("@IdEncargado", encargado.IdTitular);
                cmd.Parameters.AddWithValue("@Nombre", encargado.Nombre);
                cmd.Parameters.AddWithValue("@Apellidos", encargado.Apellidos);
                cmd.Parameters.AddWithValue("@IdTitulo", encargado.IdTitulo);
                cmd.Parameters.AddWithValue("@NombMay", encargado.NombreStr);
                cmd.Parameters.AddWithValue("@IdOrganismo", encargado.IdOrganismo);
                cmd.Parameters.AddWithValue("@IdUsr", AccesoUsuario.Llave);
                cmd.Parameters.AddWithValue("@Fecha", DateTimeUtilities.DateToInt(DateTime.Now));
                cmd.Parameters.AddWithValue("@Obs", encargado.Observaciones);
                cmd.Parameters.AddWithValue("@Genero", encargado.Genero);
                cmd.Parameters.AddWithValue("@IdTpoOrg", encargado.IdTpoOrg);
                cmd.Parameters.AddWithValue("@IdFuncion", encargado.IdFuncion);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                insertCompleted = true;
            }
            catch (SqlException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,EncargadosModel", "DirectorioSjf2017");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,EncargadosModel", "DirectorioSjf2017");
            }
            finally
            {
                connection.Close();
            }

            return insertCompleted;
        }

        /// <summary>
        /// Actualiza los datos del encargado seleccionado
        /// </summary>
        /// <param name="encargado"></param>
        /// <returns></returns>
        public bool UpdateEncargado(Encargado encargado)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            bool updateCompleted = false;

            try
            {
                connection.Open();

                string sqlQuery = "UPDATE C_Encargado SET Nombre = @Nombre,Apellidos = @Apellidos," +
                                  "NombMay = @NombMay,Obs = @Obs, IdTitulo = @IdTitulo, IdOrganismo = @IdOrganismo, IdTpoOrg = @IdTpoOrg, " +
                                  " IdUsr = @IdUsr, Fecha = @Fecha, Genero = @Genero, IdFuncion = @IdFuncion  WHERE IdEncargado = @IdEncargado";

                SqlCommand cmd = new SqlCommand(sqlQuery, connection);
                cmd.Parameters.AddWithValue("@Nombre", encargado.Nombre);
                cmd.Parameters.AddWithValue("@Apellidos", encargado.Apellidos);
                cmd.Parameters.AddWithValue("@NombMay", encargado.NombreStr);
                cmd.Parameters.AddWithValue("@Obs", encargado.Observaciones);
                cmd.Parameters.AddWithValue("@IdTitulo", encargado.IdTitulo);
                cmd.Parameters.AddWithValue("@IdOrganismo", encargado.IdOrganismo);
                cmd.Parameters.AddWithValue("@IdTpoOrg", encargado.IdTpoOrg);
                cmd.Parameters.AddWithValue("@IdUsr", AccesoUsuario.Llave);
                cmd.Parameters.AddWithValue("@Fecha", DateTimeUtilities.DateToInt(DateTime.Now));
                cmd.Parameters.AddWithValue("@Genero", encargado.Genero);
                cmd.Parameters.AddWithValue("@IdFuncion", encargado.IdFuncion);
                cmd.Parameters.AddWithValue("@IdEncargado", encargado.IdTitular);

                cmd.ExecuteNonQuery();

                cmd.Dispose();
                updateCompleted = true;

            }
            catch (SqlException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,EncargadosModel", "DirectorioSjf2017");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,EncargadosModel", "DirectorioSjf2017");
            }
            finally
            {
                connection.Close();
            }

            return updateCompleted;
        }

    }
}
