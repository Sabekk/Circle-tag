using Gameplay.Management;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.UI
{
    public class UIWindowBase : MonoBehaviour
    {
        #region VARIABLES

        [SerializeField] private UIViewBase _defaultView;

        private List<UIViewBase> _views;
        private List<UIViewBase> _viewsHierarchy;

        #endregion

        #region PROPERTIES

        private UIManager Manager => UIManager.Instance;

        #endregion

        #region UNITY_METHODS

        private void Awake()
        {
            _views = new List<UIViewBase>();
            _viewsHierarchy = new List<UIViewBase>();

            InitializeViews();
        }

        #endregion

        #region METHODS

        public void Initialize()
        {
            ToggleView(_defaultView, true);
        }

        public void CleanUp()
        {
            _viewsHierarchy.Clear();
        }

        public void ToggleView(UIViewBase view, bool state)
        {
            DisableAllViews();
            view.gameObject.SetActive(state);

            if (state)
                _viewsHierarchy.Add(view);
            else
                _viewsHierarchy.Remove(view);

            CloseOrShowLastView();
        }

        private void InitializeViews()
        {
            _views.AddRange(GetComponentsInChildren<UIViewBase>(true));

            for (int i = 0; i < _views.Count; i++)
            {
                _views[i].Initialize(this);
                _views[i].gameObject.SetActive(false);
            }
        }

        private void DisableAllViews()
        {
            for (int i = 0; i < _views.Count; i++)
            {
                _views[i].gameObject.SetActive(false);
            }
        }

        private void CloseOrShowLastView()
        {
            if (_viewsHierarchy.Count == 0)
                Manager.CloseWindow(this);
            else
                _viewsHierarchy[_viewsHierarchy.Count - 1].gameObject.SetActive(true);
        }

        #endregion
    }
}
