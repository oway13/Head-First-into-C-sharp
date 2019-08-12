using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HideAndSeekCh7
{
    class Outside : Location
    {
        public Outside(string name, bool Hot) : base(name)
        {
            this.hot = Hot;
        }

        private bool hot;
        public bool Hot
        {
            get { return hot; }
        }

        public override string Description
        {
            get
            {
                string description = base.Description;
                if (Hot)
                    description += "It is very hot here. ";
                return description;
            }
        }
    }
}
