using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Confero
{
    class CTrip
    {

        private int _tripID;

        public int TripID
        {
            get { return _tripID; }
            set { _tripID = value; }
        }

        private int _configurationID;

        public int ConfigurationID
        {
            get { return _configurationID; }
            set { _configurationID = value; }
        }
        private int _optimumSpeed;

        public int OptimumSpeed
        {
            get { return _optimumSpeed; }
            set { _optimumSpeed = value; }
        }
        private int _weightofVehicle;

        public int WeightofVehicle
        {
            get { return _weightofVehicle; }
            set { _weightofVehicle = value; }
        }
        private string _location;

        public string Location
        {
            get { return _location; }
            set { _location = value; }
        }
        private string _weatherCondition;

        public string WeatherCondition
        {
            get { return _weatherCondition; }
            set { _weatherCondition = value; }
        }
        private int _distanceTravelled;

        public int DistanceTravelled
        {
            get { return _distanceTravelled; }
            set { _distanceTravelled = value; }
        }
        private DateTime _starttime;

        public DateTime Starttime
        {
            get { return _starttime; }
            set { _starttime = value; }
        }
        private DateTime _endtime;

        public DateTime Endtime
        {
            get { return _endtime; }
            set { _endtime = value; }
        }
        private int _fuelusage;

        public int Fuelusage
        {
            get { return _fuelusage; }
            set { _fuelusage = value; }
        }
        private double _maxGForce;

        public double MaxGForce
        {
            get { return _maxGForce; }
            set { _maxGForce = value; }
        }
        private double _horsePower;

        public double HorsePower
        {
            get { return _horsePower; }
            set { _horsePower = value; }
        }
    }
}
