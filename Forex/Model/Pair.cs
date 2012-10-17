using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Forex.Model
{
    class Pair
    {
        private String symbol;
        private String name;
        private float current;
        private float up;
        private float down;
        private float opening;
        private float highest;
        private float lowest;
        private float amplitude;
        private float buy;
        private float sell;
        private DateTime time;

        public Pair()
        {
            buy = sell = 0;
            time = DateTime.Now;
        }


        public System.String Symbol
        {
            get { return symbol; }
            set { symbol = value; }
        }
        public System.String Name
        {
            get { return name; }
            set { name = value; }
        }
        public float Current
        {
            get { return current; }
            set { current = value; }
        }
        public float Up
        {
            get { return up; }
            set { up = value; }
        }
        public float Down
        {
            get { return down; }
            set { down = value; }
        }
        public float Opening
        {
            get { return opening; }
            set { opening = value; }
        }
        public float Highest
        {
            get { return highest; }
            set { highest = value; }
        }
        public float Lowest
        {
            get { return lowest; }
            set { lowest = value; }
        }
        public float Amplitude
        {
            get { return amplitude; }
            set { amplitude = value; }
        }
        public float Buy
        {
            get { return buy; }
            set { buy = value; }
        }
        public float Sell
        {
            get { return sell; }
            set { sell = value; }
        }
        public System.DateTime Time
        {
            get { return time; }
            set { time = value; }
        }
    }
}
