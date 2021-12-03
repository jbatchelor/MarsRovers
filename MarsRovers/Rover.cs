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

        private int _XPosition
        { get; set; }
        
        private int _YPosition
        { get; set; }

        private string? _Facing
        { get; set; }

        private SearchGrid _searchGrid;

        public Rover(SearchGrid sg, string[] arrRoverCoords)
        {
            _searchGrid = sg;
            bool xValid = int.TryParse(arrRoverCoords[0], out int x);
            bool yValid = int.TryParse(arrRoverCoords[1], out int y);
            // If valid positions are not provided, default to 0
            _XPosition = xValid ? x : 0;
            _YPosition = yValid ? y : 0;
            // If a valid facing is not specified, default to 'N'
            _Facing = arrRoverCoords.Length < 3 ? "N" : arrRoverCoords[2];
        }

        public string GetLocation => $"{_XPosition} {_YPosition} {_Facing}";

        public void Turn(string direction)
        {
            // Simply find the current Facing's position in the _compassPoints array
            int currFacingIndex = Array.IndexOf(_compassPoints, _Facing);

            switch (direction)
            {
                // then, based on L or R, increment or decrement the facing, looping
                // if you reach the beginning or end of the array
                case "L":
                    _Facing = currFacingIndex > 0 ? _compassPoints[currFacingIndex-1] : _compassPoints.Last();
                    break;
                case "R":
                    _Facing = currFacingIndex == _compassPoints.Length - 1 ? _compassPoints.First() : _compassPoints[currFacingIndex+1];
                    break;
            }
        }

        public void Move(int distance = 1)
        {
            // It was not specified, but I created a default distance
            // param of 1, in case in the future there would be syntax for
            // implementing multiple forward-moves.

            // Nothing will be accepted except N,E,S,W in this scheme
            switch(_Facing)
            {
                case "N":
                    _YPosition = _YPosition < _searchGrid.ySize ? _YPosition + distance : _searchGrid.ySize;
                    break;
                case "E":
                    _XPosition = _XPosition < _searchGrid.xSize ? _XPosition + distance : _searchGrid.xSize;
                    break;
                case "S":
                    _YPosition = _YPosition > 0 ? _YPosition - distance : 0;
                    break;
                case "W":
                    _XPosition = _XPosition > 0 ? _XPosition - distance : 0;
                    break;
            }
        }

        public void ReceiveCommands(char[] commands)
        {
            foreach (char cmd in commands)
            {
                // I am assuming here that we do not want
                // junk commands so there is no "default"
                switch (cmd)
                {
                    case 'L':
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
