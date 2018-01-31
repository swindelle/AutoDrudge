using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drudge
{
   public enum FreeTimeAction { Shop, Organise };

   public class FreeTime : AllocatableAction
    {

        private static readonly int Target = 6;
        public FreeTime() : base(Target)
        {

        }

        public override int BalanceAfterTurn
        {
            get { return 0; }
        }

        public FreeTimeAction FreeTimeUse { get; set; }
    }
}
