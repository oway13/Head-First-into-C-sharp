using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HideAndSeekCh7
{
    class RoomWithHidingPlace : Room, IHidingPlace
    {
        public RoomWithHidingPlace(String Name, string Decoration, String HidingPlace) : base(Name, Decoration)
        {
            this.hidingPlace = HidingPlace;
        }
        private string hidingPlace;
        public string HidingPlace
        {
            get { return hidingPlace; }
        }

        public override string Description
        {
            get
            {
                return base.Description + "Someone could hide " + hidingPlace + " here.";
            }
        }
    }
}
