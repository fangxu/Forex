using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Forex.Model
{
    class TecItem
    {
        DateTime time;
        String name;
        String advice;
        String url;
        public System.String Url
        {
            get { return url; }
            set { url = value; }
        }
        public System.String Advice
        {
            get { return advice; }
            set { advice = value; }
        }
        public System.String Name
        {
            get { return name; }
            set { name = value; }
        }
        public System.DateTime Time
        {
            get { return time; }
            set { time = value; }
        }
    }
}
