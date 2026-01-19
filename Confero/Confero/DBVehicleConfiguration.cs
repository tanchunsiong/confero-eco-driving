using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
namespace Confero
{
    class DBVehicleConfiguration
    {
        //dreamtcs, to be done
    SqlConnection conn = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=conferoclient;Integrated Security=True");

        public CVehicleConfiguration populateData(CVehicleConfiguration cv)
        {
            String sqlcmd = "SELECT        TOP (1) dbo.tblVehicleConfiguration.vehicleConfigurationID, dbo.tblVehicle.model, dbo.tblVehicle.make, dbo.tblVehicle.capacity, dbo.tblVehicle.year,   dbo.tblVehicleType.description AS VehicleDescription, dbo.tblTyre.brand AS TyreBrand, dbo.tblTyre.width, dbo.tblTyre.size, dbo.tblTyre.material,    dbo.tblTyre.rollingresistance, dbo.tblPropellent.octane, dbo.tblPropellent.brand AS PropellentBrand,  dbo.tblPropellentType.description AS PropellentDescription, dbo.tblTyre.model AS TyreModel, dbo.tblTyre.type AS tyretype FROM            dbo.tblVehicleConfiguration INNER JOIN    dbo.tblTyre ON dbo.tblVehicleConfiguration.tyreID = dbo.tblTyre.tyreID INNER JOIN    dbo.tblVehicle ON dbo.tblVehicleConfiguration.vehicleID = dbo.tblVehicle.vehicleID INNER JOIN    dbo.tblVehicleType ON dbo.tblVehicle.vehicleTypeID = dbo.tblVehicleType.vehicleTypeID INNER JOIN  dbo.tblPropellent ON dbo.tblVehicleConfiguration.propellentID = dbo.tblPropellent.propellentID INNER JOIN dbo.tblPropellentType ON dbo.tblPropellent.propellentTypeID = dbo.tblPropellentType.PropellentTypeID  order by 1 DESC";



            DataSet ds = new DataSet();

            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            da.Fill(ds);


            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                cv.ConfigurationID =int.Parse( dr[0].ToString());
                cv.Vehiclemodel = dr[1].ToString();
                cv.Vehiclemake = dr[2].ToString();
                cv.Vehiclecapacity = dr[3].ToString();
                cv.Vehicleyear = dr[4].ToString();
                cv.Vehicletype = dr[5].ToString();
                cv.Tyrebrand = dr[6].ToString();
                cv.Tyrewidth = dr[7].ToString();
                cv.Tyresize = dr[8].ToString();
                cv.Tyrematerial = dr[9].ToString();
                cv.Tyrerollingresistance = dr[10].ToString();
                cv.Propellentoctane = dr[11].ToString();
                cv.Propellentbrand = dr[12].ToString();
                cv.Propellenttype = dr[13].ToString();
                cv.Tyremodel = dr[14].ToString();
                cv.Tyretype = dr[15].ToString();

            }


            return cv;
        }

