using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mackoy.Bvets;

namespace Mackoy.Bvets
{
    class GIPI : IInputDevice
    {
        public event InputEventHandler LeverMoved;
        public event InputEventHandler KeyDown;
        public event InputEventHandler KeyUp;

        public void Configure(System.Windows.Forms.IWin32Window owner)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Load(string settingsPath)
        {
            throw new NotImplementedException();
        }

        public void SetAxisRanges(int[][] ranges)
        {
            throw new NotImplementedException();
        }

        public void Tick()
        {
            throw new NotImplementedException();
        }
    }
}
