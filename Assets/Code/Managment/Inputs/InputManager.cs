using Gameplay.Management.Core;

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

        private GameplayCoreManager GameplayCoreManager => GameplayCoreManager.Instance;

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
            if (GameplayCoreManager)
            {
                GameplayCoreManager.OnGameStateChanged += HandleGameStateChanged;
            }
        }

        protected override void DetachEvents()
        {

            if (GameplayCoreManager)
            {
                GameplayCoreManager.OnGameStateChanged -= HandleGameStateChanged;
            }
        }

        private void RefreshInputs()
        {
            switch (GameplayCoreManager.GameState)
            {
                case GameStateType.MAIN_MENU:
                    CharacterInputs.Disable();
                    HotkeysInputs.Disable();
                    break;
                case GameStateType.GAMEPLAY:
                    CharacterInputs.Enable();
                    HotkeysInputs.Enable();
                    break;
                case GameStateType.PAUSE:
                    CharacterInputs.Disable();
                    HotkeysInputs.Enable();
                    break;
                default:
                    break;
            }
        }

        #region HANDLERS

        private void HandleGameStateChanged(GameStateType gameState)
        {
            RefreshInputs();
        }

        #endregion

        #endregion
    }
}
