using Dapper;
using Practice.Ecommerce.Domain.Entity;
using Practice.Ecommerce.Infrastructure.Interface;
using Practice.Ecommerce.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Ecommerce.Infrastructure.Repository
{
    public class SalesRepository: ISalesRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public SalesRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        #region Métodos Síncronos        

        public bool Insert(Sales sales)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "SalesInsert";
                var parameters = new DynamicParameters();
                parameters.Add("SalesID", sales.SalesId);
                parameters.Add("Cliente", sales.Cliente);
                parameters.Add("Producto", sales.Producto);
                parameters.Add("Cantidad", sales.Cantidad);
                parameters.Add("Precio", sales.Precio);
                parameters.Add("Fecha", sales.Fecha);

                var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public bool Update(Sales sales)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "SalesUpdate";
                var parameters = new DynamicParameters();
                parameters.Add("SalesID", sales.SalesId);
                parameters.Add("Cliente", sales.Cliente);
                parameters.Add("Producto", sales.Producto);
                parameters.Add("Cantidad", sales.Cantidad);
                parameters.Add("Precio", sales.Precio);
                parameters.Add("Fecha", sales.Fecha);

                var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public bool Delete(string salesId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "SalesDelete";
                var parameters = new DynamicParameters();
                parameters.Add("SalesID", salesId);
                var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public Sales Get(string salesId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "SalesGetByID";
                var parameters = new DynamicParameters();
                parameters.Add("SalesID", salesId);

                var customer = connection.QuerySingle<Sales>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return customer;
            }
        }

        public IEnumerable<Sales> GetAll()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "SalesList";

                var customers = connection.Query<Sales>(query, commandType: CommandType.StoredProcedure);
                return customers;
            }
        }

        #endregion

        #region Métodos Asíncronos

        public async Task<bool> InsertAsync(Sales sales)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "SalesInsert";
                var parameters = new DynamicParameters();
                parameters.Add("SalesID", sales.SalesId);
                parameters.Add("Cliente", sales.Cliente);
                parameters.Add("Producto", sales.Producto);
                parameters.Add("Cantidad", sales.Cantidad);
                parameters.Add("Precio", sales.Precio);
                parameters.Add("Fecha", sales.Fecha);

                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public async Task<bool> UpdateAsync(Sales sales)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "SalessUpdate";
                var parameters = new DynamicParameters();
                parameters.Add("SalesID", sales.SalesId);
                parameters.Add("Cliente", sales.Cliente);
                parameters.Add("Producto", sales.Producto);
                parameters.Add("Cantidad", sales.Cantidad);
                parameters.Add("Precio", sales.Precio);
                parameters.Add("Fecha", sales.Fecha);

                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public async Task<bool> DeleteAsync(string salesId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "SalesDelete";
                var parameters = new DynamicParameters();
                parameters.Add("SalesID", salesId);
                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public async Task<Sales> GetAsync(string salesId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "SalesGetByID";
                var parameters = new DynamicParameters();
                parameters.Add("SalesID", salesId);

                var customer = await connection.QuerySingleAsync<Sales>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return customer;
            }
        }

        public async Task<IEnumerable<Sales>> GetAllAsync()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "SalesList";

                var customers = await connection.QueryAsync<Sales>(query, commandType: CommandType.StoredProcedure);
                return customers;
            }
        }

        #endregion
    }
}
