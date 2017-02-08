using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using PadronApi.Dto;
using ScjnUtilities;

namespace DirectorioSjf2017.Model
{
    public class OrganismoDirModel
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["Base"].ConnectionString;


        public ObservableCollection<Organismo> GetOrganismos()
        {
            ObservableCollection<Organismo> catalogoOrganismo = new ObservableCollection<Organismo>();

            List<int> tienePresidente = this.GetTienenPresidente();

            string sqlCadena = "SELECT O.*, Tpo.TpoOrg as Texto,IdGrupo, D.Distribucion  " +
                               "FROM C_Distribucion D INNER JOIN (C_TipoOrganismo Tpo INNER JOIN C_Organismo O ON Tpo.IdTpoOrg = O.IdTpoOrg)  " +
                               "ON D.IdDistribucion = O.IdTpodist WHERE O.Activo = 1 AND Tpo.IdGrupo = 1 " +
                               "ORDER BY O.IdTpoOrg, O.IdCircuito, O.IdOrdinal, DescOrgMay";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = null;
            SqlDataReader reader = null;

            try
            {
                connection.Open();

                cmd = new SqlCommand(sqlCadena, connection);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Organismo organismo = new Organismo();
                        organismo.IdOrganismo = Convert.ToInt32(reader["IdOrg"]);
                        organismo.OrganismoDesc = reader["DescOrg"].ToString();
                        organismo.OrganismoStr = reader["DescOrgMay"].ToString();
                        organismo.TipoOrganismo = Convert.ToInt32(reader["IdTpoOrg"]);
                        organismo.Circuito = Convert.ToInt32(reader["IdCircuito"]);
                        organismo.Ordinal = Convert.ToInt32(reader["IdOrdinal"]);
                        organismo.Materia = reader["Materia"].ToString();
                        organismo.Ciudad = Convert.ToInt32(reader["IdCiudad"]);
                        organismo.Estado = Convert.ToInt32(reader["IdEstado"]);
                        organismo.Orden = reader["OrdenVer"] as int? ?? 0;
                        organismo.Calle = reader["Calle"].ToString();
                        organismo.Colonia = reader["Colonia"].ToString();
                        organismo.Delegacion = reader["Delegacion"].ToString();
                        organismo.Cp = reader["Cp"].ToString();
                        organismo.Telefono = reader["Tel"].ToString();
                        organismo.Extension = reader["Ext"].ToString();
                        organismo.Telefono2 = reader["Tel1"].ToString();
                        organismo.Extension2 = reader["Ext1"].ToString();
                        organismo.Telefono3 = reader["Tel2"].ToString();
                        organismo.Extension3 = reader["Ext2"].ToString();
                        organismo.Telefono4 = reader["Tel3"].ToString();
                        organismo.Extension4 = reader["Ext3"].ToString();
                        organismo.Observaciones = reader["Obs"].ToString();
                        organismo.Activo = Convert.ToInt32(reader["Activo"]);
                        organismo.TipoDistr = Convert.ToInt32(reader["IdTpoDist"]);
                        organismo.Abreviado = reader["Abreviado"].ToString();
                        organismo.TipoOrganismoStr = reader["Texto"].ToString();
                        organismo.Distribucion = reader["Distribucion"].ToString();
                        organismo.IdGrupo = Convert.ToInt32(reader["IdGrupo"]);

                        catalogoOrganismo.Add(organismo);
                    }

                    foreach (KeyValuePair<int, int> pair in this.GetAdscritosOrganismo())
                    {
                        try
                        {
                            Organismo org = (from n in catalogoOrganismo
                                             where n.IdOrganismo == pair.Key
                                             select n).ToList()[0];

                            org.TotalAdscritos = pair.Value;

                            if (org.TipoOrganismo == 2 && org.TotalAdscritos > 0 && !tienePresidente.Contains(org.IdOrganismo))
                                org.TotalAdscritos = 10000;
                        }
                        catch (Exception) { }
                    }
                }
                cmd.Dispose();
                reader.Close();
            }
            catch (SqlException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,OrganismosModel", "PadronApi");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,OrganismosModel", "PadronApi");
            }
            finally
            {
                connection.Close();
            }

            return catalogoOrganismo;
        }


        private ObservableCollection<KeyValuePair<int, int>> GetAdscritosOrganismo()
        {
            ObservableCollection<KeyValuePair<int, int>> asignados = new ObservableCollection<KeyValuePair<int, int>>();

            string sqlCadena = "SELECT IdOrg,COUNT(IdOrg) AS Ads FROM vTitularOrg GROUP BY IdOrg";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = null;
            SqlDataReader reader = null;

            try
            {
                connection.Open();

                cmd = new SqlCommand(sqlCadena, connection);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        asignados.Add(new KeyValuePair<int, int>(Convert.ToInt32(reader["IdOrg"]), Convert.ToInt32(reader["Ads"])));
                    }
                }
                cmd.Dispose();
                reader.Close();
            }
            catch (SqlException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,OrganismoModel", "PadronApi");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,OrganismoModel", "PadronApi");
            }
            finally
            {
                connection.Close();
            }

            return asignados;
        }

        /// <summary>
        /// Obtiene el listado de los tribunales a los cuales ya se les asigno un presidente
        /// </summary>
        /// <returns></returns>
        private List<int> GetTienenPresidente()
        {
            List<int> asignados = new List<int>();

            string sqlCadena = "SELECT IdOrg FROM AcuerdoPadron WHERE IdFuncion = 1 GROUP BY IdOrg";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = null;
            SqlDataReader reader = null;

            try
            {
                connection.Open();

                cmd = new SqlCommand(sqlCadena, connection);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        asignados.Add(Convert.ToInt32(reader["IdOrg"]));
                    }
                }
                cmd.Dispose();
                reader.Close();
            }
            catch (SqlException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,OrganismoModel", "PadronApi");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,OrganismoModel", "PadronApi");
            }
            finally
            {
                connection.Close();
            }

            return asignados;
        }

    }
}
