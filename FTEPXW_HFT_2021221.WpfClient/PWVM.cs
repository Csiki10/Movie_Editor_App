﻿using FTEPXW_HFT_2021221.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FTEPXW_HFT_2021221.WpfClient
{
    public class PWVM : ObservableRecipient
    {
        public RestCollection<Protagonist> Protagonists { get; set; }

        private Protagonist selectedProtagonist;

        public Protagonist SelectedProtagonist
        {
            get { return selectedProtagonist; }
            set
            {
                if (value != null)
                {
                    selectedProtagonist = new Protagonist()
                    {
                        Name = value.Name,
                        Gender = value.Gender,
                        Age = value.Age,
                        ProtagonistID = value.ProtagonistID,
                        Oscar = value.Oscar                     
                    };
                    OnPropertyChanged();
                    (CreateProtagonistCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public ICommand CreateProtagonistCommand { get; set; }
        public ICommand DeleteProtagonistCommand { get; set; }
        public ICommand UpdateProtagonistCommand { get; set; }
     
        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public PWVM()
        {
            if (!IsInDesignMode)
            {               
                Protagonists = new RestCollection<Protagonist>("http://localhost:44216/", "protagonist", "hub");

                CreateProtagonistCommand = new RelayCommand(() =>
                {
                    Protagonists.Add(new Protagonist()
                    {
                        Name = SelectedProtagonist.Name,
                        Gender = SelectedProtagonist.Gender,
                        Age = SelectedProtagonist.Age,
                        Oscar = SelectedProtagonist.Oscar,
                    });
                });

                UpdateProtagonistCommand = new RelayCommand(() =>
                {
                    Protagonists.Update(SelectedProtagonist);
                });

                DeleteProtagonistCommand = new RelayCommand(() =>
                {
                    Protagonists.Delete(SelectedProtagonist.ProtagonistID);
                },
                () =>
                {
                    return SelectedProtagonist != null;
                });
                SelectedProtagonist = new Protagonist();
            }
        }
    }
}
