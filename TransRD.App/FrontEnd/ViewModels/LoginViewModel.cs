// LoginViewModel.cs
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using TransRD.Views;
using Microsoft.Maui.Controls;
using TransRD.Infraestructura.Models;
using Microsoft.EntityFrameworkCore.Query.Internal;
using TransRD.Data;
using Microsoft.EntityFrameworkCore;
using TransRD.FrontEnd.Controls;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using System.Net.Http.Json;
using TransRD.API.Controllers.Auth;

namespace TransRD.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        private readonly TransRDDbController Data = new TransRDDbController();
        private readonly Login LoginController = new Login();
        private readonly HttpClient httpClient = HttpClientController.Client;

        [ObservableProperty]
        private string? email;

        [ObservableProperty]
        private string? password;


        public LoginViewModel()
        {
            // Constructor
        }

        [RelayCommand]
        private async Task LoginAsync()
        {
            if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Todos los campos son obligatorios.", "OK");
                return;
            }

      // Autenticación simulada
            var LoginData = new LoginData { Email = email, Password = password };
      //var LoginResult = LoginController.Post(LoginData);
            var LoginResult = await httpClient.PostAsJsonAsync("auth/login/", LoginData);
            if (LoginResult.IsSuccessStatusCode)
            { 
                await Application.Current.MainPage.DisplayAlert("Bienvenido", "Inicio de sesión exitoso", "OK");

                await SecureStorage.SetAsync("auth_token", await LoginResult.Content.ReadAsStringAsync());
                Navigate.NavigateToPage(new SplashPage(), false);
                // Navegar a la página principal
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Credenciales inválidas", "OK");
            }
        }

        [RelayCommand]
        private async Task NavigateToRegisterAsync()
        {
            Navigate.NavigateToPage(new Views.RegisterPage(),false);
        }

        [RelayCommand]
        private async Task NavigateToResetPasswordAsync()
        {
           Navigate.NavigateToPage(new Views.RecuperarClavePage(),true);
        }
    }
}
