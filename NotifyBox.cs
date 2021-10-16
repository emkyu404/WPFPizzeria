using System;
using System.Collections.Generic;
using System.Text;

namespace Projet_Pizzaria
{
    class NotifyBox
    {
        private List<String> messageBox;

        public NotifyBox()
        {
            messageBox = new List<String>();
        }

        public List<String> getMessageBox()
        {
            return messageBox;
        }

        public void addMessage(string s)
        {
            messageBox.Add(s);
        }
    }
}
