using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HideAndSeekCh7
{
    class OutsideWithHidingPlace: Outside, IHidingPlace
    {

        public OutsideWithHidingPlace(String Name, bool Hot, String HidingPlace):base(Name, Hot)
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
