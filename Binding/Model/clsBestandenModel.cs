using Binding.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binding.Model
{
    public class clsBestandenModel : clsCommonModelPropertiesBase
    {
        private string _bestandsNaam;
        public string BestandsNaam
        {
            get { return _bestandsNaam; }
            set
            {
                _bestandsNaam = value;
                OnPropertyChanged();
            }
        }
    }
}
