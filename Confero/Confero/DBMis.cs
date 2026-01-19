using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

namespace Confero
{
    class DBMis
    {
        SqlCommand objCmd;
        SqlConnection objCn;

        public DBMis() {
            objCmd = new SqlCommand();
            objCn = new SqlConnection(@"Data Source=192.168.233.128.\sqlexpress;Initial Catalog=CONFEROSERVER;User ID=conferoclient;Password=password");
        }
        public string GenerateHash(string SourceText)
        {

            UnicodeEncoding Ue = new UnicodeEncoding();

            byte[] ByteSourceText = Ue.GetBytes(SourceText);

            MD5CryptoServiceProvider Md5 = new MD5CryptoServiceProvider();

            byte[] ByteHash = Md5.ComputeHash(ByteSourceText);

            return Convert.ToBase64String(ByteHash);
        }

        public int Transaction_Propellent(int propellentTypeID, string octane, string brand)
        {

            DBUser objDBUser = new DBUser();
            int PropollentId;

            objCmd = new SqlCommand();
            objCmd.Connection = objCn;

            try
            {
                objCn.Open();

                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "sp_Transaction_Propellent";

                {

                    objCmd.Parameters.Add("@pPropellentTypeID", SqlDbType.Int).Value = propellentTypeID;
                    objCmd.Parameters.Add("@pOctane", SqlDbType.VarChar, 50).Value = octane;
                    objCmd.Parameters.Add("@pBrand", SqlDbType.VarChar, 50).Value = brand;
                }


                PropollentId =int.Parse( objCmd.ExecuteScalar().ToString());
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                objCn.Close();
            }

            return PropollentId;
        }
        public int Transaction_VehicleOwnerShip(int userid, int vehicleid)
        {

            DBUser objDBUser = new DBUser();
            int VehicleOwnerShipId;

            objCmd = new SqlCommand();
            objCmd.Connection = objCn;

            try
            {
                objCn.Open();

                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "sp_Transaction_VehicleOwnerShip";

                {
                    objCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = userid;
                    objCmd.Parameters.Add("@VehicleID", SqlDbType.Int).Value = vehicleid;
                }

                VehicleOwnerShipId = int.Parse(objCmd.ExecuteScalar().ToString());
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                objCn.Close();
            }

            return VehicleOwnerShipId;
        }
        public int Transaction_Vehicle(int vehicletypeid, string vehiclemodel, string vehiclemake, string vehicleyears,string vehiclecapacity)
        {

            DBUser objDBUser = new DBUser();
            int VehicleId;

            objCmd = new SqlCommand();
            objCmd.Connection = objCn;

            try
            {
                objCn.Open();

                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "sp_Transaction_Vehicle";

                {


                    objCmd.Parameters.Add("@vVehicleTypeID", SqlDbType.Int).Value = vehicletypeid;
                    objCmd.Parameters.Add("@vModel", SqlDbType.VarChar, 50).Value = vehiclemodel;
                    objCmd.Parameters.Add("@vMake", SqlDbType.VarChar, 50).Value = vehiclemake;
                    objCmd.Parameters.Add("@vYears", SqlDbType.VarChar, 50).Value =vehicleyears;
                    objCmd.Parameters.Add("@vCapacity", SqlDbType.VarChar, 50).Value = vehiclecapacity;
                }


                VehicleId = int.Parse(objCmd.ExecuteScalar().ToString());
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                objCn.Close();
            }

            return VehicleId;
        }
        public int Transaction_Tyre(string tyrebrand,string tyrewidth,string tyresize,string tyrematerial, string rollingresistance, string tyremodel, string tyretype)
        {

            DBUser objDBUser = new DBUser();
            int TyreId;

            objCmd = new SqlCommand();
            objCmd.Connection = objCn;

            try
            {
                objCn.Open();

                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "sp_Transaction_Tyre";

                {

                    objCmd.Parameters.Add("@tBrand", SqlDbType.VarChar, 50).Value = tyrebrand;
                    objCmd.Parameters.Add("@tWidth", SqlDbType.VarChar, 50).Value = tyrewidth;
                    objCmd.Parameters.Add("@tTyreSize", SqlDbType.VarChar, 50).Value = tyresize;
                    objCmd.Parameters.Add("@tMaterial", SqlDbType.VarChar, 50).Value = tyrematerial;
                    objCmd.Parameters.Add("@tRollingresistance", SqlDbType.VarChar, 50).Value = rollingresistance;
                    objCmd.Parameters.Add("@tModel", SqlDbType.VarChar, 50).Value = tyremodel;
                    objCmd.Parameters.Add("@tType", SqlDbType.VarChar, 50).Value = tyretype;
                }

                TyreId = int.Parse(objCmd.ExecuteScalar().ToString());
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                objCn.Close();
            }

            return TyreId;
        }
        public int Transaction_VehicleConfiguration(int tyreid, int propellentid, int vehicleid)
        {

            DBUser objDBUser = new DBUser();
            int VehicleConfigurationId;

            objCmd = new SqlCommand();
            objCmd.Connection = objCn;

            try
            {
                objCn.Open();

                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "sp_Transaction_VehicleConfiguration";

                {
                    objCmd.Parameters.Add("@TyreID", SqlDbType.Int).Value = tyreid;
                    objCmd.Parameters.Add("@VehicleID", SqlDbType.Int).Value = vehicleid;
                    objCmd.Parameters.Add("@PropellentID", SqlDbType.Int).Value = propellentid;
                }


                VehicleConfigurationId = int.Parse(objCmd.ExecuteScalar().ToString());
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                objCn.Close();
            }

            return VehicleConfigurationId;
        }
        public int Transaction_Trip(CTrip objTrip)
        {

            DBUser objDBUser = new DBUser();
            int TripId;

            objCmd = new SqlCommand();
            objCmd.Connection = objCn;

            try
            {
                objCn.Open();

                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "sp_Transaction_Trip";

                {
                    objCmd.Parameters.Add("@rVehicleConfigurationID", SqlDbType.Int).Value = objTrip.ConfigurationID;
                    objCmd.Parameters.Add("@trOptimumSpeed", SqlDbType.Int).Value = objTrip.OptimumSpeed;
                    objCmd.Parameters.Add("@trWeightOfVehicle", SqlDbType.Int).Value = objTrip.WeightofVehicle;
                    objCmd.Parameters.Add("@trLocation", SqlDbType.VarChar, 50).Value = objTrip.Location;
                    objCmd.Parameters.Add("@trWeatherCondition", SqlDbType.VarChar, 50).Value = objTrip.WeatherCondition;
                    objCmd.Parameters.Add("@trDistanceTravelled", SqlDbType.Int).Value = objTrip.DistanceTravelled;
                    objCmd.Parameters.Add("@trStartTime", SqlDbType.DateTime).Value = objTrip.Starttime;
                    objCmd.Parameters.Add("@trEndTime", SqlDbType.DateTime).Value = objTrip.Endtime;
                    objCmd.Parameters.Add("@trFuelusage", SqlDbType.Int).Value = objTrip.Fuelusage;
                    objCmd.Parameters.Add("@trMaxGForce", SqlDbType.Decimal, 18).Value = objTrip.MaxGForce;
                    objCmd.Parameters.Add("@trHorsepower", SqlDbType.Decimal, 18).Value = objTrip.HorsePower;
                }

                TripId = int.Parse(objCmd.ExecuteScalar().ToString());
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                objCn.Close();
            }

            return TripId;
        }
    }
}
