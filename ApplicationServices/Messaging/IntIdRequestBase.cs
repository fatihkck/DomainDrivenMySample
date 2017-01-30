using System;

namespace ApplicationServices.Model
{
    public abstract class IntegerIdRequest : ServiceRequestBase
    {

        private int id;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
                ValidId(id);
            }
        }

        private void ValidId(int id)
        {
            if (id < 1)
            {
                throw new ArgumentException("ID must be positive.");
            }
        }
    }
}
