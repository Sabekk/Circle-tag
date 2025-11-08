using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Management
{
    public class ManagersParent : MonoSingleton<ManagersParent>
    {
        #region ACTION

        public event Action OnManagersInitialized;

        #endregion

        #region VARIABLES

        [SerializeField] protected List<IGameplayManager> managers = new();

        #endregion

        #region PROPERTIES

        public bool Initialized { get; set; }

        #endregion

        #region UNITY_METHODS

        private void Start()
        {
            InitializeManagers();
            LateInitializeManagers();

            Initialized = true;
            OnManagersInitialized?.Invoke();
        }

        private void OnDestroy()
        {
            CleanUpManagers();
        }

        #endregion

        #region METHODS

        public void InitializeManagers()
        {
            if (managers == null)
                managers = new();

            managers.AddRange(GetComponentsInChildren<IGameplayManager>());

            for (int i = 0; i < managers.Count; i++)
                managers[i].Initialize();
        }

        public void LateInitializeManagers()
        {
            for (int i = 0; i < managers.Count; i++)
                managers[i].LateInitialize();
        }

        public void CleanUpManagers()
        {
            for (int i = 0; i < managers.Count; i++)
                managers[i].CleanUp();
        }

        #endregion
    }
}