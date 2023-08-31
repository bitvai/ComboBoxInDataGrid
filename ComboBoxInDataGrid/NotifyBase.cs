using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ComboBoxInDataGrid
{
    public class NotifyBase : INotifyPropertyChanged
    {
        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;


        /// <summary>
        /// Default version of OnPropertyChanged. Use this in usual cases
        /// </summary>
        /// <param name="propertyName"></param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
            => RaisePropertyChanged(propertyName);

        /// <summary>
        /// Use this to raise a property changed event from code. Also override this if you need to inhibit or modify property change notification.
        /// </summary>
        /// <param name="propertyName"></param>
        protected virtual void RaisePropertyChanged(string propertyName, INotifyPropertyChanged source = null)
            => PropertyChanged?.Invoke(source ?? this, new PropertyChangedEventArgs(propertyName ?? ""));

        /// <summary>
        /// Use this helper from property set bodies to get equality test and property change notification.
        /// </summary>
        /// <param name="field">a reference to the backing field of the property</param>
        /// <param name="value">the new value of the property, "value" in the setter</param>
        /// <param name="onChanged">action to execute if the property actually changed</param>
        protected void Set<T>(ref T field, T value, Action onChanged = null, [CallerMemberName] string propertyName = null)
        {
            if (!EqualityComparer<T>.Default.Equals(field, value))
            {
                field = value;
                RaisePropertyChanged(propertyName);
                onChanged?.Invoke();
            }
        }


    }
}
