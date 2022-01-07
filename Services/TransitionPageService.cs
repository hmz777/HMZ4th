using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMZ4th.Services
{
    public class TransitionPageService
    {
        public event Action<bool> Transition;

        public void DoTransition(bool state) { Transition?.Invoke(state); }
    }
}
