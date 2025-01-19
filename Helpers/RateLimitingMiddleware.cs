namespace ECommerceOrderManagementAPI.Helpers
{
    public class RateLimitingMiddleware
    {
        private readonly RequestDelegate _next;
        private static int _requestCount = 0;
        private static DateTime _lastRequestTime = DateTime.Now;
        private int _requestlimit = 5;
        private int _limittimeInSeconds = 60;
        public RateLimitingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            _requestCount++;
            var timeDifference = DateTime.Now - _lastRequestTime;
            if ((DateTime.Now - _lastRequestTime).TotalSeconds > _limittimeInSeconds)
            {
                _requestCount = 1;
                _lastRequestTime = DateTime.Now;
                await _next(context);
            }
            else 
            {
                if (_requestCount > _requestlimit)
                {
                    _lastRequestTime = DateTime.Now;
                    context.Response.StatusCode = 429;
                    await context.Response.WriteAsync("Too many requests, please try again later.");
                }
                else
                {
                    _lastRequestTime = DateTime.Now;
                    await _next(context);
                }
                    
            }

        }
    }
}
