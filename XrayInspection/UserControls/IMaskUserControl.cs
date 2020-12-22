using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XrayInspection.UserControls
{
    public interface IMaskUserControl
    {
        bool ucMandatory        { get; set; }
        string ucLabelText        { get; set; }
        bool ucMandatoryCheck { get; }
    }
}
