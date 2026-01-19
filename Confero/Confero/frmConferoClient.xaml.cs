using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Collections;
using System.Data;
using Phidgets.Events;
using Phidgets;
using GPS;
using System.IO.Ports;
using System.Runtime.InteropServices;


namespace Confero
{

    public partial class Window1 : Window
    {
        //Accelerometer Stuff
        private TimeSpan _currentTime;
        private TimeSpan _previousTime;
        private TimeSpan ts;
        private CCalculator _statCalculator;   
        private Accelerometer _vehicleTimer;
        private double _accelerationStartThreshold = 0.02;//  default this (can be changed in setup)
        private double _currentAcc;
        private string _currentAcceleration;
        private string _currentSpeed;
        private string _distanceTraveled;
        private string _horsepower;
        private bool _isNewRun = true;
        private bool _isSetup = false;
        private double _lastScreenUpdateInSeconds;
        private double _firstAccel;
        private bool _reverseAccelerationFlag = false;
        private double _stopTime;
        private string _totalTime;
        private bool _vehicleStartedMoving = false;
       
        
        //GPS Stuff
        private NMEAProtocol protocol = new NMEAProtocol();
        private SerialPort port = new SerialPort();
        private Encoding encoding = System.Text.ASCIIEncoding.GetEncoding(1252);

        //rmisc stuff
        private double milespergallon = 1;
        private double deadzone = 0.05;

        //Declare an InterfaceKit object
        static InterfaceKit ifKit;
        private int powerUsage;

        //timers
        private DispatcherTimer timerSpeedometer;
        private DispatcherTimer timerGPSLock;
        private DispatcherTimer timerUpdateGMeter;

        //web form Control
        public WebBrowser.WebBrowserControlForm browserControl;
       // ObjectForScriptingHelper _scriptingHelper;

        //configuration form Control
        public Configuration.UserControl1 configurationFormControl;

        //temperature
        private double temperature;
        private double slider;
        private double rotationknob;

        //Sync Database
        private CDBSync CDBS;
        private CUser cu;
        private DBUser dbuser;


        //loggin stuff
        private CTrip ctrip;
        private CVehicleConfiguration cv;
        private DBVehicleConfiguration dbvc;

