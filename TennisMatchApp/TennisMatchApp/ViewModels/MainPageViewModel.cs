﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TennisMatchApp.ViewModels
{
    class MainPageViewModel : BaseViewModel
    {
        INavigation Navigation;
        Match _selectedItem;
        public Command New_Match_Clicked { get; set; }
        public Command Delete_Match_Clicked { get; set; }
        public MainPageViewModel(INavigation p_navigation)
        {
            Navigation = p_navigation;
            New_Match_Clicked = new Command(NewMatch);
            Delete_Match_Clicked = new Command<Match>(DeleteMatch);
        }
        public Match SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                _selectedItem = value;

                if (_selectedItem == null)
                    return;

                Match m = _selectedItem;

                SelectedItem = null;

                OnPropertyChanged(nameof(SelectedItem));

                OpenMatch(m);
            }
        }
        void OpenMatch(Match m)
        {
            Navigation.PushAsync(new MatchPage(m));
        }
        void NewMatch(object obj)
        {
            Navigation.PushAsync(new NewMatchPage());
        }
        void DeleteMatch(Match obj)
        {
            App.matches.Remove((Match)obj);
        }
    }
}