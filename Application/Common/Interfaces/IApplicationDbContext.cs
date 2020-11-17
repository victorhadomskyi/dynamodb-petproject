namespace Application.Common.Interfaces
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Amazon.DynamoDBv2.DataModel;
    using Amazon.DynamoDBv2.DocumentModel;

    public interface IApplicationDbContext
    {
        Task SaveAsync<T>(T value, CancellationToken cancellationToken = default);

        Task<T> LoadAsync<T>(object hashKey, object rangeKey, CancellationToken cancellationToken = default);
        AsyncSearch<T> QueryAsync<T>(object hashKeyValue, QueryOperator op, IEnumerable<object> values,
            DynamoDBOperationConfig operationConfig = default);
        AsyncSearch<T> ScanAsync<T>(IEnumerable<ScanCondition> conditions, DynamoDBOperationConfig operationConfig = null);
        BatchWrite<T> CreateBatchWrite<T>();
        Task<List<string>> GetMenuGroupsAsync();
    }
}
