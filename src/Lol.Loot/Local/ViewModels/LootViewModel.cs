﻿using Lol.Foundation.Mvvm;
using Lol.Database.Controller;
using Lol.Database.Entites.Schema;
using System.Collections.Generic;
using System.Linq;

namespace Lol.Loot.Local.ViewModels
{
    public class LootViewModel : ObservableObject
    {
        #region Variables

        private List<Loots> _menus;
        private List<PlantHeaders> _treeSource;
        private List<Loots> _items;
        private List<ChampCb> _cbxSource;
        private Loots _currentMneu;
        private ChampCb _currentCbx;
        #endregion

        #region Menus

        public List<Loots> Menus
        {
            get { return _menus; }
            set { _menus = value; OnPropertyChanged(); }
        }
        #endregion

        #region TreeSource

        public List<PlantHeaders> TreeSource
        {
            get { return _treeSource; }
            set { _treeSource = value; OnPropertyChanged(); }
        }
        #endregion

        #region Items

        public List<Loots> Items
        {
            get { return _items; }
            set { _items = value; OnPropertyChanged(); }
        }
        #endregion

        #region CurrentMenu

        public Loots CurrentMenu
        {
            get { return _currentMneu; }
            set { _currentMneu = value; OnPropertyChanged(); MenuChanged(value.Seq); }
        }
        #endregion

        #region CbxSource

        public List<ChampCb> CbxSource
        {
            get { return _cbxSource; }
            set { _cbxSource = value; OnPropertyChanged(); }
        }
        #endregion

        #region CurrentCbx

        public ChampCb CurrentCbx
        {
            get { return _currentCbx; }
            set { _currentCbx = value; OnPropertyChanged(); }
        }
        #endregion

        #region Constructor

        public LootViewModel()
        {
            CbxSource = new LootApi().GetComboBox();
            CurrentCbx = CbxSource[0];
            Items = new LootApi().GetLootItems();
            Menus = new LootApi().GetLoots();
            CurrentMenu = Menus[0];            
        }
        #endregion

        #region MenuChanged

        private void MenuChanged(int seq)
        {
            var treeSource = new LootApi().GetPlantHeaders();

            if (seq != 0)
                treeSource = treeSource.Where(x => x.LootSeq == seq).ToList();

            TreeSource = treeSource;
        }
        #endregion
    }
}