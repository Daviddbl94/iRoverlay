using System;

public class Class1
{
	public Class1()
	{

    public SdkWrapper wrapper;

    public Boolean estadoTelemetria;

    public string GameData_CarIdX { get; private set; }

    //Variables GameData
    #region 
    public string GameData_Track_Name { get; private set; }
    public string GameData_Track_Length { get; private set; }
    public string GameData_Track_Longitud { get; private set; }
    public string GameData_Track_Num_Turns { get; private set; }
    public string GameData_Track_Surface_Temp { get; private set; }
    public string GameData_Track_Air_Temp { get; private set; }
    public string GameData_Track_Air_Pressure { get; private set; }
    public float GameData_Track_Wind_Vel { get; private set; }
    public float GameData_Track_Wind_Dir { get; private set; }
    public string GameData_Track_Fog_Level { get; private set; }
    public string GameData_Session_Laps { get; private set; }
    public string GameData_Race_TotalLaps { get; private set; }
    public bool OnPit { get; private set; }
    public float LapPercentage { get; private set; }
    public float Speed { get; private set; }
    public int Gear { get; private set; }
    public float CurrentLap { get; private set; }
    public int DriverPosition { get; private set; }
    public int GameData_CurrentLap { get; private set; }
    public float TrackTemp { get; private set; }
    public float AirTemp { get; private set; }
    public float FuelL { get; private set; }
    public float OilTemp { get; private set; }
    public float OilPress { get; private set; }
    public float OilLevel { get; private set; }
    public float FuelPercentage { get; private set; }
    public float BestLapTime { get; private set; }
    public float LastLapTime { get; private set; }
    public float CurrentLapTime { get; private set; }
    public int LapBestLap { get; private set; }
    public int SessionLapsRemain { get; private set; }
    public float GameData_LFrontL_Carcass { get; private set; }
    public float GameData_LFrontM_Carcass { get; private set; }
    public float GameData_LFrontR_Carcass { get; private set; }
    public float GameData_RFrontL_Carcass { get; private set; }
    public float GameData_RFrontM_Carcass { get; private set; }
    public float GameData_RFrontR_Carcass { get; private set; }
    public float GameData_LRearL_Carcass { get; private set; }
    public float GameData_LRearM_Carcass { get; private set; }
    public float GameData_LRearR_Carcass { get; private set; }
    public float GameData_RRearL_Carcass { get; private set; }
    public float GameData_RRearM_Carcass { get; private set; }
    public float GameData_RRearR_Carcass { get; private set; }
    public float GameData_LFrontL_Surface { get; private set; }
    public float GameData_LFrontM_Surface { get; private set; }
    public float GameData_LFrontR_Surface { get; private set; }
    public float GameData_RFrontL_Surface { get; private set; }
    public float GameData_RFrontM_Surface { get; private set; }
    public float GameData_RFrontR_Surface { get; private set; }
    public float GameData_LRearL_Surface { get; private set; }
    public float GameData_LRearM_Surface { get; private set; }
    public float GameData_LRearR_Surface { get; private set; }
    public float GameData_RRearL_Surface { get; private set; }
    public float GameData_RRearM_Surface { get; private set; }
    public float GameData_RRearR_Surface { get; private set; }

    // Tread percentage
    public float GameData_LFrontL_Percentage { get; private set; }
    public float GameData_LFrontM_Percentage { get; private set; }
    public float GameData_LFrontR_Percentage { get; private set; }
    public float GameData_RFrontL_Percentage { get; private set; }
    public float GameData_RFrontM_Percentage { get; private set; }
    public float GameData_RFrontR_Percentage { get; private set; }
    public float GameData_LRearL_Percentage { get; private set; }
    public float GameData_LRearM_Percentage { get; private set; }
    public float GameData_LRearR_Percentage { get; private set; }
    public float GameData_RRearL_Percentage { get; private set; }
    public float GameData_RRearM_Percentage { get; private set; }
    public float GameData_RRearR_Percentage { get; private set; }

    #endregion

    SessionFlag GameData_Flag;

    public Telemetria()
    {

    }

    public void Start()
    {
        try
        {
            // Create instance
            wrapper = new SdkWrapper();

            // Set some properties
            wrapper.TelemetryUpdateFrequency = 1;

            // Listen to events
            wrapper.TelemetryUpdated += OnTelemetryUpdated;
            wrapper.SessionInfoUpdated += OnSessionInfoUpdated;

            // Start it!
            wrapper.Start();

            updateWrapperState();
        }
        catch (Exception ex)
        {

        }
    }

    public void ApagarTelemetria()
    {
        try
        {
            wrapper.Stop();

            updateWrapperState();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Mensaje error al desconectar telemetria: " + ex);
        }
    }

    // Metodo para actualizar estado de booleano estadoTelemetria.
    private void updateWrapperState()
    {
        if (wrapper.IsConnected)
        {
            estadoTelemetria = true;
        }
        else
        {
            estadoTelemetria = false;
        }
    }

    public bool GetWrapperState()
    {
        return estadoTelemetria;
    }

    private void OnSessionInfoUpdated(object sender, SdkWrapper.SessionInfoUpdatedEventArgs e)
    {
        Actualizar_Datos_Sesion(e);
    }
    private void OnTelemetryUpdated(object sender, SdkWrapper.TelemetryUpdatedEventArgs e)
    {
        Actualizar_Datos_Piloto();
    }

    private void Actualizar_Datos_Piloto()
    {
        try
        {
            /*
            LapPercentage = wrapper.GetTelemetryValue<float>("LapDistPct").Value;


            // SESIÓN
            CurrentLap = wrapper.GetTelemetryValue<int>("Lap").Value;
            BestLapTime = wrapper.GetTelemetryValue<float>("LapBestLapTime").Value;
            LastLapTime = wrapper.GetTelemetryValue<float>("LapLastLapTime").Value;
            CurrentLapTime = wrapper.GetTelemetryValue<float>("LapCurrentLapTime").Value;
            DriverPosition = wrapper.GetTelemetryValue<int>("PlayerCarClassPosition").Value;
            BestLapTime = wrapper.GetTelemetryValue<float>("LapBestLapTime").Value;
            LastLapTime = wrapper.GetTelemetryValue<float>("LapLastLapTime").Value;
            CurrentLapTime = wrapper.GetTelemetryValue<float>("LapCurrentLapTime").Value;
            LapBestLap = wrapper.GetTelemetryValue<int>("LapBestLap").Value;
            SessionLapsRemain = wrapper.GetTelemetryValue<int>("SessionLapsRemain").Value;

            // OIL
            OilTemp = wrapper.GetTelemetryValue<float>("OilTemp").Value;
            OilPress = wrapper.GetTelemetryValue<float>("OilPress").Value;
            OilLevel = wrapper.GetTelemetryValue<float>("OilLevel").Value;
            // CIRCUITO
            GameData_Track_Wind_Dir = wrapper.GetTelemetryValue<float>("WindDir").Value;
            GameData_Track_Wind_Vel = wrapper.GetTelemetryValue<float>("WindVel").Value;
            TrackTemp = wrapper.GetTelemetryValue<float>("TrackTempCrew").Value;
            AirTemp = wrapper.GetTelemetryValue<float>("AirTemp").Value;


            // PLAYER CAR
            Speed = wrapper.GetTelemetryValue<float>("Speed").Value;
            Gear = wrapper.GetTelemetryValue<int>("Gear").Value;
            FuelL = wrapper.GetTelemetryValue<float>("FuelLevel").Value;
            FuelPercentage = wrapper.GetTelemetryValue<float>("FuelLevelPct").Value;
            OnPit = wrapper.GetTelemetryValue<bool>("OnPitRoad").Value;

            // TYRES
            // Carcass

            // LEFT FRONT
            GameData_LFrontL_Carcass = wrapper.GetTelemetryValue<float>("LFtempCL").Value;
            GameData_LFrontM_Carcass = wrapper.GetTelemetryValue<float>("LFtempCM").Value;
            GameData_LFrontR_Carcass = wrapper.GetTelemetryValue<float>("LFtempCR").Value;

            // RIGHT FRONT
            GameData_RFrontL_Carcass = wrapper.GetTelemetryValue<float>("RFtempCL").Value;
            GameData_RFrontM_Carcass = wrapper.GetTelemetryValue<float>("RFtempCM").Value;
            GameData_RFrontR_Carcass = wrapper.GetTelemetryValue<float>("RFtempCR").Value;

            // LEFT REAR
            GameData_LRearL_Carcass = wrapper.GetTelemetryValue<float>("LRtempCL").Value;
            GameData_LRearM_Carcass = wrapper.GetTelemetryValue<float>("LRtempCM").Value;
            GameData_LRearR_Carcass = wrapper.GetTelemetryValue<float>("LRtempCR").Value;

            // RIGHT REAR
            GameData_RRearL_Carcass = wrapper.GetTelemetryValue<float>("RRtempCL").Value;
            GameData_RRearM_Carcass = wrapper.GetTelemetryValue<float>("RRtempCM").Value;
            GameData_RRearR_Carcass = wrapper.GetTelemetryValue<float>("RRtempCR").Value;

            //Surface

            // LEFT FRONT
            GameData_LFrontL_Surface = wrapper.GetTelemetryValue<float>("LFtempL").Value;
            GameData_LFrontM_Surface = wrapper.GetTelemetryValue<float>("LFtempM").Value;
            GameData_LFrontR_Surface = wrapper.GetTelemetryValue<float>("LFtempR").Value;

            // RIGHT FRONT
            GameData_RFrontL_Surface = wrapper.GetTelemetryValue<float>("RFtempL").Value;
            GameData_RFrontM_Surface = wrapper.GetTelemetryValue<float>("RFtempM").Value;
            GameData_RFrontR_Surface = wrapper.GetTelemetryValue<float>("RFtempR").Value;

            // LEFT REAR
            GameData_LRearL_Surface = wrapper.GetTelemetryValue<float>("LRtempL").Value;
            GameData_LRearM_Surface = wrapper.GetTelemetryValue<float>("LRtempM").Value;
            GameData_LRearR_Surface = wrapper.GetTelemetryValue<float>("LRtempR").Value;

            // RIGHT REAR
            GameData_RRearL_Surface = wrapper.GetTelemetryValue<float>("RRtempL").Value;
            GameData_RRearM_Surface = wrapper.GetTelemetryValue<float>("RRtempM").Value;
            GameData_RRearR_Surface = wrapper.GetTelemetryValue<float>("RRtempR").Value;

            // Tread percentage

            // LEFT FRONT
            GameData_LFrontL_Percentage = wrapper.GetTelemetryValue<float>("LFwearL").Value;
            GameData_LFrontM_Percentage = wrapper.GetTelemetryValue<float>("LFwearM").Value;
            GameData_LFrontR_Percentage = wrapper.GetTelemetryValue<float>("LFwearR").Value;

            // RIGHT FRONT
            GameData_RFrontL_Percentage = wrapper.GetTelemetryValue<float>("RFwearL").Value;
            GameData_RFrontM_Percentage = wrapper.GetTelemetryValue<float>("RFwearM").Value;
            GameData_RFrontR_Percentage = wrapper.GetTelemetryValue<float>("RFwearR").Value;

            // LEFT REAR
            GameData_LRearL_Percentage = wrapper.GetTelemetryValue<float>("LRwearL").Value;
            GameData_LRearM_Percentage = wrapper.GetTelemetryValue<float>("LRwearM").Value;
            GameData_LRearR_Percentage = wrapper.GetTelemetryValue<float>("LRwearR").Value;

            // RIGHT REAR
            GameData_RRearL_Percentage = wrapper.GetTelemetryValue<float>("RRwearL").Value;
            GameData_RRearM_Percentage = wrapper.GetTelemetryValue<float>("RRwearM").Value;
            GameData_RRearR_Percentage = wrapper.GetTelemetryValue<float>("RRwearR").Value;
            */
            // FLAG


            Console.WriteLine("OBTENIDOS DATOS SESION");
        }
        catch (Exception)
        {
            Console.WriteLine("FALLO PILOTO");
            throw;
        }
    }


    private void Actualizar_Datos_Sesion(SdkWrapper.SessionInfoUpdatedEventArgs e)
    {
        try
        {
            // GameData_CarIdX = e.SessionInfo["SessionInfo"]["Sessions"]["ResultsPositions"]["CarIdx"].Value;



            GameData_Track_Name = e.SessionInfo["WeekendInfo"]["TrackName"].Value;
            GameData_Track_Length = e.SessionInfo["WeekendInfo"]["TrackLength"].Value;
            GameData_Track_Longitud = e.SessionInfo["WeekendInfo"]["TrackLongitude"].Value;

            //GameData_Track_Surface_Temp = e.SessionInfo["WeekendInfo"]["TrackSurfaceTemp"].Value;

            GameData_Track_Air_Temp = e.SessionInfo["WeekendInfo"]["TrackAirTemp"].Value;

            GameData_Track_Fog_Level = e.SessionInfo["WeekendInfo"]["TrackFogLevel"].Value;


            /*
             * GameData_Session_Laps = e.SessionInfo["Sessions"]["SessionLaps"].Value;
             * 
                GameData_Track_Num_Turns = e.SessionInfo["WeekendInfo"]["TrackNumTurns"].Value;
                GameData_Track_Surface_Temp = e.SessionInfo["WeekendInfo"]["TrackSurfaceTemp"].Value;

                GameData_Track_Air_Temp = e.SessionInfo["WeekendInfo"]["TrackAirTemp"].Value;
                GameData_Track_Air_Pressure = e.SessionInfo["WeekendInfo"]["TrackAirPressure"].Value;


                GameData_Track_Fog_Level = e.SessionInfo["WeekendInfo"]["TrackFogLevel"].Value;

                  */

            //  GameData_Race_TotalLaps = e.SessionInfo["DriverInfo"]["Drivers"][GameData_CarIdX]["IRating"].Value;



            // GameData_ = e.SessionInfo["WeekendInfo"][""].Value;
        }
        catch (Exception)
        {
            Console.WriteLine("FALLO SESION");
            throw;
        }

    }
}
}
