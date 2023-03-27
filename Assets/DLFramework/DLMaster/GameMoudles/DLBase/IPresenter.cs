namespace DLBASE
{
    public abstract class IPresenter<T>where T:new ()
    {
        private static T Ins;

        public static T Instance
        {
            get
            {
                if (Ins == null)
                {
                    Ins = new T();
                }

                return Ins;
            }
        }
        public abstract void OnInit();
    }
}