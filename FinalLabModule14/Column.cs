using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalLabModule14
{
    public class Column
    {
        public int ColNum { get; private set; }
        public int Height { get; private set; }

        public Column(int colNum, int height)
        {
            ColNum = colNum;
            Height = height;
        }
    }
}
