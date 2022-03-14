using Showroom.Domain.Contracts.Repositories;

namespace Showroom.Business.Services
{
    public class ApplicationService
    {
        private IUnitOfWork _unitOfWork;
        //private IHandler<DomainNotification> _notifications;
        /// <summary>
        /// Padrão true, Setado para false quando um service chama o salvar de outro service. 
        /// </summary>
        public static bool _ToCommit;

        public ApplicationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork; ;
            _ToCommit = true;
        }

        public bool HasNotifications()
        {
            //TODO: ADD NOTIFICATIONS
            return false;
        }

        public bool Commit()
        {
            if (!_ToCommit)
                return false;

            _unitOfWork.Commit();
            return true;
        }

    }
}
