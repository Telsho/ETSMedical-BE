using AuthJWT.Models.Dtos;
using AuthJWT.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthJWT.Hubs
{
    [Authorize]
    public class PatientDataHub : Hub
    {
        
        IConnectionService _connectionService;

        public PatientDataHub(IConnectionService connectionService)
        {
            _connectionService = connectionService;
        }

        public void Login(string name)
        {
            _connectionService.LoginInCallUser(Context.ConnectionId, name);
        }

        public async Task SendData(PatientDataDto data)
        {
            var connectionId = _connectionService.GetInCallUserIdByName(data.DoctorName);
            if (connectionId == null)
                throw new Exception("User is not connected");

            await Clients.Client(connectionId).SendAsync("transferTemperature", data.Temperature);
            await Clients.Client(connectionId).SendAsync("transferHeartbeat", data.Heartbeat);
        }


        public override async Task OnDisconnectedAsync(Exception exception)
        {
            var user = _connectionService.LogoutInCallUser(Context.User.Identity.Name);

            await base.OnDisconnectedAsync(exception);
        }

    }
}
