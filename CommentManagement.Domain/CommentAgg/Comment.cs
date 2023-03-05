using _0_FrameWork.Domain;
using System;
using System.Collections.Generic;

namespace CommentManagement.Domain.CommentAgg
{
    public class Comment : EntityBase
    { 
        
        public long ProductId { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Message { get; private set; }
        public bool IsConfirmation { get; private set; }
        public bool IsSpam { get; private set; }
       

    


        #region Constractor Add || Reject || Confirmation

        public Comment()
        {
        }

        public Comment(long productid,string name, string email, string message)
        {
            ProductId=productid;
            Name = name;
            Email = email;
            Message = message;
            IsSpam = false;
        }
   
        public void Confirmation()
        {
            IsConfirmation = true;
        }

        public void Rejection()
        {
            IsConfirmation = false;
        }

        public void Spam()
        {
            IsSpam = true;
        }

        #endregion


    }


}
