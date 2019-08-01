﻿using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using SquareSpaceSharp.Entities;
using SquareSpaceSharp.Extensions;
using SquareSpaceSharp.Infrastructure;

namespace SquareSpaceSharp.Services.Inventory
{
    public class InventoryService : SquareSpaceService
    {
        /// <summary>
        /// Creates a new instance of <see cref="InventoryService" />.
        /// </summary>
        /// <param name="secretApiKey">App Secret Api Key</param>
        public InventoryService(string secretApiKey) : base(secretApiKey)
        {
        }

        /// <summary>
        /// Returns collection of orders
        /// </summary>
        /// <param name="cursor">optional Type: A string token, returned from the pagination.nextPageCursor of a previous response.Identifies where the next page of results should begin.If this parameter is not present or empty, the first page of inventory data will be returned.</param>
        public virtual async Task<InventoryCollection> GetInventoriesAsync(string cursor)
        {
            var req = PrepareRequest($"inventory?cursor={cursor}");

            return await ExecuteRequestAsync<InventoryCollection>(req, HttpMethod.Get);
        }

        /// <summary>
        /// Returns a order with provided ID.
        /// </summary>
        /// <param name="variantsIds">A comma-separated list of variant ids. Specifies the inventory items to retrieve by variant id.</param>
        /// <returns>The <see cref="Order"/>.</returns>
        public virtual async Task<List<Entities.Inventory>> GetOrderAsync(string variantsIds)
        {
            var req = PrepareRequest($"inventory/{variantsIds}");

            return await ExecuteRequestAsync<List<Entities.Inventory>>(req, HttpMethod.Get);
        }

        /// <summary>
        /// Post a update stock adjustment request
        /// </summary>
        ///  /// <param name="stockAdjustmentQuery">Requested Stock adjustment query parameters</param>
        public virtual async Task UpdateStockAdjustment(StockAdjustmentQuery stockAdjustmentQuery)
        {
            var req = PrepareRequest($"inventory/adjustments");
            HttpContent content = null;

            if (stockAdjustmentQuery != null)
            {
                var body = stockAdjustmentQuery.ToDictionary();
                content = new JsonContent(body);
            }
            await ExecuteRequestAsync<object>(req, HttpMethod.Post, content);
        }
    }
}