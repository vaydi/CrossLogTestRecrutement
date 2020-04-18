using System.Data.Common;
using Crosslog.TestRecrutement.DataAccess.Dto;

namespace Crosslog.TestRecrutement.DataAccess
{
    public interface ICustomerDataAccess
    {
        /// <summary>
        /// Recupérer depuis la base tous les clients avec pour chacun, le nombre total de commandes ainsi que le chiffre d’affaire
        /// </summary>
        /// <param name="conn">connexion</param>
        /// <returns>CustomerListEntityDto (objets de transfert de données)</returns>
        CustomerListEntityDto GetCustomers(DbConnection conn);

        /// <summary>
        /// Mettre a jour les information du client dans la base
        /// </summary>
        /// <param name="customer">objet CustomerEntity dto (objets de transfert de données)</param>
        /// <param name="conn">connexion</param>
        /// <returns>true si les info est bien enregistrées</returns>
        bool UpdateCustomer(CustomerEntityDto customer, DbConnection conn);
    }
}