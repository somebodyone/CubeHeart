
using DLBASE;

namespace DLAM
{
    public class TouchPresenter:DLSingleton<TouchPresenter>
    {
        private MoveDir _movedir = MoveDir.Stop;
        private bool _openskill;

        public bool OpenSkill
        {
            get => _openskill;
            set
            {
                _openskill = value;
            }
        }
        
        public MoveDir MoveDir
        {
            get => _movedir;
            set
            {
                _movedir = value;
            }
        }
    }
}
