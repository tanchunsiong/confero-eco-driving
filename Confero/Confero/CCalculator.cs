using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
namespace Confero
{
    public class CCalculator
    {

        public const double ACCELERATION_DUE_TO_G = 9.80665;

        public const double AIR_DENSITY_AT_AVG_TEMP = 1.225;

        public const double FEET_PER_METER = 3.2808399;

        public const double FEET_PER_MILE = 5280;

        public const double POUNDS_PER_GALLON_OF_GAS = 6.25;

        public const double POUNDS_PER_KG = 2.20462262;

        public const double WATTS_PER_HORSEPOWER = 745.69987158227025;

        public const double SECONDS_IN_HOUR = 3600;

        private double _averagePower;

        private double _averageSpeed;

        private ArrayList _checkPoints;

        private double _currentPower;

        private double _currentSpeed;

        private double _distanceTraveled;

        private double _dragCoefficient;

        private double _frontalArea;

        private double _lastAcceleration;

        private double _lastCheckpoint;

        private double _lastDistance;

        private double _lastSpeed;

        private long _numOfIterations;

        private double _peakPower;

        private double _weight;

        private double _totalTime;

        public CCalculator(double weight)
        {
            this.Weight = weight;
            this.reset();
        }

        public double Weight
        {
            get
            {
                return _weight;
            }
            set
            {
                _weight = (value / POUNDS_PER_KG);
            }
        }

        public double WeightInPounds
        {
            get
            {
                return (_weight * POUNDS_PER_KG);
            }
        }

        public double CurrentSpeed
        {
            get
            {
                return (_currentSpeed * FEET_PER_METER)
                            / FEET_PER_MILE * SECONDS_IN_HOUR;
            }
            set
            {
                _currentSpeed = value;
            }
        }

        public double LastSpeed
        {
            get
            {
                return ((_lastSpeed * FEET_PER_METER)
                            / (FEET_PER_MILE * SECONDS_IN_HOUR));
            }
            set
            {
                _lastSpeed = value;
            }
        }

        public double AverageSpeed
        {
            get
            {
                return ((_averageSpeed * FEET_PER_METER)
                            / (FEET_PER_MILE * SECONDS_IN_HOUR));
            }
            set
            {
                _averageSpeed = value;
            }
        }

        public double DistanceTraveled
        {
            get
            {
                return ((_distanceTraveled * FEET_PER_METER)
                            / FEET_PER_MILE);
            }
            set
            {
                _distanceTraveled = value;
            }
        }

        public double PeakHorsepower
        {
            get
            {
                return _peakPower;
            }
            set
            {
                _peakPower = value;
            }
        }

        public double Horsepower
        {
            get
            {
                return _currentPower;
            }
            set
            {
                _currentPower = value;
            }
        }

        public double AverageHorsepower
        {
            get
            {
                if ((_numOfIterations > 0))
                {
                    return (_averagePower / _numOfIterations);
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                _averagePower = value;
            }
        }

        public double TotalTime
        {
            get
            {
                return _totalTime;
            }
            set
            {
                _totalTime = value;
            }
        }

        public ArrayList Checkpoints
        {
            get
            {
                return _checkPoints;
            }
            set
            {
                _checkPoints = value;
            }
        }

        public double DragCoefficient
        {
            get
            {
                return _dragCoefficient;
            }
            set
            {
                _dragCoefficient = value;
            }
        }

        public double FrontalArea
        {
            get
            {
                return _frontalArea;
            }
            set
            {
                _frontalArea = value;
            }
        }

        public void AddCheckPoint(double speedInMPH)
        {
            _checkPoints.Add(speedInMPH);
        }

        public delegate void SpeedReachedCheckpointHandler(double seconds, double speed);
        public event SpeedReachedCheckpointHandler SpeedReachedCheckpoint;

        public void reset()
        {
            _averagePower = 0;
            _averageSpeed = 0;
            _currentPower = 0;
            _currentSpeed = 0;
            _distanceTraveled = 0;
            _lastAcceleration = 0;
            _lastDistance = 0;
            _lastSpeed = 0;
            _numOfIterations = 0;
            _peakPower = 0;
            _totalTime = 0;
        }

        public void SetKinematicsProperties(double gs, double seconds)
        {
            try
            {
             
                gs *= ACCELERATION_DUE_TO_G;
                _numOfIterations++;
                _totalTime = (_totalTime + seconds);
               
                _currentSpeed = (_lastSpeed
                            + (((gs + _lastAcceleration)
                            * seconds)
                            / 2));
                _distanceTraveled = (_lastDistance
                            + (((_currentSpeed + _lastSpeed)
                            * seconds)
                            / 2));
                _averageSpeed = (_distanceTraveled / _totalTime);
                // F=ma (Newtons)
                double force = (this.Weight * gs);
                // power=Force*Distance/Time (Watts)
                double power1 = (force * _currentSpeed);
                // http://en.wikipedia.org/wiki/Drag_(physics)
                double power2 = ((AIR_DENSITY_AT_AVG_TEMP
                            * (Math.Pow(_currentSpeed, 3)
                            * (FrontalArea * DragCoefficient)))
                            / 2);
                _currentPower = ((power1 + power2)
                            / WATTS_PER_HORSEPOWER);
                if ((_currentPower > _peakPower))
                {
                    _peakPower = _currentPower;
                }
                if ((_currentPower > 0))
                {
                    _averagePower = (_averagePower + _currentPower);
                }
                else
                {
                    _numOfIterations--;
                }

                if ((_lastSpeed == 0))
                {
                    _lastCheckpoint = 0;
                }
                if (!(_checkPoints == null))
                {
                    foreach (double speed in _checkPoints)
                    {
                        if ((_lastCheckpoint != Math.Floor(speed))
                                    && (Math.Floor(CurrentSpeed) == Math.Floor(speed)))
                        {
                            SpeedReachedCheckpoint(_totalTime, CurrentSpeed);
                            _lastCheckpoint = Math.Floor(CurrentSpeed);
                        }
                    }
                }
                _lastSpeed = _currentSpeed;
                _lastAcceleration = gs;
                _lastDistance = _distanceTraveled;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
