using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tangy_Models
{
    public class Demo_AccountHead
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public IEnumerable<Demo_AccountHead> AccountHeads { get; set; }

    }
}
