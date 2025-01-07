using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binding.ViewModel
{
    public class clsVMLocator
    {


        public clsPersonenViewModel PersonenViewModel
        {
            get
            {
                return new clsPersonenViewModel();
            }
        }


    }
}
