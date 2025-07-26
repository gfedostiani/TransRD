using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using TransRD.Infraestructura.Models;
using TransRD.Data;
using TransRD.Views;
using TransRD.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using TransRD.FrontEnd.Controls;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Http.HttpResults;
using NuGet.Protocol;

namespace TransRD.ViewModels
{
    public partial class RegisterViewModel : ObservableObject
    {
        private readonly TransRDDbContext DataContext;
        private readonly HttpClient httpClient = HttpClientController.Client;
        private readonly Register RegisterController = new Register();

        [ObservableProperty]
        private string fullName;

        [ObservableProperty]
        private string email;

        [ObservableProperty]
        private string password;

        [ObservableProperty]
        private string confirmPassword;

        [ObservableProperty]
        private bool acceptTerms;

        public RegisterViewModel()
        {
            
        }

        [RelayCommand]
        private async Task RegisterAsync()
        {
            if (string.IsNullOrWhiteSpace(FullName) ||
                string.IsNullOrWhiteSpace(Email) ||
                string.IsNullOrWhiteSpace(Password) ||
                string.IsNullOrWhiteSpace(ConfirmPassword))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Por favor completa todos los campos.", "OK");
                return;
            }

            if (Password != ConfirmPassword)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Las contraseñas no coinciden.", "OK");
                return;
            }

            if (!AcceptTerms)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Debes aceptar los términos y condiciones.", "OK");
                return;
            }

      // Aquí va la lógica de registro real

            var Data = new RegisterData { Name = fullName, Email = email, Password = password };
            // var IsRegisterSuccesful = RegisterController.Post(Data);
            var RegisterResponse = await httpClient.PostAsJsonAsync("/auth/register/", Data);

            if (RegisterResponse.IsSuccessStatusCode)
            {
                await Application.Current.MainPage.DisplayAlert("Éxito", "Usuario registrado correctamente.", "OK");
                Navigate.NavigateToPage(new Views.LoginPage(), false);
            }
            else
            {
              await Application.Current.MainPage.DisplayAlert("Error", "Ya existe un usuario con este correo.", "OK");
            }
        }

        [RelayCommand]
        private async Task NavigateToLoginAsync()
        {
            Navigate.NavigateToPage(new Views.LoginPage(),false);
        }
    }
}
