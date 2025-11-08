using UnityEngine;

namespace Gameplay.Management.Character
{
    public class CharacterManager : GameplayManager<CharacterManager>
    {
        #region VARIABLES

        [SerializeField] private PlayerCharacter _playerPrefab;

        #endregion

        #region PROPERTIES

        public PlayerCharacter Player { get; set; }

        #endregion

        #region METHODS

        public override void CleanUp()
        {
            base.CleanUp();
            CleanUpPlayer();
        }

        public void SpawnPlayer(Transform parent = null)
        {
            Player = GameObject.Instantiate(_playerPrefab, parent);
            Player.Initialzie();
        }

        public void CleanUpPlayer()
        {
            if (Player)
            {
                Player.CleanUp();
                GameObject.Destroy(Player.gameObject);
                Player = null;
            }
        }

        #endregion
    }
}