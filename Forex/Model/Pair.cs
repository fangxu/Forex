using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Forex.Model
{
    /*
<Rate Symbol="EURUSD">
    <Bid>1.31009</Bid>
    <Ask>1.31037</Ask>
    <High>1.31257</High>
    <Low>1.30505</Low>
    <Direction>-1</Direction>
    <Last>21:13:41</Last>
</Rate>
     */
    class Pair
    {
        private String symbol;
        private float bid;
        private float ask;
        private float high;
        private float low;
        private int direction;
        private DateTime last;

        public System.DateTime Last
        {
            get { return last; }
            set { last = value; }
        }
        public int Direction
        {
            get { return direction; }
            set { direction = value; }
        }
        public float Low
        {
            get { return low; }
            set { low = value; }
        }
        public float High
        {
            get { return high; }
            set { high = value; }
        }
        public float Ask
        {
            get { return ask; }
            set { ask = value; }
        }
        public float Bid
        {
            get { return bid; }
            set { bid = value; }
        }
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
