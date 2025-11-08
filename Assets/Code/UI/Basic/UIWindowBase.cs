using Gameplay.Management.UI;
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

        public virtual void Initialize()
        {
            ToggleView(_defaultView, true);
            DetachEvents();
            AttachEvents();
        }

        public void Close()
        {
            Manager.CloseWindow(this);
        }

        public void CleanUp()
        {
            DisableAllViews();
            _viewsHierarchy.Clear();

            DetachEvents();
        }

        public void ToggleView(UIViewBase view, bool state, bool checkLast = true)
        {
            DisableAllViews();
            view.gameObject.SetActive(state);

            if (state)
            {
                view.Initialize();
                _viewsHierarchy.Remove(view);
                _viewsHierarchy.Add(view);
            }
            else
            {
                view.CleanUp();
                _viewsHierarchy.Remove(view);
            }

            if (checkLast)
                CloseOrShowLastView();
        }

        protected virtual void AttachEvents()
        {

        }

        protected virtual void DetachEvents()
        {

        }

        private void InitializeViews()
        {
            _views.AddRange(GetComponentsInChildren<UIViewBase>(true));

            for (int i = 0; i < _views.Count; i++)
            {
                _views[i].InitializeWindow(this);
                _views[i].gameObject.SetActive(false);
            }
        }

        private void DisableAllViews()
        {
            for (int i = 0; i < _views.Count; i++)
            {
                _views[i].CleanUp();
                _views[i].gameObject.SetActive(false);
            }
        }

        private void CloseOrShowLastView()
        {
            if (_viewsHierarchy.Count == 0)
                Close();
            else
            {
                var view = _viewsHierarchy[_viewsHierarchy.Count - 1];
                ToggleView(view, true, false);
            }
        }

        #endregion
    }
}
