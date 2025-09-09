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
            AddObject(new InventoryModel());
           
            AddObject(_switchMenu);    
            AddObject(new Bank());    
            
            AddObject(new Player());
        }

        public void Start()
        {
            Initialize();
        }

        public void OnDestroy()
        {
            Dispose();
        }
    }
}