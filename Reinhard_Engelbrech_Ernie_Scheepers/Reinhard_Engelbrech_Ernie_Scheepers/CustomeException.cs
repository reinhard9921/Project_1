using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reinhard_Engelbrech_Ernie_Scheepers
{
    class CustomeException : Exception
    {
        public CustomeException(string messages) : base(messages)
        {
            System.Windows.Forms.MessageBox.Show(messages, "Exception thrwon", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
        }
    }
}
