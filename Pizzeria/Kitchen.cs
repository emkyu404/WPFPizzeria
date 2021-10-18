using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Pizzaria
{
    public class Kitchen
    {
        private static Kitchen instance = null;

        public Kitchen()
        {
            if(Kitchen.instance == null)
            {
                Kitchen.instance = this;
            }
        }

        public static Kitchen getInstance()
        {
            return instance;
        }

        public async Task prepareOrderAsync(Order od)
        {
            await Task.Run(() => prepareOrder(od));
        }

        public void prepareOrder(Order od)
        {
            foreach (Item i in od.getItems())
            {
                //3 secondes de traitement par items
                Task.Delay(3000).Wait();
            }
            od.isReady();
        }


    }
}
