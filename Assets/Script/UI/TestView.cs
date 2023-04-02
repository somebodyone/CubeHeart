using System;
using DLBASE;
using FairyGUI;

namespace DLAM
{
    public class TestView:DLDialog
    {
        private GList _list;
        private string _url = "ui://TestView/testbtn";  
        public override void OnInit()
        {
            SetContentWith("TestView","TestView");
        }

        protected override void InitCompent()
        {
            _list = contentPlane.GetChild("_list").asList;
        }

        protected override void InitAddlistioner()
        {
            for (int i = 0; i < Res.Levels.Length; i++)
            {
                CreatBtn("打开第" + i +"关", i,(level) =>
                {
                    GamePresenter.Instance.Level = level;
                    GameManager.Instance.ResetGame();
                    GameManager.Instance.LoadGame();
                    GameManager.Instance.LoadPlayer();
                    GameManager.Instance.StartGame();
                });
            }
        }

        public void CreatBtn(string name,int targetlevel,Action<int> callback)
        {
            int level = targetlevel;
            GButton btn = UIPackage.CreateObjectFromURL(_url).asButton;
            btn.title = name;
            btn.onClick.Add(() =>
            {
                callback?.Invoke(level);
            });
            _list.AddChild(btn);
        }
    }
}