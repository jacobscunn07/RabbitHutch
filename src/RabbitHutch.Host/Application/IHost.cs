using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitHutch.Host.Application
{
    public interface IHost
    {
        void Start();
        void Stop();
    }
}
