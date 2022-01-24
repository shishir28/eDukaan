using Basket.API.Entities;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Basket.API.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDistributedCache _redisCache;
        public BasketRepository(IDistributedCache redisCache) =>
            _redisCache = redisCache ?? throw new ArgumentNullException(nameof(redisCache));


        public async Task<ShoppingCart> GetBasket(string userName)
        {
            var basket = await _redisCache.GetStringAsync(userName);

            if (String.IsNullOrEmpty(basket))
                return null;

            return JsonConvert.DeserializeObject<ShoppingCart>(basket);
        }

        public async Task<ShoppingCart> UpdateBasket(ShoppingCart basket)
        {
            var userName = basket.UserName;
            var basketString = JsonConvert.SerializeObject(basket);
            _redisCache.SetString(userName, basketString);
            return await GetBasket(basket.UserName);
        }

        public Task DeleteBasket(string userName) => _redisCache.RemoveAsync(userName);
    }

}