using DLBASE;
using FairyGUI;

namespace DLAM
{
    public class MainView : DLDialog
    {
        private GButton _start;
        private GButton _test;
        private Controller _controller;
        
        public override void OnInit() 
        {
            SetContentWith("Main","MainView");
        }

        protected override void InitCompent()
        {
            _start = contentPlane.GetChild("_start").asButton;
            _test = contentPlane.GetChild("_testbtn").asButton;
            _controller = contentPlane.GetController("game");
        }

        protected override void InitAddlistioner()
        {
            _test.onClick.Add(() =>
            {
                DLDialogManager.Instance.OpenView<TestView>();
            });
            
            _start.onClick.Add(() =>
            {
                GameManager.Instance.CheckInit();
                GravityPresenter.Instance.ResetGravity();
                GameManager.Instance.ResetGame();
                GameManager.Instance.LoadGame();
                GameManager.Instance.LoadPlayer();
                GameManager.Instance.StartGame();
                _controller.SetSelectedPage("gameing");
            });
        }
    }
}
