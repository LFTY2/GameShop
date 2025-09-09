using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Gameplay.UI
{
    public class SwitchMenu : MonoBehaviour, IInitializable
    {
        [SerializeField] private RectTransform _moveTransform;
        [SerializeField] private RectTransform _shopOpenPosition;
        [SerializeField] private RectTransform _inventoryOpenPosition;
        [SerializeField] private ShopController _shopController;
        [SerializeField] private InventoryController _inventoryController;
        private Coroutine _moveCoroutine;
        public void Initialize()
        {
            _shopController.Initialize();
            _inventoryController.Initialize();
        }
        public void OpenMenu(bool isShop)
        {
            if (_moveCoroutine != null)
            {
                StopCoroutine(_moveCoroutine);
            }
            _moveCoroutine = StartCoroutine(OpenMenuRoutine(isShop));
        }

        private IEnumerator OpenMenuRoutine(bool isShop)
        {
            if (!isShop)
            {
                _shopController.Close();
            }
            else
            {
                _inventoryController.Close();
            }
            
            Vector2 position = isShop ? _shopOpenPosition.anchoredPosition :  _inventoryOpenPosition.anchoredPosition;
            yield return _moveTransform.AnchorPosAnim(position, 1f);
            if (isShop)
            {
                _shopController.Open();
            }
            else
            {
                _inventoryController.Open();
            }
        }

        
    }
}