using DLBASE;
using FairyGUI;

namespace DLAM
{
    public class TestView:DLDialog
    {
        private GList _list;
        private string _url;  
        public override void OnInit()
        {
            SetContentWith("TestView","TestView");
        }

        protected override void InitCompent()
        {
            
        }

        protected override void InitAddlistioner()
        {
            
        }
    }
}