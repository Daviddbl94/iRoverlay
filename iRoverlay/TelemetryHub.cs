namespace iRoverlay
{
    public class TelemetryHub
    {
        public async Task SendTelemetryData(TelemetryData telemetryData)
        {
            // Aquí procesa los datos de telemetría recibidos
            // y envía la información actualizada a todos los clientes
            await Clients.All.SendAsync("ReceiveTelemetryData", telemetryData);
        }
    }
}
