using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WormLifeSimulator
{
    public class OutputFileWriter : ILogger
    {
        private string path;
        public StreamWriter _output;

        public OutputFileWriter()
        {
            _output = new StreamWriter(@"C:\Users\kir20\source\repos\WormLifeSimulator\log.txt");
        }

        public void Log(WorldDto data)
        {
            _output.Write("Round " + data.Step);
            _output.Write(" Worms: [");
            foreach (var worm in data.Worms)
            {
                _output.Write(" " + worm.Name + "-" + worm.Life + " (" + worm.X + ", " + worm.Y + "), ");
            }
            _output.Write("], Food: ");
            foreach (var food in data.Foods)
            {
                _output.Write(" (" + food.X + ", " + food.Y + ") ");
            }
            _output.WriteLine();
            _output.Flush();
        }

        public void Dispose()
        {
            //_output.Dispose();
        }
    }
}