        public ArrayList getAllConfiguration()
        {
            ArrayList objarraylist = new ArrayList();
            ArrayList objarraylistofCTrips = new ArrayList();
            String sqlcmd = "SELECT  dbo.tblVehicleConfiguration.vehicleConfigurationID, dbo.tblVehicle.model, dbo.tblVehicle.make, dbo.tblVehicle.capacity, dbo.tblVehicle.year,   dbo.tblVehicleType.description AS VehicleDescription, dbo.tblTyre.brand AS TyreBrand, dbo.tblTyre.width, dbo.tblTyre.size, dbo.tblTyre.material,    dbo.tblTyre.rollingresistance, dbo.tblPropellent.octane, dbo.tblPropellent.brand AS PropellentBrand,  dbo.tblPropellentType.description AS PropellentDescription, dbo.tblTyre.model AS TyreModel, dbo.tblTyre.type AS tyretype,  tblPropellent.propellentTypeID, tblVehicle.vehicleTypeID FROM            dbo.tblVehicleConfiguration INNER JOIN    dbo.tblTyre ON dbo.tblVehicleConfiguration.tyreID = dbo.tblTyre.tyreID INNER JOIN    dbo.tblVehicle ON dbo.tblVehicleConfiguration.vehicleID = dbo.tblVehicle.vehicleID INNER JOIN    dbo.tblVehicleType ON dbo.tblVehicle.vehicleTypeID = dbo.tblVehicleType.vehicleTypeID INNER JOIN  dbo.tblPropellent ON dbo.tblVehicleConfiguration.propellentID = dbo.tblPropellent.propellentID INNER JOIN dbo.tblPropellentType ON dbo.tblPropellent.propellentTypeID = dbo.tblPropellentType.PropellentTypeID  order by 1 DESC";
            CVehicleConfiguration cv;
            CTrip ctrip;

            DataSet ds = new DataSet();

            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            da.Fill(ds);


            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                cv = new CVehicleConfiguration();
                cv.ConfigurationID = int.Parse(dr[0].ToString());
                cv.Vehiclemodel = dr[1].ToString();
                cv.Vehiclemake = dr[2].ToString();
                cv.Vehiclecapacity = dr[3].ToString();
                cv.Vehicleyear = dr[4].ToString();
                cv.Vehicletype = dr[5].ToString();
                cv.Tyrebrand = dr[6].ToString();
                cv.Tyrewidth = dr[7].ToString();
                cv.Tyresize = dr[8].ToString();
                cv.Tyrematerial = dr[9].ToString();
                cv.Tyrerollingresistance = dr[10].ToString();
                cv.Propellentoctane = dr[11].ToString();
                cv.Propellentbrand = dr[12].ToString();
                cv.Propellenttype = dr[13].ToString();
                cv.Tyremodel = dr[14].ToString();
                cv.Tyretype = dr[15].ToString();
                cv.Propellenttypeid = int.Parse(dr[16].ToString());
                cv.Vehicletypeid = int.Parse(dr[17].ToString());
             //loop for each trip with this configuration ID
                SqlCommand sqlcmd2 = new SqlCommand();
                sqlcmd2.CommandText=  "SELECT        tripID, vehicleConfigurationID, optimumSpeed, weightOfVehicle, location, weatherCondition, distanceTravelled, startTime, endTime, fuelusage, maxGForce,  horsepower FROM            tblTrip WHERE        (vehicleConfigurationID = @vehicleConfigurationID)";
                sqlcmd2.Parameters.Add("@vehicleConfigurationID", SqlDbType.Int).Value = cv.ConfigurationID;
                sqlcmd2.Connection = conn;
                DataSet ds2 = new DataSet();
                    //   SqlDataAdapter da2 = new SqlDataAdapter(sqlcmd2, conn);
                      SqlDataAdapter da2 = new SqlDataAdapter(sqlcmd2);
                       da2.Fill(ds2);
                       objarraylistofCTrips = new ArrayList();
                       foreach (DataRow dr2 in ds2.Tables[0].Rows)
                       {
                           
                           ctrip = new CTrip();
                           ctrip.TripID = int.Parse(dr2[0].ToString());
                           ctrip.ConfigurationID = int.Parse(dr2[1].ToString());
                           ctrip.OptimumSpeed = int.Parse(dr2[2].ToString());
                           ctrip.WeightofVehicle = int.Parse(dr2[3].ToString());
                           ctrip.Location=dr2[4].ToString();
                           ctrip.WeatherCondition=dr2[5].ToString();
                           ctrip.DistanceTravelled= int.Parse(dr2[6].ToString());
                           
                           ctrip.Starttime=Convert.ToDateTime( dr2[7].ToString());
                           ctrip.Endtime=Convert.ToDateTime( dr2[8].ToString());
                           ctrip.Fuelusage=int.Parse(dr2[9].ToString());
                           ctrip.MaxGForce=double.Parse(dr2[10].ToString());
                           ctrip.HorsePower = double.Parse(dr2[11].ToString());

                           objarraylistofCTrips.Add(ctrip);
                       }
                       cv.Ctrips = objarraylistofCTrips;
                        objarraylist.Add(cv);
            }


