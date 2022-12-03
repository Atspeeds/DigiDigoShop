using System;

namespace _0_FrameWork.Domain
{
    public class EntityBase 
    {
        public long KeyId { get; private set; }
        public DateTime CreationDate { get; private set; }

        public EntityBase()
        {
            CreationDate = DateTime.Now;
        }

    }
}
