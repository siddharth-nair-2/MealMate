﻿using MealMate.Services;
using MealMate.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MealMate.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string _Username;
        public string Username
        {
            set
            {
                this._Username = value;
                OnPropertyChanged();
            }
            get 
            { 
                return this._Username; 
            }
        }

        private string _Password;
        public string Password
        {
            set
            {
                this._Password = value;
                OnPropertyChanged();
            }
            get
            {
                return this._Password;
            }
        }

        private bool _IsBusy;
        public bool IsBusy
        {
            set
            {
                this._IsBusy = value;
                OnPropertyChanged();
            }
            get
            {
                return this._IsBusy;
            }
        }

        private string _Result;
        public string Result
        {
            set
            {
                this._Result = value;
                OnPropertyChanged();
            }
            get
            {
                return this._Result;
            }
        }
        private bool _Disable;
        public bool Disable
        {
            set
            {
                this._Disable = value;
                OnPropertyChanged();
            }
            get
            {
                return this._Disable;
            }
        }

        public Command LoginCommand { get; set; }
        public Command RegisterCommand { get; set; }
        public LoginViewModel() 
        {
            Disable = false;
            LoginCommand = new Command(async () => await LoginCommandAsync());
            RegisterCommand = new Command(async () => await RegisterCommandAsync());
        }

        private async Task RegisterCommandAsync()
        {
            if (IsBusy) return;
            try
            {
                IsBusy= true;
                var userService = new UserService();
                Result = await userService.RegisterUser(Username, Password);
                if(Result == "true")
                {
                    await Application.Current.MainPage.DisplayAlert("Success", "User Registered!", "OK");
                } else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "User Already Exists!", "OK");
                }

            } 
            catch (Exception ex) 
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
            finally 
            { 
                IsBusy = false; 
            }
        }

        private async Task LoginCommandAsync()
        {
            if (IsBusy) return;
            try
            {
                IsBusy = true;
                var userService = new UserService();
                Result = await userService.LoginUser(Username, Password);
                if(Result == "admin") {
                    await Application.Current.MainPage.Navigation.PushModalAsync(new SettingsPage());
                } else if(Result == "user") {
                    Preferences.Set("Username", Username);
                    await Application.Current.MainPage.Navigation.PushModalAsync(new ProductsView());
                } else {
                    await Application.Current.MainPage.DisplayAlert("Error", "Invalid Username or Password", "OK");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
