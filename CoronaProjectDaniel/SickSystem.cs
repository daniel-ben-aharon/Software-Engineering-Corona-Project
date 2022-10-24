using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaProjectDaniel
{
    /// <summary>
    /// System that tracks sick people.
    /// </summary>
    class SickSystem
    {
        // singleton
        private static SickSystem _sys = null;
        /// <summary>
        /// List of people registered in the system (only functions visible).
        /// </summary>
        public IPersonList List { get; private set; }
        /// <summary>
        /// The single instance of the sick-tracking system.
        /// </summary>
        public static SickSystem System
        {
            get
            {
                if (_sys == null)
                    _sys = new SickSystem();
                return _sys;
            }
        }

        // singleton initialize
        private SickSystem()
        {
            List = new PersonList();
        }
    }
}