            return objarraylist;
        }
        //dreamtcs, need to test this
        public string getCurrentRollingResistance() {
            String returnvalue = "";
            String sqlcmd = "SELECT        TOP (1) tblTyre.rollingresistance FROM            tblVehicleConfiguration INNER JOIN tblTyre ON tblVehicleConfiguration.tyreID = tblTyre.tyreID  order by 1 DESC";
            SqlCommand cmd = new SqlCommand(sqlcmd, conn);

            try {
                conn.Open();
                returnvalue = cmd.ExecuteScalar().ToString();
            }

            catch (Exception ex) {
                ex.ToString();
            }

            finally { conn.Close(); 
            }
            return returnvalue;
        }

        public bool removeTrip(int tripid)
        {
            bool returnvalue = false;
            String sqlcmd = "DELETE FROM tblTrip WHERE        (tripID = @tripid)";
            SqlCommand cmd = new SqlCommand(sqlcmd, conn);
            cmd.Parameters.Add("@tripid", SqlDbType.Int).Value = tripid;
            try
            {
                int noOfRowAffected= -1;
                conn.Open();
                noOfRowAffected =cmd.ExecuteNonQuery();
                    if (noOfRowAffected ==1){
                    returnvalue=true;}
            }

            catch (Exception ex)
            {
                ex.ToString();
            }

            finally
            {
                conn.Close();
            }
            return returnvalue;
        }
        public int getWeight()
        {
            int returnvalue = 0;
            String sqlcmd = "SELECT  weight FROM tblWeight where weightID = 1";
            SqlCommand cmd = new SqlCommand(sqlcmd, conn);

            try
            {
                conn.Open();
                returnvalue =int.Parse( cmd.ExecuteScalar().ToString());
            }

            catch (Exception ex)
            {
                ex.ToString();
            }

            finally
            {
                conn.Close();
            }
            return returnvalue;
        }

        // public CVehicleConfiguration populateData(CVehicleConfiguration cv)
        //{
        //    String sqlcmd = "SELECT        TOP (1) dbo.tblVehicleConfiguration.vehicleConfigurationID, dbo.tblVehicle.model, dbo.tblVehicle.make, dbo.tblVehicle.capacity, dbo.tblVehicle.year,   dbo.tblVehicleType.description AS VehicleDescription, dbo.tblTyre.brand AS TyreBrand, dbo.tblTyre.width, dbo.tblTyre.size, dbo.tblTyre.material,    dbo.tblTyre.rollingresistance, dbo.tblPropellent.octane, dbo.tblPropellent.brand AS PropellentBrand,  dbo.tblPropellentType.description AS PropellentDescription, dbo.tblTyre.model AS TyreModel, dbo.tblTyre.type AS tyretype FROM            dbo.tblVehicleConfiguration INNER JOIN    dbo.tblTyre ON dbo.tblVehicleConfiguration.tyreID = dbo.tblTyre.tyreID INNER JOIN    dbo.tblVehicle ON dbo.tblVehicleConfiguration.vehicleID = dbo.tblVehicle.vehicleID INNER JOIN    dbo.tblVehicleType ON dbo.tblVehicle.vehicleTypeID = dbo.tblVehicleType.vehicleTypeID INNER JOIN  dbo.tblPropellent ON dbo.tblVehicleConfiguration.propellentID = dbo.tblPropellent.propellentID INNER JOIN dbo.tblPropellentType ON dbo.tblPropellent.propellentTypeID = dbo.tblPropellentType.PropellentTypeID  order by 1 DESC";



        //    DataSet ds = new DataSet();

        //    SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
        //    da.Fill(ds);


        //    foreach (DataRow dr in ds.Tables[0].Rows)
        //    {
        //        cv.ConfigurationID =int.Parse( dr[0].ToString());
        //        cv.Vehiclemodel = dr[1].ToString();
        //        cv.Vehiclemake = dr[2].ToString();
        //        cv.Vehiclecapacity = dr[3].ToString();
        //        cv.Vehicleyear = dr[4].ToString();
        //        cv.Vehicletype = dr[5].ToString();
        //        cv.Tyrebrand = dr[6].ToString();
        //        cv.Tyrewidth = dr[7].ToString();
        //        cv.Tyresize = dr[8].ToString();
        //        cv.Tyrematerial = dr[9].ToString();
        //        cv.Tyrerollingresistance = dr[10].ToString();
        //        cv.Propellentoctane = dr[11].ToString();
        //        cv.Propellentbrand = dr[12].ToString();
        //        cv.Propellenttype = dr[13].ToString();
        //        cv.Tyremodel = dr[14].ToString();
        //        cv.Tyretype = dr[15].ToString();

        //    }


        //    return cv;
        //}
        //dreamtcs, need to test this
        //public string getCurrentRollingResistance() {
        //    String returnvalue = "";
        //    String sqlcmd = "SELECT        TOP (1) tblTyre.rollingresistance FROM            tblVehicleConfiguration INNER JOIN tblTyre ON tblVehicleConfiguration.tyreID = tblTyre.tyreID  order by 1 DESC";
        //    SqlCommand cmd = new SqlCommand(sqlcmd, conn);

        //    try {
        //        conn.Open();
        //        returnvalue = cmd.ExecuteScalar().ToString();
        //    }

        //    catch (Exception ex) {
        //        ex.ToString();
        //    }

        //    finally { conn.Close(); 
        //    }
        //    return returnvalue;
        //}
        //public int getWeight()
        //{
        //    int returnvalue = 0;
        //    String sqlcmd = "SELECT  weight FROM tblWeight where weightID = 1";
        //    SqlCommand cmd = new SqlCommand(sqlcmd, conn);

        //    try
        //    {
        //        conn.Open();
        //        returnvalue =int.Parse( cmd.ExecuteScalar().ToString());
        //    }

        //    catch (Exception ex)
        //    {
        //        ex.ToString();
        //    }

        //    finally
        //    {
        //        conn.Close();
        //    }
        //    return returnvalue;
        //}

        public void setWeight(int weight)
        {
            String sqlcmd = "UPDATE       tblWeight SET                weight = @weight WHERE        (weightID = 1)";
            SqlCommand cmd = new SqlCommand(sqlcmd, conn);

            try
            {
                cmd.Parameters.Add("@weight", SqlDbType.Int).Value =weight;
                conn.Open();
                cmd.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                ex.ToString();
            }

            finally
            {
                conn.Close();
            }
         
        }

        public Boolean updateDatabase(CVehicleConfiguration oldconfig, CVehicleConfiguration newconfig)
        {
            int rowaffected=-1;
            bool result = false;
            //dreamtcs, still need to update weight nontheless
            setWeight(newconfig.Weight);
            if (compareConfig(oldconfig, newconfig))
            {
                int tyreID=0;
                int vehicleID=0;
                int propellentID=0;
                int vehicleTypeID = 0;
                int propellentTypeID = 0;

                String cmd = "select vehicleTypeID from tblVehicleType where description like @vehicleType";
                SqlCommand sqlcmd = new SqlCommand(cmd, conn);
                sqlcmd.Parameters.Add("@vehicleType", SqlDbType.VarChar).Value = newconfig.Vehicletype;

                try
                {
                    conn.Open();
                    vehicleTypeID =int.Parse( sqlcmd.ExecuteScalar().ToString());
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }

                finally {

                    conn.Close();
                }

                cmd = "select propellentTypeID from tblPropellentType where description like @propellentType";
                 sqlcmd = new SqlCommand(cmd, conn);
                sqlcmd.Parameters.Clear();
                sqlcmd.Parameters.Add("@propellentType", SqlDbType.VarChar).Value = newconfig.Propellenttype;

                try
                {
                    conn.Open();
                    propellentTypeID =int.Parse( sqlcmd.ExecuteScalar().ToString());
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }

                finally
                {

                    conn.Close();
                }

               
            try {
                 //now insert into each table
                //propellent
                cmd = "INSERT INTO tblPropellent (propellentTypeID, octane, brand) VALUES        (@propellentTypeID,@propellentoctane,@propellentbrand)";    
                sqlcmd = new SqlCommand(cmd, conn);
                sqlcmd.Parameters.Clear();
                sqlcmd.Parameters.Add("@propellentTypeID", SqlDbType.Int).Value = propellentTypeID;
                sqlcmd.Parameters.Add("@propellentoctane", SqlDbType.VarChar).Value = newconfig.Propellentoctane;
                sqlcmd.Parameters.Add("@propellentbrand", SqlDbType.VarChar).Value = newconfig.Propellentbrand;
                conn.Open();
                rowaffected=sqlcmd.ExecuteNonQuery();
                cmd = "select top(1) propellentID from tblPropellent  order by 1 DESC";
                sqlcmd = new SqlCommand(cmd, conn);
                sqlcmd.Parameters.Clear();
                propellentID=int.Parse(sqlcmd.ExecuteScalar().ToString());
            
            //tyre
                cmd = "INSERT INTO tblTyre (brand, width, size, material, rollingresistance, model, type) VALUES        (@tyreBrand,@tyreWidth,@tyreSize,@tyreMaterial,@tyrerollingResistance,@tyreModel,@tyreType)";     
                sqlcmd = new SqlCommand(cmd, conn);
                sqlcmd.Parameters.Clear();
                sqlcmd.Parameters.Add("@tyreBrand", SqlDbType.VarChar).Value = newconfig.Tyrebrand;
                sqlcmd.Parameters.Add("@tyreWidth", SqlDbType.VarChar).Value = newconfig.Tyrewidth;
                sqlcmd.Parameters.Add("@tyreSize", SqlDbType.VarChar).Value = newconfig.Tyresize;
                sqlcmd.Parameters.Add("@tyrematerial", SqlDbType.VarChar).Value = newconfig.Tyrematerial;
                sqlcmd.Parameters.Add("@tyrerollingresistance", SqlDbType.VarChar).Value = newconfig.Tyrerollingresistance;
                sqlcmd.Parameters.Add("@tyremodel", SqlDbType.VarChar).Value = newconfig.Tyremodel;
                sqlcmd.Parameters.Add("@tyretype", SqlDbType.VarChar).Value = newconfig.Tyretype;
                rowaffected = -1;
                rowaffected=sqlcmd.ExecuteNonQuery();
                cmd = "select top(1) tyreID from tblTyre order by 1 DESC";
                sqlcmd = new SqlCommand(cmd, conn);
                sqlcmd.Parameters.Clear();
               tyreID=int.Parse(sqlcmd.ExecuteScalar().ToString());
                //vehicle

               cmd = "INSERT INTO tblVehicle (vehicleTypeID, model, make, year, capacity) VALUES (@vehicleTypeID,@vehicleModel,@vehicleMake,@vehicleYear,@vehicleCapacity)";
               sqlcmd = new SqlCommand(cmd, conn);
               sqlcmd.Parameters.Clear();
               sqlcmd.Parameters.Add("@vehicleTypeID", SqlDbType.Int).Value = vehicleTypeID;
               sqlcmd.Parameters.Add("@vehicleModel", SqlDbType.VarChar).Value = newconfig.Vehiclemodel;
               sqlcmd.Parameters.Add("@vehicleMake", SqlDbType.VarChar).Value = newconfig.Vehiclemake;
               sqlcmd.Parameters.Add("@vehicleYear", SqlDbType.VarChar).Value = newconfig.Vehicleyear;
               sqlcmd.Parameters.Add("@vehicleCapacity", SqlDbType.VarChar).Value = newconfig.Vehiclecapacity;
            
               rowaffected = -1;
               rowaffected = sqlcmd.ExecuteNonQuery();
               cmd = "select top(1) vehicleID from tblVehicle order by 1 DESC";
               sqlcmd = new SqlCommand(cmd, conn);
               sqlcmd.Parameters.Clear();
               vehicleID= int.Parse(sqlcmd.ExecuteScalar().ToString());
           
            //vehicle configuration

               cmd = "INSERT INTO tblVehicleConfiguration (vehicleID, propellentID, tyreID) VALUES        (@vehicleID,@propellentID,@tyreID)";
               sqlcmd = new SqlCommand(cmd, conn);
               sqlcmd.Parameters.Clear();
               sqlcmd.Parameters.Add("@vehicleID", SqlDbType.Int).Value = vehicleID;
               sqlcmd.Parameters.Add("@propellentID", SqlDbType.Int).Value = propellentID;
               sqlcmd.Parameters.Add("@tyreID", SqlDbType.Int).Value = tyreID;

               rowaffected = -1;
               rowaffected = sqlcmd.ExecuteNonQuery();
              
           
            }
                catch (Exception ex){
                    ex.ToString();
                }
                finally{
            conn.Close();}
            
            }

            return result;
        }
        public Boolean updateDatabaseTrip(CTrip ctrip)
        {
            int rowaffected = -1;
            bool result = false;
          
                String cmd = "INSERT INTO tblTrip (vehicleConfigurationID, optimumSpeed, weightOfVehicle, location, weatherCondition, distanceTravelled, startTime, endTime, fuelusage, maxGForce, horsepower) VALUES  (@vehicleConfigurationID,@optimumSpeed,@weightOfVehicle,@location,@weatherCondition,@distanceTravelled,@startTime,@endTime,@fuelusage,@maxGForce,@horsePower)";
                SqlCommand sqlcmd = new SqlCommand(cmd, conn);
                sqlcmd.Parameters.Add("@vehicleConfigurationID", SqlDbType.Int).Value = ctrip.ConfigurationID;
              sqlcmd.Parameters.Add("@optimumSpeed", SqlDbType.Int).Value =ctrip.OptimumSpeed;
              sqlcmd.Parameters.Add("@weightofvehicle", SqlDbType.Int).Value =ctrip.WeightofVehicle;
              sqlcmd.Parameters.Add("@location", SqlDbType.VarChar).Value =ctrip.Location;
              sqlcmd.Parameters.Add("@weathercondition", SqlDbType.VarChar).Value = ctrip.WeatherCondition;
              sqlcmd.Parameters.Add("@distancetravelled", SqlDbType.Int).Value =ctrip.DistanceTravelled;
              sqlcmd.Parameters.Add("@starttime", SqlDbType.DateTime).Value = ctrip.Starttime;
              sqlcmd.Parameters.Add("@endtime", SqlDbType.DateTime).Value = ctrip.Endtime;
              sqlcmd.Parameters.Add("@fuelusage", SqlDbType.Int).Value = ctrip.Fuelusage;
              sqlcmd.Parameters.Add("@maxgforce", SqlDbType.Decimal).Value = ctrip.MaxGForce;
                      sqlcmd.Parameters.Add("@horsepower", SqlDbType.Decimal).Value = ctrip.HorsePower;
            try
                {
                    conn.Open();
                   rowaffected  = sqlcmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }

                finally
                {

                    conn.Close();
                }


            if (rowaffected == 1)
            {
                result = true; 
            }

            return result;
        }


        private bool compareConfig(CVehicleConfiguration oldconfig, CVehicleConfiguration newconfig)
        {
            //if there is change, its a new config and return true, else return false
            bool result = false;

            if (!oldconfig.Vehiclemodel.ToLower().Equals(newconfig.Vehiclemodel.ToLower())) { result = true; }
            if (!oldconfig.Vehiclemake.ToLower().Equals(newconfig.Vehiclemake.ToLower())) { result = true; }
            if (!oldconfig.Vehiclecapacity.ToLower().Equals(newconfig.Vehiclecapacity.ToLower())) { result = true; }
            if (!oldconfig.Vehicleyear.ToLower().Equals(newconfig.Vehicleyear.ToLower())) { result = true; }
            if (!oldconfig.Vehicletype.ToLower().Equals(newconfig.Vehicletype.ToLower())) { result = true; }
            if (!oldconfig.Tyrebrand.ToLower().Equals(newconfig.Tyrebrand.ToLower())) { result = true; }
            if (!oldconfig.Tyrewidth.ToLower().Equals(newconfig.Tyrewidth.ToLower())) { result = true; }
            if (!oldconfig.Tyresize.ToLower().Equals(newconfig.Tyresize.ToLower())) { result = true; }
            if (!oldconfig.Tyrematerial.ToLower().Equals(newconfig.Tyrematerial.ToLower())) { result = true; }
            if (!oldconfig.Tyrerollingresistance.ToLower().Equals(newconfig.Tyrerollingresistance.ToLower())) { result = true; }
            if (!oldconfig.Propellentoctane.ToLower().Equals(newconfig.Propellentoctane.ToLower())) { result = true; }
            if (!oldconfig.Propellentbrand.ToLower().Equals(newconfig.Propellentbrand.ToLower())) { result = true; }
            if (!oldconfig.Propellenttype.ToLower().Equals(newconfig.Propellenttype.ToLower())) { result = true; }
            if (!oldconfig.Tyremodel.ToLower().Equals(newconfig.Tyremodel.ToLower())) { result = true; }
            if (oldconfig.Tyretype.ToLower().Equals(newconfig.Tyretype.ToLower())) { result = true; }

            return result;
        }
    }
}
