using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Worker.Application
{
    public interface IWorkerService
    {
        public Task<string> GetMessage(string message);
    }
}
