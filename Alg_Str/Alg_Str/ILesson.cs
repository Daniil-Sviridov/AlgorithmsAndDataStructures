using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg_Str
{
    /// <summary>
    /// Общий интерфейс занятия
    /// </summary>
    interface ILesson
    {
        /// <summary>
        /// 
        /// </summary>
        string Name { get; }
        /// <summary>
        /// 
        /// </summary>
        string Discription { get; }

        /// <summary>
        /// 
        /// </summary>
        public void Demo();
    }
}
