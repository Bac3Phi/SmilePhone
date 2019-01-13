using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace SmilePhone.Validations
{
    public class TextFieldsViewModel : INotifyPropertyChanged
    {
        private String[] _bindingValidate;
        public TextFieldsViewModel()
        {
        }

        public String[] BindingValidate
        {
            get { return _bindingValidate; }
            set
            {
                this.MutateVerbose(ref _bindingValidate, value, RaisePropertyChanged());
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private Action<PropertyChangedEventArgs> RaisePropertyChanged()
        {
            return args => PropertyChanged?.Invoke(this, args);
        }
    }
}
