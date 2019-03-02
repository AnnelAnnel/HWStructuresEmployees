using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company
{
    public enum position { topmanager, manager, worker};
    public enum gender { female, male};
    public interface IWorker
    {
        string name { get; set; }
        double salary { get; set; }
        position position { get; set; }
        gender gender { get; set; }
        DateTime startDate { get; set; }
        void printInfo();
    }
}

