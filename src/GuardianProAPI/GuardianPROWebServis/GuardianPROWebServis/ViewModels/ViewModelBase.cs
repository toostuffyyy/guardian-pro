﻿using ReactiveUI;

namespace GuardianPROWebServis.ViewModels;

public class ViewModelBase : ReactiveObject
{
    public ViewModelBase Owner { get; set; }
}