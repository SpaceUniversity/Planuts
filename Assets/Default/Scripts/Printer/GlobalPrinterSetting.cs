using System.Linq;
using UnityEngine;

namespace Default.Scripts.Printer
{

    [CreateAssetMenu(fileName = "new GlobalPrinterSetting", menuName = "Printer/Global Printer Setting")]
    public class GlobalPrinterSetting : Util.ScriptableSingleton<GlobalPrinterSetting>
    {
        public PrintStyle defaultTextAnimationStyle;

        public PrintStyle skipTextAnimationStyle;

        public PrintStyle[] dialogStyles;

        public PrintStyle FindDialogStyle(string name)
        {
            return dialogStyles.ToList().Find((x) => x.name == name);
        }
    }
}