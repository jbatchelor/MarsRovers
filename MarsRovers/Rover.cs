using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRovers
{
    internal class Rover
    {
        private readonly string[] _compassPoints = { "N", "E", "S", "W" };

        private int XPosition
        { get; set; }
        
        private int YPosition
        { get; set; }

        private string? Facing
        { get; set; }

        private SearchGrid _searchGrid;

        public Rover(SearchGrid sg, string[] arrRoverCoords)
        {
            _searchGrid = sg;
            SetLocation(int.Parse(arrRoverCoords[0]), int.Parse(arrRoverCoords[1]), arrRoverCoords[2]);
        }

        public string GetLocation => $"{XPosition} {YPosition} {Facing}";

        public void SetLocation(int x, int y, string? facing = "N")
        {
            XPosition = x;
            YPosition = y;
            Facing = facing;
        }

        public void Turn(string direction)
        {
            int currFacingIndex = Array.IndexOf(_compassPoints, Facing);

            switch (direction)
            {
                case "L":
                    Facing = currFacingIndex > 0 ? _compassPoints[currFacingIndex-1] : _compassPoints.Last();
                    break;
                case "R":
                    Facing = currFacingIndex == _compassPoints.Length - 1 ? _compassPoints.First() : _compassPoints[currFacingIndex+1];
                    break;
            }
        }

        public void Move(int distance = 1)
        {
            switch(Facing)
            {
                case "N":
                    YPosition = YPosition < _searchGrid.ySize ? YPosition + distance : _searchGrid.ySize;
                    break;
                case "E":
                    XPosition = XPosition < _searchGrid.xSize ? XPosition + distance : _searchGrid.xSize;
                    break;
                case "S":
                    YPosition = YPosition > 0 ? YPosition - distance : 0;
                    break;
                case "W":
                    XPosition = XPosition > 0 ? XPosition - distance : 0;
                    break;
            }
        }

        public void RecieveCommands(char[] commands)
        {
            foreach (char cmd in commands)
            {
                switch (cmd)
                {
                    case 'L':
                        Turn(cmd.ToString());
                        break;
                    case 'R':
                        Turn(cmd.ToString());
                        break;
                    case 'M':
                        Move();
                        break;
                }
            }
        }
    }
}
