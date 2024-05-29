﻿using Avalonia.Animation;
using Avalonia.Controls.Primitives;
using ReactiveUI;

namespace GuardianProWebServis.ViewModels;

public class MainViewModel : ViewModelBase
{
    private ViewModelBase _selectedViewModel;

    public ViewModelBase SelectedViewModel
    {
        get => _selectedViewModel;
        set => this.RaiseAndSetIfChanged(ref _selectedViewModel, value);
    }

    public MainViewModel()
    {
        SelectedViewModel = new AuthorizationViewModel() { Owner = this };
    }
}