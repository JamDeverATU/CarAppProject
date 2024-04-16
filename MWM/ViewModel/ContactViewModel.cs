using Project.Core;
using Project.MWM.Model;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Project.MWM.ViewModel
{
    class ContactViewModel : ObservableObjectTwo
    {
        public ObservableCollection<MessageModel> Messages { get; set; }
        public ObservableCollection<ContactModel> Contacts { get; set; }


        public  RelayCommandtwo SendCommand { get; set; }


        private ContactModel _selectedContact;

        public ContactModel SelectedContact
        {
            get { return _selectedContact; }
            set { _selectedContact = value;
                OnPropertyChanged();

            }
        }


        private string _message;

        public string Message
        {
            get { return _message; }
            set { _message = value; 
            OnPropertyChanged();
            }
        }

        public ContactViewModel()
        {
            Messages = new ObservableCollection<MessageModel>();
            Contacts = new ObservableCollection<ContactModel>();


            SendCommand = new RelayCommandtwo(o =>
                {
                    Messages.Add(new MessageModel
                    {
                        Message = Message,
                        FirstMessage = false
                    });

                    Message = "";
            });


            Messages.Add(new MessageModel
            {
                Username = "James",
                UsernameColor = "#409aff",
                ImageSource = "https://shorturl.at/hil49",
                Message = "Test",
                time = DateTime.Now,
                IsNativeOrigin = false,
                FirstMessage = true
            });

            for (int i = 0; i < 3; i++)
            {
                Messages.Add(new MessageModel
                {
                    Username = "James",
                    UsernameColor = "#409aff",
                    ImageSource = "https://shorturl.at/hil49",
                    Message = "Test",
                    time = DateTime.Now,
                    IsNativeOrigin = false,
                    FirstMessage = false
                });
            }

            for (int i = 0; i < 4; i++)
            {
                Messages.Add(new MessageModel
                {
                    Username = "GTR",
                    UsernameColor = "#409aff",
                    ImageSource = "https://shorturl.at/bmvP5",
                    Message = "Test",
                    time = DateTime.Now,
                    IsNativeOrigin = true,
                });
            }

            Messages.Add(new MessageModel
            {
                Username = "GTR",
                UsernameColor = "#409aff",
                ImageSource = "https://shorturl.at/bmvP5",
                Message = "Last",
                time = DateTime.Now,
                IsNativeOrigin = true,
            });

            for (int i = 0; i < 1; i++)
            {
                Contacts.Add(new ContactModel
                {
                    Username = $"GTR",
                    ImageSource = "https://shorturl.at/bmvP5",
                    Messages = Messages
                });
            }
        }
    }
}
