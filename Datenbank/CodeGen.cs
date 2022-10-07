using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
namespace U_MemeChat
{
    #region Chats
    public class Chats
    {
        #region Member Variables
        protected string _Id;
        protected string _User_Id;
        protected string _User_Id;
        #endregion
        #region Constructors
        public Chats() { }
        public Chats(string User_Id, string User_Id)
        {
            this._User_Id=User_Id;
            this._User_Id=User_Id;
        }
        #endregion
        #region Public Properties
        public virtual string Id
        {
            get {return _Id;}
            set {_Id=value;}
        }
        public virtual string User_Id
        {
            get {return _User_Id;}
            set {_User_Id=value;}
        }
        public virtual string User_Id
        {
            get {return _User_Id;}
            set {_User_Id=value;}
        }
        #endregion
    }
    #endregion
}using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
namespace U_MemeChat
{
    #region Messages
    public class Messages
    {
        #region Member Variables
        protected unknown _Id;
        protected string _URL;
        protected string _SendById;
        protected DateTime _SendAt;
        protected string _ChatId;
        #endregion
        #region Constructors
        public Messages() { }
        public Messages(string URL, string SendById, DateTime SendAt, string ChatId)
        {
            this._URL=URL;
            this._SendById=SendById;
            this._SendAt=SendAt;
            this._ChatId=ChatId;
        }
        #endregion
        #region Public Properties
        public virtual unknown Id
        {
            get {return _Id;}
            set {_Id=value;}
        }
        public virtual string URL
        {
            get {return _URL;}
            set {_URL=value;}
        }
        public virtual string SendById
        {
            get {return _SendById;}
            set {_SendById=value;}
        }
        public virtual DateTime SendAt
        {
            get {return _SendAt;}
            set {_SendAt=value;}
        }
        public virtual string ChatId
        {
            get {return _ChatId;}
            set {_ChatId=value;}
        }
        #endregion
    }
    #endregion
}using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
namespace U_MemeChat
{
    #region Users
    public class Users
    {
        #region Member Variables
        protected string _Id;
        protected string _Nickname;
        protected string _Name;
        protected string _Email;
        protected string _Password;
        protected string _Avatar;
        protected string _About;
        protected DateTime _DateOfBirth;
        #endregion
        #region Constructors
        public Users() { }
        public Users(string Nickname, string Name, string Email, string Password, string Avatar, string About, DateTime DateOfBirth)
        {
            this._Nickname=Nickname;
            this._Name=Name;
            this._Email=Email;
            this._Password=Password;
            this._Avatar=Avatar;
            this._About=About;
            this._DateOfBirth=DateOfBirth;
        }
        #endregion
        #region Public Properties
        public virtual string Id
        {
            get {return _Id;}
            set {_Id=value;}
        }
        public virtual string Nickname
        {
            get {return _Nickname;}
            set {_Nickname=value;}
        }
        public virtual string Name
        {
            get {return _Name;}
            set {_Name=value;}
        }
        public virtual string Email
        {
            get {return _Email;}
            set {_Email=value;}
        }
        public virtual string Password
        {
            get {return _Password;}
            set {_Password=value;}
        }
        public virtual string Avatar
        {
            get {return _Avatar;}
            set {_Avatar=value;}
        }
        public virtual string About
        {
            get {return _About;}
            set {_About=value;}
        }
        public virtual DateTime DateOfBirth
        {
            get {return _DateOfBirth;}
            set {_DateOfBirth=value;}
        }
        #endregion
    }
    #endregion
}