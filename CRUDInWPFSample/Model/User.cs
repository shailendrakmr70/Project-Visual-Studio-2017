using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDInWPFSample.Model
{
    public class User : INotifyPropertyChanged
    {
        private string _id;
        private string _firstName;
        private string _address;
        private string _lastName;
        private string _language;
        private string _dob;
        private string _nationality;
        private string _gender;
        private bool _male;
        private bool _female;
        private bool _hindi;
        private bool _english;
        private bool _french;

        public User()
        {
        }

        public string ID
        {
            get { return _id; }
            set
            {
                _id = value;
                NotifyOfPropertyChange("ID");
            }
        }
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                NotifyOfPropertyChange("FirstName");
            }
        }
        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                NotifyOfPropertyChange("LastName");
            }
        }
        public string Address
        {
            get { return _address; }
            set
            {
                _address = value;
                NotifyOfPropertyChange("Address");
            }
        }

        public string Language
        {
            get { return _language; }
            set
            {
                _language = string.Empty;
                string Comma = string.Empty;
                if (Hindi)
                {
                    _language = "Hindi";
                }
                if (English)
                {
                    if (!string.IsNullOrEmpty(_language))
                    {
                        Comma = ",";
                    }
                    _language = _language + Comma + "English";
                }
                if (French)
                {
                    if (!string.IsNullOrEmpty(_language))
                    {
                        Comma = ",";
                    }
                    _language = _language + Comma + "French";
                }
                NotifyOfPropertyChange("Language");
            }
        }

        public string DOB
        {
            get { return _dob; }
            set
            {
                _dob = Convert.ToDateTime(value).ToString("MM/dd/yyyy");
                NotifyOfPropertyChange("DOB");
            }
        }

        public string Nationality
        {
            get { return _nationality; }
            set
            {
                _nationality = value;
                NotifyOfPropertyChange("Nationality");
            }
        }

        public bool Male
        {
            get { return _male; }
            set
            {
                _male = value;
                Gender = "Male";
                NotifyOfPropertyChange("Male");
            }
        }

        public bool Female
        {
            get { return _female; }
            set
            {
                _female = value;
                Gender = "Female";
                NotifyOfPropertyChange("Female");
            }
        }
        public string Gender
        {
            get { return _gender; }
            set
            {
                if (Male)
                {
                    _gender = "Male";
                }
                if (Female)
                {
                    _gender = "Female";
                }

                NotifyOfPropertyChange("Gender");
            }
        }

        public bool Hindi
        {
            get { return _hindi; }
            set
            {
                _hindi = value;
                Language = "Hindi";
                NotifyOfPropertyChange("Hindi");
            }
        }

        public bool English
        {
            get { return _english; }
            set
            {
                _english = value;
                Language = "English";
                NotifyOfPropertyChange("English");
            }
        }

        public bool French
        {
            get { return _french; }
            set
            {
                _french = value;
                Language = "French";
                NotifyOfPropertyChange("French");
            }
        }

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyOfPropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
