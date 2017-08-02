using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Xamarin.Forms;
using System.Reflection;
using System.Linq;
using NotesBook.Services;

namespace NotesBook.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        protected readonly NotesBookApiService ApiService;
        protected readonly NavigationService Navigation_Service;

        public BaseViewModel()
        {
            ApiService = DependencyService.Get<NotesBookApiService>();
            Navigation_Service = DependencyService.Get<NavigationService>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Notifica mudança numa propriedade
        /// </summary>
        /// <param name="nomePropriedade"></param>
        protected void OnPropertyChange(string nomePropriedade)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nomePropriedade));
        }

        /// <summary>
        /// Set de qualquer propriedade com binding notify
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="propriedade"></param>
        /// <param name="valor"></param>
        /// <param name="nomePropriedade"></param>
        /// <returns></returns>
        public bool SetProperty<T>(ref T propriedade, T valor, [CallerMemberName]string nomePropriedade = null)
        {
            if (EqualityComparer<T>.Default.Equals(propriedade, valor))
                return false;

            propriedade = valor;
            OnPropertyChange(nomePropriedade);
            return true;
        }
    }
}
