using System;
using Project.Gameplay.UI;
using UnityEngine;

namespace Project
{
    public class GameShopContainer : ModuleContainer
    {
        [SerializeField] private ItemCreator _itemCreator;
        [SerializeField] private SwitchMenu _switchMenu;
        
        public override void Awake()
        {
            base.Awake();
            AddObject(_itemCreator);    
            AddObject(_switchMenu);    
            AddObject(new Bank());    
            AddObject(new InventoryModel());
            AddObject(new Player());
            
            Initialize();
        }

        public void OnDestroy()
        {
            Dispose();
        }
    }
}