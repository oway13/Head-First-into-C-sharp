using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HideAndSeekCh7
{
    class Room : Location
    {
        public Room(string name, string Decoration) : base(name)
        {
            this.decoration = Decoration;
        }

        private string decoration;
        public string Decoration
        {
            get { return decoration; }
        }

        public override string Description
        {
            get
            {
                string description = base.Description;
                description += "You see " + Decoration + " here.";
                return description;
            }
        }
    }

}
