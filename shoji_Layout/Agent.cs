using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shoji_Layout
{
    class Agent
    {
        public class AgentBase
        {
            ///<summary>
            ///X座標
            /// </summary>
            public double X { get; set; }

            ///<summary>
            ///X座標
            /// </summary>
            public double Y { get; set; }

            ///<summary>
            ///X座標
            /// </summary>
            public double Radius { get; set; } = 25.0;

            ///<summary>
            ///X座標
            /// </summary>
            public double Speed { get; set; } = 15.0;

            ///<summary>
            ///X座標
            /// </summary>
            public double RoujinSpeed { get; set; } = 8.0;

            public AgentBase(double x, double y)
            {
                X = x;
                Y = y;
            }

        }
    }
}