        public Window1()
        {
            try
            {
                //windows default
                InitializeComponent();

                
                //phidgets stuff
                initialiseIK();

                //logging stuff
                ctrip = new CTrip();
                cv = new CVehicleConfiguration();
                dbvc = new DBVehicleConfiguration();


                //sync database
                cu = new CUser();
                dbuser = new DBUser();
                CDBS = new CDBSync();

                //place browser control
                browserControl = new WebBrowser.WebBrowserControlForm();
                browserControl.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
                hostWinForms.Child = browserControl.getWebBrowserControl();
                hostWinForms.Child.Width = 1024;
                hostWinForms.Child.Height = 600;
                if (ConnectionExists())
                {
                    browserControl.getWebBrowserControl().Url = new Uri(@"C:\Confero Software\Confero\Confero\VE.htm");
                }
                browserControl_Resize();

                //place configuration form control
                configurationFormControl = new Configuration.UserControl1();
                configurationFormControl.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
                hostWinFormConfig.Child = configurationFormControl;
                hostWinFormConfig.Child.Width = 1000;
                hostWinFormConfig.Child.Height = 600;

                //default weight is 1000kg
                _statCalculator = new CCalculator(1000);
                _vehicleTimer = new Accelerometer();
               
                //timer stuff, to delegate to which method and set timing
                //WPFe does not support timer object, hence we need to do something below for Confero
                timerSpeedometer = new DispatcherTimer(DispatcherPriority.Background);
                timerSpeedometer.Interval = TimeSpan.FromSeconds(0.025);
                timerSpeedometer.Tick += delegate { ScheduleUpdate(); };
                timerUpdateGMeter = new DispatcherTimer(DispatcherPriority.Background);
                timerUpdateGMeter.Interval = TimeSpan.FromSeconds(0.075);
                timerUpdateGMeter.Tick += delegate { UpdateGMeter(); };
                timerGPSLock = new DispatcherTimer(DispatcherPriority.Background);
                timerGPSLock.Interval = TimeSpan.FromSeconds(1);
                timerGPSLock.Tick += delegate { ReadDataFromGPSReceiver(); };

                //this is to reset the state of the vehicle calculator values
                resetState();

            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error occured during load. Details are: {0} The application will now terminate, as this is an invalid" +
                        " state.", ex.Message));

            }//end try catch
        }//end constructor

        #region web stuff

        void browserControl_Resize()
        {
            ExecuteScript("Resize", browserControl.Width, browserControl.Height);
        }

        private void ExecuteScript(string scriptName, params object[] parameters)
        {

            browserControl.getWebBrowserControl().Document.InvokeScript(scriptName, parameters);
        }

        #endregion

        #region phidget interfacekit stuff

        public void initialiseIK()
        {
            try
            {
                //Initialize the InterfaceKit object
                ifKit = new InterfaceKit();

               
                //Hook the phidget spcific event handlers
                ifKit.InputChange += new InputChangeEventHandler(ifKit_InputChange);
                ifKit.OutputChange += new OutputChangeEventHandler(ifKit_OutputChange);
                ifKit.SensorChange += new SensorChangeEventHandler(ifKit_SensorChange);

                //Open the object for device connections
                ifKit.open();
            }
            catch (PhidgetException ex)
            {
                ex.ToString();
            }
        }

        public void ifKit_InputChange(object sender, InputChangeEventArgs e)
        {
            Console.WriteLine("Input index {0} value (1)", e.Index, e.Value.ToString());
        }

        //Output change event handler...Display the output index and the new valu to 
        //the console
        public void ifKit_OutputChange(object sender, OutputChangeEventArgs e)
        {
            Console.WriteLine("Output index {0} value {0}", e.Index, e.Value.ToString());
        }

        //Sensor Change event handler...Display the sensor index and it's new value to 
        //the console
        public void ifKit_SensorChange(object sender, SensorChangeEventArgs e)
        {
            if (e.Index == 0)
            {
                //this is for demo only
                powerUsage = e.Value;
            }
            if (e.Index == 1)
            {
                temperature = e.Value;
            }
            if (e.Index == 2)
            {
                slider = e.Value;
            }
            if (e.Index == 3)
            {
                rotationknob = e.Value;
            }
        }

        #endregion

        #region timer Stuff

        public void ScheduleUpdate()
        {

            ts += timerSpeedometer.Interval;
            try
            {
                double dblcurrentacceleration = double.Parse(_currentAcceleration);

                //if acceleration is negative, make it positive
                if (dblcurrentacceleration < 0)
                {
                    dblcurrentacceleration = dblcurrentacceleration * -1;
                }
                //set deadzone for accelerometer
                if ((dblcurrentacceleration <= deadzone) && dblcurrentacceleration >= deadzone)
                {
                    lblGValue.Content = "0.00 Gs";
                }
                else
                {
                    lblGValue.Content = dblcurrentacceleration.ToString("F2") + "G";
                }
                //if current acceleration is larger then recorded, record it
                if (dblcurrentacceleration >= ctrip.MaxGForce)
                {

                    ctrip.MaxGForce = dblcurrentacceleration;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

            // here we are doing the rotation for the speedometer
            if (_currentSpeed != null)
            {
                
                RotateTransform transform = new RotateTransform();
                try
                {
                    double dblcurrentspeed = calculateAmp(powerUsage) * 5;
                    if (dblcurrentspeed <= 220)
                    {
                        //negative to positive value
                        if (dblcurrentspeed < 0)
                        {
                            dblcurrentspeed = dblcurrentspeed * -1;
                        }
                        transform.Angle = -128 + ((240 / 200) * dblcurrentspeed);
                        canDial1.RenderTransform = transform;

                        this.lblSpeed.Text = dblcurrentspeed.ToString("F2") + " KM/H";
                    }

                }
                catch (Exception Ex)
                {
                    Ex.ToString();
                }
            }



            if (_distanceTraveled != null)
            {
                double dbldistanceTravelled = double.Parse(_distanceTraveled);
               //from negative to positive
                if (dbldistanceTravelled < 0)
                {

                    this.lblDistance.Text = (dbldistanceTravelled * -1).ToString("F1");
                }
                else
                {
                    this.lblDistance.Text = dbldistanceTravelled.ToString("F1");
                }
                ctrip.DistanceTravelled = Convert.ToInt32(double.Parse(_distanceTraveled));
            }

            String tempString = (calculateAmp(powerUsage)).ToString();
            if (tempString[0].Equals('-'))
            {
                tempString = tempString.Substring(1);
            }
            //rotate for MPG meter
            try
            {
                RotateTransform transform = new RotateTransform();

                double dblpowerusage = calculateAmp(powerUsage);
                if (dblpowerusage < 0)
                {
                    dblpowerusage = dblpowerusage * -1;
                }
                if (calculateAmp(powerUsage) == 0)
                {
                    transform.Angle = -120;
                    canDial.RenderTransform = transform;
                    lblEfficiency.Content = "0.00 Km/A";
                }
                else
                {
                    transform.Angle = -120 + ((10) * dblpowerusage);
                    canDial.RenderTransform = transform;
                    lblEfficiency.Content = dblpowerusage.ToString("F2") + " Km/A";

                    if (dblpowerusage > milespergallon)
                    {
                        lblOptimumSpeed.Content = (calculateAmp(powerUsage) * 5).ToString("F2") + " is your optimum speed";
                        milespergallon = dblpowerusage;
                        ctrip.OptimumSpeed = Convert.ToInt32(calculateAmp(powerUsage));
                    }
                }
                double currentpower = (calculateAmp(powerUsage));
                if (currentpower < 0)
                {
                    currentpower = currentpower * -1;
                }

                if (dblpowerusage != 0)
                {
                    if (lblTotalPowerUsage.Content.ToString().Equals(""))
                    {
                        lblTotalPowerUsage.Content = 0;
                    }
                    lblTotalPowerUsage.Content = double.Parse(lblTotalPowerUsage.Content.ToString()) + (currentpower / 0.025);
                    ctrip.Fuelusage = Convert.ToInt32(double.Parse(lblTotalPowerUsage.Content.ToString()) + (currentpower / 0.025));
                }
               
         

            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            txtTemp.Text = (((temperature / 1000) * 250) - 50).ToString();
        }

        #endregion



        public void UpdateGMeter()
        {


            if (_currentAcceleration != null)
            {
                if (!_currentAcceleration[0].Equals('-'))
                {
                    this.GBlocker.Margin = new Thickness((300 * (double.Parse(_currentAcceleration) / 1)) - 20, this.GBlocker.Margin.Top, this.GBlocker.Margin.Right, this.GBlocker.Margin.Bottom);

                    this.gAccel.Visibility = System.Windows.Visibility.Visible;
                    this.gdeaccel.Visibility = System.Windows.Visibility.Hidden;

                }
                else
                {
                    this.GBlocker.Margin = new Thickness((300 * ((double.Parse(_currentAcceleration) / 1) * -1)) - 20, this.GBlocker.Margin.Top, this.GBlocker.Margin.Right, this.GBlocker.Margin.Bottom);
                    this.gAccel.Visibility = System.Windows.Visibility.Hidden;
                    this.gdeaccel.Visibility = System.Windows.Visibility.Visible;
                }
                if (double.Parse(_currentAcceleration) > ctrip.MaxGForce)
                {
                    ctrip.MaxGForce = double.Parse(_currentAcceleration);
                }
                
            }

        }




        #region car calculator stuff
      

        private void accel_AccelerationChange(object sender, AccelerationChangeEventArgs e)
        {
            try
            {
                _vehicleTimer.axes[1].Sensitivity = 0.02;
                _vehicleTimer.axes[0].Sensitivity = 0.02;
                double changeInAccel = 0.0;
                if (!_vehicleStartedMoving)
                {
                    if (_isNewRun)
                    {
                        _firstAccel = _vehicleTimer.axes[1].Acceleration;        // first read  
                        _isNewRun = false;
                    }
                
                }
                _currentAcc = _vehicleTimer.axes[1].Acceleration;
                changeInAccel = (_currentAcc - _firstAccel);// _firstAccel only gets set once

                if (((Math.Abs(changeInAccel) <= _accelerationStartThreshold)
                            && !_vehicleStartedMoving))
                {
                    return;
                }
                if (_reverseAccelerationFlag)
                {
                    // will be false until after 1st calculation
                    if ((changeInAccel <= 0))
                    {
                        // actually increasing here...
                        changeInAccel = Math.Abs(changeInAccel);
                    }
                    else
                    {
                        // actually decreasing here...
                        changeInAccel = (changeInAccel * -1);
                    }
                }
                if (!_vehicleStartedMoving)
                {
                    if ((changeInAccel < 0))
                    {
                        // we started to move backwards first time through
                        _reverseAccelerationFlag = true;
                        changeInAccel = Math.Abs(changeInAccel);
                    }
                    _vehicleStartedMoving = true;
                    this.timerSpeedometer.Start();
                    this.timerUpdateGMeter.Start();
                }
                //  keep the following line as close to the SetKinematicsProperties method as possible
                //dreamtcs need to check
                _currentTime = ts;
                _statCalculator.SetKinematicsProperties(changeInAccel, (_currentTime - _previousTime).TotalSeconds);
                _previousTime = _currentTime;
                _currentAcceleration = changeInAccel.ToString("F4");
                _currentSpeed = _statCalculator.CurrentSpeed.ToString("F2");
                _distanceTraveled = _statCalculator.DistanceTraveled.ToString("F4");
                _horsepower = _statCalculator.Horsepower.ToString("F2");
                _totalTime = _statCalculator.TotalTime.ToString("F3");
                if (((_statCalculator.TotalTime - _lastScreenUpdateInSeconds)
                            >= 0.25))//  only need to update display every 1/4 second
                {
                    
                 //   RefreshGridData();
                    _lastScreenUpdateInSeconds = _statCalculator.TotalTime;
                }

                if (((_stopTime > 0)
                            && (_previousTime.TotalSeconds >= _stopTime)))
                {
                    //  we want to end at a stopping point that the user chose
                    string msg = ("Peak horsepower: "
                                + (_statCalculator.PeakHorsepower.ToString("F4") + ("\r\n" + ("Average horsepower: " + _statCalculator.AverageHorsepower.ToString("F4")))));
                    resetState();
                    MessageBox.Show(msg);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error occured. Details are: {0}", ex.Message));
                resetState();
            }
        }



        private void resetState()
        {
            if (!(_vehicleTimer == null))
            {
                _vehicleTimer.AccelerationChange -= accel_AccelerationChange;
            }



            _currentAcc = 0;
            _currentAcceleration = null;
            _currentSpeed = null;
            _currentTime = TimeSpan.Zero;
            _distanceTraveled = null;
            _firstAccel = 0;
            _horsepower = null;
            _isNewRun = true;
            _lastScreenUpdateInSeconds = 0;
            _previousTime = TimeSpan.Zero;
            _reverseAccelerationFlag = false;
            ts = TimeSpan.Zero;
            timerSpeedometer.Stop();
            _totalTime = null;
            _vehicleStartedMoving = false;
            _statCalculator.reset();
            
        }

        #endregion


        #region event handlers
        private void button1_Click_1(object sender, RoutedEventArgs e)
        {
            cv = new CVehicleConfiguration();
            cv = dbvc.populateData(cv);
            ctrip = new CTrip();
            ctrip.ConfigurationID = cv.ConfigurationID;
            ctrip.Location = "Singapore";
            ctrip.Starttime = DateTime.Now;
            ctrip.WeightofVehicle = dbvc.getWeight();
            ctrip.MaxGForce = 0;
            ctrip.OptimumSpeed = 0;
            ctrip.Endtime = DateTime.Now; ;
            ctrip.DistanceTravelled = 0;
            ctrip.Fuelusage = 0;
            ctrip.WeatherCondition = "N/A";

            try
            {
                _statCalculator.Weight = dbvc.getWeight();
                _statCalculator.DragCoefficient = 0.3;
                _statCalculator.FrontalArea = 2.74;
            }
            catch { }
            timerSpeedometer.Start();
            if (!(_vehicleTimer == null))
            {
                _vehicleTimer.open();
                _vehicleTimer.AccelerationChange += new AccelerationChangeEventHandler(this.accel_AccelerationChange);
            }
        }

        private void chkWeather_Checked(object sender, RoutedEventArgs e)
        {
            ExecuteScript("showWeather");
        }

        private void chkWeather_Unchecked(object sender, RoutedEventArgs e)
        {
            ExecuteScript("hideWeather");
        }

        private void chkTraffic_Checked(object sender, RoutedEventArgs e)
        {
            ExecuteScript("showTraffic");
        }


        private void chkNavi_Checked(object sender, RoutedEventArgs e)
        {

            try
            {
                //GPS
                port.PortName = "COM5";
                port.Parity = Parity.None;
                port.BaudRate = 4800;
                port.StopBits = StopBits.One;
                port.DataBits = 8;
                port.Open();

                timerGPSLock.Start();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

        }

        private void chkNavi_unChecked(object sender, RoutedEventArgs e)
        {
            port.Close();
            timerGPSLock.Stop();
        }

        private void chkTraffic_Unchecked(object sender, RoutedEventArgs e)
        {
            ExecuteScript("hideTraffic");
        }

        private void chkUserInfo_Unchecked(object sender, RoutedEventArgs e)
        {
            //dreamtcs
            ExecuteScript("clearoverlay");

        }

        private void chkUserInfo_Checked(object sender, RoutedEventArgs e)
        {
            //dreamtcs
            //select all user generated data from past 15 mins
            if (ConnectionExists())
            {
                ArrayList objarraylist = new ArrayList();
                CUserGeneratedInformation cgui;
                objarraylist = CDBS.getUserGeneratedInformation();
                foreach (Object obj in objarraylist)
                {
                    try
                    {
                        cgui = (CUserGeneratedInformation)obj;
                        ExecuteScript("addMarker", cgui.longti, cgui.Lat, cgui.Description, cgui.Value);
                    }
                    catch { }
                    finally { }
                }
            }
        }


        #endregion

        #region GPS Stuff

        private void ReadDataFromGPSReceiver()
        {
            byte[] bData = new byte[256];

            try
            {
                port.Read(bData, 0, 256);
                protocol.ParseBuffer(bData);
                DisplayCurrentLocationOnMap();
            }
            catch (Exception e)
            {
                e.ToString();
            }
        }

        private void DisplayCurrentLocationOnMap()
        {
          
            object[] array = { ConvertToDecimalDegree(protocol.GPGGA.Latitude), ConvertToDecimalDegree(protocol.GPGGA.Longitude), Convert.ToInt32((sliderZoom.Value * 1.7) + 1) };

            browserControl.getWebBrowserControl().Document.InvokeScript("DoCenterZoom", array);
        }

        #endregion

        bool ConnectionExists()
        {
            try
            {
                System.Net.Sockets.TcpClient clnt = new System.Net.Sockets.TcpClient("www.microsoft.com", 80);
                clnt.Close();
                return true;
            }
            catch (System.Exception ex)
            {
                ex.ToString();
                return false;
            }
        }





        public double calculateAmp(int rawvalue)
        {
            double returnvalue = 0.00;
            if ((rawvalue >= 495) && (rawvalue <= 505))
            {
                rawvalue = 500;
            }
            else if ((rawvalue >= 450) && (rawvalue <= 550))
            {
                if (rawvalue <= 500)
                {
                    rawvalue = 500 + (500 - rawvalue);
                }
                returnvalue = (((double)rawvalue / 1000) * 125) - 62.5;
            }
            return returnvalue;
        }

        private void btnStartLocation_Click(object sender, RoutedEventArgs e)
        {
            if ((txtEndAddress.Text != "") && (txtStartAddress.Text != ""))
            {
                object[] array = { txtStartAddress.Text, txtEndAddress.Text };
                browserControl.getWebBrowserControl().Document.InvokeScript("getRoute", array);
            }
            else
            {
                MessageBox.Show("Please enter an address");
            }

        }



  
        private void btnEndTrip_Click(object sender, RoutedEventArgs e)
        {
            //dreamtcs, need to display a lot of information in the last form
            timerSpeedometer.Stop();
            timerUpdateGMeter.Stop();
            if (_horsepower != null)
            {
                ctrip.HorsePower = double.Parse(_horsepower);
            }
            ctrip.Endtime = DateTime.Now;
            if (ctrip.DistanceTravelled < 0)
            {

                ctrip.DistanceTravelled = ctrip.DistanceTravelled * -1;

            }

            if (ctrip.HorsePower < 0)
            {

                ctrip.HorsePower = ctrip.HorsePower * -1;

            }

            if (ctrip.OptimumSpeed < 0)
            {

                ctrip.OptimumSpeed = ctrip.OptimumSpeed * -1;

            }
            dbvc.updateDatabaseTrip(ctrip);
            label10.Content = "Distance travelled:" + ctrip.DistanceTravelled.ToString() + "km";
            label2.Content = "Start Time:" + ctrip.Starttime.ToString() + "";
            label3.Content = "End Time:" + ctrip.Endtime.ToString() + "";
            label4.Content = "Horsepower:" + ctrip.HorsePower + "HP";
            label5.Content = "Location:" + ctrip.Location + "";
            label6.Content = "Max G Force:" + ctrip.MaxGForce + "Gs";
            label7.Content = "Weather Condition:" + ctrip.WeatherCondition + "";
            label8.Content = "Optimum Speed:" + ctrip.OptimumSpeed + "km/h";
            label9.Content = "Weight of Vehicle:" + ctrip.WeightofVehicle + "KG";

        }

        public double ConvertToDecimalDegree(double tempdbl)
        {
            String deci = tempdbl.ToString().Substring(0, tempdbl.ToString().IndexOf('.'));
            String mm = tempdbl.ToString().Substring(tempdbl.ToString().IndexOf('.') + 1);
            double dblmm = tempdbl;
            mm = mm.Insert(2, ".");
            try
            {
                dblmm = double.Parse(mm);
                dblmm = dblmm / 60;
                dblmm = dblmm + double.Parse(deci);
            }
            catch (Exception e)
            {
                e.ToString();
            }

            return dblmm;
        }



        private void btnSync_Click(object sender, RoutedEventArgs e)
        {
            DBMis dbmis = new DBMis();
            int userid = 0;
            //set back user credentials

            cu.LoginID = txtLoginUser.Text;
            cu.Password = txtPassword.Password;
            //dreamtcs
            //if internet connection is available
            if (ConnectionExists())
            {//try to validate
                //dreamtcs need to hash password first
                userid = dbuser.Get_UserId(cu.LoginID, dbmis.GenerateHash(cu.Password));

                //if there is a new userID
                if (userid != 0)
                {
                    //if valid user, call wee cheng's method, create classes to loop
                    //loop selection configuration from tblVehicleConfiguration
                    ArrayList objConfigurationarraylist = new ArrayList();
                    //select all configuration from localdatabase
                    objConfigurationarraylist = dbvc.getAllConfiguration();
                    foreach (object obj in objConfigurationarraylist)
                    {
                        CVehicleConfiguration objvehconfig = new CVehicleConfiguration();
                        objvehconfig = (CVehicleConfiguration)obj;
                        if (objvehconfig.Ctrips.Count != 0)
                        {
                            //insert into server tyres, vehicle, propellent to add into configuration and get configuration Id
                            //then add into ownership

                            ArrayList objArrayCtrips = objvehconfig.Ctrips;
                            int tyreid = 0;
                            int vehicleid = 0;
                            int propellentid = 0;
                            int configurationid = 0;
                            foreach (object obj2 in objArrayCtrips)
                            {
                                CTrip objctrip = new CTrip();
                                objctrip = (CTrip)obj2;
                                tyreid = dbmis.Transaction_Tyre(objvehconfig.Tyrebrand, objvehconfig.Tyrewidth, objvehconfig.Tyresize, objvehconfig.Tyrematerial, objvehconfig.Tyrerollingresistance, objvehconfig.Tyremodel, objvehconfig.Tyretype);
                                propellentid = dbmis.Transaction_Propellent(objvehconfig.Propellenttypeid, objvehconfig.Propellentoctane, objvehconfig.Propellentbrand);
                                //     propellentid = dbmis.Transaction_Propellent(objvehconfig.Propellenttype, objvehconfig.Propellentoctane, objvehconfig.Propellentbrand);
                                vehicleid = dbmis.Transaction_Vehicle(objvehconfig.Vehicletypeid, objvehconfig.Vehiclemodel, objvehconfig.Vehiclemake, objvehconfig.Vehiclecapacity, objvehconfig.Vehiclecapacity);

                                configurationid = dbmis.Transaction_VehicleConfiguration(tyreid, propellentid, vehicleid);
                                dbmis.Transaction_VehicleOwnerShip(userid, vehicleid);

                                objctrip.ConfigurationID = configurationid;
                                //add to database
                                dbmis.Transaction_Trip(objctrip);

                                //delete from localdatabase
                                dbvc.removeTrip(objctrip.TripID);
                            }
                        }
                        MessageBox.Show("Synchronisation done");
                    }



                    //for each trip, add to central database
                    //if add successful, delete from local


                }


            }

        }

        private void endingLayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {

            //loading for first time
            if (!ConnectionExists())
            {
                btnSync.IsEnabled = false;
                btnSync.Content = "No Connection";
            }


        }

        private void btnConfigure_Click(object sender, RoutedEventArgs e)
        {

        }

    }

}
