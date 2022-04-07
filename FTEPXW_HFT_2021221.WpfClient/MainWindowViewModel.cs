﻿using FTEPXW_HFT_2021221.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FTEPXW_HFT_2021221.WpfClient
{
    public class MainWindowViewModel : ObservableRecipient
    {

        public RestCollection<Movie> Movies { get; set; }

        private Movie selectedMovie;

        public Movie SelectedMovie
        {
            get { return selectedMovie; }
            set { 
                SetProperty(ref selectedMovie, value);
                (DeleteMovieCommand as RelayCommand).NotifyCanExecuteChanged();
            
            }
        }


        public ICommand CreateMovieCommand { get; set; }
        public ICommand DeleteMovieCommand { get; set; }
        public ICommand UpdateMovieCommand { get; set; }
        

        public MainWindowViewModel()
        {
            Thread.Sleep(6000);
            Movies = new RestCollection<Movie>("http://localhost:44216/", "movie");

            CreateMovieCommand = new RelayCommand(() =>
            {
                Movies.Add(new Movie()
                {
                    Name = "ASASSAS",                  
                    Music = "ASASSAS",
                    RunningTime = 120,
                    Budget = 122,
                    Genre = "ASASSAS",
                    AgeLimit = 12,
                    Income = 121212,
                    DirectorID = 2,
                    ProtagonistID = 3


                });
            });

            DeleteMovieCommand = new RelayCommand(() =>
            {
                Movies.Delete(selectedMovie.MovieID);
            },
            () => 
            { 
                return selectedMovie != null;
            });

        }


    }
}
