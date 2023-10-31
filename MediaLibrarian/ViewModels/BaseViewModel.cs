using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace MediaLibrarian.ViewModels
{
    internal class BaseViewModel : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        #endregion

        #region INotifyDataErrorInfo

        private readonly Dictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public bool HasErrors => _errors.Any();

        public IEnumerable GetErrors(string propertyName)
        {
            return _errors.TryGetValue(propertyName, out var errors) ? errors : null;
        }

        private void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        protected void AddError(string propertyName, string error)
        {
            if (!_errors.ContainsKey(propertyName)) _errors[propertyName] = new List<string>();

            if (_errors[propertyName].Contains(error)) return;

            _errors[propertyName].Add(error);
            OnErrorsChanged(propertyName);
        }

        protected void ClearErrors(string propertyName)
        {
            if (!_errors.ContainsKey(propertyName)) return;

            _errors.Remove(propertyName);
            OnErrorsChanged(propertyName);
        }

        //public string GetErrorsAsString(string propertyName)
        //{
        //    return _errors.TryGetValue(propertyName, out var errors)
        //        ? string.Join(Environment.NewLine, errors)
        //        : null;
        //}

        #endregion
    }
}