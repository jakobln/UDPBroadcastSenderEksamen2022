using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDPBroadcastSender
{
    public class WindData
    {

        private static readonly string[] Directions = { "N", "NE", "E", "SE", "S", "SW", "W", "NW" };
        private int _direction = 0;
        private int _speed = 6;
        private readonly Random _ran = new Random();

        public string NextDirection()
        {
            _direction += _ran.Next(-1, 2);
            if (_direction == -1) _direction = 7;
            if (_direction == 8) _direction = 0;
            return Directions[_direction];
        }

        public int NextSpeed()
        {
            _speed += _ran.Next(-1, 2);
            if (_speed < 0) _speed = 0;
            return _speed;
        }

        public WindData(string direction, int speed)
        {
            Direction = direction;
            Speed = speed;
        }

        public WindData()
        {
        }

        public string Direction
        {
            get => NextDirection();
            set { }
        }

        public int Speed
        {
            get => NextSpeed();
            set { }
        }

    }
}
