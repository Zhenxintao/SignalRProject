using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using ProjectSignalR.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSignalR.SignalR
{
    [EnableCors("any")]
    public class ChatHub:Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("UniformedUpdate", user, message);
        }

        //定于一个通讯管道，用来管理我们和客户端的连接
        //1、客户端调用 GetLatestCount，就像订阅
        public async Task GetLatestCount(string random)
        {
            string json = JsonConvert.SerializeObject(new UniformedServiceResponse() { IndoorSystem = 123 });
            //2、服务端主动向客户端发送数据，名字千万不能错
            await Clients.All.SendAsync("UniformedUpdate", json);

            //3、客户端再通过 ReceiveUpdate ，来接收

        }
    }
}
