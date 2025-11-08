using UnityEngine;

namespace Gameplay.UI
{
    public class UIViewBase : MonoBehaviour
    {
        #region VARIABLES

        #endregion

        #region PROPERTIES

        protected UIWindowBase Window { get; set; }

        #endregion

        #region METHODS

        public virtual void Initialize(UIWindowBase window)
        {
            Window = window;
        }

        #region UI_ACTIONS

        public void Back()
        {
            Window.ToggleView(this, false);
        }

        #endregion

        #endregion
    }
}