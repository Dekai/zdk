using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Library.Model.Struct
{
    public class NameValue : INotifyPropertyChanged
    {
        public NameValue()
        {

        }

        public NameValue(string name ,object value)
        {
            this.Name = name;
            this.Value = value;
        }

        public NameValue(string name, object value,object tag)
        {
            this.Name = name;
            this.Value = value;
            this.Tag = tag;
        }

        public string Name { get; set; }
        public object Value { get; set; }
        public bool IsSelected
        {
            get
            {
                return m_IsSelected;
            }
            set
            {
                m_IsSelected = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("IsSelected"));
                }
            }
        }

        private bool m_IsSelected = true;

        public object Tag { get; set; }

        public override string ToString()
        {
            return this.Name.ToString();
        }

        public string StringValue
        {
            get
            {
                return Value.ToString();
            }
        }

        public int? IntValue
        {
            get
            {
                if (Value != null)
                {
                    return int.Parse(Value.ToString());
                }
                return null;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
