using Infrastructure.Repository;
using System;

namespace ApplicationServices.Implementations
{
    public abstract class ImplementationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ImplementationService(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null) throw new ArgumentNullException("UnitOfWork");
            _unitOfWork = unitOfWork;
        }

        protected IUnitOfWork UnitOfWork
        {
            get
            {
                return _unitOfWork;
            }
        }
    }
}
