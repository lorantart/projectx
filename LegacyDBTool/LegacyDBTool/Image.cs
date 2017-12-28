using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyDBTool
{
    public class Image
    {
        public string id;
        public int stars;

        public override string ToString()
        {
            return id + ":" + stars;
        }
    }
}
