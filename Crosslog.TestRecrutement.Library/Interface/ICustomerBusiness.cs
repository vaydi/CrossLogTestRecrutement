using Crosslog.TestRecrutement.Library.BusinessEntity;

namespace Crosslog.TestRecrutement.Library
{
    public interface ICustomerBusiness
    {
        /// <summary>
        /// Recupérer tous les clients avec pour chacun, le nombre total de commandes ainsi que le chiffre d’affaire 
        /// </summary>
        /// <returns>CustomerListEntity</returns>
        CustomerListEntity GetCustomers();

        /// <summary>
        /// Mettre a jour les information du client
        /// </summary>
        /// <param name="customer">objet CustomerEntity</param>
        /// <returns>true si les info est bien enregistrées</returns>
        bool UpdateCustomer(CustomerEntity customer);
    }
}