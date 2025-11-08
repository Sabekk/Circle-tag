namespace Gameplay.Management.Inputs
{
    public class InputManager : GameplayManager<InputManager>
    {
        #region VARIABLES

        static InputBinds _controll;

        #endregion

        #region PROPERTIES

        public HotkeysInputs HotkeysInputs { get; private set; }
        public CharacterInputs CharacterInputs { get; private set; }

        public static InputBinds Input
        {
            get
            {
                if (_controll == null)
                    _controll = new InputBinds();
                return _controll;
            }
        }


        #endregion

        #region UNITY_METHODS

        private void OnEnable() => Input.Enable();

        private void OnDisable() => Input.Disable();

        #endregion

        #region METHODS

        public override void Initialize()
        {
            base.Initialize();
            HotkeysInputs = new(Input);
            CharacterInputs = new(Input);
        }

        public override void LateInitialize()
        {
            base.LateInitialize();
            RefreshInputs();
        }

        protected override void AttachEvents()
        {
        }

        protected override void DetachEvents()
        {

        }

        private void RefreshInputs()
        {
            CharacterInputs.Enable();
            HotkeysInputs.Enable();
        }

        #endregion
    }
}
