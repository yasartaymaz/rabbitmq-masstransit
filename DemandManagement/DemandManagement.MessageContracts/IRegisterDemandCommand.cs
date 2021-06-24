using System;
using System.Collections.Generic;
using System.Text;

namespace DemandManagement.MessageContracts
{
    public interface IRegisterDemandCommand
    {
        public string Subject { get; set; }
        public string Description { get; set; }
    }
}
