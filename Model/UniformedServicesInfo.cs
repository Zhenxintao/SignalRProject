using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSignalR.Model
{
    public class UniformedServicesInfo
    {
        public int Id { get; set; }
        /// <summary>
        /// 服务名称
        /// </summary>
        public string ServiceName { get; set; }
        /// <summary>
        /// 详细内容
        /// </summary>
        public string ServiceContent { get; set; }
        /// <summary>
        /// 请求开始时间
        /// </summary>
        public string RequestStartDate { get; set; }
        /// <summary>
        /// 请求结束时间
        /// </summary>
        public string RequestEndDate { get; set; }
        /// <summary>
        /// 相应时长
        /// </summary>
        public int CorrespondingTime { get; set; }
        /// <summary>
        /// 服务Id
        /// </summary>
        public int ServiceId { get; set; }
        /// <summary>
        /// 展示状态 true/false
        /// </summary>
        public bool ShowStatus { get; set; }
    }
}
